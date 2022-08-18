using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Servico
{
    public class clipping
    {
        [FunctionName("clipping")]
        public void Run([TimerTrigger("05:00:00")]TimerInfo myTimer, ILogger log)
        {
            NewsApi.BuscaNoticiasTermoPackage("Curitiba", DateTime.Now.AddMonths(-1));
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
