using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Injector
{
    public partial class MainForm : Form
    {
        public IntPtr? SelectedProcess => (processDataGridView.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault()?.DataBoundItem as DataRowView)
                    ?.Row
                    ?.Field<IntPtr>("pid");
        public MainForm()
        {
            InitializeComponent();

            RefreshProcesses();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [PreserveSig]
        public static extern uint GetModuleFileName([In] IntPtr hModule, [Out] StringBuilder lpFilename,
            [In][MarshalAs(UnmanagedType.U4)] int nSize);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, uint processId);

        private void RefreshProcesses()
        {
            var dt = new DataTable();
            dt.Columns.Add("Process", typeof(string));
            dt.Columns.Add("PID", typeof(IntPtr));
            dt.Columns.Add("Path", typeof(string));
            Process[] processes = Process.GetProcesses();

            foreach (var p in processes)
            {
                var row = dt.NewRow();
                row["Process"] = p.ProcessName + ".exe";
                row["PID"] = (IntPtr)p.Id;
                //row["Path"] = "beans";
                IntPtr hProc = OpenProcess(0x1FFFFF, false, (uint)p.Id);
                if (hProc != IntPtr.Zero)
                {
                    var path = new StringBuilder(1024);
                    var len = GetModuleFileName(hProc, path, 1024);
                    if (len > 0)
                    {
                        row["Path"] = path;
                    }
                    else
                    {
                        row["Path"] = Marshal.GetLastWin32Error();

                    }
                }
                else
                {
                    row["Path"] = "Beans";
                }
                //row["Path"] = GetMainModuleFilepath(p.Id);
                dt.Rows.Add(row);
            }

            dt.DefaultView.Sort = "Process ASC";

            processDataGridView.DataSource = dt;
        }

        private void ApplyFilter()
        {
            var filter = filterTextBox.Text;
            if (!string.IsNullOrEmpty(filter))
            {
                filter = $"process like '%{filter}%' or path like '%{filter}%' or CONVERT(pid, System.String) like '%{filter}%'";
            }
            ((DataTable)processDataGridView.DataSource).DefaultView.RowFilter = filter;
        }

        private void dllButton_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "All DLLs |*.dll"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                dllPathTextBox.Text = ofd.FileName;
            }
        }
        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void injectButton_Click(object sender, EventArgs e)
        {
            if (processDataGridView.SelectedRows.Count > 0)
            {
                Injector.Inject((IntPtr)SelectedProcess, dllPathTextBox.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshProcesses();
        }
    }


}