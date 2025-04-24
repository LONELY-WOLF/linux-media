using System.Runtime.InteropServices;

namespace LinuxMedia.Drm
{
    public class Drawable : DrmObjectHandle
    {
        public Drawable(int fd)
        {
            drm_fd = fd;

            drmCreateDrawable(drm_fd, ref drm_handle);
        }

        ~Drawable()
        {
            drmDestroyDrawable(drm_fd, drm_handle);
        }

        /// <summary>
        /// <c>int drmCreateDrawable(int fd, drm_drawable_t* handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmCreateDrawable(int fd, ref uint handle);
        /// <summary>
        /// <c>int drmDestroyDrawable(int fd, drm_drawable_t handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmDestroyDrawable(int fd, uint handle);
        /// <summary>
        /// <c>int drmUpdateDrawableInfo(int fd, drm_drawable_t handle, drm_drawable_info_type_t type, unsigned int num, void* data);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmUpdateDrawableInfo(int fd, uint handle, drm_drawable_info_type_t type, uint num, IntPtr data);
    }
}
