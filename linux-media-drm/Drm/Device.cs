using System.Runtime.InteropServices;

namespace LinuxMedia.Drm
{
    public class Device : DrmObjectPtr
    {
        public Device(int fd)
        {
            drmGetDevice(fd, ref ptr_handle);
        }

        public Device(int fd, UInt32 flags)
        {
            drmGetDevice2(fd, flags, ref ptr_handle);
        }

        public Device(UInt32 dev_id, UInt32 flags)
        {
            drmGetDeviceFromDevId(dev_id, flags, ref ptr_handle);
        }

        ~Device()
        {
            drmFreeDevice(ref ptr_handle);
        }

        /// <summary>
        /// <c>int drmGetDevice(int fd, drmDevicePtr* device);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetDevice(int fd, ref IntPtr device);
        /// <summary>
        /// <c>void drmFreeDevice(drmDevicePtr* device);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmFreeDevice(ref IntPtr device);

        /// <summary>
        /// <c>int drmGetDevices(drmDevicePtr devices[], int max_devices);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetDevices(IntPtr devices, int max_devices);
        /// <summary>
        /// <c>void drmFreeDevices(drmDevicePtr devices[], int count);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmFreeDevices(IntPtr devices, int count);

        /// <summary>
        /// <c>int drmGetDevice2(int fd, uint32_t flags, drmDevicePtr* device);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetDevice2(int fd, UInt32 flags, ref IntPtr device);
        /// <summary>
        /// <c>int drmGetDevices2(uint32_t flags, drmDevicePtr devices[], int max_devices);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetDevices2(UInt32 flags, IntPtr devices, int max_devices);

        /// <summary>
        /// <c>int drmGetDeviceFromDevId(dev_t dev_id, uint32_t flags, drmDevicePtr* device);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetDeviceFromDevId(UInt32 dev_id, UInt32 flags, ref IntPtr device);

        /// <summary>
        /// <c>int drmDevicesEqual(drmDevicePtr a, drmDevicePtr b);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmDevicesEqual(IntPtr a, IntPtr b);
    }
}
