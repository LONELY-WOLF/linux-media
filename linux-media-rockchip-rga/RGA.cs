using System.Runtime.InteropServices;

namespace LinuxMedia.Rockchip
{
    public static class RGA
    {
        public static int Blit(rga_info src, rga_info dst, rga_info src1)
        {
            IntPtr src_ptr = Marshal.AllocHGlobal(Marshal.SizeOf(src));
            Marshal.StructureToPtr(src, src_ptr, true);
            IntPtr dst_ptr = Marshal.AllocHGlobal(Marshal.SizeOf(dst));
            Marshal.StructureToPtr(dst, dst_ptr, true);
            IntPtr src1_ptr = Marshal.AllocHGlobal(Marshal.SizeOf(src1));
            Marshal.StructureToPtr(src1, src1_ptr, true);

            int ret = c_RkRgaBlit(src_ptr, dst_ptr, src1_ptr);
            //src = Marshal.PtrToStructure<rga_info>(src_ptr);
            //dst = Marshal.PtrToStructure<rga_info>(dst_ptr);
            //src1 = Marshal.PtrToStructure<rga_info>(src1_ptr);

            return ret;
        }

        public static int Blit(rga_info src, rga_info dst)
        {
            IntPtr src_ptr = Marshal.AllocHGlobal(Marshal.SizeOf(src));
            Marshal.StructureToPtr(src, src_ptr, true);
            IntPtr dst_ptr = Marshal.AllocHGlobal(Marshal.SizeOf(dst));
            Marshal.StructureToPtr(dst, dst_ptr, true);

            int ret = c_RkRgaBlit(src_ptr, dst_ptr, IntPtr.Zero);
            //src = Marshal.PtrToStructure<rga_info>(src_ptr);
            //dst = Marshal.PtrToStructure<rga_info>(dst_ptr);

            return ret;
        }

        public static int ColorFill(rga_info dst)
        {
            IntPtr dst_ptr = Marshal.AllocHGlobal(Marshal.SizeOf(dst));
            Marshal.StructureToPtr(dst, dst_ptr, true);

            int ret = c_RkRgaColorFill(dst_ptr);
            //dst = Marshal.PtrToStructure<rga_info>(dst_ptr);

            return ret;
        }

        public static int Flush()
        {
            return c_RkRgaFlush();
        }

        [DllImport("librga", SetLastError = true)]
        private static extern int c_RkRgaBlit(IntPtr src, IntPtr dst, IntPtr src1);

        [DllImport("librga", SetLastError = true)]
        private static extern int c_RkRgaColorFill(IntPtr dst);

        [DllImport("librga", SetLastError = true)]
        private static extern int c_RkRgaFlush();
    }
}