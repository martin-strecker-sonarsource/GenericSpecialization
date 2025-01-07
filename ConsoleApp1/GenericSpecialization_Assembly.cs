// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Engines;
using Microsoft.Diagnostics.Tracing.Parsers.Kernel;
using System;
using System.Runtime.CompilerServices;

[DisassemblyDiagnoser(printInstructionAddresses: true, syntax: DisassemblySyntax.Masm, printSource: true)]
[MemoryDiagnoser]
[SimpleJob(RunStrategy.Throughput, launchCount: 1, warmupCount: 5, iterationCount: 5, id: "FastAndDirtyJob")]
public class GenericSpecializationAssembly
{
    [Benchmark]
    public int GenerateCode()
    {
        int i = new Container<ClassWithSomeProperty>(new()).GetValue();
        i += new Container<OtherClassWithSomeProperty>(new()).GetValue();
        i += new Container(new ClassWithSomeProperty()).GetValue();
        i += new Container(new OtherClassWithSomeProperty()).GetValue();
        i += new Container<StructWithSomeProperty>(new()).GetValue();
        i += new Container<OtherStructWithSomeProperty>(new()).GetValue();
        i += new Container(new StructWithSomeProperty()).GetValue();
        i += new Container(new OtherStructWithSomeProperty()).GetValue();
        return i;
    }
}

class Container<T> where T : IHaveSomeProperty
{
    private readonly T value;

    public Container(T value)
    {
        this.value = value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int GetValue() => value.SomeProperty;
}

class Container
{
    private readonly IHaveSomeProperty value;

    public Container(IHaveSomeProperty value)
    {
        this.value = value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int GetValue() => value.SomeProperty;
}
