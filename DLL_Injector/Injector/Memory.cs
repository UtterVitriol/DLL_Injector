using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
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
        
        [DllImport("./injectionLib.dll")]
        static extern uint inject(string dllPath, IntPtr procId);

        public static void Inject(IntPtr pid, string dll)
        {
            uint err = inject(dll, pid);

            if (err != 0)
            {
                MessageBox.Show("Injection Failure: Error " + err);
            }
            else
            {
                MessageBox.Show("Injection Success");
            }

        }
    }
}
