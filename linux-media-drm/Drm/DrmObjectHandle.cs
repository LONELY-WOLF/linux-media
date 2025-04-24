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
    }
}
