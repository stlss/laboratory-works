using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using MailSlotsInfrastructure;
using System.Threading;

namespace MailSlots
{
    public partial class frmMain : Form
    {
        private int _serverHandleMailSlot;
        private int _clientHandleMailSlot;

        private readonly Thread _thread;
        private bool _continue = true;

        public frmMain()
        {
            InitializeComponent();

            var hostName = Dns.GetHostName();

            Text += " - " + hostName;
            _tbLogin.Text = hostName;

            Thread t = new Thread(ReceiveMessage);
            t.Start();
        }


        private void BtnConnect_Click(object sender, EventArgs e)
        {
            var connectedMailSlot = TryConnectMailSlot(out var handleMailSlot);

            if (connectedMailSlot)
            {
                _serverHandleMailSlot = handleMailSlot;

                _tbLogin.Enabled = false;
                _btnConnect.Enabled = false;

                _tbMessage.Enabled = true;

                var clientMailSlotName = "\\\\.\\mailslot\\ClientMailslot" + _tbLogin.Text;
                _clientHandleMailSlot = CreateHandleClientMailSlot(clientMailSlotName);

                SendMessage(_tbLogin.Text + " присоединяется к чату!");
            }
            else
            {
                MessageBox.Show("Не удалось подключиться к мейлслоту");
            }
        }

        private bool TryConnectMailSlot(out int handleMailSlot)
        {
            try
            {
                handleMailSlot = Kernel32.CreateFile(lpFileName: "\\\\*\\mailslot\\" + _tbMailSlot.Text,
                    dwDesiredAccess: Enums.EFileAccess.GenericWrite,
                    dwShareMode: Enums.EFileShare.Read,
                    lpSecurityAttributes: 0,
                    dwCreationDisposition: Enums.ECreationDisposition.OpenExisting,
                    dwFlagsAndAttributes: 0,
                    hTemplateFile: 0);

                return handleMailSlot != -1;
            }
            catch
            {
                handleMailSlot = -1;
                return false;
            }
        }

        private static int CreateHandleClientMailSlot(string clientMailSlotName)
        {
            return Kernel32.CreateMailslot(lpName: clientMailSlotName,
                nMaxMessageSize: 0,
                lReadTimeout: Constants.MAILSLOT_WAIT_FOREVER,
                securityAttributes: 0);
        }


        private void BtnSend_Click(object sender, EventArgs e)
        {
            var message = _tbLogin.Text + " >> " + _tbMessage.Text;
            SendMessage(message);
        }

        private void SendMessage(string message)
        {
            uint bytesWritten = 0;
            byte[] buff = Encoding.Unicode.GetBytes(message);

            Kernel32.WriteFile(hFile: _serverHandleMailSlot,
                lpBuffer: buff,
                nNumberOfBytesToWrite: Convert.ToUInt32(buff.Length),
                lpNumberOfBytesWritten: ref bytesWritten,
                lpOverlapped: 0);
        }


        private void TbMailSlot_TextChanged(object sender, EventArgs e)
        {
            if (!_btnConnect.Enabled)
            {
                _btnConnect.Enabled = true;

                _btnSend.Enabled = false;

                _tbMessage.Enabled = false;
                _tbMessage.Text = string.Empty;

                _tbLogin.Enabled = true;

                SendMessage(_tbLogin.Text + " выходит из чата.");
                _rtbMessages.Text = string.Empty;

                if (_clientHandleMailSlot != -1)
                    Kernel32.CloseHandle(_clientHandleMailSlot);
            }

            _btnConnect.Enabled = _tbMailSlot.Text.Length != 0;
        }

        private void TbLogin_TextChanged(object sender, EventArgs e)
        {
            _btnConnect.Enabled = _tbLogin.Text.Length != 0;
        }

        private void TbMessage_TextChanged(object sender, EventArgs e)
        {
            _btnSend.Enabled = _tbMessage.Text.Length != 0;
        }


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_clientHandleMailSlot != 0)
                SendMessage(_tbLogin.Text + " выходит из чата.");

            Kernel32.CloseHandle(_serverHandleMailSlot);

            _continue = false;

            if (_clientHandleMailSlot != -1)
                Kernel32.CloseHandle(_clientHandleMailSlot);

            _thread?.Abort();
        }


        private void ReceiveMessage()
        {
            string msg = string.Empty;
            int MailslotSize = 0;
            int lpNextSize = 0;
            int MessageCount = 0;
            uint realBytesReaded = 0;

            while (_continue)
            {
                Kernel32.GetMailslotInfo(hMailslot: _clientHandleMailSlot,
                    lpMaxMessageSize: MailslotSize,
                    lpNextSize: ref lpNextSize,
                    lpMessageCount: ref MessageCount,
                    lpReadTimeout: 0);

                if (MessageCount > 0)
                {
                    for (int i = 0; i < MessageCount; i++)
                    {
                        Kernel32.FlushFileBuffers(_clientHandleMailSlot);

                        byte[] buff = new byte[1024];

                        Kernel32.ReadFile(_clientHandleMailSlot,
                            lpBuffer: buff,
                            nNumberOfBytesToRead: 1024,
                            lpNumberOfBytesRead: ref realBytesReaded,
                            lpOverlapped: 0);

                        msg = Encoding.Unicode.GetString(buff);

                        _rtbMessages.Invoke((MethodInvoker)delegate
                        {
                            if (msg != string.Empty)
                                _rtbMessages.Text += "\n >> " + msg;
                        });

                        Thread.Sleep(500);
                    }
                }
            }
        }
    }
}