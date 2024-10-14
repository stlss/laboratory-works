using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using MailSlotsInfrastructure;

namespace MailSlots
{
    public partial class frmMain : Form
    {
        private int _handleMailSlot;


        public frmMain()
        {
            InitializeComponent();

            var hostName = Dns.GetHostName();
            Text += " - " + hostName;
        }


        private void BtnConnect_Click(object sender, EventArgs e)
        {
            var connectedMailSlot = TryConnectMailSlot(out var handleMailSlot);

            if (connectedMailSlot)
            {
                _handleMailSlot = handleMailSlot;
                _tbMailSlot.Enabled = false;
                _btnConnect.Enabled = false;
                _btnSend.Enabled = true;
            }
            else
            {
                MessageBox.Show("Не удалось подключиться к мейлслоту");
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            var message = Dns.GetHostName().ToString() + " >> " + _tbMessage.Text;
            SendMessage(message);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Kernel32.CloseHandle(_handleMailSlot);
        }


        private bool TryConnectMailSlot(out int handleMailSlot)
        {
            try
            {
                handleMailSlot = Kernel32.CreateFile(lpFileName: _tbMailSlot.Text,
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

        private void SendMessage(string message)
        {
            uint bytesWritten = 0;
            byte[] buff = Encoding.Unicode.GetBytes(message);

            Kernel32.WriteFile(hFile: _handleMailSlot,
                lpBuffer: buff,
                nNumberOfBytesToWrite: Convert.ToUInt32(buff.Length),
                lpNumberOfBytesWritten: ref bytesWritten,
                lpOverlapped: 0);
        }
    }
}