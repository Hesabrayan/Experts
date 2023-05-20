using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;

namespace ExpertProble3_ExpertBenchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [SimpleJob(RuntimeMoniker.Net70, baseline: true)]
    public class Worker
    {
        public static List<object> ValueObjects;
         
        [GlobalSetup]
        public void Setup()
        {
            ValueObjects = new List<object>();

            for (int i = 0; i < 30_000; i++)
            {
                ValueObjects.Add(new object());
            }
        }
         
        [Benchmark(Baseline = true)]
        public int BaseExample_GenerateHashCode_Aggregate()
        {
            return ValueObjects.Select(x => (x is not null) ? x.GetHashCode() : 0)
                                    .Aggregate((x, y) => x ^ y);
        }
  
        // ========== Developer Solutions ================



    }
}
