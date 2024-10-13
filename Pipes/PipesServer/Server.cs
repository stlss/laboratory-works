using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using PipesInfrastructure;

namespace Pipes
{
    public partial class frmMain : Form
    {
        private readonly int _pipeHandle;
        private readonly string _pipeName;
        private readonly Thread _thread;
        private bool _continue = true;


        public frmMain()
        {
            InitializeComponent();

            _pipeName = $"\\\\.\\pipe\\ServerPipe";

            _pipeHandle = Kernel32.CreateNamedPipe(
                lpName: _pipeName, 
                dwOpenMode: Constants.PIPE_ACCESS_DUPLEX, 
                dwPipeMode: Constants.PIPE_TYPE_BYTE | Constants.PIPE_WAIT, 
                nMaxInstances: Constants.PIPE_UNLIMITED_INSTANCES, 
                nOutBufferSize: 0, 
                nInBufferSize: 1024,
                nDefaultTimeOut: Constants.NMPWAIT_WAIT_FOREVER,
                lpSecurityAttributes: 0);


            var hostName = Dns.GetHostName();
            Text += "-" + hostName;

            _thread = new Thread(ReceiveMessage);
            _thread.Start();
        }


        private void ReceiveMessage()
        {
            uint realBytesReaded = 0;

            while (_continue)
            {
                if (Kernel32.ConnectNamedPipe(_pipeHandle, 0))
                {
                    Kernel32.FlushFileBuffers(_pipeHandle);

                    byte[] buff = new byte[1024];

                    Kernel32.ReadFile(hFile: _pipeHandle, 
                        lpBuffer: buff, 
                        nNumberOfBytesToRead: 1024, 
                        lpNumberOfBytesRead: ref realBytesReaded, 
                        lpOverlapped: 0);

                    var msg = Encoding.Unicode.GetString(buff);

                    _rtbMessages.Invoke((MethodInvoker)delegate
                    {
                        if (msg != string.Empty)
                            _rtbMessages.Text += "\n >> " + msg;
                    });

                    Kernel32.DisconnectNamedPipe(_pipeHandle); 
                    Thread.Sleep(500);
                }
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _continue = false;

            if (_pipeHandle != -1)
                Kernel32.CloseHandle(_pipeHandle);

            _thread?.Abort();
        }
    }
}