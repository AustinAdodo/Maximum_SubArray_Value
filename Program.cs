using System;
using Maximum_SubArray_Value;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;


namespace Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Test1Results = BenchmarkRunner.Run<SpeedTester>();
        }

        [MemoryDiagnoser(false)]
        public class SpeedTester
        {
            [Params(10, 100, 1000)]
            public int size { get; set; }

            [Benchmark(Baseline = true)]
            public void Test1()
            {
                int[] TestArr = { -2, -1, -4, 4, 7, 20, 1, 2, 5, -1, -4 };
                int[] TestArr2 = { 3, 2, -4, -23, 7, 11, 7, 9, 100, -1, -1 };
                Aus.Maximum_Subarray(TestArr);
            }
            [Benchmark] //open for scrutiny.
            public void Test2()
            {

            }

            [Benchmark] //possible third benhmark open for scrutiny.
            public void Test3()
            {

            }
        }
    }
}