using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;

namespace ExpertProble4_ExpertBenchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [SimpleJob(RuntimeMoniker.Net70, baseline: true)]
    public class Worker
    {
        public static List<string> dataOfString;

        [GlobalSetup]
        public void Setup()
        {
            dataOfString = new List<string>();

            for (int i = 0; i < 30_000; i++)
            {
                dataOfString.Add(DateTime.Now.AddDays(i).ToShortDateString());
            }
        }

        [Benchmark(Baseline = true)]
        public string BaseExample_MergeStringItems()
        {
            return dataOfString.Aggregate((current, next) => current + "," + next)
                                    .ToString();
        }
 
        // ========== Developer Solutions ================
         
    }
}
