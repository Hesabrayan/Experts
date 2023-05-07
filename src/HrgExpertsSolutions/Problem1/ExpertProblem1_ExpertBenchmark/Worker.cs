using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using Infrastructures.EntityFrameworks.RegisterAllEntities;

namespace ExpertProblem1_ExpertBenchmark
{

    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [SimpleJob(RuntimeMoniker.Net70, baseline: true)]
    public class Worker
    {

        [GlobalSetup]
        public void Setup()
        {

        }

        [Benchmark(Baseline = true)]
        public void BaseExample_ReadOwnTypes()
        {
            var assembly = typeof(IAssemblyMaker).Assembly;

            List<Type> types = assembly.GetTypes()
                                           .Where(x => x.IsClass)
                                           .Where(x => !x.IsAbstract)
                                           .Where(x => x.BaseType == typeof(AppEntity))
                                           .ToList();
        }

        // ========== Developer Solutions ================


    }
}
