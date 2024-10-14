using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using MailSlotsInfrastructure;

namespace MailSlots
{
    public partial class frmMain : Form
    {
        private readonly int _clientHandleMailSlot;
        private readonly Thread _thread;
        private bool _continue = true;


        public frmMain()
        {
            InitializeComponent();

            var mailSlotName = "\\\\.\\mailslot\\ServerMailslot";

            _clientHandleMailSlot = Kernel32.CreateMailslot(lpName: mailSlotName, 
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

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _continue = false;

            if (_clientHandleMailSlot != -1)
                Kernel32.CloseHandle(_clientHandleMailSlot);

            _thread?.Abort();
        }
    }
}