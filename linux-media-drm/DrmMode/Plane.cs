using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class Plane : DrmObjectPtr
    {
        /// <summary>
        /// <c>void drmModeFreePlane(drmModePlanePtr ptr);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmModeFreePlane(IntPtr ptr);
        /// <summary>
        /// <c>drmModePlanePtr drmModeGetPlane(int fd, uint32_t plane_id);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeGetPlane(int fd, UInt32 plane_id);
        /// <summary>
        /// <c>int drmModeSetPlane(int fd, uint32_t plane_id, uint32_t crtc_id, uint32_t fb_id, uint32_t flags, int32_t crtc_x, int32_t crtc_y, uint32_t crtc_w, uint32_t crtc_h, uint32_t src_x, uint32_t src_y, uint32_t src_w, uint32_t src_h);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeSetPlane(int fd, UInt32 plane_id, UInt32 crtc_id, UInt32 fb_id, UInt32 flags, Int32 crtc_x, Int32 crtc_y, UInt32 crtc_w, UInt32 crtc_h, UInt32 src_x, UInt32 src_y, UInt32 src_w, UInt32 src_h);
    }
}
