using System.Runtime.InteropServices;

namespace LinuxMedia.Drm
{
    public class SkipList : DrmObjectPtr
    {
        public SkipList()
        {
            ptr_handle = drmSLCreate();
        }

        ~SkipList()
        {
            drmSLDestroy(PtrHandle);
        }

        public IntPtr Lookup(ulong key)
        {
            IntPtr value = IntPtr.Zero;
            drmSLLookup(PtrHandle, key, ref value);
            return value;
        }

        public void Insert(ulong key, IntPtr value)
        {
            drmSLInsert(PtrHandle, key, value);
        }

        public void Delete(ulong key)
        {
            drmSLDelete(PtrHandle, key);
        }

        public void Next(ref ulong key, ref IntPtr value)
        {
            drmSLNext(PtrHandle, ref key, ref value);
        }

        public void First(ref ulong key, ref IntPtr value)
        {
            drmSLFirst(PtrHandle, ref key, ref value);
        }

        public void Dump()
        {
            drmSLDump(PtrHandle);
        }

        public void LookupNeighbors(ulong key, ref ulong prev_key, ref IntPtr prev_value, ref ulong next_key, ref IntPtr next_value)
        {
            drmSLLookupNeighbors(PtrHandle, key, ref prev_key, ref prev_value, ref next_key, ref next_value);
        }

        /* Skip list routines */

        /// <summary>
        /// <c>void* drmSLCreate(void);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmSLCreate();
        /// <summary>
        /// <c>int drmSLDestroy(void* l);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSLDestroy(IntPtr l);
        /// <summary>
        /// <c>int drmSLLookup(void* l, unsigned long key, void** value);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSLLookup(IntPtr l, ulong key, ref IntPtr value);
        /// <summary>
        /// <c>int drmSLInsert(void* l, unsigned long key, void* value);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSLInsert(IntPtr l, ulong key, IntPtr value);
        /// <summary>
        /// <c>int drmSLDelete(void* l, unsigned long key);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSLDelete(IntPtr l, ulong key);
        /// <summary>
        /// <c>int drmSLNext(void* l, unsigned long* key, void** value);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSLNext(IntPtr l, ref ulong key, ref IntPtr value);
        /// <summary>
        /// <c>int drmSLFirst(void* l, unsigned long* key, void** value);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSLFirst(IntPtr l, ref ulong key, ref IntPtr value);
        /// <summary>
        /// <c>void drmSLDump(void* l);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmSLDump(IntPtr l);
        /// <summary>
        /// <c>int drmSLLookupNeighbors(void* l, unsigned long key, unsigned long* prev_key, void** prev_value, unsigned long* next_key, void** next_value);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSLLookupNeighbors(IntPtr l, ulong key, ref ulong prev_key, ref IntPtr prev_value, ref ulong next_key, ref IntPtr next_value);
    }
}
