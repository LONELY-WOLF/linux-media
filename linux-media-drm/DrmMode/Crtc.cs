using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class Crtc : DrmModeObject
    {
        /// <summary>
        /// <c>void drmModeFreeCrtc(drmModeCrtcPtr ptr);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmModeFreeCrtc(IntPtr ptr);
        /*
         * Crtc functions
         */

        /**
         * Retrieve information about the ctrt crtcId
         */
        /// <summary>
        /// <c>drmModeCrtcPtr drmModeGetCrtc(int fd, uint32_t crtcId);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeGetCrtc(int fd, UInt32 crtcId);

        /**
         * Set the mode on a crtc crtcId with the given mode modeId.
         */
        /// <summary>
        /// <c>int drmModeSetCrtc(int fd, uint32_t crtcId, uint32_t bufferId, uint32_t x, uint32_t y, uint32_t* connectors, int count, drmModeModeInfoPtr mode);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeSetCrtc(int fd, UInt32 crtcId, UInt32 bufferId, UInt32 x, UInt32 y, [MarshalAs(UnmanagedType.LPArray)] UInt32 connectors, int count, IntPtr mode);
        /// <summary>
        /// <c>int drmModeCrtcSetGamma(int fd, uint32_t crtc_id, uint32_t size, const uint16_t* red, const uint16_t* green, const uint16_t* blue);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeCrtcSetGamma(int fd, UInt32 crtc_id, UInt32 size, [MarshalAs(UnmanagedType.LPArray)] UInt16 red, [MarshalAs(UnmanagedType.LPArray)] UInt16 green, [MarshalAs(UnmanagedType.LPArray)] UInt16 blue);
        /// <summary>
        /// <c>int drmModeCrtcGetGamma(int fd, uint32_t crtc_id, uint32_t size, uint16_t* red, uint16_t* green, uint16_t* blue);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeCrtcGetGamma(int fd, UInt32 crtc_id, UInt32 size, [MarshalAs(UnmanagedType.LPArray)] UInt16 red, [MarshalAs(UnmanagedType.LPArray)] UInt16 green, [MarshalAs(UnmanagedType.LPArray)] UInt16 blue);

        /// <summary>
        /// <c>int drmModePageFlip(int fd, uint32_t crtc_id, uint32_t fb_id, uint32_t flags, void* user_data);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModePageFlip(int fd, UInt32 crtc_id, UInt32 fb_id, UInt32 flags, IntPtr user_data);
        /// <summary>
        /// <c>int drmModePageFlipTarget(int fd, uint32_t crtc_id, uint32_t fb_id, uint32_t flags, void* user_data, uint32_t target_vblank);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModePageFlipTarget(int fd, UInt32 crtc_id, UInt32 fb_id, UInt32 flags, IntPtr user_data, UInt32 target_vblank);
        /**
         * Set the cursor on crtc
         */
        /// <summary>
        /// <c>int drmModeSetCursor(int fd, uint32_t crtcId, uint32_t bo_handle, uint32_t width, uint32_t height);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeSetCursor(int fd, UInt32 crtcId, UInt32 bo_handle, UInt32 width, UInt32 height);

        /// <summary>
        /// <c>int drmModeSetCursor2(int fd, uint32_t crtcId, uint32_t bo_handle, uint32_t width, uint32_t height, int32_t hot_x, int32_t hot_y);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeSetCursor2(int fd, UInt32 crtcId, UInt32 bo_handle, UInt32 width, UInt32 height, UInt32 hot_x, UInt32 hot_y);
        /**
         * Move the cursor on crtc
         */
        /// <summary>
        /// <c>int drmModeMoveCursor(int fd, uint32_t crtcId, int x, int y);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeMoveCursor(int fd, UInt32 crtcId, int x, int y);
    }
}
