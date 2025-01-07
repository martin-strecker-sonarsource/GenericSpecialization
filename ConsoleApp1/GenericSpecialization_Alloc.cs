// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Engines;

[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, launchCount: 1, warmupCount: 5, iterationCount: 5, id: "FastAndDirtyJob")]
public class GenericSpecializationAllocations
{
    [Benchmark]
    public int GenericClass() => new Container<ClassWithSomeProperty>(new()).GetValue();

    [Benchmark]
    public int GenericOtherClass() => new Container<OtherClassWithSomeProperty>(new()).GetValue();

    [Benchmark]
    public int NonGenericClass() => new Container(new ClassWithSomeProperty()).GetValue();
    [Benchmark]
    public int NonGenericOtherClass() => new Container(new OtherClassWithSomeProperty()).GetValue();
    [Benchmark]
    public int GenericStruct() => new Container<StructWithSomeProperty>(new()).GetValue();
    [Benchmark]
    public int GenericOtherStruct() => new Container<OtherStructWithSomeProperty>(new()).GetValue();
    [Benchmark]
    public int NonGenericStruct() => new Container(new StructWithSomeProperty()).GetValue();
    [Benchmark]
    public int NonGenericOtherStruct() => new Container(new OtherStructWithSomeProperty()).GetValue();
}