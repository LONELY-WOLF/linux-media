namespace LinuxMedia.Drm
{
    static internal class Utils
    {
        static internal void ThrowExceptionOnErrno(int errno)
        {
            switch (errno)
            {
                case 0:
                    {
                        return;
                    }
                default:
                    {
                        throw new Exception($"Errno: {errno}");
                    }
            }
        }
    }
}
