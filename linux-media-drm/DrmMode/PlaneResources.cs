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
            UInt32[] plane_ids = Utils.ReadUInt32Array(planeResources.planes, planeResources.count_planes);
            Plane[] planes = plane_ids.Select<uint, Plane>(id => new Plane(this, id)).ToArray();
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
