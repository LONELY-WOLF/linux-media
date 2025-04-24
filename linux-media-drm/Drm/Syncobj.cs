using System.Runtime.InteropServices;

namespace LinuxMedia.Drm
{
    public class Syncobj
    {
        /// <summary>
        /// <c>int drmSyncobjCreate(int fd, uint32_t flags, uint32_t* handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjCreate(int fd, UInt32 flags, ref UInt32 handle);
        /// <summary>
        /// <c>int drmSyncobjDestroy(int fd, uint32_t handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjDestroy(int fd, UInt32 handle);
        /// <summary>
        /// <c>int drmSyncobjHandleToFD(int fd, uint32_t handle, int* obj_fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjHandleToFD(int fd, UInt32 handle, ref int obj_fd);
        /// <summary>
        /// <c>int drmSyncobjFDToHandle(int fd, int obj_fd, uint32_t* handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjFDToHandle(int fd, int obj_fd, ref UInt32 handle);

        /// <summary>
        /// <c>int drmSyncobjImportSyncFile(int fd, uint32_t handle, int sync_file_fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjImportSyncFile(int fd, UInt32 handle, int sync_file_fd);
        /// <summary>
        /// <c>int drmSyncobjExportSyncFile(int fd, uint32_t handle, int* sync_file_fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjExportSyncFile(int fd, UInt32 handle, ref int sync_file_fd);
        /// <summary>
        /// <c>int drmSyncobjWait(int fd, uint32_t* handles, unsigned num_handles, int64_t timeout_nsec, unsigned flags, uint32_t* first_signaled);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjWait(int fd, ref UInt32 handles, uint num_handles, Int64 timeout_nsec, uint flags, ref UInt32 first_signaled);
        /// <summary>
        /// <c>int drmSyncobjReset(int fd, const uint32_t* handles, uint32_t handle_count);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjReset(int fd, IntPtr handles, UInt32 handle_count);
        /// <summary>
        /// <c>int drmSyncobjSignal(int fd, const uint32_t* handles, uint32_t handle_count);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjSignal(int fd, IntPtr handles, UInt32 handle_count);
        /// <summary>
        /// <c>int drmSyncobjTimelineSignal(int fd, const uint32_t* handles, uint64_t* points, uint32_t handle_count);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjTimelineSignal(int fd, IntPtr handles, IntPtr points, UInt32 handle_count);
        /// <summary>
        /// <c>int drmSyncobjTimelineWait(int fd, uint32_t* handles, uint64_t* points, unsigned num_handles, int64_t timeout_nsec, unsigned flags, uint32_t* first_signaled);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjTimelineWait(int fd, IntPtr handles, IntPtr points, uint num_handles, Int64 timeout_nsec, uint flags, IntPtr first_signaled);
        /// <summary>
        /// <c>int drmSyncobjQuery(int fd, uint32_t* handles, uint64_t* points, uint32_t handle_count);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjQuery(int fd, IntPtr handles, IntPtr points, UInt32 handle_count);
        /// <summary>
        /// <c>int drmSyncobjQuery2(int fd, uint32_t* handles, uint64_t* points, uint32_t handle_count, uint32_t flags);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjQuery2(int fd, IntPtr handles, IntPtr points, UInt32 handle_count, UInt32 flags);
        /// <summary>
        /// <c>int drmSyncobjTransfer(int fd, uint32_t dst_handle, uint64_t dst_point, uint32_t src_handle, uint64_t src_point, uint32_t flags);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjTransfer(int fd, UInt32 dst_handle, UInt64 dst_point, UInt32 src_handle, UInt64 src_point, UInt32 flags);
        /// <summary>
        /// <c>int drmSyncobjEventfd(int fd, uint32_t handle, uint64_t point, int ev_fd, uint32_t flags);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSyncobjEventfd(int fd, UInt32 handle, UInt64 point, int ev_fd, UInt32 flags);
    }
}
