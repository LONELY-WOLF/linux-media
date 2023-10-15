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
        /// <param name="x">ROI x coord</param>
        /// <param name="y">ROI y coord</param>
        /// <param name="w">ROI width</param>
        /// <param name="h">ROI height</param>
        /// <param name="ws">Buffer width</param>
        /// <param name="hs">Buffer height</param>
        /// <param name="format">Buffer format</param>
        public rga_rect(int x, int y, int w, int h, int ws, int hs, int format)
        {
            xoffset = x;
            yoffset = y;
            width = w;
            height = h;
            wstride = ws;
            hstride = hs;
            this.format = format;
        }
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

    /// <summary>
    /// <c>MAX(min, (max - channel_value))</c>
    /// </summary>
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
        /// <summary>
        /// ac swap flag <br/>
        /// • <b>0</b>: CA <br/>
        /// • <b>1</b>: AC
        /// </summary>
        public byte ac_swap;
        /// <summary>
        /// rgba2bpp endian swap <br/>
        /// • <b>0</b>: Big endian <br/>
        /// • <b>1</b>: Little endian
        /// </summary>
        public byte endian_swap;
        public rga_color color0;
        public rga_color color1;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct rga_osd_mode_ctrl
    {
        /// <summary>
        /// OSD cal mode: <br/>
        /// • <b>0b'1</b>: statistics mode <br/>
        /// • <b>1b'1</b>: auto inversion overlap mode
        /// </summary>
        public byte mode;
        /// <summary>
        /// horizontal or vertical <br/>
        /// • <b>0</b>: horizontal <br/>
        /// • <b>1</b>: vertical
        /// </summary>
        public byte direction_mode;
        /// <summary>
        /// using @fix_width or LUT width <br/>
        /// • <b>0</b>: fix width <br/>
        /// • <b>1</b>: LUT width
        /// </summary>
        public byte width_mode;
        /// <summary>
        /// OSD block fixed width <br/>
        /// <c>real width = (fix_width + 1) * 2</c>
        /// </summary>
        public UInt16 block_fix_width;
        /// <summary>
        /// OSD block num
        /// </summary>
        public byte block_num;
        /// <summary>
        /// auto invert flags index
        /// </summary>
        public UInt16 flags_index;

        /* invertion config */
        /// <summary>
        /// selete color <br/>
        /// • <b>0</b>: src1 color <br/>
        /// • <b>1</b>: config data color
        /// </summary>
        public byte color_mode;
        /// <summary>
        /// invert flag selete <br/>
        /// • <b>0</b>: use RAM flag <br/>
        /// • <b>1</b>: usr last result
        /// </summary>
        public byte invert_flags_mode;
        /// <summary>
        /// default color mode <br/>
        /// • <b>0</b>: default is bright <br/>
        /// • <b>1</b>: default is dark
        /// </summary>
        public byte default_color_sel;
        /// <summary>
        /// invert channel enable <br/>
        /// • <b>1 &lt;&lt; 0</b>: aplha enable <br/>
        /// • <b>1 &lt;&lt; 1</b>: Y/G disable <br/>
        /// • <b>1 &lt;&lt; 2</b>: C/RB disable
        /// </summary>
        public byte invert_enable;
        /// <summary>
        /// invert cal mode <br/>
        /// • <b>0</b>: normal(max-data) <br/>
        /// • <b>1</b>: swap
        /// </summary>
        public byte invert_mode;
        /// <summary>
        /// if luma &gt; thresh, osd_flag to be 1
        /// </summary>
        public byte invert_thresh;
        /// <summary>
        /// OSD width config index
        /// </summary>
        public byte unfix_index;
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

        /// <summary>
        /// also a <c>ctx_id</c>
        /// </summary>
        public int job_handle;

        // total size = 696
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 402)]
        public byte[] reserve;
    }
}
