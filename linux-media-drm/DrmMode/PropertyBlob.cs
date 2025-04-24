using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class PropertyBlob : DrmModeObject
    {
        /// <summary>
        /// <c>drmModePropertyBlobPtr drmModeGetPropertyBlob(int fd, uint32_t blob_id);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeGetPropertyBlob(int fd, UInt32 blob_id);
#if false
        /// <summary>
        /// <c>bool drmModeFormatModifierBlobIterNext(const drmModePropertyBlobRes* blob, drmModeFormatModifierIterator *iter);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern bool drmModeFormatModifierBlobIterNext(const drmModePropertyBlobRes* blob, drmModeFormatModifierIterator *iter);
#endif
        /// <summary>
        /// <c>void drmModeFreePropertyBlob(drmModePropertyBlobPtr ptr);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmModeFreePropertyBlob(IntPtr ptr);
        /// <summary>
        /// <c>int drmModeCreatePropertyBlob(int fd, const void* data, size_t size, uint32_t* id);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeCreatePropertyBlob(int fd, IntPtr data, UInt64 size, ref UInt32 id);
        /// <summary>
        /// <c>int drmModeDestroyPropertyBlob(int fd, uint32_t id);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeDestroyPropertyBlob(int fd, UInt32 id);
    }
}
