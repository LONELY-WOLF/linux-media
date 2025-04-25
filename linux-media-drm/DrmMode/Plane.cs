using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class Plane : DrmModeObject
    {
        public override Type ObjectType => Type.PLANE;

        public Plane(DRM drm, UInt32 plane_id) : base(drm, plane_id)
        {

        }

        public void Set(Crtc crtc, FrameBuffer fb, UInt32 flags, Int32 crtc_x, Int32 crtc_y, UInt32 crtc_w, UInt32 crtc_h, UInt32 src_x, UInt32 src_y, UInt32 src_w, UInt32 src_h)
        {
            Utils.ThrowExceptionOnErrno(
                drmModeSetPlane(DRM_FD, ID, crtc.ID, fb.ID, flags, crtc_x, crtc_y, crtc_w, crtc_h, src_x, src_y, src_w, src_h)
                );
        }

        public Info GetInfo()
        {
            return new Info(DRM_FD, ID);
        }

        public class Info : DrmModePtr
        {
            NativeInfo nativeInfo;

            internal Info(int drm_fd, UInt32 plane_id)
            {
                Ptr = drmModeGetPlane(drm_fd, plane_id);
                nativeInfo = Marshal.PtrToStructure<NativeInfo>(Ptr);
            }

            ~Info()
            {
                drmModeFreePlane(Ptr);
            }

            UInt32[] formats = null;
            public UInt32[] Formats
            {
                get
                {
                    if(formats == null)
                    {
                        formats = Utils.ReadUInt32Array(nativeInfo.formats, nativeInfo.count_formats);
                    }
                    return formats;
                }
            }
            public UInt32 PlaneID => nativeInfo.plane_id;
            public UInt32 CRTC_ID => nativeInfo.crtc_id;
            public UInt32 FB_ID => nativeInfo.fb_id;
            public UInt32 CRTC_X => nativeInfo.crtc_x;
            public UInt32 CRTC_Y => nativeInfo.crtc_y;
            public UInt32 X => nativeInfo.x;
            public UInt32 Y => nativeInfo.y;
            public UInt32 PossibleCRTCs => nativeInfo.possible_crtcs;
            public UInt32 GammaSize => nativeInfo.gamma_size;

            /// <summary>
            /// <c>void drmModeFreePlane(drmModePlanePtr ptr);</c>
            /// </summary>
            [DllImport("libdrm", SetLastError = true)]
            internal static extern void drmModeFreePlane(IntPtr ptr);
            /// <summary>
            /// <c>drmModePlanePtr drmModeGetPlane(int fd, uint32_t plane_id);</c>
            /// </summary>
            [DllImport("libdrm", SetLastError = true)]
            internal static extern IntPtr drmModeGetPlane(int fd, UInt32 plane_id);

            [StructLayout(LayoutKind.Sequential)]
            struct NativeInfo
            {
                internal UInt32 count_formats;
                internal IntPtr formats;
                internal UInt32 plane_id;

                internal UInt32 crtc_id;
                internal UInt32 fb_id;

                internal UInt32 crtc_x, crtc_y;
                internal UInt32 x, y;

                internal UInt32 possible_crtcs;
                internal UInt32 gamma_size;

            }
        }

        /// <summary>
        /// <c>int drmModeSetPlane(int fd, uint32_t plane_id, uint32_t crtc_id, uint32_t fb_id, uint32_t flags, int32_t crtc_x, int32_t crtc_y, uint32_t crtc_w, uint32_t crtc_h, uint32_t src_x, uint32_t src_y, uint32_t src_w, uint32_t src_h);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeSetPlane(int fd, UInt32 plane_id, UInt32 crtc_id, UInt32 fb_id, UInt32 flags, Int32 crtc_x, Int32 crtc_y, UInt32 crtc_w, UInt32 crtc_h, UInt32 src_x, UInt32 src_y, UInt32 src_w, UInt32 src_h);
    }
}
