using System.Runtime.InteropServices;

namespace MyApp;

public static class Calculator
{
    [UnmanagedCallersOnly(EntryPoint = "add")]
    public static int Add(int a, int b) => a + b;
    
    [UnmanagedCallersOnly(EntryPoint = "subtract")]
    public static int Subtract(int a, int b) => a - b;
}
