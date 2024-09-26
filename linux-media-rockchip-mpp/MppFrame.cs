using System.Runtime.InteropServices;

namespace LinuxMedia.Rockchip
{
    public class MppFrame : MppHandle, IDisposable
    {
        private MppFrame(nint handle) : base(handle)
        {

        }

        public MppFrame()
        {
            mpp_frame_init(ref Handle);
        }

        ~MppFrame()
        {
            Dispose();
        }

        public static MppFrame GetEmptyFrame()
        {
            return new MppFrame(0);
        }

        public UInt32 Width
        {
            get
            {
                return mpp_frame_get_width(Handle);
            }
            set
            {
                mpp_frame_set_width(Handle, value);
            }
        }

        public UInt32 Height
        {
            get
            {
                return mpp_frame_get_height(Handle);
            }
            set
            {
                mpp_frame_set_height(Handle, value);
            }
        }

        public UInt32 HorStride
        {
            get
            {
                return mpp_frame_get_hor_stride(Handle);
            }
            set
            {
                mpp_frame_set_hor_stride(Handle, value);
            }
        }

        public UInt32 VerStride
        {
            get
            {
                return mpp_frame_get_ver_stride(Handle);
            }
            set
            {
                mpp_frame_set_ver_stride(Handle, value);
            }
        }

        public UInt32 HorStridePixel
        {
            get
            {
                return mpp_frame_get_hor_stride_pixel(Handle);
            }
            set
            {
                mpp_frame_set_hor_stride_pixel(Handle, value);
            }
        }

        public UInt32 FbcHdrStride
        {
            get
            {
                return mpp_frame_get_fbc_hdr_stride(Handle);
            }
            set
            {
                mpp_frame_set_fbc_hdr_stride(Handle, value);
            }
        }

        public UInt32 OffsetX
        {
            get
            {
                return mpp_frame_get_offset_x(Handle);
            }
            set
            {
                mpp_frame_set_offset_x(Handle, value);
            }
        }

        public UInt32 OffsetY
        {
            get
            {
                return mpp_frame_get_offset_y(Handle);
            }
            set
            {
                mpp_frame_set_offset_y(Handle, value);
            }
        }

        public UInt32 Mode
        {
            get
            {
                return mpp_frame_get_mode(Handle);
            }
            set
            {
                mpp_frame_set_mode(Handle, value);
            }
        }

        public UInt32 Discard
        {
            get
            {
                return mpp_frame_get_discard(Handle);
            }
            set
            {
                mpp_frame_set_discard(Handle, value);
            }
        }

        public UInt32 ViewId
        {
            get
            {
                return mpp_frame_get_viewid(Handle);
            }
            set
            {
                mpp_frame_set_viewid(Handle, value);
            }
        }

        public UInt32 Poc
        {
            get
            {
                return mpp_frame_get_poc(Handle);
            }
            set
            {
                mpp_frame_set_poc(Handle, value);
            }
        }

        public Int64 Pts
        {
            get
            {
                return mpp_frame_get_pts(Handle);
            }
            set
            {
                mpp_frame_set_pts(Handle, value);
            }
        }

        public Int64 Dts
        {
            get
            {
                return mpp_frame_get_dts(Handle);
            }
            set
            {
                mpp_frame_set_dts(Handle, value);
            }
        }

        public UInt32 ErrInfo
        {
            get
            {
                return mpp_frame_get_errinfo(Handle);
            }
            set
            {
                mpp_frame_set_errinfo(Handle, value);
            }
        }

        public UInt64 BufSize
        {
            get
            {
                return mpp_frame_get_buf_size(Handle);
            }
            set
            {
                mpp_frame_set_buf_size(Handle, value);
            }
        }

        public UInt32 ThumbnailEn
        {
            get
            {
                return mpp_frame_get_thumbnail_en(Handle);
            }
            set
            {
                mpp_frame_set_thumbnail_en(Handle, value);
            }
        }

        public UInt32 Eos
        {
            get
            {
                return mpp_frame_get_eos(Handle);
            }
            set
            {
                mpp_frame_set_eos(Handle, value);
            }
        }

        public UInt32 InfoChange
        {
            get
            {
                return mpp_frame_get_info_change(Handle);
            }
            set
            {
                mpp_frame_set_info_change(Handle, value);
            }
        }

        public MppBuffer Buffer
        {
            get
            {
                return new MppBuffer(mpp_frame_get_buffer(Handle));
            }
            set
            {
                mpp_frame_set_buffer(Handle, value.Handle);
            }
        }

