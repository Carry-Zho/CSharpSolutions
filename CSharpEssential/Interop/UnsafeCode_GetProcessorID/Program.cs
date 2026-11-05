using System.Runtime.InteropServices;
using System.Text;

namespace UnsafeCode_GetProcessorID
{
    internal class Program
    {
        public unsafe delegate void MethodInvoker(byte* buffer);  // Declare a delegate type for the method to be invoked

        static void Main(string[] args)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.WriteLine("Running on Windows");
                unsafe
                {
                    byte[] codeBytes = new byte[]
                    {
                        0x49,0x89,0xd8,     // mov r8, rbx
                        0x49,0x89,0xC9,     // mov r9, rcx
                        0x48,0x31,0xc0,     // xor rax, rax
                        0x0f,0xa2,          // cpuid
                        0x4C,0x89,0xc8,     // mov rax, r9
                        0x89,0x18,          // mov [rax], ebx
                        0x89,0x50,0x04,     // mov [rax+4], edx
                        0x89,0x48,0x08,     // mov [rax+8], ecx
                        0x4c,0x89, 0xc3,    // mov rbx, r8
                        0xc3                // ret
                    };
                    byte[] buffer = new byte[12];
                    using (VirtualMemoryPtr codeBytesPtr = new VirtualMemoryPtr(codeBytes.Length))
                    {
                        Marshal.Copy(codeBytes, 0, codeBytesPtr, codeBytes.Length);
                        MethodInvoker method = Marshal.GetDelegateForFunctionPointer<MethodInvoker>(codeBytesPtr);
                        fixed (byte* newBuffer = &buffer[0])
                        {
                            method(newBuffer);
                        }
                    }
                    Console.Write("Processor Id:");
                    Console.WriteLine(Encoding.ASCII.GetChars(buffer));
                }
            }
            else 
            {
                Console.WriteLine("This sample is only supported on Windows.");
            }
        }
    }
}
