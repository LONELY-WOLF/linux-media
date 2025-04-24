using System.Runtime.InteropServices;

namespace LinuxMedia.Drm
{
    public abstract class DrmObjectHandle
    {
        protected int drm_fd;
        protected uint drm_handle;

        public int DrmFd
        {
            get
            {
                return drm_fd;
            }
        }

        public uint DrmHandle
        {
            get
            {
                return drm_handle;
            }
        }
        /// <summary>
        /// <c>drmModeObjectPropertiesPtr drmModeObjectGetProperties(int fd, uint32_t object_id, uint32_t object_type);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeObjectGetProperties(int fd, UInt32 object_id, UInt32 object_type);
        /// <summary>
        /// <c>void drmModeFreeObjectProperties(drmModeObjectPropertiesPtr ptr);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmModeFreeObjectProperties(IntPtr ptr);
        /// <summary>
        /// <c>int drmModeObjectSetProperty(int fd, uint32_t object_id, uint32_t object_type, uint32_t property_id, uint64_t value);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeObjectSetProperty(int fd, UInt32 object_id, UInt32 object_type, UInt32 property_id, UInt64 value);
    }
}
