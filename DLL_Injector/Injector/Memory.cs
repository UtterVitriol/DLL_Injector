using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace Injector
{
    public class ProcessInfo
    {
        public IntPtr PID { get; }

        public string Process { get; }

        public string Path { get; }

        // TODO: Icon stuff

        public ProcessInfo(IntPtr pid, string process, string path)
        {
            Contract.Requires(process != null);
            Contract.Requires(path != null);

            PID = pid;
            Process = process;
            Path = path;
        }
    }

    public class Injector
    {
        [Flags]
        public enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        [Flags]
        public enum MemoryProtection
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, uint processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
    IntPtr dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
            [MarshalAs(UnmanagedType.AsAny)] object lpBuffer, int dwSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes,
            uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        public static void Inject(IntPtr pid, string dll)
        {
            IntPtr hProc = OpenProcess(0x1FFFFF, false, (uint)pid.ToInt32());
            if (hProc == IntPtr.Zero)
            {
                return;
            }
            IntPtr MAX_PATH = new IntPtr(260);
            IntPtr bWritten = IntPtr.Zero;
            var loc = VirtualAllocEx(hProc, (IntPtr)0, MAX_PATH, AllocationType.Commit | AllocationType.Reserve, MemoryProtection.ReadWrite);
            WriteProcessMemory(hProc, loc, dll, dll.Length + 1, out bWritten);

            var LoadLibrary = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

            IntPtr tID = IntPtr.Zero;
            var hThread = CreateRemoteThread(hProc, (IntPtr)0, 0, LoadLibrary, loc, 0, out tID);
        }
    }
}
