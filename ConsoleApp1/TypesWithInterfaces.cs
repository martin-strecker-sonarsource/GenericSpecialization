using System.Runtime.CompilerServices;

public static class Extensions
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int HelperMethodGeneric<T>(this T value) where T : IHaveSomeProperty =>
        value.SomeProperty - Environment.TickCount;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int HelperMethodInterface(this IHaveSomeProperty value) =>
        value.SomeProperty - Environment.TickCount;
}

class ClassWithSomeProperty : IHaveSomeProperty
{
    public int SomeProperty { get; set; }
}

class OtherClassWithSomeProperty : IHaveSomeProperty
{
    public int SomeProperty { get; set; }
    public double SomeOtherProperty { get; set; }
}

struct StructWithSomeProperty : IHaveSomeProperty
{
    public int SomeProperty { get; set; }
}

struct OtherStructWithSomeProperty : IHaveSomeProperty
{
    public double SomeOtherProperty { get; set; }
    public int SomeProperty { get; set; }
}

public interface IHaveSomeProperty
{
    public int SomeProperty { get; set; }
}
