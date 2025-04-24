using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class FrameBuffer : DrmModeObject
    {

        public class FB : DrmObjectPtr
        {
            /// <summary>
            /// <c>void drmModeFreeFB(drmModeFBPtr ptr);</c>
            /// </summary>
            [DllImport("libdrm", SetLastError = true)]
            internal static extern void drmModeFreeFB(IntPtr ptr);
            /// <summary>
            /// <c>drmModeFBPtr drmModeGetFB(int fd, uint32_t bufferId);</c>
            /// </summary>
            [DllImport("libdrm", SetLastError = true)]
            internal static extern IntPtr drmModeGetFB(int fd, UInt32 bufferId);
        }

        public class FB2 : DrmObjectPtr
        {
            /// <summary>
            /// <c>void drmModeFreeFB2(drmModeFB2Ptr ptr);</c>
            /// </summary>
            [DllImport("libdrm", SetLastError = true)]
            internal static extern void drmModeFreeFB2(IntPtr ptr);
            /// <summary>
            /// <c>drmModeFB2Ptr drmModeGetFB2(int fd, uint32_t bufferId);</c>
            /// </summary>
            [DllImport("libdrm", SetLastError = true)]
            internal static extern IntPtr drmModeGetFB2(int fd, UInt32 bufferId);
        }

        /**
         * Creates a new framebuffer with an buffer object as its scanout buffer.
         */
        /// <summary>
        /// <c>int drmModeAddFB(int fd, uint32_t width, uint32_t height, uint8_t depth,uint8_t bpp, uint32_t pitch, uint32_t bo_handle, uint32_t* buf_id);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeAddFB(int fd, UInt32 width, UInt32 height, byte depth, byte bpp, UInt32 pitch, UInt32 bo_handle, ref UInt32 buf_id);
        /* ...with a specific pixel format */
        /// <summary>
        /// <c>int drmModeAddFB2(int fd, uint32_t width, uint32_t height, uint32_t pixel_format, const uint32_t bo_handles[4], const uint32_t pitches[4], const uint32_t offsets[4], uint32_t *buf_id, uint32_t flags);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeAddFB2(int fd, UInt32 width, UInt32 height, UInt32 pixel_format, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] UInt32[] bo_handles, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] UInt32[] pitches, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] UInt32[] offsets, ref UInt32 buf_id, UInt32 flags);

        /* ...with format modifiers */
        /// <summary>
        /// <c>int drmModeAddFB2WithModifiers(int fd, uint32_t width, uint32_t height, uint32_t pixel_format, const uint32_t bo_handles[4], const uint32_t pitches[4], const uint32_t offsets[4], const uint64_t modifier[4], uint32_t *buf_id, uint32_t flags);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeAddFB2WithModifiers(int fd, UInt32 width, UInt32 height, UInt32 pixel_format, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] UInt32[] bo_handles, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] UInt32[] pitches, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] UInt32[] offsets, [MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] UInt64[] modifier, ref UInt32 buf_id, UInt32 flags);

        /**
         * Destroies the given framebuffer.
         */
        /// <summary>
        /// <c>int drmModeRmFB(int fd, uint32_t bufferId);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeRmFB(int fd, UInt32 bufferId);

        /**
         * Mark a region of a framebuffer as dirty.
         */
        /// <summary>
        /// <c>int drmModeDirtyFB(int fd, uint32_t bufferId, drmModeClipPtr clips, uint32_t num_clips);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeDirtyFB(int fd, UInt32 bufferId, IntPtr clips, UInt32 num_clips);
    }
}
