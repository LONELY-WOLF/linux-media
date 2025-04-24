using System.Runtime.InteropServices;

namespace LinuxMedia.Drm
{
    public class DRM
    {
        public readonly int FD;

        public static int Available
        {
            get
            {
                return drmAvailable();
            }
        }

        private DRM(int fd)
        {
            FD = fd;
            if (FD < 0)
            {
                throw new Exception($"Cannot open DRM {FD}");
            }
        }

        public DRM(string name, string busid)
        {
            FD = drmOpen(name, busid);
            if(FD < 0)
            {
                throw new Exception($"Cannot open DRM {FD}");
            }
        }

        public DRM(string name, string busid, int type)
        {
            FD = drmOpenWithType(name, busid, type);
            if (FD < 0)
            {
                throw new Exception($"Cannot open DRM {FD}");
            }
        }

        public static DRM OpenControl(int minor)
        {
            return new DRM(drmOpenControl(minor));
        }

        public static DRM OpenRender(int minor)
        {
            return new DRM(drmOpenRender(minor));
        }

        ~DRM()
        {
            drmClose(FD);
        }

        #region Native Calls
        /* General user-level programmer's API: unprivileged */
        /// <summary>
        /// <c>int drmAvailable(void);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAvailable();
        /// <summary>
        /// <c>int drmOpen(const char* name, const char* busid);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmOpen([MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string busid);

        /// <summary>
        /// <c>int drmOpenWithType(const char* name, const char* busid, int type);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmOpenWithType([MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string busid, int type);

        /// <summary>
        /// <c>int drmOpenControl(int minor);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        [Obsolete("deprecated: always fails")]
        internal static extern int drmOpenControl(int minor);
        /// <summary>
        /// <c> int drmOpenRender(int minor);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmOpenRender(int minor);
        /// <summary>
        /// <c>int drmClose(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmClose(int fd);
        /// <summary>
        /// <c>drmVersionPtr drmGetVersion(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmGetVersion(int fd);
        /// <summary>
        /// <c>drmVersionPtr drmGetLibVersion(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmGetLibVersion(int fd);
        /// <summary>
        /// <c>int drmGetCap(int fd, uint64_t capability, uint64_t* value);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetCap(int fd, UInt64 capability, ref UInt64 value);
        /// <summary>
        /// <c>void drmFreeVersion(drmVersionPtr);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmFreeVersion(IntPtr drmVersionPtr);
        /// <summary>
        /// <c>int drmGetMagic(int fd, drm_magic_t* magic);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetMagic(int fd, ref uint magic);
        /// <summary>
        /// <c>char* drmGetBusid(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern string drmGetBusid(int fd);
        /// <summary>
        /// <c>int drmGetInterruptFromBusID(int fd, int busnum, int devnum, int funcnum);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetInterruptFromBusID(int fd, int busnum, int devnum, int funcnum);
        /// <summary>
        /// <c>int drmGetMap(int fd, int idx, drm_handle_t* offset, drmSize* size, drmMapType* type, drmMapFlags* flags, drm_handle_t* handle, int* mtrr);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetMap(int fd, int idx, ref uint offset, IntPtr size, IntPtr type, IntPtr flags, ref uint handle, ref int mtrr);
        /// <summary>
        /// <c>int drmGetClient(int fd, int idx, int* auth, int* pid, int* uid, unsigned long* magic, unsigned long* iocs);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetClient(int fd, int idx, ref int auth, ref int pid, ref int uid, ref ulong magic, ref ulong iocs);
        /// <summary>
        /// <c>int drmGetStats(int fd, drmStatsT* stats);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetStats(int fd, IntPtr stats);
        /// <summary>
        /// <c>int drmSetInterfaceVersion(int fd, drmSetVersion* version);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSetInterfaceVersion(int fd, IntPtr version);
        /// <summary>
        /// <c>int drmCommandNone(int fd, unsigned long drmCommandIndex);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmCommandNone(int fd, ulong drmCommandIndex);
        /// <summary>
        /// <c>int drmCommandRead(int fd, unsigned long drmCommandIndex, void* data, unsigned long size);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmCommandRead(int fd, ulong drmCommandIndex, IntPtr data, ulong size);
        /// <summary>
        /// <c>int drmCommandWrite(int fd, unsigned long drmCommandIndex, void* data, unsigned long size);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmCommandWrite(int fd, ulong drmCommandIndex, IntPtr data, ulong size);
        /// <summary>
        /// <c>int drmCommandWriteRead(int fd, unsigned long drmCommandIndex, void* data, unsigned long size);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmCommandWriteRead(int fd, ulong drmCommandIndex, IntPtr data, ulong size);

