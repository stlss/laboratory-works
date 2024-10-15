using System.Runtime.InteropServices;

namespace PipesInfrastructure
{
    public static class Kernel32
    {
        [DllImport("kernel32.dll")]
        public static extern int CreateNamedPipe(string lpName,
            uint dwOpenMode,
            uint dwPipeMode,
            uint nMaxInstances,
            uint nOutBufferSize,
            uint nInBufferSize,
            int nDefaultTimeOut,
            uint lpSecurityAttributes);


        [DllImport("kernel32.dll")]
        public static extern bool ConnectNamedPipe(int hNamedPipe, 
            int lpOverlapped);

        [DllImport("kernel32.dll")]
        public static extern bool DisconnectNamedPipe(int hPipe);


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
