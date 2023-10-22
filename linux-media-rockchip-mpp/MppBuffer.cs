using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LinuxMedia.Rockchip
{
    public class MppBuffer : MppHandle
    {
        internal MppBuffer(IntPtr handle)
        {
            Handle = handle;
        }

        public MppBuffer(MppBufferGroup group, MppBufferInfo info, string? tag = null)
        {
            IntPtr info_ptr = Marshal.AllocHGlobal(Marshal.SizeOf(info));
            Marshal.StructureToPtr(info, info_ptr, true);
            mpp_buffer_import_with_tag(group.Handle, info_ptr, ref Handle, tag);
            // Is it ok to free info_ptr?
            Marshal.FreeHGlobal(info_ptr);
        }

        public MppBuffer(MppBufferGroup group, UInt64 size, string? tag = null)
        {
            mpp_buffer_get_with_tag(group.Handle, ref Handle, size, tag);
        }

        public MPP_RET Put()
        {
            return mpp_buffer_put_with_caller(Handle);
        }

        public MPP_RET IncRef()
        {
            return mpp_buffer_inc_ref_with_caller(Handle);
        }

        public MppBufferInfo Info
        {
            get
            {
                IntPtr info_ptr = Marshal.AllocHGlobal(Marshal.SizeOf<MppBufferInfo>());
                mpp_buffer_info_get_with_caller(Handle, info_ptr);
                MppBufferInfo info = Marshal.PtrToStructure<MppBufferInfo>(info_ptr);
                Marshal.FreeHGlobal(info_ptr);
                return info;
            }
        }

        public MPP_RET Read(UInt64 offset, IntPtr data, UInt64 size)
        {
            return mpp_buffer_read_with_caller(Handle, offset, data, size);
        }

        public MPP_RET Write(UInt64 offset, IntPtr data, UInt64 size)
        {
            return mpp_buffer_write_with_caller(Handle, offset, data, size);
        }

        public IntPtr Ptr
        {
            get
            {
                return mpp_buffer_get_ptr_with_caller(Handle);
            }
        }

        public int Fd
        {
            get
            {
                return mpp_buffer_get_fd_with_caller(Handle);
            }
        }

        public UInt64 Size
        {
            get
            {
                return mpp_buffer_get_size_with_caller(Handle);
            }
        }

        public int Index
        {
            get
            {
                return mpp_buffer_get_index_with_caller(Handle);
            }
            set
            {
                mpp_buffer_set_index_with_caller(Handle, value);
            }
        }

        public UInt64 Offset
        {
            get
            {
                return mpp_buffer_get_offset_with_caller(Handle);
            }
            set
            {
                mpp_buffer_set_offset_with_caller(Handle, value);
            }
        }

        /*
         * mpp_buffer_import_with_tag(MppBufferGroup group, MppBufferInfo* info, MppBuffer* buffer)
         *
         * 1. group - specified the MppBuffer to be attached to.
         * group can be NULL then this buffer will attached to default legecy group
         *    Default to NULL on mpp_buffer_import case
         *
         * 2. info  - input information for the output MppBuffer
         * info can NOT be NULL.It must contain at least one of ptr/fd.
         *
         * 3. buffer - generated MppBuffer from MppBufferInfo.
         *    buffer can be NULL then the buffer is commit to group with unused status.
         *    Otherwise generated buffer will be directly got and ref_count increased.
         *    Default to NULL on mpp_buffer_commit case
         *
         * mpp_buffer_commit usage:
         *
         * Add a external buffer info to group.This buffer will be on unused status.
         * Typical usage is on Android. MediaPlayer gralloc Graphic buffer then commit these buffer
         * to decoder's buffer group. Then decoder will recycle these buffer and return buffer reference
         * to MediaPlayer for display.
         *
         * mpp_buffer_import usage:
         *
         * Transfer a external buffer info to MppBuffer but it is not expected to attached to certain
         * buffer group. So the group is set to NULL.Then this buffer can be used for MppFrame/MppPacket.
         * Typical usage is for image processing. Image processing normally will be a oneshot operation
         * It does not need complicated group management.But in other hand mpp still need to know the
         * imported buffer is leak or not and trace its usage inside mpp process. So we attach this kind
         * of buffer to default misc buffer group for management.
         */

        /*
         * MppBuffer interface
         * these interface will change value of group and buffer so before calling functions
         * parameter need to be checked.
         *
         * IMPORTANT:
         * mpp_buffer_import_with_tag - compounded interface for commit and import
         *
         */
        /// <summary>
        /// <c>MPP_RET mpp_buffer_import_with_tag(MppBufferGroup group, MppBufferInfo* info, MppBuffer* buffer, *char* tag, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_buffer_import_with_tag(IntPtr group, IntPtr info, ref IntPtr buffer, [MarshalAs(UnmanagedType.LPStr)] string? tag, [CallerMemberName] [MarshalAs(UnmanagedType.LPStr)] string caller = "");
        /// <summary>
        /// <c>MPP_RET mpp_buffer_get_with_tag(MppBufferGroup group, MppBuffer* buffer, size_t size, const char* tag, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_buffer_get_with_tag(IntPtr group, ref IntPtr buffer, UInt64 size, [MarshalAs(UnmanagedType.LPStr)] string? tag, [CallerMemberName] [MarshalAs(UnmanagedType.LPStr)] string caller = "");
        /// <summary>
        /// <c>MPP_RET mpp_buffer_put_with_caller(MppBuffer buffer, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_buffer_put_with_caller(IntPtr buffer, [CallerMemberName] [MarshalAs(UnmanagedType.LPStr)] string caller = "");
        /// <summary>
        /// <c>MPP_RET mpp_buffer_inc_ref_with_caller(MppBuffer buffer, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_buffer_inc_ref_with_caller(IntPtr buffer, [CallerMemberName] [MarshalAs(UnmanagedType.LPStr)] string caller = "");

        /// <summary>
        /// <c>MPP_RET mpp_buffer_info_get_with_caller(MppBuffer buffer, MppBufferInfo* info, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_buffer_info_get_with_caller(IntPtr buffer, IntPtr info, [CallerMemberName] [MarshalAs(UnmanagedType.LPStr)] string caller = "");
        /// <summary>
        /// <c>MPP_RET mpp_buffer_read_with_caller(MppBuffer buffer, size_t offset, void* data, size_t size, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_buffer_read_with_caller(IntPtr buffer, UInt64 offset, IntPtr data, UInt64 size, [CallerMemberName] [MarshalAs(UnmanagedType.LPStr)] string caller = "");
        /// <summary>
        /// <c>MPP_RET mpp_buffer_write_with_caller(MppBuffer buffer, size_t offset, void* data, size_t size, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_buffer_write_with_caller(IntPtr buffer, UInt64 offset, IntPtr data, UInt64 size, [CallerMemberName] [MarshalAs(UnmanagedType.LPStr)] string caller = "");
        /// <summary>
        /// <c>void* mpp_buffer_get_ptr_with_caller(MppBuffer buffer, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern IntPtr mpp_buffer_get_ptr_with_caller(IntPtr buffer, [CallerMemberName] [MarshalAs(UnmanagedType.LPStr)] string caller = "");
        /// <summary>
        /// <c>int mpp_buffer_get_fd_with_caller(MppBuffer buffer, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern int mpp_buffer_get_fd_with_caller(IntPtr buffer, [CallerMemberName] [MarshalAs(UnmanagedType.LPStr)] string caller = "");
        /// <summary>
        /// <c>size_t mpp_buffer_get_size_with_caller(MppBuffer buffer, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt64 mpp_buffer_get_size_with_caller(IntPtr buffer, [CallerMemberName] [MarshalAs(UnmanagedType.LPStr)] string caller = "");
        /// <summary>
        /// <c>int mpp_buffer_get_index_with_caller(MppBuffer buffer, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern int mpp_buffer_get_index_with_caller(IntPtr buffer, [CallerMemberName] [MarshalAs(UnmanagedType.LPStr)] string caller = "");
        /// <summary>
        /// <c>MPP_RET mpp_buffer_set_index_with_caller(MppBuffer buffer, int index, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_buffer_set_index_with_caller(IntPtr buffer, int index, [CallerMemberName] [MarshalAs(UnmanagedType.LPStr)] string caller = "");
        /// <summary>
        /// <c>size_t mpp_buffer_get_offset_with_caller(MppBuffer buffer, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern UInt64 mpp_buffer_get_offset_with_caller(IntPtr buffer, [CallerMemberName] [MarshalAs(UnmanagedType.LPStr)] string caller = "");
        /// <summary>
        /// <c>MPP_RET mpp_buffer_set_offset_with_caller(MppBuffer buffer, size_t offset, const char* caller);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_buffer_set_offset_with_caller(IntPtr buffer, UInt64 offset, [CallerMemberName] [MarshalAs(UnmanagedType.LPStr)] string caller = "");
    }
}
