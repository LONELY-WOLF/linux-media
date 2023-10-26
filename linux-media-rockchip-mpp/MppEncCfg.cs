using System.Runtime.InteropServices;

namespace LinuxMedia.Rockchip
{
    public class MppEncCfg : MppHandle, IDisposable
    {
        public MppEncCfg()
        {
            mpp_enc_cfg_init(ref Handle);
        }

        ~MppEncCfg()
        {
            Dispose();
        }

        public MPP_RET Set(string name, Int32 val)
        {
            return mpp_enc_cfg_set_s32(Handle, name, val);
        }

        public MPP_RET Set(string name, UInt32 val)
        {
            return mpp_enc_cfg_set_u32(Handle, name, val);
        }

        public MPP_RET Set(string name, Int64 val)
        {
            return mpp_enc_cfg_set_s64(Handle, name, val);
        }

        public MPP_RET Set(string name, UInt64 val)
        {
            return mpp_enc_cfg_set_u64(Handle, name, val);
        }

        public MPP_RET Set(string name, IntPtr val)
        {
            return mpp_enc_cfg_set_ptr(Handle, name, val);
        }



        #region Native calls
        /// <summary>
        /// <c>MPP_RET mpp_enc_cfg_init(ref IntPtr cfg);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_cfg_init(ref IntPtr cfg);
        /// <summary>
        /// <c>MPP_RET mpp_enc_cfg_deinit(IntPtr cfg);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_cfg_deinit(IntPtr cfg);

        /// <summary>
        /// <c>MPP_RET mpp_enc_cfg_set_s32(MppEncCfg cfg, const char* name, RK_S32 val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_cfg_set_s32(IntPtr cfg, [MarshalAs(UnmanagedType.LPStr)] string name, Int32 val);
        /// <summary>
        /// <c>MPP_RET mpp_enc_cfg_set_u32(MppEncCfg cfg, const char* name, RK_U32 val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_cfg_set_u32(IntPtr cfg, [MarshalAs(UnmanagedType.LPStr)] string name, UInt32 val);
        /// <summary>
        /// <c>MPP_RET mpp_enc_cfg_set_s64(MppEncCfg cfg, const char* name, RK_S64 val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_cfg_set_s64(IntPtr cfg, [MarshalAs(UnmanagedType.LPStr)] string name, Int64 val);
        /// <summary>
        /// <c>MPP_RET mpp_enc_cfg_set_u64(MppEncCfg cfg, const char* name, RK_U64 val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_cfg_set_u64(IntPtr cfg, [MarshalAs(UnmanagedType.LPStr)] string name, UInt64 val);
        /// <summary>
        /// <c>MPP_RET mpp_enc_cfg_set_ptr(MppEncCfg cfg, const char* name, void* val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_cfg_set_ptr(IntPtr cfg, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr val);
#if false
        /// <summary>
        /// <c>MPP_RET mpp_enc_cfg_set_st(MppEncCfg cfg, const char* name, void* val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_cfg_set_st(IntPtr cfg, [MarshalAs(UnmanagedType.LPStr)] string name, void* val);
#endif

        /// <summary>
        /// <c>MPP_RET mpp_enc_cfg_get_s32(MppEncCfg cfg, const char* name, RK_S32 *val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_cfg_get_s32(IntPtr cfg, [MarshalAs(UnmanagedType.LPStr)] string name, ref Int32 val);
        /// <summary>
        /// <c>MPP_RET mpp_enc_cfg_get_u32(MppEncCfg cfg, const char* name, RK_U32 *val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_cfg_get_u32(IntPtr cfg, [MarshalAs(UnmanagedType.LPStr)] string name, ref UInt32 val);
        /// <summary>
        /// <c>MPP_RET mpp_enc_cfg_get_s64(MppEncCfg cfg, const char* name, RK_S64 *val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_cfg_get_s64(IntPtr cfg, [MarshalAs(UnmanagedType.LPStr)] string name, ref Int64 val);
        /// <summary>
        /// <c>MPP_RET mpp_enc_cfg_get_u64(MppEncCfg cfg, const char* name, RK_U64 *val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_cfg_get_u64(IntPtr cfg, [MarshalAs(UnmanagedType.LPStr)] string name, ref UInt64 val);
        /// <summary>
        /// <c>MPP_RET mpp_enc_cfg_get_ptr(MppEncCfg cfg, const char* name, void** val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_cfg_get_ptr(IntPtr cfg, [MarshalAs(UnmanagedType.LPStr)] string name, ref IntPtr val);
#if false
        /// <summary>
        /// <c>MPP_RET mpp_enc_cfg_get_st(MppEncCfg cfg, const char* name, void* val);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_cfg_get_st(IntPtr cfg, [MarshalAs(UnmanagedType.LPStr)] string name, void* val);
#endif
        #endregion

        public void Dispose()
        {
            if (Handle != nint.Zero)
            {
                mpp_enc_cfg_deinit(Handle);
                Handle = nint.Zero;
            }
        }
    }
}
