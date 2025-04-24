using System.Runtime.InteropServices;

namespace LinuxMedia.Drm.Mode
{
    public class Connector : DrmModeObject
    {

        /// <summary>
        /// <c>void drmModeFreeConnector(drmModeConnectorPtr ptr);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern void drmModeFreeConnector(IntPtr ptr);

        /**
         * Retrieve all information about the connector connectorId. This will do a
         * forced probe on the connector to retrieve remote information such as EDIDs
         * from the display device.
         */
        /// <summary>
        /// <c>drmModeConnectorPtr drmModeGetConnector(int fd, uint32_t connectorId);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeGetConnector(int fd, UInt32 connectorId);

        /**
         * Retrieve current information, i.e the currently active mode and encoder,
         * about the connector connectorId. This will not do any probing on the
         * connector or remote device, and only reports what is currently known.
         * For the complete set of modes and encoders associated with the connector
         * use drmModeGetConnector() which will do a probe to determine any display
         * link changes first.
         */
        /// <summary>
        /// <c>drmModeConnectorPtr drmModeGetConnectorCurrent(int fd, uint32_t connector_id);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern IntPtr drmModeGetConnectorCurrent(int fd, UInt32 connector_id);

        /**
         * Get a bitmask of CRTCs a connector is compatible with.
         *
         * The bits reference CRTC indices. If the n-th CRTC is compatible with the
         * connector, the n-th bit will be set. The indices are taken from the array
         * returned by drmModeGetResources(). The indices are different from the object
         * IDs.
         *
         * Zero is returned on error.
         */
        /// <summary>
        /// <c>uint32_t drmModeConnectorGetPossibleCrtcs(int fd, const drmModeConnector* connector);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern UInt32 drmModeConnectorGetPossibleCrtcs(int fd, IntPtr connector);

        /**
         * Attaches the given mode to an connector.
         */
        /// <summary>
        /// <c>int drmModeAttachMode(int fd, uint32_t connectorId, drmModeModeInfoPtr mode_info);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeAttachMode(int fd, UInt32 connectorId, IntPtr mode_info);

        /**
         * Detaches a mode from the connector
         * must be unused, by the given mode.
         */
        /// <summary>
        /// <c>int drmModeDetachMode(int fd, uint32_t connectorId, drmModeModeInfoPtr mode_info);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeDetachMode(int fd, UInt32 connectorId, IntPtr mode_info);
        /// <summary>
        /// <c>int drmModeConnectorSetProperty(int fd, uint32_t connector_id, uint32_t property_id, uint64_t value);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        internal static extern int drmModeConnectorSetProperty(int fd, UInt32 connector_id, UInt32 property_id, UInt64 value);
        /**
         * Get a string describing a connector type.
         *
         * NULL is returned if the connector type is unsupported. Callers should handle
         * this gracefully, e.g. by falling back to "Unknown" or printing the raw value.
         */
        /// <summary>
        /// <c>const char* drmModeGetConnectorTypeName(uint32_t connector_type);</c>
        /// </summary>
        [DllImport("libdrm", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern string drmModeGetConnectorTypeName(UInt32 connector_type);
    }
}
