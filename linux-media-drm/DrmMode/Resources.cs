using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class Resources : DrmModePtr
    {
        /// <summary>
        /// <c>void drmModeFreeResources(drmModeResPtr ptr);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmModeFreeResources(IntPtr ptr);

        /**
         * Retrieves all of the resources associated with a card.
         */
        /// <summary>
        /// <c>drmModeResPtr drmModeGetResources(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeGetResources(int fd);
    }
}
