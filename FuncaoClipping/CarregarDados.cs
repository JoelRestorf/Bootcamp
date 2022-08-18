using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FuncaoClipping
{
    public class CarregarDados
    {
        [FunctionName("CarregarDados")]
        public void Run([TimerTrigger("04:00:00")]TimerInfo myTimer, ILogger log)
        {
            NewsApi.BuscaNoticiasTermoPackage("Curitiba", DateTime.Now.AddHours(-4));
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
