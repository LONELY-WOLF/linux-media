using LinuxMedia.Drm.Mode;
using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class FrameBuffer : DrmModeObject
    {

        public override Type ObjectType => Type.FB;

        public FrameBuffer(DRM drm, UInt32 fb_id)
        {
            ID = fb_id;
            DRM = drm;
        }

        public FB GetFB()
        {
            return new FB(DRM, ID);
        }

        public FB2 GetFB2()
        {
            return new FB2(DRM, ID);
        }

        public void RmFB()
        {
            Utils.ThrowExceptionOnErrno(
                drmModeRmFB(DRM.FD, ID)
                );
        }

        public void DirtyFB()
        {
            throw new NotImplementedException();
        }

        public class FB : DrmModePtr
        {
            NativeFB nativeFB;

            internal FB(DRM drm, UInt32 fb_id)
            {
                Ptr = drmModeGetFB(drm.FD, fb_id);
                nativeFB = Marshal.PtrToStructure<NativeFB>(Ptr);
            }

            ~FB()
            {
                drmModeFreeFB(Ptr);
            }

            public UInt32 FB_ID => nativeFB.fb_id;
            public UInt32 Width => nativeFB.width;
            public UInt32 Height => nativeFB.height;
            public UInt32 Pitch => nativeFB.pitch;
            public UInt32 BPP => nativeFB.bpp;
            public UInt32 Depth => nativeFB.depth;
            /// <summary>
            /// driver specific handle
            /// </summary>
            public UInt32 Handle => nativeFB.handle;

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

            [StructLayout(LayoutKind.Sequential)]
            struct NativeFB
            {
                public UInt32 fb_id;
                public UInt32 width, height;
                public UInt32 pitch;
                public UInt32 bpp;
                public UInt32 depth;
                /* driver specific handle */
                public UInt32 handle;
            }
        }

        public class FB2 : DrmModePtr
        {
            NativeFB2 nativeFB2;

            internal FB2(DRM drm, UInt32 fb_id)
            {
                Ptr = drmModeGetFB2(drm.FD, fb_id);
                nativeFB2 = Marshal.PtrToStructure<NativeFB2>(Ptr);
            }

            ~FB2()
            {
                drmModeFreeFB2(Ptr);
            }

            public UInt32 FB_ID => nativeFB2.fb_id;
            public UInt32 Width => nativeFB2.width;
            public UInt32 Height => nativeFB2.height;
            /// <summary>
            /// fourcc code from drm_fourcc.h
            /// </summary>
            public UInt32 PixelFormat => nativeFB2.pixel_format;
            /// <summary>
            /// applies to all buffers
            /// </summary>
            public UInt32 Modifier => nativeFB2.modifier;
            public UInt32 Flags => nativeFB2.flags;
            /// <summary>
            /// per-plane GEM handle; may be duplicate entries for multiple planes
            /// </summary>
            public UInt32[] Handles => nativeFB2.handles;
            /// <summary>
            /// bytes
            /// </summary>
            public UInt32[] Pitches => nativeFB2.pitches;
            /// <summary>
            /// bytes
            /// </summary>
            public UInt32[] Offsets => nativeFB2.offsets;

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

            [StructLayout(LayoutKind.Sequential)]
            struct NativeFB2
            {
                public UInt32 fb_id;
                public UInt32 width, height;
                public UInt32 pixel_format; /* fourcc code from drm_fourcc.h */
                public UInt32 modifier; /* applies to all buffers */
                public UInt32 flags;

                /* per-plane GEM handle; may be duplicate entries for multiple planes */
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
                public UInt32[] handles;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
                public UInt32[] pitches; /* bytes */
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
                public UInt32[] offsets; /* bytes */
            }
        }

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

namespace LinuxMedia.Drm
{
    public partial class DRM
    {
        public FrameBuffer AddFB(byte depth, BufferObject bo)
        {
            UInt32 buf_id = 0;
            Utils.ThrowExceptionOnErrno(
                drmModeAddFB(FD, bo.Width, bo.Height, depth, (byte)bo.Bpp, bo.Pitch, bo.DrmHandle, ref buf_id)
                );
            return new FrameBuffer(this, buf_id);
        }

        public FrameBuffer AddFB2(int fd, UInt32 pixel_format, BufferObject[] bo, UInt32[] offsets, UInt32 flags)
        {
            UInt32 buf_id = 0;
            UInt32[] h = { 0, 0, 0, 0 };
            UInt32[] p = { 0, 0, 0, 0 };
            UInt32[] o = { 0, 0, 0, 0 };

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    h[i] = bo[i].DrmHandle;
                    p[i] = bo[i].Pitch;
                    o[i] = offsets[i];
                }
            }
            catch(ArgumentOutOfRangeException ex)
            {

            }

            Utils.ThrowExceptionOnErrno(
                drmModeAddFB2(FD, bo[0].Width, bo[0].Height, pixel_format, h, p, o, ref buf_id, flags)
                );
            return new FrameBuffer(this, buf_id);
        }

        public FrameBuffer AddFB2(int fd, UInt32 pixel_format, BufferObject[] bo, UInt32[] offsets, UInt64[] modifier, UInt32 flags)
        {
            UInt32 buf_id = 0;
            UInt32[] h = { 0, 0, 0, 0 };
            UInt32[] p = { 0, 0, 0, 0 };
            UInt32[] o = { 0, 0, 0, 0 };
            UInt64[] m = { 0, 0, 0, 0 };

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    h[i] = bo[i].DrmHandle;
                    p[i] = bo[i].Pitch;
                    o[i] = offsets[i];
                    m[i] = modifier[i];
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }

            Utils.ThrowExceptionOnErrno(
                drmModeAddFB2WithModifiers(FD, bo[0].Width, bo[0].Height, pixel_format, h, p, o, m, ref buf_id, flags)
                );
            return new FrameBuffer(this, buf_id);
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
    }
}
