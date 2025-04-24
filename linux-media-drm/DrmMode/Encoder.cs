using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class Encoder : DrmModeObject
    {
        /// <summary>
        /// <c>void drmModeFreeEncoder(drmModeEncoderPtr ptr);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmModeFreeEncoder(IntPtr ptr);
        /// <summary>
        /// <c>drmModeEncoderPtr drmModeGetEncoder(int fd, uint32_t encoder_id);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeGetEncoder(int fd, UInt32 encoder_id);
    }
}
