using System;
using System.Runtime.InteropServices;

namespace MailSlotsInfrastructure
{
    public static class Kernel32
    {
        //Создание майлслота
        [DllImport("kernel32.dll")]
        public static extern int CreateMailslot(string lpName,
            int nMaxMessageSize,    
            int lReadTimeout,
            int securityAttributes);

        [DllImport("kernel32.dll")]
        public static extern bool GetMailslotInfo(int hMailslot,
            int lpMaxMessageSize, 
            ref int lpNextSize, 
            ref int lpMessageCount,
            int lpReadTimeout);


        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int CreateFile(string lpFileName,
            Enums.EFileAccess dwDesiredAccess,
            Enums.EFileShare dwShareMode,
            int lpSecurityAttributes,
            Enums.ECreationDisposition dwCreationDisposition,
            int dwFlagsAndAttributes,
            int hTemplateFile);


        [DllImport("kernel32.dll")]
        public static extern bool ReadFile(int hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToRead,
            ref uint lpNumberOfBytesRead,
            int lpOverlapped);

        [DllImport("kernel32.dll")]
        public static extern bool WriteFile(int hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite,
            ref uint lpNumberOfBytesWritten,
            int lpOverlapped);


        [DllImport("kernel32.dll")]
        public static extern byte FlushFileBuffers(int hPipe);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(int hObject);
    }
}
