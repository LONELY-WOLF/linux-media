using System.Runtime.InteropServices;

namespace LinuxMedia.Rockchip
{
    public class MppTask : MppHandle
    {
        public MPP_RET SetMeta(MppMetaKey key, Int32 val)
        {
            return mpp_task_meta_set_s32(Handle, key, val);
        }

        public MPP_RET SetMeta(MppMetaKey key, Int64 val)
        {
            return mpp_task_meta_set_s64(Handle, key, val);
        }

        public MPP_RET SetMeta(MppMetaKey key, nint val)
        {
            return mpp_task_meta_set_ptr(Handle, key, val);
        }

        public MPP_RET SetMeta(MppMetaKey key, MppFrame val)
        {
            return mpp_task_meta_set_frame(Handle, key, val.Handle);
        }

        public MPP_RET SetMeta(MppMetaKey key, MppPacket val)
        {
            return mpp_task_meta_set_packet(Handle, key, val.Handle);
        }

        public MPP_RET SetMeta(MppMetaKey key, MppBuffer val)
        {
            return mpp_task_meta_set_buffer(Handle, key, val.Handle);
        }

        public MPP_RET GetMeta(MppMetaKey key, ref Int32 val, Int32 default_val)
        {
            return mpp_task_meta_get_s32(Handle, key, ref val, default_val);
        }

        public MPP_RET GetMeta(MppMetaKey key, ref Int64 val, Int64 default_val)
        {
            return mpp_task_meta_get_s64(Handle, key, ref val, default_val);
        }

        public MPP_RET GetMeta(MppMetaKey key, ref nint val, nint default_val)
        {
            return mpp_task_meta_get_ptr(Handle, key, ref val, default_val);
        }

        public MPP_RET GetMeta(MppMetaKey key, MppFrame val)
        {
            return mpp_task_meta_get_frame(Handle, key, ref val.Handle);
        }

        public MPP_RET GetMeta(MppMetaKey key, MppPacket val)
        {
            return mpp_task_meta_get_packet(Handle, key, ref val.Handle);
        }

        public MPP_RET GetMeta(MppMetaKey key, MppBuffer val)
        {
            return mpp_task_meta_get_buffer(Handle, key, ref val.Handle);
        }

        /// <summary>
        /// <c>MPP_RET mpp_task_meta_set_s32(MppTask task, MppMetaKey key, RK_S32 val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_task_meta_set_s32(nint task, MppMetaKey key, Int32 val);
        /// <summary>
        /// <c>MPP_RET mpp_task_meta_set_s64(MppTask task, MppMetaKey key, RK_S64 val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_task_meta_set_s64(nint task, MppMetaKey key, Int64 val);
        /// <summary>
        /// <c>MPP_RET mpp_task_meta_set_ptr(MppTask task, MppMetaKey key, void* val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_task_meta_set_ptr(nint task, MppMetaKey key, nint val);
        /// <summary>
        /// <c>MPP_RET mpp_task_meta_set_frame(MppTask task, MppMetaKey key, MppFrame frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_task_meta_set_frame(nint task, MppMetaKey key, nint frame);
        /// <summary>
        /// <c>MPP_RET mpp_task_meta_set_packet(MppTask task, MppMetaKey key, MppPacket packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_task_meta_set_packet(nint task, MppMetaKey key, nint packet);
        /// <summary>
        /// <c>MPP_RET mpp_task_meta_set_buffer(MppTask task, MppMetaKey key, MppBuffer buffer);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_task_meta_set_buffer(nint task, MppMetaKey key, nint buffer);

        /// <summary>
        /// <c>MPP_RET mpp_task_meta_get_s32(MppTask task, MppMetaKey key, RK_S32* val, RK_S32 default_val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_task_meta_get_s32(nint task, MppMetaKey key, ref Int32 val, Int32 default_val);
        /// <summary>
        /// <c>MPP_RET mpp_task_meta_get_s64(MppTask task, MppMetaKey key, RK_S64* val, RK_S64 default_val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_task_meta_get_s64(nint task, MppMetaKey key, ref Int64 val, Int64 default_val);
        /// <summary>
        /// <c>MPP_RET mpp_task_meta_get_ptr(MppTask task, MppMetaKey key, void** val, void* default_val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_task_meta_get_ptr(nint task, MppMetaKey key, ref nint val, nint default_val);
        /// <summary>
        /// <c>MPP_RET mpp_task_meta_get_frame(MppTask task, MppMetaKey key, MppFrame* frame);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_task_meta_get_frame(nint task, MppMetaKey key, ref nint frame);
        /// <summary>
        /// <c>MPP_RET mpp_task_meta_get_packet(MppTask task, MppMetaKey key, MppPacket* packet);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_task_meta_get_packet(nint task, MppMetaKey key, ref nint packet);
        /// <summary>
        /// <c>MPP_RET mpp_task_meta_get_buffer(MppTask task, MppMetaKey key, MppBuffer* buffer);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_task_meta_get_buffer(nint task, MppMetaKey key, ref nint buffer);
    }
}
