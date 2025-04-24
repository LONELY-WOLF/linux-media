using System.Runtime.InteropServices;

namespace LinuxMedia.Drm
{
    public class ScatterGather : DrmObjectHandle
    {
        public ScatterGather(int fd, ulong size)
        {
            drm_fd = fd;

            drmScatterGatherAlloc(drm_fd, size, ref drm_handle);
        }

        ~ScatterGather()
        {
            drmScatterGatherFree(drm_fd, drm_handle);
        }

        /* PCI scatter/gather support: X server (root) only */
        /// <summary>
        /// <c>int drmScatterGatherAlloc(int fd, unsigned long size, drm_handle_t* handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmScatterGatherAlloc(int fd, ulong size, ref uint handle);
        /// <summary>
        /// <c>int drmScatterGatherFree(int fd, drm_handle_t handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmScatterGatherFree(int fd, uint handle);
    }
}
