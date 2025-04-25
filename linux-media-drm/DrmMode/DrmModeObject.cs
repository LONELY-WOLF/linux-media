using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public abstract class DrmModeObject
    {
        public abstract Type ObjectType { get; }

        public UInt32 ID { get; protected set; }
        public int DRM_FD { get; protected set; }

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

        public enum Type : UInt32
        {
            CRTC = 0xcccccccc,
            CONNECTOR = 0xc0c0c0c0,
            ENCODER = 0xe0e0e0e0,
            MODE = 0xdededede,
            PROPERTY = 0xb0b0b0b0,
            FB = 0xfbfbfbfb,
            BLOB = 0xbbbbbbbb,
            PLANE = 0xeeeeeeee,
            ANY = 0,
        }
    }
}
