using System.Runtime.InteropServices;

namespace LinuxMedia.Rockchip
{
    public class MppPacket : MppHandle
    {
        public MppPacket()
        {
            mpp_packet_new(ref Handle);
        }

        public MppPacket(IntPtr data, UInt64 size)
        {
            mpp_packet_init(ref Handle, data, size);
        }

        public MppPacket(MppBuffer buffer)
        {
            mpp_packet_init_with_buffer(ref Handle, buffer.Ptr);
        }

        public MppPacket(MppPacket src)
        {
            mpp_packet_copy_init(ref Handle, src.Handle);
        }

        ~MppPacket()
        {
            mpp_packet_deinit(ref Handle);
        }

        public IntPtr Data
        {
            get
            {
                return mpp_packet_get_data(Handle);
            }
            set
            {
                mpp_packet_set_data(Handle, value);
            }
        }

        public UInt64 Size
        {
            get
            {
                return mpp_packet_get_size(Handle);
            }
            set
            {
                mpp_packet_set_size(Handle, value);
            }
        }

        public IntPtr Pos
        {
            get
            {
                return mpp_packet_get_pos(Handle);
            }
            set
            {
                mpp_packet_set_pos(Handle, value);
            }
        }

        public UInt64 Length
        {
            get
            {
                return mpp_packet_get_length(Handle);
            }
            set
            {
                mpp_packet_set_length(Handle, value);
            }
        }

        public Int64 Pts
        {
            get
            {
                return mpp_packet_get_pts(Handle);
            }
            set
            {
                mpp_packet_set_pts(Handle, value);
            }
        }

        public Int64 Dts
        {
            get
            {
                return mpp_packet_get_dts(Handle);
            }
            set
            {
                mpp_packet_set_dts(Handle, value);
            }
        }

        public UInt32 Flag
        {
            get
            {
                return mpp_packet_get_flag(Handle);
            }
            set
            {
                mpp_packet_set_flag(Handle, value);
            }
        }

        public bool Eos
        {
            get
            {
                return mpp_packet_get_eos(Handle) != 0;
            }
            set
            {
                if(value)
                {
                    mpp_packet_set_eos(Handle);
                }
                else
                {
                    mpp_packet_clr_eos(Handle);
                }
            }
        }

        public MPP_RET SetExtraData()
        {
            return mpp_packet_set_extra_data(Handle);
        }

        public MppBuffer Buffer
        {
            get
            {
                return new MppBuffer(mpp_packet_get_buffer(Handle));
            }
            set
            {
                mpp_packet_set_buffer(Handle, value.Handle);
            }
        }

        public MPP_RET Read(UInt64 offset, IntPtr data, UInt64 size)
        {
            return mpp_packet_read(Handle, offset, data, size);
        }

        public MPP_RET Write(UInt64 offset, IntPtr data, UInt64 size)
        {
            return mpp_packet_write(Handle, offset, data, size);
        }

        public Int32 HasMeta
        {
            get
            {
                return mpp_packet_has_meta(Handle);
            }
        }

        public MppMeta Meta
        {
            get
            {
                return new MppMeta(mpp_packet_get_meta(Handle));
            }
        }

        public UInt32 IsPartition
        {
            get
            {
                return mpp_packet_is_partition(Handle);
            }
        }

        public UInt32 IsSoi
        {
            get
            {
                return mpp_packet_is_soi(Handle);
            }
        }

        public UInt32 IsEoi
        {
            get
            {
                return mpp_packet_is_eoi(Handle);
            }
        }

        public UInt32 SegmentNb
        {
            get
            {
                return mpp_packet_get_segment_nb(Handle);
            }
        }

        public MppPktSeg SegmentInfo
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #region Native calls
        /// <summary>
        /// <c>MPP_RET mpp_packet_new(MppPacket* packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_packet_new(ref IntPtr packet);
        /// <summary>
        /// <c>MPP_RET mpp_packet_init(MppPacket* packet, void* data, size_t size);</c>
        /// <c>mpp_packet_init = mpp_packet_new + mpp_packet_set_data + mpp_packet_set_size</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_packet_init(ref IntPtr packet, IntPtr data, UInt64 size);
        /// <summary>
        /// <c>MPP_RET mpp_packet_init_with_buffer(MppPacket* packet, MppBuffer buffer);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_packet_init_with_buffer(ref IntPtr packet, IntPtr buffer);
        /// <summary>
        /// <c>MPP_RET mpp_packet_copy_init(MppPacket* packet, const MppPacket src);</c>
        /// <c>mpp_packet_copy_init = mpp_packet_init + memcpy</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_packet_copy_init(ref IntPtr packet, IntPtr src);
        /// <summary>
        /// <c>MPP_RET mpp_packet_deinit(MppPacket* packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_packet_deinit(ref IntPtr packet);

