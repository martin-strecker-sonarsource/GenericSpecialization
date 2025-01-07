// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Engines;

[DisassemblyDiagnoser(printInstructionAddresses: true, syntax: DisassemblySyntax.Masm)]
[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, launchCount: 1, warmupCount: 5, iterationCount: 5, id: "FastAndDirtyJob")]
public class GenericSpecialization
{
    [Benchmark]
    public void ClassGenericCall() => 
        new ClassWithSomeProperty().HelperMethodGeneric();

    [Benchmark]
    public void OtherClassGenericCall() =>
        new OtherClassWithSomeProperty().HelperMethodGeneric();

    [Benchmark]
    public void ClassInterfaceCall() =>
        new ClassWithSomeProperty().HelperMethodInterface();

    [Benchmark]
    public void OtherClassInterfaceCall() =>
        new OtherClassWithSomeProperty().HelperMethodInterface();

    [Benchmark]
    public void StructGenericCall() =>
        new StructWithSomeProperty().HelperMethodGeneric();

    [Benchmark]
    public void OtherStructGenericCall() =>
        new OtherStructWithSomeProperty().HelperMethodGeneric();

    [Benchmark]
    public void StructInterfaceCall() =>
        new StructWithSomeProperty().HelperMethodInterface();

    [Benchmark]
    public void OtherStructInterfaceCall() =>
        new OtherStructWithSomeProperty().HelperMethodInterface();
}
