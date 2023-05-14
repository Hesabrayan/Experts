using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpertProble2_ExpertBenchmark
{

    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [SimpleJob(RuntimeMoniker.Net70, baseline: true)]
    public class Worker
    {
        public static List<Claim> GetClaims() =>
            new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier ,"12345678765432134567"),
                new Claim(ClaimTypes.Email,"JoshStivens@outlook.com"),
                new Claim(ClaimTypes.Name,"Josh Stivens"),
                new Claim(ClaimTypes.MobilePhone,"0912127004*"),
                new Claim("Age","20"),
                new Claim("IsAdmin","False"),
            };


        [Benchmark(Baseline = true)]
        public string BaseExample_GeneratJWTToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sekret_key_arqeflsd245689023dfge54tgty45wevtw"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "devblogs.ir",
                audience: "devblogs.ir",
                GetClaims(),
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // ========== Developer Solutions ================



    }
}