        public Int32 HasMeta
        {
            get
            {
                return mpp_frame_has_meta(Handle);
            }
        }

        public MppMeta Meta
        {
            get
            {
                return new MppMeta(mpp_frame_get_meta(Handle));
            }
            set
            {
                mpp_frame_set_meta(Handle, value.Handle);
            }
        }

        public MppFrameColorRange ColorRange
        {
            get
            {
                return mpp_frame_get_color_range(Handle);
            }
            set
            {
                mpp_frame_set_color_range(Handle, value);
            }
        }

        public MppFrameColorPrimaries ColorPrimaries
        {
            get
            {
                return mpp_frame_get_color_primaries(Handle);
            }
            set
            {
                mpp_frame_set_color_primaries(Handle, value);
            }
        }

        public MppFrameColorTransferCharacteristic ColorTrc
        {
            get
            {
                return mpp_frame_get_color_trc(Handle);
            }
            set
            {
                mpp_frame_set_color_trc(Handle, value);
            }
        }

        public MppFrameColorSpace ColorSpace
        {
            get
            {
                return mpp_frame_get_colorspace(Handle);
            }
            set
            {
                mpp_frame_set_colorspace(Handle, value);
            }
        }

        public MppFrameChromaLocation ChromaLocation
        {
            get
            {
                return mpp_frame_get_chroma_location(Handle);
            }
            set
            {
                mpp_frame_set_chroma_location(Handle, value);
            }
        }

        public MppFrameFormat Fmt
        {
            get
            {
                return mpp_frame_get_fmt(Handle);
            }
            set
            {
                mpp_frame_set_fmt(Handle, value);
            }
        }

        public MppFrameRational Sar
        {
            get
            {
                return mpp_frame_get_sar(Handle);
            }
            set
            {
                mpp_frame_set_sar(Handle, value);
            }
        }

        public MppFrameMasteringDisplayMetadata MasteringDisplay
        {
            get
            {
                return mpp_frame_get_mastering_display(Handle);
            }
            set
            {
                mpp_frame_set_mastering_display(Handle, value);
            }
        }

        public MppFrameContentLightMetadata ContentLight
        {
            get
            {
                return mpp_frame_get_content_light(Handle);
            }
            set
            {
                mpp_frame_set_content_light(Handle, value);
            }
        }

        public MppFrameHdrDynamicMeta HdrDynamicMeta
        {
            get
            {
                IntPtr p = mpp_frame_get_hdr_dynamic_meta(Handle);
                return Marshal.PtrToStructure<MppFrameHdrDynamicMeta>(p);
            }
            set
            {
                IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf<MppFrameHdrDynamicMeta>());
                Marshal.StructureToPtr(value, p, true);
                mpp_frame_set_hdr_dynamic_meta(Handle, p);
                // Is it ok to free memory here?
                Marshal.FreeHGlobal(p);
            }
        }

        #region Native calls
        /*
        * MppFrame interface
        */
        /// <summary>
        /// <c>MPP_RET mpp_frame_init(MppFrame* frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_frame_init(ref IntPtr frame);

        /// <summary>
        /// <c>MPP_RET mpp_frame_deinit(MppFrame* frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_frame_deinit(ref IntPtr frame);

