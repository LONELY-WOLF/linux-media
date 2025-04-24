using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class BufferObject : DrmModeObject
    {
        /**
         * Create a dumb buffer.
         *
         * Given a width, height and bits-per-pixel, the kernel will return a buffer
         * handle, pitch and size. The flags must be zero.
         *
         * Returns 0 on success, negative errno on error.
         */
        /// <summary>
        /// <c>int drmModeCreateDumbBuffer(int fd, uint32_t width, uint32_t height, uint32_t bpp, uint32_t flags, uint32_t* handle, uint32_t* pitch, uint64_t* size);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeCreateDumbBuffer(int fd, UInt32 width, UInt32 height, UInt32 bpp, UInt32 flags, ref UInt32 handle, ref UInt32 pitch, ref UInt64 size);

        /**
         * Destroy a dumb buffer.
         *
         * Returns 0 on success, negative errno on error.
         */
        /// <summary>
        /// <c>int drmModeDestroyDumbBuffer(int fd, uint32_t handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeDestroyDumbBuffer(int fd, UInt32 handle);

        /**
         * Prepare a dumb buffer for mapping.
         *
         * The kernel returns an offset which can be used as an argument to mmap(2) on
         * the DRM FD.
         *
         * Returns 0 on success, negative errno on error.
         */
        /// <summary>
        /// <c>int drmModeMapDumbBuffer(int fd, uint32_t handle, uint64_t* offset);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeMapDumbBuffer(int fd, UInt32 handle, ref UInt64 offset);
    }
}
