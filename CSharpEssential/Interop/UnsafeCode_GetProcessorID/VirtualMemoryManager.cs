using System.ComponentModel;
using System.Runtime.InteropServices;

namespace UnsafeCode_GetProcessorID
{
    internal static class VirtualMemoryManager
    {
        // 1. 导入必要的 Win32 API
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetCurrentProcess();

        // 包装方法，便于在其他类中调用
        internal static IntPtr GetCurrentProcessHandle()
        {
            return GetCurrentProcess();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(
            IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize,
            AllocationType flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool VirtualFreeEx(
            IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, IntPtr dwFreeType);

        // 2. 定义枚举，对应 Win32 API 的常量
        [Flags]
        private enum AllocationType : uint
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
        }

        [Flags]
        private enum ProtectionOptions : uint
        {
            Execute = 0x10,
            PageExecuteRead = 0x20,
            PageExecuteReadWrite = 0x40,
        }

        [Flags]
        private enum MemoryFreeType : uint
        {
            Decommit = 0x4000,
            Release = 0x8000,
        }

        // 3. 核心包装方法：分配可执行内存
        // 这是 VirtualMemoryPtr 构造时真正调用的方法
        public static IntPtr AllocExecutionBlock(int size, IntPtr hProcess)
        {
            IntPtr codeBytesPtr = VirtualAllocEx(
                hProcess,
                IntPtr.Zero,
                (IntPtr)size,
                AllocationType.Reserve | AllocationType.Commit, // 保留并提交
                (uint)ProtectionOptions.PageExecuteReadWrite); // 关键：设置为可执行

            if (codeBytesPtr == IntPtr.Zero)
            {
                // 如果分配失败，抛出包含具体 Win32 错误的异常
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return codeBytesPtr;
        }

        // 重载版本，自动使用当前进程句柄
        public static IntPtr AllocExecutionBlock(int size)
        {
            return AllocExecutionBlock(size, GetCurrentProcessHandle());
        }

        // 4. 核心包装方法：释放内存
        // 这是 VirtualMemoryPtr.ReleaseHandle() 中调用的方法
        public static bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize)
        {
            bool result = VirtualFreeEx(
                hProcess,
                lpAddress,
                dwSize,
                (IntPtr)MemoryFreeType.Decommit); // 默认使用 Decommit

            if (!result)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return true;
        }

        public static bool VirtualFreeEx(IntPtr lpAddress, IntPtr dwSize)
        {
            return VirtualFreeEx(GetCurrentProcessHandle(), lpAddress, dwSize);
        }
    }
}
