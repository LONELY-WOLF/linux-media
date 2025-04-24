using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class Property : DrmModeObject
    {
        /// <summary>
        /// <c>drmModePropertyPtr drmModeGetProperty(int fd, uint32_t propertyId);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeGetProperty(int fd, UInt32 propertyId);
        /// <summary>
        /// <c>void drmModeFreeProperty(drmModePropertyPtr ptr);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmModeFreeProperty(IntPtr ptr);
    }
}
