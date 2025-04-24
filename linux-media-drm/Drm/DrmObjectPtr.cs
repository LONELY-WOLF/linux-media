namespace LinuxMedia.Drm
{
    public abstract class DrmObjectPtr
    {
        protected IntPtr ptr_handle;

        public IntPtr PtrHandle
        {
            get
            {
                return ptr_handle;
            }
        }
    }
}
