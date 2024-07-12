using LogUploader.Contracts;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogUploader.Timer
{
    public class HelloJob:IJob
    {
       // private readonly IMac2s_logRepository _LogRepository;
        //private readonly ILogger<HelloJob> _logger;
        //public HelloJob(
        //    //IMac2s_logRepository logRepository, 
        //    ILoggerFactory loggerFactory
        //    )
        //{
        //    //_LogRepository = logRepository;
        //    _logger = loggerFactory.CreateLogger<HelloJob>();
        //}
        public async Task Execute(IJobExecutionContext context)
        {
            //_logger.LogInformation("Hello");
            await Console.Out.WriteLineAsync($"Testing timer the time is now {DateTime.Now}, UTC is {DateTime.UtcNow}!");
        }
    }
}
