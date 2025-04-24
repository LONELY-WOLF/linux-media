using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class Encoder : DrmModeObject
    {
        public override Type ObjectType => Type.ENCODER;

        public Encoder(DRM drm, UInt32 encoder_id) : base(drm, encoder_id)
        {

        }

        public Info GetInfo()
        {
            return new Info(DRM_FD, ID);
        }

        public class Info : DrmModePtr
        {
            NativeInfo nativeInfo;

            internal Info(int drm_fd, UInt32 encoder_id)
            {
                Ptr = drmModeGetEncoder(drm_fd, encoder_id);
                nativeInfo = Marshal.PtrToStructure<NativeInfo>(Ptr);
            }

            ~Info()
            {
                drmModeFreeEncoder(Ptr);
            }

            public UInt32 EncoderID => nativeInfo.encoder_id;
            public UInt32 EncoderType => nativeInfo.encoder_type;
            public UInt32 CRTC_ID => nativeInfo.crtc_id;
            public UInt32 PossibleCRTCs => nativeInfo.possible_crtcs;
            public UInt32 PossibleClones => nativeInfo.possible_clones;

            /// <summary>
            /// <c>void drmModeFreeEncoder(drmModeEncoderPtr ptr);</c>
            /// </summary>
            [DllImport("libdrm", SetLastError = true)]
            internal static extern void drmModeFreeEncoder(IntPtr ptr);
            /// <summary>
            /// <c>drmModeEncoderPtr drmModeGetEncoder(int fd, uint32_t encoder_id);</c>
            /// </summary>
            [DllImport("libdrm", SetLastError = true)]
            internal static extern IntPtr drmModeGetEncoder(int fd, UInt32 encoder_id);

            [StructLayout(LayoutKind.Sequential)]
            struct NativeInfo
            {
                internal UInt32 encoder_id;
                internal UInt32 encoder_type;
                internal UInt32 crtc_id;
                internal UInt32 possible_crtcs;
                internal UInt32 possible_clones;
            }
        }
    }
}