        /*
         * data   : ( R/W ) start address of the whole packet memory
         * size   : ( R/W ) total size of the whole packet memory
         * pos    : ( R/W ) current access position of the whole packet memory, used for buffer read/write
         * length : ( R/W ) the rest length from current position to end of buffer
         *                  NOTE: normally length is updated only by set_pos,
         *                        so set length must be used carefully for special usage
         */
        /// <summary>
        /// <c>void mpp_packet_set_data(MppPacket packet, void* data);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_packet_set_data(IntPtr packet, IntPtr data);
        /// <summary>
        /// <c>void mpp_packet_set_size(MppPacket packet, size_t size);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_packet_set_size(IntPtr packet, UInt64 size);
        /// <summary>
        /// <c>void mpp_packet_set_pos(MppPacket packet, void* pos);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_packet_set_pos(IntPtr packet, IntPtr pos);
        /// <summary>
        /// <c>void mpp_packet_set_length(MppPacket packet, size_t size);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_packet_set_length(IntPtr packet, UInt64 size);

        /// <summary>
        /// <c>void* mpp_packet_get_data(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern IntPtr mpp_packet_get_data(IntPtr packet);
        /// <summary>
        /// <c>void* mpp_packet_get_pos(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern IntPtr mpp_packet_get_pos(IntPtr packet);
        /// <summary>
        /// <c>size_t mpp_packet_get_size(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt64 mpp_packet_get_size(IntPtr packet);
        /// <summary>
        /// <c>size_t mpp_packet_get_length(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt64 mpp_packet_get_length(IntPtr packet);


        /// <summary>
        /// <c>void mpp_packet_set_pts(MppPacket packet, RK_S64 pts);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_packet_set_pts(IntPtr packet, Int64 pts);
        /// <summary>
        /// <c>RK_S64 mpp_packet_get_pts(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern Int64 mpp_packet_get_pts(IntPtr packet);
        /// <summary>
        /// <c>void mpp_packet_set_dts(MppPacket packet, RK_S64 dts);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_packet_set_dts(IntPtr packet, Int64 dts);
        /// <summary>
        /// <c>RK_S64 mpp_packet_get_dts(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern Int64 mpp_packet_get_dts(IntPtr packet);

        /// <summary>
        /// <c>void mpp_packet_set_flag(MppPacket packet, RK_U32 flag);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_packet_set_flag(IntPtr packet, UInt32 flag);
        /// <summary>
        /// <c>RK_U32 mpp_packet_get_flag(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_packet_get_flag(IntPtr packet);

        /// <summary>
        /// <c>MPP_RET mpp_packet_clr_eos(MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_packet_set_eos(IntPtr packet);
        /// <summary>
        /// <c></c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_packet_clr_eos(IntPtr packet);
        /// <summary>
        /// <c>RK_U32 mpp_packet_get_eos(MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_packet_get_eos(IntPtr packet);
        /// <summary>
        /// <c>MPP_RET mpp_packet_set_extra_data(MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_packet_set_extra_data(IntPtr packet);

        /// <summary>
        /// <c>void mpp_packet_set_buffer(MppPacket packet, MppBuffer buffer);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern void mpp_packet_set_buffer(IntPtr packet, IntPtr buffer);
        /// <summary>
        /// <c>MppBuffer mpp_packet_get_buffer(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern IntPtr mpp_packet_get_buffer(IntPtr packet);

        /*
         * data access interface
         */
        /// <summary>
        /// <c>MPP_RET mpp_packet_read(MppPacket packet, size_t offset, void* data, size_t size);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_packet_read(IntPtr packet, UInt64 offset, IntPtr data, UInt64 size);
        /// <summary>
        /// <c>MPP_RET mpp_packet_write(MppPacket packet, size_t offset, void* data, size_t size);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_packet_write(IntPtr packet, UInt64 offset, IntPtr data, UInt64 size);

        /*
         * meta data access interface
         */
        /// <summary>
        /// <c>RK_S32 mpp_packet_has_meta(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern Int32 mpp_packet_has_meta(IntPtr packet);
        /// <summary>
        /// <c>MppMeta mpp_packet_get_meta(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern IntPtr mpp_packet_get_meta(IntPtr packet);

        /*
         * multi packet sequence interface for slice/split encoding/decoding
         * partition - the packet is a part of a while image
         * soi - Start Of Image
         * eoi - End Of Image
         */
        /// <summary>
        /// <c>RK_U32 mpp_packet_is_partition(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_packet_is_partition(IntPtr packet);
        /// <summary>
        /// <c>RK_U32 mpp_packet_is_soi(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_packet_is_soi(IntPtr packet);
        /// <summary>
        /// <c>RK_U32 mpp_packet_is_eoi(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_packet_is_eoi(IntPtr packet);
        #endregion

        /*
         * packet segement pack info for
         * segment number - number of segment
         * segment info   - base address of segment info
         */

        public struct MppPktSeg
        {
            public Int32 index;
            public Int32 type;
            public UInt32 offset;
            public UInt32 len;
            public IntPtr next;
        };

        /// <summary>
        /// <c>RK_U32 mpp_packet_get_segment_nb(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt32 mpp_packet_get_segment_nb(IntPtr packet);
        /// <summary>
        /// <c>const MppPktSeg* mpp_packet_get_segment_info(const MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern IntPtr mpp_packet_get_segment_info(IntPtr packet);
    }
}
