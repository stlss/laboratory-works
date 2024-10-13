using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using PipesInfrastructure;

namespace Pipes
{
    public partial class frmMain : Form
    {
        private readonly string _hostName = Dns.GetHostName();


        public frmMain()
        {
            InitializeComponent();

            Text += " - " + _hostName;
        }


        private void TbMessage_TextChanged(object sender, EventArgs e)
        {
            _btnSend.Enabled = _tbMessage.Text.Length != 0;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            uint bytesWritten = 0;
            byte[] buff = Encoding.Unicode.GetBytes(_hostName + " >> " + _tbMessage.Text);

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
    }
}
