using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Engines;
using System.Runtime.CompilerServices;

namespace ConsoleApp1;

public class GenericSpecializationOnType1
{
    private readonly bool someBool;
    private readonly int someInt;
}

public class GenericSpecializationOnType2
{
    private readonly int someInt;
    private readonly long someLong;
    private readonly long someOtherLong;
}

public class ClassContainer<T>
{
    private readonly T value;
    private readonly bool hasValue;

    public ClassContainer() => (this.value, this.hasValue) = (default, false);
    public ClassContainer(T value) => (this.value, this.hasValue) = (value, true);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T GetValue() => hasValue ? value : default;
}

[DisassemblyDiagnoser(printInstructionAddresses: true, syntax: DisassemblySyntax.Masm, printSource: true, exportCombinedDisassemblyReport: true)]
[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, launchCount: 1, warmupCount: 5, iterationCount: 5, id: "FastAndDirtyJob")]
public class Benchmark
{
    [Benchmark]
    public string AccessFieldInContainer()
    {
        var e1 = new GenericSpecializationOnType1();
        var c1 = new ClassContainer<GenericSpecializationOnType1>(e1);
        var v1 = c1.GetValue();
        
        var e2 = new GenericSpecializationOnType2();
        var c2 = new ClassContainer<GenericSpecializationOnType2>(e2);
        var v2 = c2.GetValue();
        return v1.ToString() + v2.ToString();
    }
}