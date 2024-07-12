using System;
using System.Configuration;
using System.Threading.Tasks;
using LogUploader.Contracts;
using LogUploader.LoggerUtil;
using LogUploader.Services;
using LogUploader.Timer;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;

namespace QuartzSampleApp
{
    public class Program
    {
        private static async Task Main(string[] args)
        {

            //var services = new ServiceCollection();
            //ConfigureServices(services);
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());
            // Grab the Scheduler instance from the Factory
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();

            // and start it off
            await scheduler.Start();
            //IJobDetail job2 = JobBuilder.Create<HelloJob>()
            //    .WithIdentity("job2", "group1")
            //    .Build();
            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<UploadJob>()
                .WithIdentity("job1", "group1")
                .Build();

            // Trigger the job to run now, and then repeat every 1 minute
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                //.WithSchedule(CronScheduleBuilder
                //.WeeklyOnDayAndHourAndMinute(DayOfWeek.Tuesday, 10, 57)
                //.InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"))
                //)
                .WithCronSchedule("0 */1 * * * ?")
                //.WithCronSchedule("*/3 * * * * ?")

                //每隔5秒执行一次：*/5 * * * * ?

                //每隔1分钟执行一次：0 */1 * * * ?

                //每天23点执行一次：0 0 23 * * ?

                //每天凌晨1点执行一次：0 0 1 * * ?

                //每月1号凌晨1点执行一次：0 0 1 1 * ?

                //每月最后一天23点执行一次：0 0 23 L * ?

                //每周星期天凌晨1点实行一次：0 0 1 ? *L

                //在26分、29分、33分执行一次：0 26,29,33 * ** ?

                //每天的0点、13点、18点、21点都执行一次：0 0 0,13,18,21 * * ?

                .Build();

            // Tell quartz to schedule the job using our trigger
            await scheduler.ScheduleJob(job, trigger);
            //await scheduler.ScheduleJob(job2, trigger);


            // some sleep to show what's happening
            await Task.Delay(TimeSpan.FromSeconds(600));

            // and last shut down the scheduler when you are ready to close your program
            await scheduler.Shutdown();

            //onsole.WriteLine("Press any key to close the application");
            //Console.ReadKey();
        }

        //private static void ConfigureServices(IServiceCollection services)
        //{

        //    services.AddLogging();
        //    services.AddScoped<IMac2s_logRepository, Mac2s_logRepository>();
        //}

        // simple log provider to get something to the console

    }

}