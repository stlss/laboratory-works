using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using PipesInfrastructure;
using System.Threading;

namespace Pipes
{
    public partial class frmMain : Form
    {
        private int _pipeClientHandle;
        private readonly string _pipeName;
        private readonly Thread _thread;
        private bool _continue = true;


        public frmMain()
        {
            InitializeComponent();

            var hostName = Dns.GetHostName();

            Text += " - " + hostName;
            _tbLogin.Text = hostName;

            _pipeName = $"\\\\.\\pipe\\ClientPipe";

            _thread = new Thread(ReceiveMessage);
            _thread.Start();
        }


        private void ReceiveMessage()
        {
            uint realBytesReaded = 0;

            while (_continue)
            {
                if (Kernel32.ConnectNamedPipe(_pipeClientHandle, 0))
                {
                    Kernel32.FlushFileBuffers(_pipeClientHandle);

                    byte[] buff = new byte[1024];

                    Kernel32.ReadFile(hFile: _pipeClientHandle,
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

                    Kernel32.DisconnectNamedPipe(_pipeClientHandle);
                    Thread.Sleep(500);
                }
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _continue = false;

            if (_pipeClientHandle != -1)
                Kernel32.CloseHandle(_pipeClientHandle);

            _thread?.Abort();
        }


        private void TbLogin_TextChanged(object sender, EventArgs e)
        {
            _btLogin.Enabled = _tbLogin.Text.Length != 0;
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            _pipeClientHandle = Kernel32.CreateNamedPipe(
                lpName: _pipeName + _tbLogin.Text,
                dwOpenMode: Constants.PIPE_ACCESS_DUPLEX,
                dwPipeMode: Constants.PIPE_TYPE_BYTE | Constants.PIPE_WAIT,
                nMaxInstances: Constants.PIPE_UNLIMITED_INSTANCES,
                nOutBufferSize: 0,
                nInBufferSize: 1024,
                nDefaultTimeOut: Constants.NMPWAIT_WAIT_FOREVER,
                lpSecurityAttributes: 0);

            SendMessage(_tbLogin.Text + " присоединяется к чату!");

            _btLogin.Enabled = false;
            _tbLogin.Enabled = false;
            _tbMessage.Enabled = true;
        }


        private void TbMessage_TextChanged(object sender, EventArgs e)
        {
            _btnSend.Enabled = _tbMessage.Text.Length != 0;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            SendMessage(_tbLogin.Text + " >> " + _tbMessage.Text);
        }

        private void SendMessage(string message)
        {
            uint bytesWritten = 0;
            byte[] buff = Encoding.Unicode.GetBytes(message);

            int pipeHandle = Kernel32.CreateFile(lpFileName: _tbPipe.Text,
                dwDesiredAccess: Enums.EFileAccess.GenericWrite,
                dwShareMode: Enums.EFileShare.Read,
                lpSecurityAttributes: 0,
                dwCreationDisposition: Enums.ECreationDisposition.OpenExisting,
                dwFlagsAndAttributes: 0,
                hTemplateFile: 0);

            Kernel32.WriteFile(hFile: pipeHandle,
                lpBuffer: buff,
                nNumberOfBytesToWrite: Convert.ToUInt32(buff.Length),
                lpNumberOfBytesWritten: ref bytesWritten,
                lpOverlapped: 0);

            Kernel32.CloseHandle(hObject: pipeHandle);
        }

        private void FrmMain_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (_pipeClientHandle != 0)
                SendMessage(_tbLogin.Text + " выходит из чата.");

            _continue = false;

            if (_pipeClientHandle != -1)
                Kernel32.CloseHandle(_pipeClientHandle);

            _thread?.Abort();
        }
    }
}
