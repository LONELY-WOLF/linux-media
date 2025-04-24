using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class Atomic : DrmModePtr
    {
        /// <summary>
        /// <c>drmModeAtomicReqPtr drmModeAtomicAlloc(void);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeAtomicAlloc();
        /// <summary>
        /// <c>drmModeAtomicReqPtr drmModeAtomicDuplicate(const drmModeAtomicReqPtr req);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeAtomicDuplicate(IntPtr req);
        /// <summary>
        /// <c>int drmModeAtomicMerge(drmModeAtomicReqPtr base, const drmModeAtomicReqPtr augment);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeAtomicMerge(IntPtr _base, IntPtr augment);
        /// <summary>
        /// <c>void drmModeAtomicFree(drmModeAtomicReqPtr req);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmModeAtomicFree(IntPtr req);
        /// <summary>
        /// <c>int drmModeAtomicGetCursor(const drmModeAtomicReqPtr req);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeAtomicGetCursor(IntPtr req);
        /// <summary>
        /// <c>void drmModeAtomicSetCursor(drmModeAtomicReqPtr req, int cursor);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmModeAtomicSetCursor(IntPtr req, int cursor);
        /// <summary>
        /// <c>int drmModeAtomicAddProperty(drmModeAtomicReqPtr req, uint32_t object_id, uint32_t property_id, uint64_t value);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeAtomicAddProperty(IntPtr req, UInt32 object_id, UInt32 property_id, UInt64 value);
        /// <summary>
        /// <c>int drmModeAtomicCommit(int fd, const drmModeAtomicReqPtr req, uint32_t flags, void* user_data);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeAtomicCommit(int fd, IntPtr req, UInt32 flags, IntPtr user_data);
    }
}
