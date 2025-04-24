using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class ModeInfo : DrmModePtr
    {

        /// <summary>
        /// <c>void drmModeFreeModeInfo(drmModeModeInfoPtr ptr);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmModeFreeModeInfo(IntPtr ptr);
    }
}
