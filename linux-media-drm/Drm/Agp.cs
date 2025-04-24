using System.Runtime.InteropServices;

namespace LinuxMedia.Drm
{
    public class Agp
    {
        /* AGP/GART support: X server (root) only */
        /// <summary>
        /// <c>int drmAgpAcquire(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAgpAcquire(int fd);
        /// <summary>
        /// <c>int drmAgpRelease(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAgpRelease(int fd);
        /// <summary>
        /// <c>int drmAgpEnable(int fd, unsigned long mode);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAgpEnable(int fd, ulong mode);
        /// <summary>
        /// <c>int drmAgpAlloc(int fd, unsigned long size, unsigned long type, unsigned long* address, drm_handle_t* handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAgpAlloc(int fd, ulong size, ulong type, ref ulong address, ref uint handle);
        /// <summary>
        /// <c>int drmAgpFree(int fd, drm_handle_t handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAgpFree(int fd, uint handle);
        /// <summary>
        /// <c>int drmAgpBind(int fd, drm_handle_t handle, unsigned long offset);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAgpBind(int fd, uint handle, ulong offset);
        /// <summary>
        /// <c>int drmAgpUnbind(int fd, drm_handle_t handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAgpUnbind(int fd, uint handle);

        /* AGP/GART info: authenticated client and/or X */
        /// <summary>
        /// <c>int drmAgpVersionMajor(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAgpVersionMajor(int fd);
        /// <summary>
        /// <c>int drmAgpVersionMinor(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAgpVersionMinor(int fd);
        /// <summary>
        /// <c>unsigned long drmAgpGetMode(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern ulong drmAgpGetMode(int fd);
        /// <summary>
        /// Physical location
        /// <c>unsigned long drmAgpBase(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern ulong drmAgpBase(int fd);
        /// <summary>
        /// Bytes
        /// <c>unsigned long drmAgpSize(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern ulong drmAgpSize(int fd);
        /// <summary>
        /// <c>unsigned long drmAgpMemoryUsed(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern ulong drmAgpMemoryUsed(int fd);
        /// <summary>
        /// <c>unsigned long drmAgpMemoryAvail(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern ulong drmAgpMemoryAvail(int fd);
        /// <summary>
        /// <c>unsigned int drmAgpVendorId(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern uint drmAgpVendorId(int fd);
        /// <summary>
        /// <c>unsigned int drmAgpDeviceId(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern uint drmAgpDeviceId(int fd);
    }
}
