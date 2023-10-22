﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LinuxMedia.Rockchip
{
    public class MppBufferGroup : MppHandle
    {
        public MppBufferGroup(MppBufferType type, MppBufferMode mode, string? tag = null)
        {
            mpp_buffer_group_get(ref Handle, type, mode, tag);
        }

        public MPP_RET Put()
        {
            return mpp_buffer_group_put(Handle);
        }

        public MPP_RET Clear()
        {
            return mpp_buffer_group_clear(Handle);
        }

        public Int32 Unused
        {
            get
            {
                return mpp_buffer_group_unused(Handle);
            }
        }

        public UInt64 Usage
        {
            get
            {
                return mpp_buffer_group_usage(Handle);
            }
        }

        public MppBufferMode Mode
        {
            get
            {
                return mpp_buffer_group_mode(Handle);
            }
        }

        public MppBufferType Type
        {
            get
            {
                return mpp_buffer_group_type(Handle);
            }
        }

        /// <summary>
        /// <c>MPP_RET mpp_buffer_group_get(MppBufferGroup* group, MppBufferType type, MppBufferMode mode, const char* tag, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_buffer_group_get(ref IntPtr group, MppBufferType type, MppBufferMode mode, [MarshalAs(UnmanagedType.LPStr)] string? tag, [CallerMemberName][MarshalAs(UnmanagedType.LPStr)] string caller = "");
        /// <summary>
        /// <c><MPP_RET mpp_buffer_group_put(MppBufferGroup group);/c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_buffer_group_put(IntPtr group);
        /// <summary>
        /// <c>MPP_RET mpp_buffer_group_clear(MppBufferGroup group);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_buffer_group_clear(IntPtr group);
        /// <summary>
        /// <c>RK_S32 mpp_buffer_group_unused(MppBufferGroup group);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern Int32 mpp_buffer_group_unused(IntPtr group);
        /// <summary>
        /// <c>size_t mpp_buffer_group_usage(MppBufferGroup group);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt64 mpp_buffer_group_usage(IntPtr group);
        /// <summary>
        /// <c>MppBufferMode mpp_buffer_group_mode(MppBufferGroup group);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MppBufferMode mpp_buffer_group_mode(IntPtr group);
        /// <summary>
        /// <c>MppBufferType mpp_buffer_group_type(MppBufferGroup group);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MppBufferType mpp_buffer_group_type(IntPtr group);
    }
}
