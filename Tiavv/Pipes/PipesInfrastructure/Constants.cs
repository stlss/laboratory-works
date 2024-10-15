namespace PipesInfrastructure
{
    public static class Constants
    {
        public const uint PIPE_ACCESS_DUPLEX = 0x00000003;
        public const uint PIPE_TYPE_BYTE = 0x00000000;
        public const uint PIPE_TYPE_MESSAGE = 0x00000004;
        public const uint PIPE_WAIT = 0x00000000;
        public const uint PIPE_UNLIMITED_INSTANCES = 255;
        public const int NMPWAIT_WAIT_FOREVER = -1;
        public const uint PIPE_OPEN_MODE = 0x00000003;

        public const int MAILSLOT_WAIT_FOREVER = -1;
    }
}