        /*
         * normal parameter
         *
         *    offset_x
         *   <-------->
         *
         *   <---------------+      hor_stride      +--------------->
         *
         *   +------------------------------------------------------+   ^   ^
         *   |                                                      |   |   |
         *   |                                                      |   |   | offset_y
         *   |                                                      |   |   |
         *   |        +--------------------------------+  ^         |   |   v
         *   |        |                                |  |         |   |
         *   |        |                                |  +         |   +
         *   |        |                                |            |
         *   |        |        valid data area         | height     | ver_stride
         *   |        |                                |            |
         *   |        |                                |  +         |   +
         *   |        |                                |  |         |   |
         *   |        +--------------------------------+  v         |   |
         *   |                                                      |   |
         *   |        <----------+   width   +--------->            |   |
         *   |                                                      |   |
         *   +------------------------------------------------------+   v
         *
         */

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_width(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_width(IntPtr frame);

        /// <summary>
        /// <c>mpp_frame_set_width(MppFrame frame, RK_U32 width);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_width(IntPtr frame, UInt32 width);

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_height(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_height(IntPtr frame);

        /// <summary>
        /// <c>mpp_frame_set_height(MppFrame frame, RK_U32 height);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_height(IntPtr frame, UInt32 height);

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_hor_stride(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_hor_stride(IntPtr frame);

        /// <summary>
        /// <c>mpp_frame_set_hor_stride(MppFrame frame, RK_U32 hor_stride);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_hor_stride(IntPtr frame, UInt32 hor_stride);

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_ver_stride(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_ver_stride(IntPtr frame);

        /// <summary>
        /// <c>mpp_frame_set_ver_stride(MppFrame frame, RK_U32 ver_stride);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_ver_stride(IntPtr frame, UInt32 ver_stride);

        /// <summary>
        /// <c>mpp_frame_set_hor_stride_pixel(MppFrame frame, RK_U32 hor_stride_pixel);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_hor_stride_pixel(IntPtr frame, UInt32 hor_stride_pixel);

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_hor_stride_pixel(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_hor_stride_pixel(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_fbc_hdr_stride(MppFrame frame, RK_U32 fbc_hdr_stride);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_fbc_hdr_stride(IntPtr frame, UInt32 fbc_hdr_stride);

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_fbc_hdr_stride(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_fbc_hdr_stride(IntPtr frame);


        /// <summary>
        /// <c>RK_U32 mpp_frame_get_offset_x(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_offset_x(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_offset_x(MppFrame frame, RK_U32 offset_x);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_offset_x(IntPtr frame, UInt32 offset_x);

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_offset_y(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_offset_y(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_offset_y(MppFrame frame, RK_U32 offset_y);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_offset_y(IntPtr frame, UInt32 offset_y);

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_mode(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_mode(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_mode(MppFrame frame, RK_U32 mode);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_mode(IntPtr frame, UInt32 mode);

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_discard(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_discard(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_discard(MppFrame frame, RK_U32 discard);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_discard(IntPtr frame, UInt32 discard);

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_viewid(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_viewid(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_viewid(MppFrame frame, RK_U32 viewid);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_viewid(IntPtr frame, UInt32 viewid);

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_poc(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_poc(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_poc(MppFrame frame, RK_U32 poc);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_poc(IntPtr frame, UInt32 poc);

        /// <summary>
        /// <c>RK_S64 mpp_frame_get_pts(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern Int64 mpp_frame_get_pts(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_pts(MppFrame frame, RK_S64 pts);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_pts(IntPtr frame, Int64 pts);

        /// <summary>
        /// <c>RK_S64 mpp_frame_get_dts(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern Int64 mpp_frame_get_dts(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_dts(MppFrame frame, RK_S64 dts);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_dts(IntPtr frame, Int64 dts);

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_errinfo(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_errinfo(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_errinfo(MppFrame frame, RK_U32 errinfo);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_errinfo(IntPtr frame, UInt32 errinfo);

        /// <summary>
        /// <c>size_t mpp_frame_get_buf_size(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt64 mpp_frame_get_buf_size(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_buf_size(MppFrame frame, size_t buf_size);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_buf_size(IntPtr frame, UInt64 buf_size);

        /// <summary>
        /// <c>void mpp_frame_set_thumbnail_en(MppFrame frame, RK_U32 thumbnail_en);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_thumbnail_en(IntPtr frame, UInt32 thumbnail_en);

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_thumbnail_en(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_thumbnail_en(IntPtr frame);

        /*
         * flow control parmeter
         */

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_eos(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_eos(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_eos(MppFrame frame, RK_U32 eos);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_eos(IntPtr frame, UInt32 eos);

        /// <summary>
        /// <c>RK_U32 mpp_frame_get_info_change(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_frame_get_info_change(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_info_change(MppFrame frame, RK_U32 info_change);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_info_change(IntPtr frame, UInt32 info_change);

        /*
         * buffer parameter
         */

        /// <summary>
        /// <c>MppBuffer mpp_frame_get_buffer(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern IntPtr mpp_frame_get_buffer(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_buffer(MppFrame frame, MppBuffer buffer);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_buffer(IntPtr frame, IntPtr buffer);

        /*
         * meta data parameter
         */

        /// <summary>
        /// <c>RK_S32 mpp_frame_has_meta(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern Int32 mpp_frame_has_meta(IntPtr frame);

        /// <summary>
        /// <c>MppMeta mpp_frame_get_meta(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern IntPtr mpp_frame_get_meta(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_meta(MppFrame frame, MppMeta meta);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_meta(IntPtr frame, IntPtr meta);

        /*
         * color related parameter
         */

        /// <summary>
        /// <c>MppFrameColorRange mpp_frame_get_color_range(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MppFrameColorRange mpp_frame_get_color_range(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_color_range(MppFrame frame, MppFrameColorRange color_range);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_color_range(IntPtr frame, MppFrameColorRange color_range);

        /// <summary>
        /// <c>MppFrameColorPrimaries mpp_frame_get_color_primaries(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MppFrameColorPrimaries mpp_frame_get_color_primaries(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_color_primaries(MppFrame frame, MppFrameColorPrimaries color_primaries);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_color_primaries(IntPtr frame, MppFrameColorPrimaries color_primaries);

        /// <summary>
        /// <c>MppFrameColorTransferCharacteristic mpp_frame_get_color_trc(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MppFrameColorTransferCharacteristic mpp_frame_get_color_trc(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_color_trc(MppFrame frame, MppFrameColorTransferCharacteristic color_trc);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_color_trc(IntPtr frame, MppFrameColorTransferCharacteristic color_trc);

        /// <summary>
        /// <c>MppFrameColorSpace mpp_frame_get_colorspace(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MppFrameColorSpace mpp_frame_get_colorspace(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_colorspace(MppFrame frame, MppFrameColorSpace colorspace);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_colorspace(IntPtr frame, MppFrameColorSpace colorspace);

        /// <summary>
        /// <c>MppFrameChromaLocation mpp_frame_get_chroma_location(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MppFrameChromaLocation mpp_frame_get_chroma_location(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_chroma_location(MppFrame frame, MppFrameChromaLocation chroma_location);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_chroma_location(IntPtr frame, MppFrameChromaLocation chroma_location);

        /// <summary>
        /// <c>MppFrameFormat mpp_frame_get_fmt(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MppFrameFormat mpp_frame_get_fmt(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_fmt(MppFrame frame, MppFrameFormat fmt);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_fmt(IntPtr frame, MppFrameFormat fmt);

        /// <summary>
        /// <c>MppFrameRational mpp_frame_get_sar(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MppFrameRational mpp_frame_get_sar(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_sar(MppFrame frame, MppFrameRational sar);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_sar(IntPtr frame, MppFrameRational sar);

        /// <summary>
        /// <c>MppFrameMasteringDisplayMetadata mpp_frame_get_mastering_display(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MppFrameMasteringDisplayMetadata mpp_frame_get_mastering_display(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_mastering_display(MppFrame frame, MppFrameMasteringDisplayMetadata mastering_display);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_mastering_display(IntPtr frame, MppFrameMasteringDisplayMetadata mastering_display);

        /// <summary>
        /// <c>MppFrameContentLightMetadata mpp_frame_get_content_light(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MppFrameContentLightMetadata mpp_frame_get_content_light(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_content_light(MppFrame frame, MppFrameContentLightMetadata content_light);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_content_light(IntPtr frame, MppFrameContentLightMetadata content_light);

        /// <summary>
        /// <c>MppFrameHdrDynamicMeta* mpp_frame_get_hdr_dynamic_meta(MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern IntPtr mpp_frame_get_hdr_dynamic_meta(IntPtr frame);

        /// <summary>
        /// <c>void mpp_frame_set_hdr_dynamic_meta(MppFrame frame, MppFrameHdrDynamicMeta* vivi_data);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_frame_set_hdr_dynamic_meta(IntPtr frame, IntPtr vivi_data);
        #endregion

        public void Dispose()
        {
            if (!IsCopy)
            {
                if (Handle != IntPtr.Zero)
                {
                    mpp_frame_deinit(ref Handle);
                }
            }
            Handle = IntPtr.Zero;
        }
    }


    /**
     * Rational number (pair of numerator and denominator).
     */
    public struct MppFrameRational
    {
        public Int32 num; ///< Numerator
        public Int32 den; ///< Denominator
    }

    public struct MppFrameMasteringDisplayMetadata
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
#warning Do proper 2D array
        public UInt32[,] display_primaries;// [3][2];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public UInt16[] white_point;
        public UInt32 max_luminance;
        public UInt32 min_luminance;
    }

    public struct MppFrameContentLightMetadata
    {
        public UInt16 MaxCLL;
        public UInt16 MaxFALL;
    }

    public struct MppFrameHdrDynamicMeta
    {
        public UInt32 hdr_fmt;
        public UInt32 size;
        public IntPtr data;
    }
}
