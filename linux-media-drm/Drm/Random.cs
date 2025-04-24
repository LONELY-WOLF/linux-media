using System.Runtime.InteropServices;

namespace LinuxMedia.Drm
{
    public class Random : DrmObjectPtr
    {
        public Random(ulong seed)
        {
            ptr_handle = drmRandomCreate(seed);
        }

        ~Random()
        {
            drmRandomDestroy(PtrHandle);
        }

        public ulong Random()
        {
            return drmRandom(PtrHandle);
        }

        public double RandomDouble()
        {
            return drmRandomDouble(PtrHandle);
        }

        /* PRNG routines */
        /// <summary>
        /// <c>void* drmRandomCreate(unsigned long seed);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmRandomCreate(ulong seed);
        /// <summary>
        /// <c>int drmRandomDestroy(void* state);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmRandomDestroy(IntPtr state);
        /// <summary>
        /// <c>unsigned long drmRandom(void* state);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern ulong drmRandom(IntPtr state);
        /// <summary>
        /// <c>double drmRandomDouble(void* state);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern double drmRandomDouble(IntPtr state);
    }
}
