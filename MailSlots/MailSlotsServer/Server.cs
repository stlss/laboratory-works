using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using MailSlotsInfrastructure;
using System;
using System.Collections.Generic;

namespace MailSlots
{
    public partial class frmMain : Form
    {
        private int _serverHandleMailSlot;

        private readonly string _serverMailSlotName;
        private readonly string _clientMailSlotName;

        private readonly Thread _thread;
        private bool _continue = true;

        private readonly HashSet<string> _clientLogins = new HashSet<string>();


        public frmMain()
        {
            InitializeComponent();

            _serverMailSlotName = "\\\\.\\mailslot\\ServerMailslot";
            _clientMailSlotName = "\\\\.\\mailslot\\ClientMailslot";

            _serverHandleMailSlot = Kernel32.CreateMailslot(lpName: _serverMailSlotName, 
                nMaxMessageSize: 0, 
                lReadTimeout: Constants.MAILSLOT_WAIT_FOREVER, 
                securityAttributes: 0);

            var hostName = Dns.GetHostName();
            Text += " - " + hostName;

            Thread t = new Thread(ReceiveMessage);
            t.Start();
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
                Kernel32.GetMailslotInfo(hMailslot: _serverHandleMailSlot, 
                    lpMaxMessageSize: MailslotSize, 
                    lpNextSize: ref lpNextSize, 
                    lpMessageCount: ref MessageCount, 
                    lpReadTimeout: 0);

                if (MessageCount > 0)
                {
                    for (int i = 0; i < MessageCount; i++)
                    {
                        Kernel32.FlushFileBuffers(_serverHandleMailSlot);

                        byte[] buff = new byte[1024];

                        Kernel32.ReadFile(_serverHandleMailSlot,
                            lpBuffer: buff,
                            nNumberOfBytesToRead: 1024,
                            lpNumberOfBytesRead: ref realBytesReaded,
                            lpOverlapped: 0);

                        msg = Encoding.Unicode.GetString(buff);

                        _rtbMessages.Invoke((MethodInvoker)delegate
                        {
                            if (msg != string.Empty)
                                _rtbMessages.Text += "\n >> " + msg;

                            var words = msg.Split();
                            var clientLogin = words[0];

                            switch (words[1])
                            {
                                case "присоединяется":
                                    _clientLogins.Add(clientLogin);
                                    SendMessageClients(buff);
                                    break;

                                case ">>":
                                    SendMessageClients(buff);
                                    break;

                                case "выходит":
                                    _clientLogins.Remove(clientLogin);
                                    SendMessageClients(buff);
                                    break;
                            }
                        });

                        Thread.Sleep(500);
                    }
                }
            }
        }

        private void SendMessageClients(byte[] buff)
        {
            foreach (var item in _clientLogins)
            {
                uint bytesWritten = 0;

                var handleMailSlot = Kernel32.CreateFile(lpFileName: _clientMailSlotName + item,
                    dwDesiredAccess: Enums.EFileAccess.GenericWrite,
                    dwShareMode: Enums.EFileShare.Read,
                    lpSecurityAttributes: 0,
                    dwCreationDisposition: Enums.ECreationDisposition.OpenExisting,
                    dwFlagsAndAttributes: 0,
                    hTemplateFile: 0);

                Kernel32.WriteFile(hFile: handleMailSlot,
                    lpBuffer: buff,
                    nNumberOfBytesToWrite: Convert.ToUInt32(buff.Length),
                    lpNumberOfBytesWritten: ref bytesWritten,
                    lpOverlapped: 0);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _continue = false;

            if (_serverHandleMailSlot != -1)
                Kernel32.CloseHandle(_serverHandleMailSlot);

            _thread?.Abort();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            var serverHandleMailSlot = Kernel32.CreateMailslot(lpName: "\\\\.\\mailslot\\" + _tbMailSlot.Text,
                nMaxMessageSize: 0,
                lReadTimeout: Constants.MAILSLOT_WAIT_FOREVER,
                securityAttributes: 0);

            if (serverHandleMailSlot != -1)
            {
                _serverHandleMailSlot = serverHandleMailSlot;
                _rtbMessages.Clear();
                _clientLogins.Clear();
            }
        }
    }
}