        /* General user-level programmer's API: X server (root) only  */
        /// <summary>
        /// <c>void drmFreeBusid(const char* busid);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmFreeBusid([MarshalAs(UnmanagedType.LPStr)] string busid);
        /// <summary>
        /// <c></c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSetBusid(int fd, [MarshalAs(UnmanagedType.LPStr)] string busid);
        /// <summary>
        /// <c>int drmAuthMagic(int fd, drm_magic_t magic);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAuthMagic(int fd, uint magic);
        /// <summary>
        /// <c>int drmAddMap(int fd, drm_handle_t offset, drmSize size, drmMapType type, drmMapFlags flags, drm_handle_t* handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAddMap(int fd, uint offset, drmSize size, drmMapType type, drmMapFlags flags, ref uint handle);
        /// <summary>
        /// <c>int drmRmMap(int fd, drm_handle_t handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmRmMap(int fd, uint handle);
        /// <summary>
        /// <c>int drmAddContextPrivateMapping(int fd, drm_context_t ctx_id, drm_handle_t handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAddContextPrivateMapping(int fd, uint ctx_id, uint handle);

        /// <summary>
        /// <c>int drmAddBufs(int fd, int count, int size, drmBufDescFlags flags, int agp_offset);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmAddBufs(int fd, int count, int size, drmBufDescFlags flags, int agp_offset);
        /// <summary>
        /// <c>int drmMarkBufs(int fd, double low, double high);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmMarkBufs(int fd, double low, double high);
        /// <summary>
        /// <c>int drmCtlInstHandler(int fd, int irq);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmCtlInstHandler(int fd, int irq);
        /// <summary>
        /// <c>int drmCtlUninstHandler(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmCtlUninstHandler(int fd);
        /// <summary>
        /// <c>int drmSetClientCap(int fd, uint64_t capability, uint64_t value);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSetClientCap(int fd, UInt64 capability, UInt64 value);

        /// <summary>
        /// <c>int drmCrtcGetSequence(int fd, uint32_t crtcId, uint64_t* sequence, uint64_t* ns);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmCrtcGetSequence(int fd, UInt32 crtcId, ref UInt64 sequence, ref UInt64 ns);
        /// <summary>
        /// <c>int drmCrtcQueueSequence(int fd, uint32_t crtcId, uint32_t flags, uint64_t sequence, uint64_t* sequence_queued, uint64_t user_data);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmCrtcQueueSequence(int fd, UInt32 crtcId, UInt32 flags, UInt64 sequence, ref UInt64 sequence_queued, UInt64 user_data);
        /* General user-level programmer's API: authenticated client and/or X */
        /// <summary>
        /// <c>int drmMap(int fd, drm_handle_t handle, drmSize size, drmAddressPtr address);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmMap(int fd, uint handle, drmSize size, IntPtr address);
        /// <summary>
        /// <c>int drmUnmap(drmAddress address, drmSize size);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmUnmap(drmAddress address, drmSize size);
        /// <summary>
        /// <c>drmBufInfoPtr drmGetBufInfo(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmGetBufInfo(int fd);
        /// <summary>
        /// <c>drmBufMapPtr drmMapBufs(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmMapBufs(int fd);
        /// <summary>
        /// <c>int drmUnmapBufs(drmBufMapPtr bufs);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmUnmapBufs(IntPtr bufs);
        /// <summary>
        /// <c>int drmDMA(int fd, drmDMAReqPtr request);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmDMA(int fd, IntPtr request);
        /// <summary>
        /// <c>int drmFreeBufs(int fd, int count, int* list);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmFreeBufs(int fd, int count, ref int list);
        /// <summary>
        /// <c>int drmGetLock(int fd, drm_context_t context, drmLockFlags flags);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetLock(int fd, uint context, drmLockFlags flags);
        /// <summary>
        /// <c>int drmUnlock(int fd, drm_context_t context);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmUnlock(int fd, uint context);
        /// <summary>
        /// <c>int drmFinish(int fd, int context, drmLockFlags flags);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmFinish(int fd, int context, drmLockFlags flags);
        /// <summary>
        /// <c>int drmGetContextPrivateMapping(int fd, drm_context_t ctx_id, drm_handle_t* handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetContextPrivateMapping(int fd, uint ctx_id, ref uint handle);


        /// <summary>
        /// <c>int drmWaitVBlank(int fd, drmVBlankPtr vbl);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmWaitVBlank(int fd, IntPtr vbl);

        /* Support routines */
        /// <summary>
        /// <c>void drmSetServerInfo(drmServerInfoPtr info);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmSetServerInfo(IntPtr info);
        /// <summary>
        /// <c>int drmError(int err, const char* label);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmError(int err, [MarshalAs(UnmanagedType.LPStr)] string label);
        /// <summary>
        /// <c>void* drmMalloc(int size);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmMalloc(int size);
        /// <summary>
        /// <c>void drmFree(void* pt);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmFree(IntPtr pt);

