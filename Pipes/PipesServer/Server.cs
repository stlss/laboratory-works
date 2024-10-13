using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using PipesInfrastructure;
using System;
using System.Collections.Generic;

namespace Pipes
{
    public partial class frmMain : Form
    {
        private readonly int _pipeServerHandle;

        private readonly string _pipeServerName;
        private readonly string _pipeClientLogin;

        private readonly Thread _thread;
        private bool _continue = true;
        

        private readonly HashSet<string> clientLogins = new HashSet<string>();


        public frmMain()
        {
            InitializeComponent();

            _pipeServerName = "\\\\.\\pipe\\ServerPipe";
            _pipeClientLogin = "\\\\.\\pipe\\ClientPipe";

            _pipeServerHandle = Kernel32.CreateNamedPipe(
                lpName: _pipeServerName, 
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
                if (Kernel32.ConnectNamedPipe(_pipeServerHandle, 0))
                {
                    Kernel32.FlushFileBuffers(_pipeServerHandle);

                    byte[] buff = new byte[1024];

                    Kernel32.ReadFile(hFile: _pipeServerHandle, 
                        lpBuffer: buff, 
                        nNumberOfBytesToRead: 1024, 
                        lpNumberOfBytesRead: ref realBytesReaded, 
                        lpOverlapped: 0);

                    var msg = Encoding.Unicode.GetString(buff);

                    _rtbMessages.Invoke((MethodInvoker)delegate
                    {
                        if (msg != string.Empty)
                            _rtbMessages.Text += "\n >> " + msg;

                        var words = msg.Split();
                        var clientLogin = words[0];

                        switch (words[1])
                        {
                            case "присоединяется":
                                clientLogins.Add(clientLogin);
                                SendMessageClients(clientLogin, buff);
                                break;

                            case ">>":
                                SendMessageClients(clientLogin, buff);
                                break;

                            case "выходит":
                                SendMessageClients(clientLogin, buff);
                                clientLogins.Remove(clientLogin);
                                break;
                        }
                    });

                    Kernel32.DisconnectNamedPipe(_pipeServerHandle); 
                    Thread.Sleep(500);
                }
            }
        }

        private void SendMessageClients(string clientLogin, byte[] buff)
        {
            foreach (var item in clientLogins)
            {
                uint BytesWritten = 0;

                var pipeClientHandle = Kernel32.CreateFile(_pipeClientLogin + item,
                    Enums.EFileAccess.GenericWrite,
                    Enums.EFileShare.Read,
                    0,
                    Enums.ECreationDisposition.OpenExisting,
                    0,
                    0);

                Kernel32.WriteFile(pipeClientHandle, buff, Convert.ToUInt32(buff.Length), ref BytesWritten, 0);
                Kernel32.CloseHandle(pipeClientHandle);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _continue = false;

            if (_pipeServerHandle != -1)
                Kernel32.CloseHandle(_pipeServerHandle);

            _thread?.Abort();
        }
    }
}