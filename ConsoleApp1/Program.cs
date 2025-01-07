// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using ConsoleApp1;

//BenchmarkRunner.Run<GenericSpecializationAllocations>();
BenchmarkRunner.Run<GenericSpecializationAssembly>();
// var sut = new GenericSpecialization();
// sut.StructGenericCall();
// sut.OtherStructGenericCall();

//sut.ClassGenericCall();
//sut.OtherClassGenericCall();

//BenchmarkRunner.Run<Benchmark>();