        /// <summary>
        /// <c>int drmOpenOnce(void* unused, const char* BusID, int* newlyopened);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmOpenOnce(IntPtr unused, [MarshalAs(UnmanagedType.LPStr)] string BusID, ref int newlyopened);
        /// <summary>
        /// <c>int drmOpenOnceWithType(const char* BusID, int* newlyopened, int type);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmOpenOnceWithType([MarshalAs(UnmanagedType.LPStr)] string BusID, ref int newlyopened, int type);
        /// <summary>
        /// <c>void drmCloseOnce(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmCloseOnce(int fd);
#if false
        /// <summary>
        /// <c>void drmMsg(const char* format, ...) DRM_PRINTFLIKE(1, 2);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmMsg(const char* format, ...) DRM_PRINTFLIKE(1, 2);
#endif

        /// <summary>
        /// <c>int drmSetMaster(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmSetMaster(int fd);
        /// <summary>
        /// <c>int drmDropMaster(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmDropMaster(int fd);
        /// <summary>
        /// <c>int drmIsMaster(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmIsMaster(int fd);

        /// <summary>
        /// <c>int drmHandleEvent(int fd, drmEventContextPtr evctx);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmHandleEvent(int fd, IntPtr evctx);

        /// <summary>
        /// <c>char* drmGetDeviceNameFromFd(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern string drmGetDeviceNameFromFd(int fd);

        /* Improved version of drmGetDeviceNameFromFd which attributes for any type of
         * device/node - card or renderD.
         */
        /// <summary>
        /// <c>char* drmGetDeviceNameFromFd2(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern string drmGetDeviceNameFromFd2(int fd);
        /// <summary>
        /// <c>int drmGetNodeTypeFromFd(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmGetNodeTypeFromFd(int fd);

        /* Convert between GEM handles and DMA-BUF file descriptors.
         *
         * Warning: since GEM handles are not reference-counted and are unique per
         * DRM file description, the caller is expected to perform its own reference
         * counting. drmPrimeFDToHandle is guaranteed to return the same handle for
         * different FDs if they reference the same underlying buffer object. This
         * could even be a buffer object originally created on the same DRM FD.
         *
         * When sharing a DRM FD with an API such as EGL or GBM, the caller must not
         * use drmPrimeHandleToFD nor drmPrimeFDToHandle. A single user-space
         * reference-counting implementation is necessary to avoid double-closing GEM
         * handles.
         *
         * Two processes can't share the same DRM FD and both use it to create or
         * import GEM handles, even when using a single user-space reference-counting
         * implementation like GBM, because GBM doesn't share its state between
         * processes.
         */
        /// <summary>
        /// <c>int drmPrimeHandleToFD(int fd, uint32_t handle, uint32_t flags, int* prime_fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmPrimeHandleToFD(int fd, UInt32 handle, UInt32 flags, ref int prime_fd);
        /// <summary>
        /// <c>int drmPrimeFDToHandle(int fd, int prime_fd, uint32_t* handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmPrimeFDToHandle(int fd, int prime_fd, ref UInt32 handle);

        /// <summary>
        /// <c>int drmCloseBufferHandle(int fd, uint32_t handle);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmCloseBufferHandle(int fd, UInt32 handle);

        /// <summary>
        /// <c>char* drmGetPrimaryDeviceNameFromFd(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern string drmGetPrimaryDeviceNameFromFd(int fd);
        /// <summary>
        /// <c>char* drmGetRenderDeviceNameFromFd(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern string drmGetRenderDeviceNameFromFd(int fd);

        /// <summary>
        /// <c>char* drmGetFormatModifierVendor(uint64_t modifier);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern string drmGetFormatModifierVendor(UInt64 modifier);

        /// <summary>
        /// <c>char* drmGetFormatModifierName(uint64_t modifier);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern string drmGetFormatModifierName(UInt64 modifier);

        /// <summary>
        /// <c>char* drmGetFormatName(uint32_t format);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern string drmGetFormatName(UInt32 format);
        /**
         * Check whether the DRM node supports Kernel Mode-Setting.
         *
         * Returns 1 if suitable for KMS, 0 otherwise.
         */
        /// <summary>
        /// <c>int drmIsKMS(int fd);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmIsKMS(int fd);
        /// <summary>
        /// <c>int drmCheckModesettingSupported(const char* busid);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmCheckModesettingSupported([MarshalAs(UnmanagedType.LPStr)] string busid);
        #endregion
    }
}