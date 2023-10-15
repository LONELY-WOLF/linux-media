using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxMedia.Rockchip
{
    public enum RK_FORMAT
    {
        RGBA_8888 = 0x0 << 8,  /* [0:31] R:G:B:A 8:8:8:8 little endian */
        RGBX_8888 = 0x1 << 8,  /* [0:31] R:G:B:X 8:8:8:8 little endian */
        RGB_888 = 0x2 << 8,  /* [0:23] R:G:B 8:8:8 little endian */
        BGRA_8888 = 0x3 << 8,  /* [0:31] B:G:R:A 8:8:8:8 little endian */
        RGB_565 = 0x4 << 8,  /* [0:15] R:G:B 5:6:5 little endian */
        RGBA_5551 = 0x5 << 8,  /* [0:15] R:G:B:A 5:5:5:1 little endian */
        RGBA_4444 = 0x6 << 8,  /* [0:15] R:G:B:A 4:4:4:4 little endian */
        BGR_888 = 0x7 << 8,  /* [0:23] B:G:R 8:8:8 little endian */

        YCbCr_422_SP = 0x8 << 8,  /* 2 plane YCbCr little endian
                                         * plane 0: [0:7] Y
                                         * plane 1: 2x1 subsampled [0:15] Cb:Cr 8:8 */
        YCbCr_422_P = 0x9 << 8,  /* 3 plane YCbCr little endian
                                         * plane 0: [0:7] Y
                                         * plane 1: 2x1 subsampled [0:7] Cb
                                         * plane 2: 2x1 subsampled [0:7] Cr */
        YCbCr_420_SP = 0xa << 8,  /* 2 plane YCbCr little endian
                                         * plane 0: [0:7] Y
                                         * plane 1: 2x2 subsampled [0:15] Cr:Cb 8:8 */
        YCbCr_420_P = 0xb << 8,  /* 3 plane YCbCr little endian
                                         * plane 0: [0:7] Y
                                         * plane 1: 2x2 subsampled [0:7] Cb
                                         * plane 2: 2x2 subsampled [0:7] Cr */

        YCrCb_422_SP = 0xc << 8,  /* 2 plane YCbCr little endian
                                         * plane 0: [0:7] Y
                                         * plane 1: 2x1 subsampled [0:15] Cb:Cr 8:8 */
        YCrCb_422_P = 0xd << 8,  /* 3 plane YCbCr little endian
                                         * plane 0: [0:7] Y
                                         * plane 1: 2x1 subsampled [0:7] Cr
                                         * plane 2: 2x1 subsampled [0:7] Cb */
        YCrCb_420_SP = 0xe << 8,  /* 2 plane YCbCr little endian
                                         * plane 0: [0:7] Y
                                         * plane 1: 2x2 subsampled [0:15] Cb:Cr 8:8 */
        YCrCb_420_P = 0xf << 8,  /* 3 plane YCbCr little endian
                                         * plane 0: [0:7] Y
                                         * plane 1: 2x2 subsampled [0:7] Cr
                                         * plane 2: 2x2 subsampled [0:7] Cb */

        BPP1 = 0x10 << 8, /* [0] little endian */
        BPP2 = 0x11 << 8, /* [0:1] little endian */
        BPP4 = 0x12 << 8, /* [0:3] little endian */
        BPP8 = 0x13 << 8, /* [0:7] little endian */

        Y4 = 0x14 << 8, /* [0:3] Y little endian */
        YCbCr_400 = 0x15 << 8, /* [0:7] Y little endian */

        BGRX_8888 = 0x16 << 8, /* [0:31] B:G:R:X 8:8:8:8 little endian */

        YVYU_422 = 0x18 << 8, /* [0:31] Y0:Cr0:Y1:cb0 8:8:8:8 little endian */
        YVYU_420 = 0x19 << 8, /* ODD : [0:31] Y0:Cr0:Y1:cb0 8:8:8:8 little endian
                                         * EVEN: [0:31] Y2:Y3:X:X 8:8:8:8 little endian */
        VYUY_422 = 0x1a << 8, /* [0:31] Cr0:Y0:Cb0:Y1 8:8:8:8 little endian */
        VYUY_420 = 0x1b << 8, /* ODD : [0:31] Cr0:Y0:Cb0:Y1 8:8:8:8 little endian
                                         * EVEN: [0:31] Y2:Y3:X:X 8:8:8:8 little endian */
        YUYV_422 = 0x1c << 8, /* [0:31] Y0:Cb0:Y1:cr0 8:8:8:8 little endian */
        YUYV_420 = 0x1d << 8, /* ODD : [0:31] Y0:Cb0:Y1:cr0 8:8:8:8 little endian
                                         * EVEN: [0:31] Y2:Y3:X:X 8:8:8:8 little endian */
        UYVY_422 = 0x1e << 8, /* [0:31] Cb0:Y0:Cr0:Y1 8:8:8:8 little endian */
        UYVY_420 = 0x1f << 8, /* ODD : [0:31] Cb0:Y0:Cr0:Y1 8:8:8:8 little endian
                                         * EVEN: [0:31] Y2:Y3:X:X 8:8:8:8 little endian */

        YCbCr_420_SP_10B = 0x20 << 8, /* 2 plane YCbCr little endian
                                             * plane 0: [0:9] Y
                                             * plane 1: 2x2 subsampled [0:19] Cb:Cr 10: 10 (default)
                                             * or
                                             * plane 1: 2x2 subsampled [0:23] Cb:Cr 16: 16 */
        YCrCb_420_SP_10B = 0x21 << 8, /* 2 plane YCbCr little endian
                                             * plane 0: [0:9] Y
                                             * plane 1: 2x2 subsampled [0:19] Cr:Cb 10: 10 (default)
                                             * or
                                             * plane 1: 2x2 subsampled [0:23] Cr:Cb 16: 16 */
        YCbCr_422_SP_10B = 0x22 << 8, /* 2 plane YCbCr little endian
                                             * plane 0: [0:9] Y
                                             * plane 1: 2x1 subsampled [0:19] Cb:Cr 10:10  (default)
                                             * or
                                             * plane 1: 2x1 subsampled [0:23] Cb:Cr 16: 16 */
        YCrCb_422_SP_10B = 0x23 << 8, /* 2 plane YCbCr little endian
                                             * plane 0: [0:9] Y
                                             * plane 1: 2x1 subsampled [0:19] Cr:Cb 10:10  (default)
                                             * or
                                             * plane 1: 2x1 subsampled [0:23] Cr:Cb 16: 16 */
        /* For compatibility with misspellings */
        YCbCr_422_10b_SP = YCbCr_422_SP_10B << 8,
        YCrCb_422_10b_SP = YCrCb_422_SP_10B << 8,

        BGR_565 = 0x24 << 8, /* [0:16] B:G:R 5:6:5 little endian */
        BGRA_5551 = 0x25 << 8, /* [0:16] B:G:R:A 5:5:5:1 little endian */
        BGRA_4444 = 0x26 << 8, /* [0:16] B:G:R:A 4:4:4:4 little endian */

        ARGB_8888 = 0x28 << 8, /* [0:31] A:R:G:B 8:8:8:8 little endian */
        XRGB_8888 = 0x29 << 8, /* [0:31] X:R:G:B 8:8:8:8 little endian */
        ARGB_5551 = 0x2a << 8, /* [0:16] A:R:G:B 5:5:5:1 little endian */
        ARGB_4444 = 0x2b << 8, /* [0:16] A:R:G:B 4:4:4:4 little endian */
        ABGR_8888 = 0x2c << 8, /* [0:31] A:B:G:R 8:8:8:8 little endian */
        XBGR_8888 = 0x2d << 8, /* [0:31] X:B:G:R 8:8:8:8 little endian */
        ABGR_5551 = 0x2e << 8, /* [0:16] A:B:G:R 5:5:5:1 little endian */
        ABGR_4444 = 0x2f << 8, /* [0:16] A:B:G:R 4:4:4:4 little endian */

        RGBA2BPP = 0x30 << 8, /* [0:1] Color:Alpha 1:1 little endian */

        UNKNOWN = 0x100 << 8,
    }

    public enum color_space_mode
    {
        yuv2rgb_mode0 = 0x0,     /* BT.601 MPEG */
        yuv2rgb_mode1 = 0x1,     /* BT.601 JPEG */
        yuv2rgb_mode2 = 0x2,     /* BT.709      */

        rgb2yuv_601_full = 0x1 << 8,
        rgb2yuv_709_full = 0x2 << 8,
        yuv2yuv_601_limit_2_709_limit = 0x3 << 8,
        yuv2yuv_601_limit_2_709_full = 0x4 << 8,
        yuv2yuv_709_limit_2_601_limit = 0x5 << 8,
        yuv2yuv_709_limit_2_601_full = 0x6 << 8,     //not support
        yuv2yuv_601_full_2_709_limit = 0x7 << 8,
        yuv2yuv_601_full_2_709_full = 0x8 << 8,     //not support
        yuv2yuv_709_full_2_601_limit = 0x9 << 8,     //not support
        yuv2yuv_709_full_2_601_full = 0xa << 8,     //not support
        full_csc_mask = 0xf00,
    }

    public enum SCHEDULER_CORE
    {
        RGA3_CORE0 = 1 << 0,
        RGA3_CORE1 = 1 << 1,
        RGA2_CORE0 = 1 << 2,
    }

    /* RGA3 rd_mode */
    public enum rd_mode
    {
        raster_mode = 0x1 << 0,
        fbc_mode = 0x1 << 1,
        tile_mode = 0x1 << 2,
    }
}
