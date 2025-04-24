using System.Runtime.InteropServices;

namespace LinuxMedia.Drm
{
    public class Context : DrmObjectHandle
    {
        public Context(int fd)
        {
            drm_fd = fd;

            drmCreateContext(drm_fd, ref drm_handle);
        }

        ~Context()
        {
            drmDestroyContext(drm_fd, drm_handle);
        }

        /// <summary>
        /// <c>int drmCreateContext(int fd, drm_context_t* handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmCreateContext(int fd, ref uint handle);
        /// <summary>
        /// <c>int drmSetContextFlags(int fd, drm_context_t context, drm_context_tFlags flags);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSetContextFlags(int fd, uint context, drm_context_tFlags flags);
        /// <summary>
        /// <c>int drmGetContextFlags(int fd, drm_context_t context, drm_context_tFlagsPtr flags);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetContextFlags(int fd, uint context, IntPtr flags);
        /// <summary>
        /// <c>int drmAddContextTag(int fd, drm_context_t context, void* tag);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAddContextTag(int fd, uint context, IntPtr tag);
        /// <summary>
        /// <c>int drmDelContextTag(int fd, drm_context_t context);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmDelContextTag(int fd, uint context);
        /// <summary>
        /// <c>void* drmGetContextTag(int fd, drm_context_t context);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmGetContextTag(int fd, uint context);
        /// <summary>
        /// <c>drm_context_t* drmGetReservedContextList(int fd, int* count);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmGetReservedContextList(int fd, ref int count);
        /// <summary>
        /// <c>void drmFreeReservedContextList(drm_context_t*);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmFreeReservedContextList(IntPtr list);
        /// <summary>
        /// <c>int drmSwitchToContext(int fd, drm_context_t context);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSwitchToContext(int fd, uint context);
        /// <summary>
        /// <c>int drmDestroyContext(int fd, drm_context_t handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmDestroyContext(int fd, uint handle);
    }
}
