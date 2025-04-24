using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    /// <summary>
    /// DRM mode lease APIs. These create and manage new drm_masters with
    /// access to a subset of the available DRM resources
    /// </summary>
    public class Lease : DrmModeObject
    {
        /// <summary>
        /// <c>int drmModeCreateLease(int fd, const uint32_t* objects, int num_objects, int flags, uint32_t *lessee_id);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeCreateLease(int fd, [MarshalAs(UnmanagedType.LPArray)] UInt32 objects, int num_objects, int flags, ref UInt32 lessee_id);

        /// <summary>
        /// <c>drmModeLesseeListPtr drmModeListLessees(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeListLessees(int fd);

        /// <summary>
        /// <c>drmModeObjectListPtr drmModeGetLease(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeGetLease(int fd);

        /// <summary>
        /// <c>int drmModeRevokeLease(int fd, uint32_t lessee_id);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeRevokeLease(int fd, UInt32 lessee_id);
    }
}
