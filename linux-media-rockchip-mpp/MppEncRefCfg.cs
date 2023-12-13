using System.Runtime.InteropServices;

namespace LinuxMedia.Rockchip
{
    public class MppEncRefCfg : MppHandle
    {
        public MppEncRefCfg()
        {
            mpp_enc_ref_cfg_init(ref Handle);
        }

        ~MppEncRefCfg()
        {
            mpp_enc_ref_cfg_deinit(ref Handle);
        }

        public MPP_RET Reset()
        {
            return mpp_enc_ref_cfg_reset(Handle);
        }

        public MPP_RET SetCfgCnt(Int32 lt_cnt, Int32 st_cnt)
        {
            return mpp_enc_ref_cfg_set_cfg_cnt(Handle, lt_cnt, st_cnt);
        }

        public MPP_RET AddLtCfg(MppEncRefLtFrmCfg[] frm)
        {
            return mpp_enc_ref_cfg_add_lt_cfg(Handle, frm.Length, frm);
        }

        public MPP_RET AddStCfg(MppEncRefStFrmCfg[] frm)
        {
            return mpp_enc_ref_cfg_add_st_cfg(Handle, frm.Length, frm);
        }

        public MPP_RET Check()
        {
            return mpp_enc_ref_cfg_check(Handle);
        }

        /// <summary>
        /// A new reference configure will restart a new gop and clear cpb by default. <br/>
        /// The keep cpb function will let encoder keeps the current cpb status and do NOT <br/>
        /// reset all the reference frame in cpb.
        /// </summary>
        public bool KeepCbp
        {
            set
            {
                mpp_enc_ref_cfg_set_keep_cpb(Handle, value ? 1 : 0);
            }
        }

        public MppEncRefPreset Preset
        {
            get
            {
                throw new NotImplementedException();
                //MppEncRefPreset p = new MppEncRefPreset;
                //mpp_enc_ref_cfg_get_preset(ref p);
                //return p;
            }
        }

        public MPP_RET Show()
        {
            return mpp_enc_ref_cfg_show(Handle);
        }

        #region Native calls
        /// <summary>
        /// <c>MPP_RET mpp_enc_ref_cfg_init(MppEncRefCfg*ref);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_ref_cfg_init(ref IntPtr cfg);
        /// <summary>
        /// <c>MPP_RET mpp_enc_ref_cfg_deinit(MppEncRefCfg*ref);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_ref_cfg_deinit(ref IntPtr cfg);

        /// <summary>
        /// <c>MPP_RET mpp_enc_ref_cfg_reset(MppEncRefCfg ref);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_ref_cfg_reset(IntPtr cfg);
        /// <summary>
        /// <c>MPP_RET mpp_enc_ref_cfg_set_cfg_cnt(MppEncRefCfg ref, RK_S32 lt_cnt, RK_S32 st_cnt);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_ref_cfg_set_cfg_cnt(IntPtr cfg, Int32 lt_cnt, Int32 st_cnt);
        /// <summary>
        /// <c>MPP_RET mpp_enc_ref_cfg_add_lt_cfg(MppEncRefCfg ref, RK_S32 cnt, MppEncRefLtFrmCfg* frm);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_ref_cfg_add_lt_cfg(IntPtr cfg, Int32 cnt, [In] MppEncRefLtFrmCfg[] frm);
        /// <summary>
        /// <c>MPP_RET mpp_enc_ref_cfg_add_st_cfg(MppEncRefCfg ref, RK_S32 cnt, MppEncRefStFrmCfg* frm);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_ref_cfg_add_st_cfg(IntPtr cfg, Int32 cnt, [In] MppEncRefStFrmCfg[] frm);
        /// <summary>
        /// <c>MPP_RET mpp_enc_ref_cfg_check(MppEncRefCfg ref);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_ref_cfg_check(IntPtr cfg);

        /// <summary>
        /// <c>MPP_RET mpp_enc_ref_cfg_set_keep_cpb(MppEncRefCfg ref, RK_S32 keep);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_ref_cfg_set_keep_cpb(IntPtr cfg, Int32 keep);
        /// <summary>
        /// <c>MPP_RET mpp_enc_ref_cfg_get_preset(MppEncRefPreset *preset);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_ref_cfg_get_preset(ref MppEncRefPreset preset);
        /// <summary>
        /// <c>MPP_RET mpp_enc_ref_cfg_show(MppEncRefCfg ref);</c>
        /// </summary>
        [DllImport("librockchip_mpp", SetLastError = true)]
        internal static extern MPP_RET mpp_enc_ref_cfg_show(IntPtr cfg);
        #endregion
    }

    public enum MppEncRefMode
    {
        /* max 32 mode in 32-bit */
        /* for default ref global config */
        REF_MODE_GLOBAL,
        REF_TO_PREV_REF_FRM = REF_MODE_GLOBAL,
        REF_TO_PREV_ST_REF,
        REF_TO_PREV_LT_REF,
        REF_TO_PREV_INTRA,

        /* for global config with args */
        REF_MODE_GLOBAL_WITH_ARG = 0x4,
        /// <summary>
        /// with ref arg as temporal layer id
        /// </summary>
        REF_TO_TEMPORAL_LAYER = REF_MODE_GLOBAL_WITH_ARG,
        /// <summary>
        /// with ref arg as long-term reference picture index
        /// </summary>
        REF_TO_LT_REF_IDX,
        /// <summary>
        /// with ref arg as short-term reference picture difference frame_num
        /// </summary>
        REF_TO_ST_PREV_N_REF,
        REF_MODE_GLOBAL_BUTT,

        /* for lt-ref */
        REF_MODE_LT = 0x18,
        REF_TO_ST_REF_SETUP,
        REF_MODE_LT_BUTT,

        /* for st-ref */
        REF_MODE_ST = 0x1C,
        REF_TO_LT_REF_SETUP,
        REF_MODE_ST_BUTT,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MppEncRefLtFrmCfg
    {
        /// <summary>
        /// lt_idx of the reference frame
        /// </summary>
        public Int32 lt_idx;
        /// <summary>
        /// temporal_id of the reference frame
        /// </summary>
        public Int32 temporal_id;
        public MppEncRefMode ref_mode;
        public Int32 ref_arg;
        /// <summary>
        /// gap between two lt-ref with same lt_idx
        /// </summary>
        public Int32 lt_gap;
        /// <summary>
        /// delay offset to igop start frame
        /// </summary>
        public Int32 lt_delay;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MppEncRefStFrmCfg
    {
        public Int32 is_non_ref;
        public Int32 temporal_id;
        public MppEncRefMode ref_mode;
        public Int32 ref_arg;
        /// <summary>
        /// repeat times
        /// </summary>
        public Int32 repeat;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MppEncRefPreset
    {
        /* input parameter for query */
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;
        public Int32 max_lt_cnt;
        public Int32 max_st_cnt;
        public IntPtr lt_cfg;
        public IntPtr st_cfg;

        /* output parameter */
        public Int32 lt_cnt;
        public Int32 st_cnt;
    }
}
