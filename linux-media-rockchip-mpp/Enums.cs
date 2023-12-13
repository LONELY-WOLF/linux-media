using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxMedia.Rockchip
{
    public enum MPP_RET
    {
        MPP_SUCCESS = 0,
        MPP_OK = 0,

        MPP_NOK = -1,
        MPP_ERR_UNKNOW = -2,
        MPP_ERR_NULL_PTR = -3,
        MPP_ERR_MALLOC = -4,
        MPP_ERR_OPEN_FILE = -5,
        MPP_ERR_VALUE = -6,
        MPP_ERR_READ_BIT = -7,
        MPP_ERR_TIMEOUT = -8,
        MPP_ERR_PERM = -9,

        MPP_ERR_BASE = -1000,

        /* The error in stream processing */
        MPP_ERR_LIST_STREAM = MPP_ERR_BASE - 1,
        MPP_ERR_INIT = MPP_ERR_BASE - 2,
        MPP_ERR_VPU_CODEC_INIT = MPP_ERR_BASE - 3,
        MPP_ERR_STREAM = MPP_ERR_BASE - 4,
        MPP_ERR_FATAL_THREAD = MPP_ERR_BASE - 5,
        MPP_ERR_NOMEM = MPP_ERR_BASE - 6,
        MPP_ERR_PROTOL = MPP_ERR_BASE - 7,
        MPP_FAIL_SPLIT_FRAME = MPP_ERR_BASE - 8,
        MPP_ERR_VPUHW = MPP_ERR_BASE - 9,
        MPP_EOS_STREAM_REACHED = MPP_ERR_BASE - 11,
        MPP_ERR_BUFFER_FULL = MPP_ERR_BASE - 12,
        MPP_ERR_DISPLAY_FULL = MPP_ERR_BASE - 13,
    }

    /**
    * @ingroup rk_mpi
    * @brief The type of mpp context
    * @details This type is used when calling mpp_init(), which including decoder,
    *          encoder and Image Signal Process(ISP). So far decoder and encoder
    *          are supported perfectly, and ISP will be supported in the future.
    */
    public enum MppCtxType
    {
        MPP_CTX_DEC,  /**< decoder */
        MPP_CTX_ENC,  /**< encoder */
        MPP_CTX_ISP,  /**< isp */
        MPP_CTX_BUTT, /**< undefined */
    }

    /**
    * @ingroup rk_mpi
    * @brief Enumeration used to define the possible video compression codings.
    *        sync with the omx_video.h
    *
    * @note  This essentially refers to file extensions. If the coding is
    *        being used to specify the ENCODE type, then additional work
    *        must be done to configure the exact flavor of the compression
    *        to be used.  For decode cases where the user application can
    *        not differentiate between MPEG-4 and H.264 bit streams, it is
    *        up to the codec to handle this.
    */
    public enum MppCodingType
    {
        MPP_VIDEO_CodingUnused,             /**< Value when coding is N/A */
        MPP_VIDEO_CodingAutoDetect,         /**< Autodetection of coding type */
        MPP_VIDEO_CodingMPEG2,              /**< AKA: H.262 */
        MPP_VIDEO_CodingH263,               /**< H.263 */
        MPP_VIDEO_CodingMPEG4,              /**< MPEG-4 */
        MPP_VIDEO_CodingWMV,                /**< Windows Media Video (WMV1,WMV2,WMV3)*/
        MPP_VIDEO_CodingRV,                 /**< all versions of Real Video */
        MPP_VIDEO_CodingAVC,                /**< H.264/AVC */
        MPP_VIDEO_CodingMJPEG,              /**< Motion JPEG */
        MPP_VIDEO_CodingVP8,                /**< VP8 */
        MPP_VIDEO_CodingVP9,                /**< VP9 */
        MPP_VIDEO_CodingVC1 = 0x01000000,   /**< Windows Media Video (WMV1,WMV2,WMV3)*/
        MPP_VIDEO_CodingFLV1,               /**< Sorenson H.263 */
        MPP_VIDEO_CodingDIVX3,              /**< DIVX3 */
        MPP_VIDEO_CodingVP6,
        MPP_VIDEO_CodingHEVC,               /**< H.265/HEVC */
        MPP_VIDEO_CodingAVSPLUS,            /**< AVS+ */
        MPP_VIDEO_CodingAVS,                /**< AVS profile=0x20 */
        MPP_VIDEO_CodingAVS2,               /**< AVS2 */
        MPP_VIDEO_CodingAV1,                /**< av1 */
        MPP_VIDEO_CodingKhronosExtensions = 0x6F000000, /**< Reserved region for introducing Khronos Standard Extensions */
        MPP_VIDEO_CodingVendorStartUnused = 0x7F000000, /**< Reserved region for introducing Vendor Extensions */
        MPP_VIDEO_CodingMax = 0x7FFFFFFF
    }

    /// <summary>
    /// One mpp task queue has two ports: input and output
    /// </summary>
    /// <remarks>
    /// The whole picture is: <br/>
    /// Top layer mpp has two ports: mpp_input_port and mpp_output_port <br/>
    /// But internally these two ports belongs to two task queue. <br/>
    /// The mpp_input_port is the mpp_input_task_queue's input port. <br/>
    /// The mpp_output_port is the mpp_output_task_queue's output port. <br/><br/>
    /// Each port uses its task queue to communication
    /// </remarks>
    public enum MppPortType
    {
        MPP_PORT_INPUT,
        MPP_PORT_OUTPUT,
        MPP_PORT_BUTT,
    }

    public enum MppTaskWorkMode
    {
        MPP_TASK_ASYNC,
        MPP_TASK_SYNC,
        MPP_TASK_WORK_MODE_BUTT,
    }

    public enum MppPollType
    {
        MPP_POLL_BUTT = -2,
        MPP_POLL_BLOCK = -1,
        MPP_POLL_NON_BLOCK = 0,
        MPP_POLL_MAX = 8000,
    }

    public enum MppEncHeaderMode
    {
        /// <summary>
        /// default mode: attach vps/sps/pps only on first frame
        /// </summary>
        MPP_ENC_HEADER_MODE_DEFAULT,
        /// <summary>
        /// IDR mode: attach vps/sps/pps on each IDR frame
        /// </summary>
        MPP_ENC_HEADER_MODE_EACH_IDR,
        MPP_ENC_HEADER_MODE_BUTT,
    }

    public enum MppEncSeiMode
    {
        /// <summary>
        /// default mode, SEI writing is disabled
        /// </summary>
        MPP_ENC_SEI_MODE_DISABLE,
        /// <summary>
        /// one sequence has only one SEI
        /// </summary>
        MPP_ENC_SEI_MODE_ONE_SEQ,
        /// <summary>
        /// one frame may have one SEI, if SEI info has changed
        /// </summary>
        MPP_ENC_SEI_MODE_ONE_FRAME
    }

    #region MppFrame
    /// <summary>
    /// MPEG vs JPEG YUV range.
    /// </summary>
    public enum MppFrameColorRange
    {
        MPP_FRAME_RANGE_UNSPECIFIED = 0,
        MPP_FRAME_RANGE_MPEG = 1,    ///< the normal 219*2^(n-8) "MPEG" YUV ranges
        MPP_FRAME_RANGE_JPEG = 2,    ///< the normal     2^n-1   "JPEG" YUV ranges
        MPP_FRAME_RANGE_NB,                 ///< Not part of ABI
    }

    public enum MppFrameVideoFormat
    {
        MPP_FRAME_VIDEO_FMT_COMPONEMT = 0,
        MPP_FRAME_VIDEO_FMT_PAL = 1,
        MPP_FRAME_VIDEO_FMT_NTSC = 2,
        MPP_FRAME_VIDEO_FMT_SECAM = 3,
        MPP_FRAME_VIDEO_FMT_MAC = 4,
        MPP_FRAME_VIDEO_FMT_UNSPECIFIED = 5,
        MPP_FRAME_VIDEO_FMT_RESERVED0 = 6,
        MPP_FRAME_VIDEO_FMT_RESERVED1 = 7,
    }

    /// <summary>
    /// Chromaticity coordinates of the source primaries.
    /// </summary>
    public enum MppFrameColorPrimaries
    {
        MPP_FRAME_PRI_RESERVED0 = 0,
        MPP_FRAME_PRI_BT709 = 1,    ///< also ITU-R BT1361 / IEC 61966-2-4 / SMPTE RP177 Annex B
        MPP_FRAME_PRI_UNSPECIFIED = 2,
        MPP_FRAME_PRI_RESERVED = 3,
        MPP_FRAME_PRI_BT470M = 4,    ///< also FCC Title 47 Code of Federal Regulations 73.682 (a)(20)

        MPP_FRAME_PRI_BT470BG = 5,    ///< also ITU-R BT601-6 625 / ITU-R BT1358 625 / ITU-R BT1700 625 PAL & SECAM
        MPP_FRAME_PRI_SMPTE170M = 6,    ///< also ITU-R BT601-6 525 / ITU-R BT1358 525 / ITU-R BT1700 NTSC/SMPTE ST 170 (2004)
        MPP_FRAME_PRI_SMPTE240M = 7,    ///< functionally identical to above/SMPTE ST 240
        MPP_FRAME_PRI_FILM = 8,    ///< colour filters using Illuminant C
        MPP_FRAME_PRI_BT2020 = 9,    ///< ITU-R BT2020 / ITU-R BT.2100-2
        MPP_FRAME_PRI_SMPTEST428_1 = 10,   ///< SMPTE ST 428-1 (CIE 1931 XYZ)
        MPP_FRAME_PRI_SMPTE431 = 11,   ///< SMPTE ST 431-2 (2011) / DCI P3
        MPP_FRAME_PRI_SMPTE432 = 12,   ///< SMPTE ST 432-1 (2010) / P3 D65 / Display P3
        MPP_FRAME_PRI_JEDEC_P22 = 22,   ///< JEDEC P22 phosphors
        MPP_FRAME_PRI_NB,                   ///< Not part of ABI
    }

    /// <summary>
    /// Color Transfer Characteristic.
    /// </summary>
    public enum MppFrameColorTransferCharacteristic
    {
        MPP_FRAME_TRC_RESERVED0 = 0,
        MPP_FRAME_TRC_BT709 = 1,     ///< also ITU-R BT1361
        MPP_FRAME_TRC_UNSPECIFIED = 2,
        MPP_FRAME_TRC_RESERVED = 3,
        MPP_FRAME_TRC_GAMMA22 = 4,     ///< also ITU-R BT470M / ITU-R BT1700 625 PAL & SECAM
        MPP_FRAME_TRC_GAMMA28 = 5,     ///< also ITU-R BT470BG
        MPP_FRAME_TRC_SMPTE170M = 6,     ///< also ITU-R BT601-6 525 or 625 / ITU-R BT1358 525 or 625 / ITU-R BT1700 NTSC
        MPP_FRAME_TRC_SMPTE240M = 7,
        MPP_FRAME_TRC_LINEAR = 8,     ///< "Linear transfer characteristics"
        MPP_FRAME_TRC_LOG = 9,     ///< "Logarithmic transfer characteristic (100:1 range)"
        MPP_FRAME_TRC_LOG_SQRT = 10,    ///< "Logarithmic transfer characteristic (100 * Sqrt(10) : 1 range)"
        MPP_FRAME_TRC_IEC61966_2_4 = 11,    ///< IEC 61966-2-4
        MPP_FRAME_TRC_BT1361_ECG = 12,    ///< ITU-R BT1361 Extended Colour Gamut
        MPP_FRAME_TRC_IEC61966_2_1 = 13,    ///< IEC 61966-2-1 (sRGB or sYCC)
        MPP_FRAME_TRC_BT2020_10 = 14,    ///< ITU-R BT2020 for 10 bit system
        MPP_FRAME_TRC_BT2020_12 = 15,    ///< ITU-R BT2020 for 12 bit system
        MPP_FRAME_TRC_SMPTEST2084 = 16,    ///< SMPTE ST 2084 for 10-, 12-, 14- and 16-bit systems
        MPP_FRAME_TRC_SMPTEST428_1 = 17,    ///< SMPTE ST 428-1
        MPP_FRAME_TRC_ARIB_STD_B67 = 18,    ///< ARIB STD-B67, known as "Hybrid log-gamma"
        MPP_FRAME_TRC_NB,                   ///< Not part of ABI
    }

    /// <summary>
    /// YUV colorspace type.
    /// </summary>
    public enum MppFrameColorSpace
    {
        MPP_FRAME_SPC_RGB = 0,      ///< order of coefficients is actually GBR, also IEC 61966-2-1 (sRGB)
        MPP_FRAME_SPC_BT709 = 1,      ///< also ITU-R BT1361 / IEC 61966-2-4 xvYCC709 / SMPTE RP177 Annex B
        MPP_FRAME_SPC_UNSPECIFIED = 2,
        MPP_FRAME_SPC_RESERVED = 3,
        MPP_FRAME_SPC_FCC = 4,      ///< FCC Title 47 Code of Federal Regulations 73.682 (a)(20)
        MPP_FRAME_SPC_BT470BG = 5,      ///< also ITU-R BT601-6 625 / ITU-R BT1358 625 / ITU-R BT1700 625 PAL & SECAM / IEC 61966-2-4 xvYCC601
        MPP_FRAME_SPC_SMPTE170M = 6,      ///< also ITU-R BT601-6 525 / ITU-R BT1358 525 / ITU-R BT1700 NTSC / functionally identical to above
        MPP_FRAME_SPC_SMPTE240M = 7,
        MPP_FRAME_SPC_YCOCG = 8,      ///< Used by Dirac / VC-2 and H.264 FRext, see ITU-T SG16
        MPP_FRAME_SPC_BT2020_NCL = 9,      ///< ITU-R BT2020 non-constant luminance system
        MPP_FRAME_SPC_BT2020_CL = 10,     ///< ITU-R BT2020 constant luminance system
        MPP_FRAME_SPC_SMPTE2085 = 11,     ///< SMPTE 2085, Y'D'zD'x
        MPP_FRAME_SPC_CHROMA_DERIVED_NCL = 12,  ///< Chromaticity-derived non-constant luminance system
        MPP_FRAME_SPC_CHROMA_DERIVED_CL = 13,   ///< Chromaticity-derived constant luminance system
        MPP_FRAME_SPC_ICTCP = 14,     ///< ITU-R BT.2100-0, ICtCp
        MPP_FRAME_SPC_NB,                   ///< Not part of ABI
    }

    /*
     * Location of chroma samples.
     *
     * Illustration showing the location of the first (top left) chroma sample of the
     * image, the left shows only luma, the right
     * shows the location of the chroma sample, the 2 could be imagined to overlay
     * each other but are drawn separately due to limitations of ASCII
     *
     *                1st 2nd       1st 2nd horizontal luma sample positions
     *                 v   v         v   v
     *                 ______        ______
     *1st luma line > |X   X ...    |3 4 X ...     X are luma samples,
     *                |             |1 2           1-6 are possible chroma positions
     *2nd luma line > |X   X ...    |5 6 X ...     0 is undefined/unknown position
     */
    public enum MppFrameChromaLocation
    {
        MPP_CHROMA_LOC_UNSPECIFIED = 0,
        MPP_CHROMA_LOC_LEFT = 1,     ///< mpeg2/4 4:2:0, h264 default for 4:2:0
        MPP_CHROMA_LOC_CENTER = 2,     ///< mpeg1 4:2:0, jpeg 4:2:0, h263 4:2:0
        MPP_CHROMA_LOC_TOPLEFT = 3,     ///< ITU-R 601, SMPTE 274M 296M S314M(DV 4:1:1), mpeg2 4:2:2
        MPP_CHROMA_LOC_TOP = 4,
        MPP_CHROMA_LOC_BOTTOMLEFT = 5,
        MPP_CHROMA_LOC_BOTTOM = 6,
        MPP_CHROMA_LOC_NB,                  ///< Not part of ABI
    }

    //#define MPP_FRAME_FMT_MASK          (0x000fffff)

    //#define MPP_FRAME_FMT_COLOR_MASK    (0x000f0000)
    //#define MPP_FRAME_FMT_YUV           (0x00000000)
    //#define MPP_FRAME_FMT_RGB           (0x00010000)

    //#define MPP_FRAME_FBC_MASK          (0x00f00000)
    //#define MPP_FRAME_FBC_NONE          (0x00000000)

    //#define MPP_FRAME_HDR_MASK          (0x0c000000)
    //#define MPP_FRAME_HDR_NONE          (0x00000000)
    //#define MPP_FRAME_HDR               (0x04000000)

    /*
     * AFBC_V1 is for ISP output.
     * It has default payload offset to be calculated * from width and height:
     * Payload offset = MPP_ALIGN(MPP_ALIGN(width, 16) * MPP_ALIGN(height, 16) / 16, SZ_4K)
     */
    //#define MPP_FRAME_FBC_AFBC_V1       (0x00100000)
    /*
     * AFBC_V2 is for video decoder output.
     * It stores payload offset in first 32-bit in header address
     * Payload offset is always set to zero.
     */
    //#define MPP_FRAME_FBC_AFBC_V2       (0x00200000)

    //#define MPP_FRAME_FMT_LE_MASK       (0x01000000)

    //#define MPP_FRAME_FMT_IS_YUV(fmt)   (((fmt & MPP_FRAME_FMT_COLOR_MASK) == MPP_FRAME_FMT_YUV) && \
    //                                     ((fmt & MPP_FRAME_FMT_MASK) < MPP_FMT_YUV_BUTT))
    //#define MPP_FRAME_FMT_IS_YUV_10BIT(fmt) ((fmt & MPP_FRAME_FMT_MASK) == MPP_FMT_YUV420SP_10BIT || \
    //                                        (fmt & MPP_FRAME_FMT_MASK) == MPP_FMT_YUV422SP_10BIT)
    //#define MPP_FRAME_FMT_IS_RGB(fmt)   (((fmt & MPP_FRAME_FMT_COLOR_MASK) == MPP_FRAME_FMT_RGB) && \
    //((fmt & MPP_FRAME_FMT_MASK) < MPP_FMT_RGB_BUTT))

    /*
     * For MPP_FRAME_FBC_AFBC_V1 the 16byte aligned stride is used.
     */
    //#define MPP_FRAME_FMT_IS_FBC(fmt)   (fmt & MPP_FRAME_FBC_MASK)

    //#define MPP_FRAME_FMT_IS_HDR(fmt)   (fmt & MPP_FRAME_HDR_MASK)

    //#define MPP_FRAME_FMT_IS_LE(fmt)    ((fmt & MPP_FRAME_FMT_LE_MASK) == MPP_FRAME_FMT_LE_MASK)
    //#define MPP_FRAME_FMT_IS_BE(fmt)    ((fmt & MPP_FRAME_FMT_LE_MASK) == 0)

    /* mpp color format index definition */
    public enum MppFrameFormat
    {
        MPP_FMT_YUV420SP = (0x00000000 + 0),  /* YYYY... UV... (NV12)     */
        /*
         * A rockchip specific pixel format, without gap between pixel aganist
         * the P010_10LE/P010_10BE
         */
        MPP_FMT_YUV420SP_10BIT = (0x00000000 + 1),
        MPP_FMT_YUV422SP = (0x00000000 + 2),  /* YYYY... UVUV... (NV16)   */
        MPP_FMT_YUV422SP_10BIT = (0x00000000 + 3),  ///< Not part of ABI
        MPP_FMT_YUV420P = (0x00000000 + 4),  /* YYYY... U...V...  (I420) */
        MPP_FMT_YUV420SP_VU = (0x00000000 + 5),  /* YYYY... VUVUVU... (NV21) */
        MPP_FMT_YUV422P = (0x00000000 + 6),  /* YYYY... UU...VV...(422P) */
        MPP_FMT_YUV422SP_VU = (0x00000000 + 7),  /* YYYY... VUVUVU... (NV61) */
        MPP_FMT_YUV422_YUYV = (0x00000000 + 8),  /* YUYVYUYV... (YUY2)       */
        MPP_FMT_YUV422_YVYU = (0x00000000 + 9),  /* YVYUYVYU... (YVY2)       */
        MPP_FMT_YUV422_UYVY = (0x00000000 + 10), /* UYVYUYVY... (UYVY)       */
        MPP_FMT_YUV422_VYUY = (0x00000000 + 11), /* VYUYVYUY... (VYUY)       */
        MPP_FMT_YUV400 = (0x00000000 + 12), /* YYYY...                  */
        MPP_FMT_YUV440SP = (0x00000000 + 13), /* YYYY... UVUV...          */
        MPP_FMT_YUV411SP = (0x00000000 + 14), /* YYYY... UV...            */
        MPP_FMT_YUV444SP = (0x00000000 + 15), /* YYYY... UVUVUVUV...      */
        MPP_FMT_YUV444P = (0x00000000 + 16), /* YYYY... UUUU... VVVV...  */
        MPP_FMT_YUV_BUTT,

        MPP_FMT_RGB565 = (0x00010000 + 0),  /* 16-bit RGB               */
        MPP_FMT_BGR565 = (0x00010000 + 1),  /* 16-bit RGB               */
        MPP_FMT_RGB555 = (0x00010000 + 2),  /* 15-bit RGB               */
        MPP_FMT_BGR555 = (0x00010000 + 3),  /* 15-bit RGB               */
        MPP_FMT_RGB444 = (0x00010000 + 4),  /* 12-bit RGB               */
        MPP_FMT_BGR444 = (0x00010000 + 5),  /* 12-bit RGB               */
        MPP_FMT_RGB888 = (0x00010000 + 6),  /* 24-bit RGB               */
        MPP_FMT_BGR888 = (0x00010000 + 7),  /* 24-bit RGB               */
        MPP_FMT_RGB101010 = (0x00010000 + 8),  /* 30-bit RGB               */
        MPP_FMT_BGR101010 = (0x00010000 + 9),  /* 30-bit RGB               */
        MPP_FMT_ARGB8888 = (0x00010000 + 10), /* 32-bit RGB               */
        MPP_FMT_ABGR8888 = (0x00010000 + 11), /* 32-bit RGB               */
        MPP_FMT_BGRA8888 = (0x00010000 + 12), /* 32-bit RGB               */
        MPP_FMT_RGBA8888 = (0x00010000 + 13), /* 32-bit RGB               */
        MPP_FMT_RGB_BUTT,

        MPP_FMT_BUTT,
    }


    public enum MppFrameError
    {
        /// <summary>
        /// General error not specified
        /// </summary>
        MPP_FRAME_ERR_UNKNOW = 0x0001,

        /// <summary>
        /// Critical error for decoder not support error
        /// </summary>
        MPP_FRAME_ERR_UNSUPPORT = 0x0002,

        /// <summary>
        /// Fatal error for decoder can not parse a valid frame for hardware. <br/>
        /// the pixel data is all invalid.
        /// </summary>
        MPP_FRAME_ERR_DEC_INVALID = 0x0010,

        /// <summary>
        /// Normal error for decoder found hardware error on decoding.
        /// </summary>
        MPP_FRAME_ERR_DEC_HW_ERR = 0x0100,

        /// <summary>
        /// Normal error for decoder found missing reference frame on decoding.
        /// </summary>
        MPP_FRAME_ERR_DEC_MISS_REF = 0x0200,
    }
    #endregion

    #region MppBuffer
    /// <summary>
    /// normal mode is recommanded to work with normal flow, working with limit  mode is not. <br/>
    /// limit  mode is recommanded to work with commit flow, working with normal mode is not.
    /// </summary>
    public enum MppBufferMode
    {
        MPP_BUFFER_INTERNAL,
        MPP_BUFFER_EXTERNAL,
        MPP_BUFFER_MODE_BUTT,
    }

    public enum MppBufferType
    {
        /// <summary>
        /// normal malloc buffer for unit test or hardware simulation
        /// </summary>
        MPP_BUFFER_TYPE_NORMAL,
        /// <summary>
        /// use ion device under Android/Linux, MppBuffer will encapsulte ion file handle
        /// </summary>
        MPP_BUFFER_TYPE_ION,
        /// <summary>
        /// the DMABUF(DMA buffers) come from the application
        /// </summary>
        MPP_BUFFER_TYPE_EXT_DMA,
        /// <summary>
        /// use the drm device interface for memory management
        /// </summary>
        MPP_BUFFER_TYPE_DRM,
        MPP_BUFFER_TYPE_DMA_HEAP,
        MPP_BUFFER_TYPE_BUTT,
    }
    #endregion

    #region MppMeta
    public enum MppMetaDataType
    {
        /*
         * mpp meta data of data flow
         * reference counter will be used for these meta data type
         */
        TYPE_FRAME = ('m' << 24) | ('p' << 16) | ('k' << 8) | ('t'),
        TYPE_BUFFER = ('m' << 24) | ('b' << 16) | ('u' << 8) | ('f'),

        /* mpp meta data of normal data type */
        TYPE_S32 = ('s' << 24) | ('3' << 16) | ('2' << 8) | (' '),
        TYPE_S64 = ('s' << 24) | ('6' << 16) | ('4' << 8) | (' '),
        TYPE_PTR = ('p' << 24) | ('t' << 16) | ('r' << 8) | (' '),
    }

    public enum MppMetaKey
    {
        /* data flow key */
        KEY_INPUT_FRAME = ('i' << 24) | ('f' << 16) | ('r' << 8) | ('m'),
        KEY_INPUT_PACKET = ('i' << 24) | ('p' << 16) | ('k' << 8) | ('t'),
        KEY_OUTPUT_FRAME = ('o' << 24) | ('f' << 16) | ('r' << 8) | ('m'),
        KEY_OUTPUT_PACKET = ('o' << 24) | ('p' << 16) | ('k' << 8) | ('t'),
        /* output motion information for motion detection */
        KEY_MOTION_INFO = ('m' << 24) | ('v' << 16) | ('i' << 8) | ('f'),
        KEY_HDR_INFO = ('h' << 24) | ('d' << 16) | ('r' << 8) | (' '),
        KEY_HDR_META_OFFSET = ('h' << 24) | ('d' << 16) | ('r' << 8) | ('o'),
        KEY_HDR_META_SIZE = ('h' << 24) | ('d' << 16) | ('r' << 8) | ('l'),

        /* flow control key */
        KEY_INPUT_BLOCK = ('i' << 24) | ('b' << 16) | ('l' << 8) | ('k'),
        KEY_OUTPUT_BLOCK = ('o' << 24) | ('b' << 16) | ('l' << 8) | ('k'),
        KEY_INPUT_IDR_REQ = ('i' << 24) | ('i' << 16) | ('d' << 8) | ('r'),
        KEY_OUTPUT_INTRA = ('o' << 24) | ('i' << 16) | ('d' << 8) | ('r'),

        /* mpp_frame / mpp_packet meta data info key */
        KEY_TEMPORAL_ID = ('t' << 24) | ('l' << 16) | ('i' << 8) | ('d'),
        KEY_LONG_REF_IDX = ('l' << 24) | ('t' << 16) | ('i' << 8) | ('d'),
        KEY_ENC_AVERAGE_QP = ('a' << 24) | ('v' << 16) | ('g' << 8) | ('q'),
        KEY_ENC_START_QP = ('s' << 24) | ('t' << 16) | ('r' << 8) | ('q'),
        KEY_ROI_DATA = ('r' << 24) | ('o' << 16) | ('i' << 8) | (' '),
        KEY_OSD_DATA = ('o' << 24) | ('s' << 16) | ('d' << 8) | (' '),
        KEY_OSD_DATA2 = ('o' << 24) | ('s' << 16) | ('d' << 8) | ('2'),
        KEY_USER_DATA = ('u' << 24) | ('s' << 16) | ('r' << 8) | ('d'),
        KEY_USER_DATAS = ('u' << 24) | ('r' << 16) | ('d' << 8) | ('s'),

        /* num of inter different size predicted block */
        KEY_LVL64_INTER_NUM = ('l' << 24) | ('6' << 16) | ('4' << 8) | ('p'),
        KEY_LVL32_INTER_NUM = ('l' << 24) | ('3' << 16) | ('2' << 8) | ('p'),
        KEY_LVL16_INTER_NUM = ('l' << 24) | ('1' << 16) | ('6' << 8) | ('p'),
        KEY_LVL8_INTER_NUM = ('l' << 24) | ('8' << 16) | ('p' << 8) | (' '),
        /* num of intra different size predicted block */
        KEY_LVL32_INTRA_NUM = ('l' << 24) | ('3' << 16) | ('2' << 8) | ('i'),
        KEY_LVL16_INTRA_NUM = ('l' << 24) | ('1' << 16) | ('6' << 8) | ('i'),
        KEY_LVL8_INTRA_NUM = ('l' << 24) | ('8' << 16) | ('i' << 8) | (' '),
        KEY_LVL4_INTRA_NUM = ('l' << 24) | ('4' << 16) | ('i' << 8) | (' '),
        /* output P skip frame indicator */
        KEY_OUTPUT_PSKIP = ('o' << 24) | ('p' << 16) | ('s' << 8) | ('p'),
        KEY_ENC_SSE = ('e' << 24) | ('s' << 16) | ('s' << 8) | ('e'),

        /*
         * For vepu580 roi buffer config mode
         * The encoder roi structure is so complex that we should provide a buffer
         * tunnel for externl user to config encoder hardware by direct sending
         * roi data buffer.
         * This way can reduce the config parsing and roi buffer data generating
         * overhead in mpp.
         */
        KEY_ROI_DATA2 = ('r' << 24) | ('o' << 16) | ('i' << 8) | ('2'),

        /*
         * qpmap for rv1109/1126 encoder qpmap config
         * Input data is a MppBuffer which contains an array of 16bit Vepu541RoiCfg.
         * And each 16bit represents a 16x16 block qp info.
         *
         * H.264 - 16x16 block qp is arranged in raster order:
         * each value is a 16bit data
         * 00 01 02 03 04 05 06 07 -> 00 01 02 03 04 05 06 07
         * 10 11 12 13 14 15 16 17    10 11 12 13 14 15 16 17
         * 20 21 22 23 24 25 26 27    20 21 22 23 24 25 26 27
         * 30 31 32 33 34 35 36 37    30 31 32 33 34 35 36 37
         *
         * H.265 - 16x16 block qp is reorder to 64x64/32x32 ctu order then 64x64 / 32x32 ctu raster order
         * 64x64 ctu
         * 00 01 02 03 04 05 06 07 -> 00 01 02 03 10 11 12 13 20 21 22 23 30 31 32 33 04 05 06 07 14 15 16 17 24 25 26 27 34 35 36 37
         * 10 11 12 13 14 15 16 17
         * 20 21 22 23 24 25 26 27
         * 30 31 32 33 34 35 36 37
         * 32x32 ctu
         * 00 01 02 03 04 05 06 07 -> 00 01 10 11 02 03 12 13 04 05 14 15 06 07 16 17
         * 10 11 12 13 14 15 16 17    20 21 30 31 22 23 32 33 24 25 34 35 26 27 36 37
         * 20 21 22 23 24 25 26 27
         * 30 31 32 33 34 35 36 37
         */
        KEY_QPMAP0 = ('e' << 24) | ('q' << 16) | ('m' << 8) | ('0'),

        /* input motion list for smart p rate control */
        KEY_MV_LIST = ('m' << 24) | ('v' << 16) | ('l' << 8) | ('t'),

        /* frame long-term reference frame operation */
        KEY_ENC_MARK_LTR = ('m' << 24) | ('l' << 16) | ('t' << 8) | ('r'),
        KEY_ENC_USE_LTR = ('u' << 24) | ('l' << 16) | ('t' << 8) | ('r'),

        /* MLVEC specified encoder feature  */
        KEY_ENC_FRAME_QP = ('f' << 24) | ('r' << 16) | ('m' << 8) | ('q'),
        KEY_ENC_BASE_LAYER_PID = ('b' << 24) | ('p' << 16) | ('i' << 8) | ('d'),

        /* Thumbnail info for decoder output frame */
        KEY_DEC_TBN_EN = ('t' << 24) | ('b' << 16) | ('e' << 8) | ('n'),
        KEY_DEC_TBN_Y_OFFSET = ('t' << 24) | ('b' << 16) | ('y' << 8) | ('o'),
        KEY_DEC_TBN_UV_OFFSET = ('t' << 24) | ('b' << 16) | ('c' << 8) | ('o'),
    }
    #endregion

    public enum MpiCmd
    {
        MPP_OSAL_CMD_BASE = 0x00100000,
        MPP_OSAL_CMD_END,

        MPP_CMD_BASE = 0x00200000,
        MPP_ENABLE_DEINTERLACE,
        [Obsolete]
        MPP_SET_INPUT_BLOCK,
        [Obsolete]
        MPP_SET_INTPUT_BLOCK_TIMEOUT,
        [Obsolete]
        MPP_SET_OUTPUT_BLOCK,
        [Obsolete]
        MPP_SET_OUTPUT_BLOCK_TIMEOUT,
        /*
         * timeout setup, refer to  MPP_TIMEOUT_XXX
         * zero     - non block
         * negative - block with no timeout
         * positive - timeout in milisecond
         */
        /// <summary>
        /// parameter type RK_S64
        /// </summary>
        MPP_SET_INPUT_TIMEOUT,
        /// <summary>
        /// parameter type RK_S64
        /// </summary>
        MPP_SET_OUTPUT_TIMEOUT,
        /// <summary>
        /// MPP no thread mode and use external thread to decode
        /// </summary>
        MPP_SET_DISABLE_THREAD,

        MPP_STATE_CMD_BASE = 0x00200000 | 0x00000100,
        MPP_START,
        MPP_STOP,
        MPP_PAUSE,
        MPP_RESUME,

        MPP_CMD_END,

        MPP_CODEC_CMD_BASE = 0x00300000,
        MPP_CODEC_GET_FRAME_INFO,
        MPP_CODEC_CMD_END,

        MPP_DEC_CMD_BASE = 0x00300000 | 0x00010000,
        /// <summary>
        /// vpu api legacy control for buffer slot dimension init
        /// </summary>
        MPP_DEC_SET_FRAME_INFO,
        /// <summary>
        /// IMPORTANT: set external buffer group to mpp decoder
        /// </summary>
        MPP_DEC_SET_EXT_BUF_GROUP,
        MPP_DEC_SET_INFO_CHANGE_READY,
        /// <summary>
        /// use input time order for output
        /// </summary>
        MPP_DEC_SET_PRESENT_TIME_ORDER,
        /// <summary>
        /// Need to setup before init
        /// </summary>
        MPP_DEC_SET_PARSER_SPLIT_MODE,
        /// <summary>
        /// Need to setup before init
        /// </summary>
        MPP_DEC_SET_PARSER_FAST_MODE,
        MPP_DEC_GET_STREAM_COUNT,
        MPP_DEC_GET_VPUMEM_USED_COUNT,
        MPP_DEC_SET_VC1_EXTRA_DATA,
        MPP_DEC_SET_OUTPUT_FORMAT,
        /// <summary>
        /// When set it will disable sw/hw error (H.264 / H.265)
        /// </summary>
        MPP_DEC_SET_DISABLE_ERROR,
        MPP_DEC_SET_IMMEDIATE_OUT,
        /// <summary>
        /// MPP enable deinterlace by default. Vpuapi can disable it
        /// </summary>
        MPP_DEC_SET_ENABLE_DEINTERLACE,
        /// <summary>
        /// enable idr output immediately
        /// </summary>
        MPP_DEC_SET_ENABLE_FAST_PLAY,
        /// <summary>
        /// MPP no thread mode and use external thread to decode
        /// </summary>
        MPP_DEC_SET_DISABLE_THREAD,
        MPP_DEC_SET_MAX_USE_BUFFER_SIZE,
        /// <summary>
        /// enable MVC decoding
        /// </summary>
        MPP_DEC_SET_ENABLE_MVC,

        MPP_DEC_CMD_QUERY = 0x00300000 | 0x00010000 | 0x00000100,
        /* query decoder runtime information for decode stage */
        /// <summary>
        /// set and get MppDecQueryCfg structure
        /// </summary>
        MPP_DEC_QUERY,

        CMD_DEC_CMD_CFG = 0x00300000 | 0x00010000 | 0x00000200,
        /// <summary>
        /// set MppDecCfg structure
        /// </summary>
        MPP_DEC_SET_CFG,
        /// <summary>
        /// get MppDecCfg structure
        /// </summary>
        MPP_DEC_GET_CFG,

        MPP_DEC_CMD_END,

        MPP_ENC_CMD_BASE = 0x00300000 | 0x00020000,
        /* basic encoder setup control */
        /// <summary>
        /// set MppEncCfg structure
        /// </summary>
        MPP_ENC_SET_CFG,
        /// <summary>
        /// get MppEncCfg structure
        /// </summary>
        MPP_ENC_GET_CFG,
        /// <summary>
        /// set MppEncPrepCfg structure, use MPP_ENC_SET_CFG instead
        /// </summary>
        [Obsolete("use MPP_ENC_SET_CFG instead")]
        MPP_ENC_SET_PREP_CFG,
        /// <summary>
        /// get MppEncPrepCfg structure, use MPP_ENC_GET_CFG instead
        /// </summary>
        [Obsolete("use MPP_ENC_GET_CFG instead")]
        MPP_ENC_GET_PREP_CFG,
        /// <summary>
        /// set MppEncRcCfg structure, use MPP_ENC_SET_CFG instead
        /// </summary>
        [Obsolete("use MPP_ENC_SET_CFG instead")]
        MPP_ENC_SET_RC_CFG,
        /// <summary>
        /// get MppEncRcCfg structure, use MPP_ENC_GET_CFG instead
        /// </summary>
        [Obsolete("use MPP_ENC_GET_CFG instead")]
        MPP_ENC_GET_RC_CFG,
        /// <summary>
        /// set MppEncCodecCfg structure, use MPP_ENC_SET_CFG instead
        /// </summary>
        [Obsolete("use MPP_ENC_SET_CFG instead")]
        MPP_ENC_SET_CODEC_CFG,
        /// <summary>
        /// get MppEncCodecCfg structure, use MPP_ENC_GET_CFG instead
        /// </summary>
        [Obsolete("use MPP_ENC_GET_CFG instead")]
        MPP_ENC_GET_CODEC_CFG,
        /* runtime encoder setup control */
        /// <summary>
        /// next frame will be encoded as intra frame
        /// </summary>
        MPP_ENC_SET_IDR_FRAME,
        [Obsolete]
        MPP_ENC_SET_OSD_LEGACY_0,
        [Obsolete]
        MPP_ENC_SET_OSD_LEGACY_1,
        [Obsolete]
        MPP_ENC_SET_OSD_LEGACY_2,
        /// <summary>
        /// get vps / sps / pps which has better sync behavior parameter is MppPacket
        /// </summary>
        MPP_ENC_GET_HDR_SYNC,
        [Obsolete]
        MPP_ENC_GET_EXTRA_INFO,
        /// <summary>
        /// SEI: Supplement Enhancemant Information, parameter is MppSeiMode
        /// </summary>
        MPP_ENC_SET_SEI_CFG,
        /// <summary>
        /// SEI: Supplement Enhancemant Information, parameter is MppPacket
        /// </summary>
        MPP_ENC_GET_SEI_DATA,
        [Obsolete]
        MPP_ENC_PRE_ALLOC_BUFF,
        /// <summary>
        /// used for adjusting qp range, the parameter can be 1 or 2
        /// </summary>
        MPP_ENC_SET_QP_RANGE,
        /// <summary>
        /// set MppEncROICfg structure
        /// </summary>
        MPP_ENC_SET_ROI_CFG,
        /// <summary>
        /// for H265 Encoder,set CTU's size and QP
        /// </summary>
        MPP_ENC_SET_CTU_QP,

        MPP_ENC_CMD_QUERY = 0x00300000 | 0x00020000 | 0x00000100,
        /* query encoder runtime information for encode stage */
        /// <summary>
        /// set and get MppEncQueryCfg structure
        /// </summary>
        MPP_ENC_QUERY,

        /// <summary>
        /// User define rate control stategy API control
        /// </summary>
        MPP_ENC_CFG_RC_API = 0x00300000 | 0x00020000 | 0x00000200,
        /*
         * Get RcApiQueryAll structure
         * Get all available rate control stategy string and count
         */
        MPP_ENC_GET_RC_API_ALL = MPP_ENC_CFG_RC_API + 1,
        /*
         * Get RcApiQueryType structure
         * Get available rate control stategy string with certain type
         */
        MPP_ENC_GET_RC_API_BY_TYPE = MPP_ENC_CFG_RC_API + 2,
        /*
         * Set RcImplApi structure
         * Add new or update rate control stategy function pointers
         */
        MPP_ENC_SET_RC_API_CFG = MPP_ENC_CFG_RC_API + 3,
        /*
         * Get RcApiBrief structure
         * Get current used rate control stategy brief information (type and name)
         */
        MPP_ENC_GET_RC_API_CURRENT = MPP_ENC_CFG_RC_API + 4,
        /*
         * Set RcApiBrief structure
         * Set current used rate control stategy brief information (type and name)
         */
        MPP_ENC_SET_RC_API_CURRENT = MPP_ENC_CFG_RC_API + 5,

        MPP_ENC_CFG_MISC = 0x00300000 | 0x00020000 | 0x00008000,
        /// <summary>
        /// set MppEncHeaderMode
        /// </summary>
        MPP_ENC_SET_HEADER_MODE,
        /// <summary>
        /// get MppEncHeaderMode
        /// </summary>
        MPP_ENC_GET_HEADER_MODE,

        MPP_ENC_CFG_SPLIT = 0x00300000 | 0x00020000 | 0x00008100,
        /// <summary>
        /// set MppEncSliceSplit structure
        /// </summary>
        MPP_ENC_SET_SPLIT,
        /// <summary>
        /// get MppEncSliceSplit structure
        /// </summary>
        MPP_ENC_GET_SPLIT,

        MPP_ENC_CFG_REF = 0x00300000 | 0x00020000 | 0x00008200,
        /// <summary>
        /// set MppEncRefCfg structure
        /// </summary>
        MPP_ENC_SET_REF_CFG,

        MPP_ENC_CFG_OSD = 0x00300000 | 0x00020000 | 0x00008400,
        /// <summary>
        /// set OSD palette, parameter should be pointer to MppEncOSDPltCfg
        /// </summary>
        MPP_ENC_SET_OSD_PLT_CFG,
        /// <summary>
        /// get OSD palette, parameter should be pointer to MppEncOSDPltCfg
        /// </summary>
        MPP_ENC_GET_OSD_PLT_CFG,
        /// <summary>
        /// set OSD data with at most 8 regions, parameter should be pointer to MppEncOSDData
        /// </summary>
        MPP_ENC_SET_OSD_DATA_CFG,

        MPP_ENC_CMD_END,

        MPP_ISP_CMD_BASE = 0x00300000 | 0x00030000,
        MPP_ISP_CMD_END,

        MPP_HAL_CMD_BASE = 0x00400000,
        MPP_HAL_CMD_END,

        MPI_CMD_BUTT,
    }
}
