namespace UnsafeCode_GetProcessorID
{
    public class VirtualMemoryPtr : System.Runtime.InteropServices.SafeHandle
    {
        public VirtualMemoryPtr(int memorySize) : base(IntPtr.Zero, true)
        {
            _ProcessHandle = VirtualMemoryManager.GetCurrentProcessHandle();
            _MemorySize = (IntPtr)memorySize;
            _AllocatedPointer = VirtualMemoryManager.AllocExecutionBlock(
                memorySize, _ProcessHandle);
            _Disposed = false;
        }

        public readonly IntPtr _AllocatedPointer;
        readonly IntPtr _ProcessHandle;
        readonly IntPtr _MemorySize;
        bool _Disposed;

        public static implicit operator IntPtr(VirtualMemoryPtr virtualMemoryPointer)
        {
            return virtualMemoryPointer._AllocatedPointer;
        }

        // SafeHandle 抽象成员：指示句柄是否无效
        public override bool IsInvalid
        {
            get { return _Disposed; }
        }

        // SafeHandle 抽象成员：在此执行实际的清理代码
        protected override bool ReleaseHandle()
        {
            if (!_Disposed)
            {
                _Disposed = true;
                GC.SuppressFinalize(this);
                VirtualMemoryManager.VirtualFreeEx(_ProcessHandle, _AllocatedPointer, _MemorySize);
            }
            return true;
        }
    }
}