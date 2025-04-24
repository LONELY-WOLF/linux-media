using LinuxMedia.Drm.Mode;
using System.Runtime.InteropServices;

namespace LinuxMedia.Drm
{
    public partial class DRM
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct PlaneResources
        {
            public UInt32 count_planes;
            public IntPtr planes;
        }

        public Plane[] GetPlaneResources()
        {
            IntPtr plane_res_ptr = drmModeGetPlaneResources(FD);
            PlaneResources planeResources = Marshal.PtrToStructure<PlaneResources>(plane_res_ptr);
            Plane[] planes = new Plane[planeResources.count_planes];
            for (int i = 0; i < planeResources.count_planes; i++)
            {
                uint plane_id = (uint)Marshal.ReadInt32(planeResources.planes, i * Marshal.SizeOf<UInt32>());
                planes[i] = new Plane(this, plane_id);
            }
            return planes;
        }

        /// <summary>
        /// <c>void drmModeFreePlaneResources(drmModePlaneResPtr ptr);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmModeFreePlaneResources(IntPtr ptr);
        /// <summary>
        /// <c>drmModePlaneResPtr drmModeGetPlaneResources(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeGetPlaneResources(int fd);
    }
}
