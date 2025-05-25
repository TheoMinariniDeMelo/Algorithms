// See https://aka.ms/new-console-template for more information
using sort.src;
using sort.src.extensions;
using BenchmarkDotNet.Running;

//BenchmarkRunner.Run<IntegerArraySort>();
int[] vector = [1957747793, 1804289383, 1714636915, 1681692777, 1649760492, 1189641421, 846930886, 719885386, 596516649, 424238335];
vector.Print();
vector.OrderBy(x => -x).ToArray().Print();
