using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class PlaneResources : DrmModePtr
    {
        /// <summary>
        /// <c>void drmModeFreePlaneResources(drmModePlaneResPtr ptr);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmModeFreePlaneResources(IntPtr ptr);
        /// <summary>
        /// <c>drmModePlaneResPtr drmModeGetPlaneResources(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeGetPlaneResources(int fd);
    }
}
