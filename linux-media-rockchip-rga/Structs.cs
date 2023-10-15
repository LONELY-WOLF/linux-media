using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LinuxMedia.Rockchip
{
    [StructLayout(LayoutKind.Sequential)]
    public struct rga_rect
    {
        public int xoffset;
        public int yoffset;
        public int width;
        public int height;
        public int wstride;
        public int hstride;
        public int format;
        public int size;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct rga_nn
    {
        public int nn_flag;
        public int scale_r;
        public int scale_g;
        public int scale_b;
        public int offset_r;
        public int offset_g;
        public int offset_b;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct rga_dither
    {
        public int enable;
        public int mode;
        public int lut0_l;
        public int lut0_h;
        public int lut1_l;
        public int lut1_h;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct rga_mosaic_info
    {
        public byte enable;
        public byte mode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct rga_pre_intr_info
    {
        public byte enable;

        public byte read_intr_en;
        public byte write_intr_en;
        public byte read_hold_en;
        public UInt32 read_threshold;
        public UInt32 write_start;
        public UInt32 write_step;
    }

    /* MAX(min, (max - channel_value)) */
    [StructLayout(LayoutKind.Sequential)]
    public struct rga_osd_invert_factor
    {
        public byte alpha_max;
        public byte alpha_min;
        public byte yg_max;
        public byte yg_min;
        public byte crb_max;
        public byte crb_min;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct rga_color
    {
        public byte red;
        public byte green;
        public byte blue;
        public byte alpha;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct rga_osd_bpp2
    {
        public byte ac_swap;           // ac swap flag
                                       // 0: CA
                                       // 1: AC
        public byte endian_swap;       // rgba2bpp endian swap
                                       // 0: Big endian
                                       // 1: Little endian
        public rga_color color0;
        public rga_color color1;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct rga_osd_mode_ctrl
    {
        public byte mode;               // OSD cal mode:
                                        //   0b'1: statistics mode
                                        //   1b'1: auto inversion overlap mode
        public byte direction_mode;     // horizontal or vertical
                                        //   0: horizontal
                                        //   1: vertical
        public byte width_mode;         // using @fix_width or LUT width
                                        //   0: fix width
                                        //   1: LUT width
        public UInt16 block_fix_width;   // OSD block fixed width
                                         //   real width = (fix_width + 1) * 2
        public byte block_num;          // OSD block num
        public UInt16 flags_index;       // auto invert flags index

        /* invertion config */
        public byte color_mode;         // selete color
                                        //   0: src1 color
                                        //   1: config data color
        public byte invert_flags_mode;  // invert flag selete
                                        //   0: use RAM flag
                                        //   1: usr last result
        public byte default_color_sel;  // default color mode
                                        //   0: default is bright
                                        //   1: default is dark
        public byte invert_enable;      // invert channel enable
                                        //   1 << 0: aplha enable
                                        //   1 << 1: Y/G disable
                                        //   1 << 2: C/RB disable
        public byte invert_mode;        // invert cal mode
                                        //   0: normal(max-data)
                                        //   1: swap
        public byte invert_thresh;      // if luma > thresh, osd_flag to be 1
        public byte unfix_index;        // OSD width config index
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct rga_osd_info
    {
        public byte enable;

        public rga_osd_mode_ctrl mode_ctrl;
        public rga_osd_invert_factor cal_factor;
        public rga_osd_bpp2 bpp2_info;

        public UInt64 last_flags;

        public UInt64 cur_flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct rga_info
    {
        /// <summary>
        /// use fd to share memory, it can be ion shard fd,and dma fd.
        /// </summary>
        public int fd;
        /// <summary>
        /// userspace address
        /// </summary>
        public IntPtr virAddr;
        /// <summary>
        /// use phy address
        /// </summary>
        public IntPtr phyAddr;
        /// <summary>
        /// use buffer_handle_t
        /// </summary>
        public uint hnd;
        public int format;
        public rga_rect rect;
        public uint blend;
        public int bufferSize;
        public int rotation;
        public int color;
        public int testLog;
        public int mmuFlag;
        public int colorkey_en;
        public int colorkey_mode;
        public int colorkey_max;
        public int colorkey_min;
        public int scale_mode;
        public int color_space_mode;
        public int sync_mode;
        public rga_nn nn;
        public rga_dither dither;
        public int rop_code;
        public int rd_mode;
        public ushort is_10b_compact;
        public ushort is_10b_endian;

        public int in_fence_fd;
        public int out_fence_fd;

        public int core;
        public int priority;

        public ushort enable;

        public int handle;

        public rga_mosaic_info mosaic_info;

        public rga_osd_info osd_info;

        public rga_pre_intr_info pre_intr;

        public int mpi_mode;

        // int ctx_id;
        public int job_handle;

        // total size = 696
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 402)]
        public byte[] reserve;
    }
}
