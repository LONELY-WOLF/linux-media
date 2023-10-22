using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LinuxMedia.Rockchip
{
    public class MppMeta : MppHandle
    {
        internal MppMeta(IntPtr handle)
        {
            Handle = handle;
        }

        public MppMeta(string? tag = null)
        {
            mpp_meta_get_with_tag(ref Handle, tag);
        }

        public MPP_RET Put()
        {
            return mpp_meta_put(Handle);
        }

        public Int32 Size
        {
            get
            {
                return mpp_meta_size(Handle);
            }
        }

        public MPP_RET Set(MppMetaKey key, Int32 val)
        {
            return mpp_meta_set_s32(Handle, key, val);
        }

        public MPP_RET Set(MppMetaKey key, Int64 val)
        {
            return mpp_meta_set_s64(Handle, key, val);
        }

        public MPP_RET Set(MppMetaKey key, IntPtr val)
        {
            return mpp_meta_set_ptr(Handle, key, val);
        }

        public MPP_RET Set(MppMetaKey key, MppFrame val)
        {
            return mpp_meta_set_frame(Handle, key, val.Handle);
        }

        public MPP_RET Set(MppMetaKey key, MppPacket val)
        {
            return mpp_meta_set_packet(Handle, key, val.Handle);
        }

        public MPP_RET Set(MppMetaKey key, MppBuffer val)
        {
            return mpp_meta_set_buffer(Handle, key, val.Handle);
        }

        public MPP_RET Get(MppMetaKey key, ref Int32 val, Int32? def = null)
        {
            if(def.HasValue)
            {
                return mpp_meta_get_s32_d(Handle, key, ref val, def.Value);
            }
            else
            {
                return mpp_meta_get_s32(Handle, key, ref val);
            }
        }

        public MPP_RET Get(MppMetaKey key, ref Int64 val, Int64? def = null)
        {
            if (def.HasValue)
            {
                return mpp_meta_get_s64_d(Handle, key, ref val, def.Value);
            }
            else
            {
                return mpp_meta_get_s64(Handle, key, ref val);
            }
        }

        public MPP_RET Get(MppMetaKey key, ref IntPtr val, IntPtr? def = null)
        {
            if (def.HasValue)
            {
                return mpp_meta_get_ptr_d(Handle, key, ref val, def.Value);
            }
            else
            {
                return mpp_meta_get_ptr(Handle, key, ref val);
            }
        }

        public MPP_RET Get(MppMetaKey key, ref MppFrame val, MppFrame? def = null)
        {
            if (def != null)
            {
                return mpp_meta_get_frame_d(Handle, key, ref val.Handle, def.Handle);
            }
            else
            {
                return mpp_meta_get_frame(Handle, key, ref val.Handle);
            }
        }

        public MPP_RET Get(MppMetaKey key, ref MppPacket val, MppPacket? def = null)
        {
            if (def != null)
            {
                return mpp_meta_get_packet_d(Handle, key, ref val.Handle, def.Handle);
            }
            else
            {
                return mpp_meta_get_packet(Handle, key, ref val.Handle);
            }
        }

        public MPP_RET Get(MppMetaKey key, ref MppBuffer val, MppBuffer? def = null)
        {
            if (def != null)
            {
                return mpp_meta_get_buffer_d(Handle, key, ref val.Handle, def.Handle);
            }
            else
            {
                return mpp_meta_get_buffer(Handle, key, ref val.Handle);
            }
        }

        /// <summary>
        /// <c>MPP_RET mpp_meta_get_with_tag(MppMeta* meta, const char* tag, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_get_with_tag(ref IntPtr meta, [MarshalAs(UnmanagedType.LPStr)] string? tag, [CallerMemberName][MarshalAs(UnmanagedType.LPStr)] string caller = "");
        /// <summary>
        /// <c>MPP_RET mpp_meta_put(MppMeta meta);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_put(IntPtr meta);
        /// <summary>
        /// <c>RK_S32 mpp_meta_size(MppMeta meta);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern Int32 mpp_meta_size(IntPtr meta);

        /// <summary>
        /// <c>MPP_RET mpp_meta_set_s32(MppMeta meta, MppMetaKey key, RK_S32 val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_set_s32(IntPtr meta, MppMetaKey key, Int32 val);
        /// <summary>
        /// <c>MPP_RET mpp_meta_set_s64(MppMeta meta, MppMetaKey key, RK_S64 val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_set_s64(IntPtr meta, MppMetaKey key, Int64 val);
        /// <summary>
        /// <c>MPP_RET mpp_meta_set_ptr(MppMeta meta, MppMetaKey key, void* val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_set_ptr(IntPtr meta, MppMetaKey key, IntPtr val);
        /// <summary>
        /// <c>MPP_RET mpp_meta_get_s32(MppMeta meta, MppMetaKey key, RK_S32* val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_get_s32(IntPtr meta, MppMetaKey key, ref Int32 val);
        /// <summary>
        /// <c>MPP_RET mpp_meta_get_s64(MppMeta meta, MppMetaKey key, RK_S64* val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_get_s64(IntPtr meta, MppMetaKey key, ref Int64 val);
        /// <summary>
        /// <c>MPP_RET mpp_meta_get_ptr(MppMeta meta, MppMetaKey key, void** val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_get_ptr(IntPtr meta, MppMetaKey key, ref IntPtr val);

        /// <summary>
        /// <c>MPP_RET mpp_meta_set_frame(MppMeta meta, MppMetaKey key, MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_set_frame(IntPtr meta, MppMetaKey key, IntPtr frame);
        /// <summary>
        /// <c>MPP_RET mpp_meta_set_packet(MppMeta meta, MppMetaKey key, MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_set_packet(IntPtr meta, MppMetaKey key, IntPtr packet);
        /// <summary>
        /// <c>MPP_RET mpp_meta_set_buffer(MppMeta meta, MppMetaKey key, MppBuffer buffer);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_set_buffer(IntPtr meta, MppMetaKey key, IntPtr buffer);
        /// <summary>
        /// <c>MPP_RET mpp_meta_get_frame(MppMeta meta, MppMetaKey key, MppFrame* frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_get_frame(IntPtr meta, MppMetaKey key, ref IntPtr frame);
        /// <summary>
        /// <c>MPP_RET mpp_meta_get_packet(MppMeta meta, MppMetaKey key, MppPacket* packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_get_packet(IntPtr meta, MppMetaKey key, ref IntPtr packet);
        /// <summary>
        /// <c>MPP_RET mpp_meta_get_buffer(MppMeta meta, MppMetaKey key, MppBuffer* buffer);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_get_buffer(IntPtr meta, MppMetaKey key, ref IntPtr buffer);

        /// <summary>
        /// <c>MPP_RET mpp_meta_get_s32_d(MppMeta meta, MppMetaKey key, RK_S32* val, RK_S32 def);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_get_s32_d(IntPtr meta, MppMetaKey key, ref Int32 val, Int32 def);
        /// <summary>
        /// <c>MPP_RET mpp_meta_get_s64_d(MppMeta meta, MppMetaKey key, RK_S64* val, RK_S64 def);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_get_s64_d(IntPtr meta, MppMetaKey key, ref Int64 val, Int64 def);
        /// <summary>
        /// <c>MPP_RET mpp_meta_get_ptr_d(MppMeta meta, MppMetaKey key, void** val, void* def);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_get_ptr_d(IntPtr meta, MppMetaKey key, ref IntPtr val, IntPtr def);
        /// <summary>
        /// <c>MPP_RET mpp_meta_get_frame_d(MppMeta meta, MppMetaKey key, MppFrame* frame, MppFrame def);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_get_frame_d(IntPtr meta, MppMetaKey key, ref IntPtr frame, IntPtr def);
        /// <summary>
        /// <c>MPP_RET mpp_meta_get_packet_d(MppMeta meta, MppMetaKey key, MppPacket* packet, MppPacket def);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_get_packet_d(IntPtr meta, MppMetaKey key, ref IntPtr packet, IntPtr def);
        /// <summary>
        /// <c>MPP_RET mpp_meta_get_buffer_d(MppMeta meta, MppMetaKey key, MppBuffer* buffer, MppBuffer def);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_meta_get_buffer_d(IntPtr meta, MppMetaKey key, ref IntPtr buffer, IntPtr def);
    }
}
