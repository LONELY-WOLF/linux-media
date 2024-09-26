namespace LinuxMedia.Rockchip
{
    public abstract class MppHandle : IEquatable<MppHandle>
    {
        internal IntPtr Handle;
        public readonly bool IsCopy = false;

        protected MppHandle()
        {

        }

        protected MppHandle(nint handle)
        {
            IsCopy = true;
            Handle = handle;
        }

        /// <summary>
        /// Check if pointer is not null
        /// </summary>
        public bool IsValid
        {
            get
            {
                return Handle != 0;
            }
        }

        /// <summary>
        /// Get pointer
        /// </summary>
        /// <returns>Pointer to unmanaged struct</returns>
        public nint GetHandle()
        {
            return Handle;
        }

        public override bool Equals(object obj) => this.Equals(obj as MppHandle);

        public bool Equals(MppHandle? other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Handle == other.Handle;
        }
    }
}
