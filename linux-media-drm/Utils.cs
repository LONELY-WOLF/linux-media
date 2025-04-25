using System.Runtime.InteropServices;

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

        static internal UInt32[] ReadUInt32Array(IntPtr ptr, uint count)
        {
            UInt32[] ids = new UInt32[count];
            for (int i = 0; i < count; i++)
            {
                ids[i] = (uint)Marshal.ReadInt32(ptr, i * Marshal.SizeOf<UInt32>());
            }
            return ids;
        }
    }
}
