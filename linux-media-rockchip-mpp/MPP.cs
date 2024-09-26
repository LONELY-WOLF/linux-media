using System.Runtime.InteropServices;

namespace LinuxMedia.Rockchip
{
    public class MPP
    {
        internal IntPtr Context;
        internal MppApi Api;

        public MPP()
        {
            Api = new MppApi();
            Create();
        }

        ~MPP()
        {
            Destroy();
        }

        /// <summary>
        /// both send video stream packet to decoder and get video frame from decoder at the same time
        /// </summary>
        /// <param name="packet">packet The input video stream, its usage can refer mpp_packet.h.</param>
        /// <param name="frame">frame The output picture, its usage can refer mpp_frame.h.</param>
        /// <returns>0 and positive for success, negative for failure. The return value is an error code.For details, please refer mpp_err.h.</returns>
        public MPP_RET Decode(MppPacket packet, MppFrame frame)
        {
            return (MPP_RET)Api.decode(Context, packet.Handle, ref frame.Handle);
        }

        /// <summary>
        /// both send video frame to encoder and get encoded video stream from encoder at the same time
        /// </summary>
        /// <param name="frame">frame The input video data, its usage can refer mpp_frame.h.</param>
        /// <param name="packet">packet The output compressed data, its usage can refer mpp_packet.h.</param>
        /// <returns>0 and positive for success, negative for failure. The return value is an error code.For details, please refer mpp_err.h.</returns>
        public MPP_RET Encode(MppFrame frame, MppPacket packet)
        {
            return (MPP_RET)Api.encode(Context, frame.Handle, ref packet.Handle);
        }

        /// <summary>
        /// send video frame to encoder only, async interface
        /// </summary>
        /// <param name="frame">frame The input video data, its usage can refer mpp_frame.h.</param>
        /// <returns>0 and positive for success, negative for failure. The return value is an error code.For details, please refer mpp_err.h.</returns>
        public MPP_RET EncodePutFrame(MppFrame frame)
        {
            return (MPP_RET)Api.encode_put_frame(Context, frame.Handle);
        }

        /// <summary>
        /// get encoded video packet from encoder only, async interface
        /// </summary>
        /// <param name="packet">packet The output compressed data, its usage can refer mpp_packet.h.</param>
        /// <returns>0 and positive for success, negative for failure. The return value is an error code.For details, please refer mpp_err.h.</returns>
        public MPP_RET EncodeGetPacket(MppPacket packet)
        {
            return (MPP_RET)Api.encode_get_packet(Context, ref packet.Handle);
        }

        public MPP_RET Control(MpiCmd cmd, MppHandle param)
        {
            return (MPP_RET)Api.control(Context, (int)cmd, param.Handle);
        }

        public MPP_RET Control(MpiCmd cmd, IntPtr param)
        {
            return (MPP_RET)Api.control(Context, (int)cmd, param);
        }

        /// <summary>
        /// Create empty context structure and mpi function pointers. <br/>
        /// Use functions in MppApi to access mpp services.
        /// </summary>
        /// <returns>
        /// 0 for success, others for failure. The return value is an <br/>
        /// error code.For details, please refer mpp_err.h.
        /// </returns>
        /// <remarks>
        /// This interface creates base flow context, all function calls <br/>
        /// are based on it.
        /// </remarks>
        internal MPP_RET Create()
        {
            IntPtr mpi_api = IntPtr.Zero;
            MPP_RET ret = mpp_create(ref Context, ref mpi_api);
            Api = Marshal.PtrToStructure<MppApi>(mpi_api);
            return ret;
        }

        /// <summary>
        /// Call after mpp_create to setup mpp type and video format. <br/>
        /// This function will call internal context init function.
        /// </summary>
        /// <param name="type">specify decoder or encoder, refer to MppCtxType.</param>
        /// <param name="coding">specify video compression coding, refer to MppCodingType.</param>
        /// <returns>
        /// 0 for success, others for failure. The return value is an <br/>
        /// error code. For details, please refer mpp_err.h.
        /// </returns>
        public MPP_RET Init(MppCtxType type, MppCodingType coding)
        {
            return mpp_init(Context, type, coding);
        }

        /// <summary>
        /// Destroy mpp context and free both context and mpi structure, <br/>
        /// it matches with mpp_init().
        /// </summary>
        /// <returns>
        /// 0 for success, others for failure. The return value is an <br/>
        /// error code. For details, please refer mpp_err.h.
        /// </returns>
        internal MPP_RET Destroy()
        {
            return mpp_destroy(Context);
        }

        public static MPP_RET CheckSupportFormat(MppCtxType type, MppCodingType coding)
        {
            return mpp_check_support_format(type, coding);
        }

        /// <summary>
        /// <c>MPP_RET mpp_create(MppCtx* ctx, MppApi** mpi);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_create(ref IntPtr ctx, ref IntPtr mpi);

        /// <summary>
        /// <c>MPP_RET mpp_init(MppCtx ctx, MppCtxType type, MppCodingType coding);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_init(IntPtr ctx, MppCtxType type, MppCodingType coding);

        /// <summary>
        /// <c>MPP_RET mpp_destroy(MppCtx ctx);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_destroy(IntPtr ctx);
        /**
         * @ingroup rk_mpi
         * @brief judge given format is supported or not by MPP.
         * @param[in] type specify decoder or encoder, refer to MppCtxType.
         * @param[in] coding specify video compression coding, refer to MppCodingType.
         * @return 0 for support, -1 for unsupported.
         */
        /// <summary>
        /// <c>mpp_check_support_format(MppCtxType type, MppCodingType coding);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_check_support_format(MppCtxType type, MppCodingType coding);
        /**
         * @ingroup rk_mpi
         * @brief List all formats supported by MPP
         * @param NULL no need to input parameter
         * @return No return value. This function just prints format information supported
         *         by MPP on standard output.
         */
        /// <summary>
        /// <c>void mpp_show_support_format(void);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_show_support_format();
        /// <summary>
        /// <c>void mpp_show_color_format(void);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_show_color_format();
    }
}