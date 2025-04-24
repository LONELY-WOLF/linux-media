using System.Runtime.InteropServices;

namespace LinuxMedia.Drm
{
    public class Hash
    {
        /* Hash table routines */
        /// <summary>
        /// <c>void* drmHashCreate(void);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmHashCreate();
        /// <summary>
        /// <c>int drmHashDestroy(void* t);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmHashDestroy(IntPtr t);
        /// <summary>
        /// <c>int drmHashLookup(void* t, unsigned long key, void** value);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmHashLookup(IntPtr t, ulong key, ref IntPtr value);
        /// <summary>
        /// <c>int drmHashInsert(void* t, unsigned long key, void* value);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmHashInsert(IntPtr t, ulong key, IntPtr value);
        /// <summary>
        /// <c>int drmHashDelete(void* t, unsigned long key);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmHashDelete(IntPtr t, ulong key);
        /// <summary>
        /// <c>int drmHashFirst(void* t, unsigned long* key, void** value);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmHashFirst(IntPtr t, ref ulong key, ref IntPtr value);
        /// <summary>
        /// <c>int drmHashNext(void* t, unsigned long* key, void** value);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmHashNext(IntPtr t, ref ulong key, ref IntPtr value);
    }
}
