﻿using Quartz;
using Quartz.Impl;
using JoreNoeBackTemplete.DomainService;
using JoreNoeBackTemplete.DomainService.JobCrawling;

namespace JoreNoeBackTemplete.API
{
    public partial class Startup
    {


        /// <summary>
        /// 爬取轮播图片
        /// </summary>
        public void TimerAddRotationMaps()
        {
            //爬取 轮播图 图片
            IScheduler scheduler;
            ISchedulerFactory factory = new StdSchedulerFactory();
            scheduler = factory.GetScheduler().Result;
            //scheduler.Start();

            //创建触发器(也叫时间策略)
            var trigger = TriggerBuilder.Create()
                            .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(3, 30))   // 每天凌晨三点执行一次
                                                                                             //.WithSimpleSchedule(x => x.WithIntervalInSeconds(86400).RepeatForever())//每10秒执行一次
                            .Build();
            //TODO:触发爬取轮播
            var jobDetail = JobBuilder.Create<TimerAddRotationMap>()
                            .UsingJobData("Url", "https://www.520ajj.com/")
                            .UsingJobData("BaseUrl", "https:")
                            .WithIdentity("Myjob", "RotationMap")//我们给这个作业取了个“Myjob”的名字，并取了个组名为“group”
                            .Build();
            //将触发器和作业任务绑定到调度器中
            scheduler.ScheduleJob(jobDetail, trigger);
        }

    

        /// <summary>
        /// 定时
        /// </summary>
        protected void EnableQuartz()
        {

            //this.TimerAddRotationMaps();
            //this.TimerCrawolingMovies();
            //this.TimerCrawlingTopMovie();
            //this.TimerCrawlingCategoryMovies();




            #region 注释









            //爬取 最新视频 首页视频
            //{
            //    IScheduler scheduler;
            //    ISchedulerFactory factory = new StdSchedulerFactory();
            //    scheduler = factory.GetScheduler().Result;
            //    scheduler.Start();

            //    //创建触发器(也叫时间策略)
            //    var trigger = TriggerBuilder.Create()
            //                    //.WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(2, 30))
            //                    .WithSimpleSchedule(x => x.WithIntervalInSeconds(6011111).RepeatForever())
            //                    .Build();
            //    //创建作业实例
            //    //Jobs即我们需要执行的作业
            //    var jobDetail = JobBuilder.Create<TimerAddMovies>()
            //                    .UsingJobData("Url", "https://www.ekmov.com/")
            //                    .WithIdentity("Myjob1", "group1")//我们给这个作业取了个“Myjob”的名字，并取了个组名为“group”
            //                    .Build();
            //    //将触发器和作业任务绑定到调度器中
            //    scheduler.ScheduleJob(jobDetail, trigger);
            //}



            ////爬取电影分类 全程执行一次就可以
            //{
            //    IScheduler scheduler;
            //    ISchedulerFactory factory = new StdSchedulerFactory();
            //    scheduler = factory.GetScheduler().Result;
            //    scheduler.Start();

            //    //创建触发器(也叫时间策略)
            //    var trigger = TriggerBuilder.Create()
            //                    //.WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(2, 30))
            //                    .WithSimpleSchedule(x => x.WithIntervalInSeconds(99999).RepeatForever())
            //                    .Build();
            //    //创建作业实例
            //    //Jobs即我们需要执行的作业
            //    var jobDetail = JobBuilder.Create<TimerAddMovieCategory>()
            //                    .UsingJobData("Url", "https://www.ekmov.com/vodshow/1-----------.html")
            //                    .UsingJobData("BaseUrl", "https://www.ekmov.com/")
            //                    .WithIdentity("Myjob2", "group2")//我们给这个作业取了个“Myjob”的名字，并取了个组名为“group”
            //                    .Build();
            //    //将触发器和作业任务绑定到调度器中
            //    scheduler.ScheduleJob(jobDetail, trigger);
            //}



            ////爬取电影分类中视频信息
            //{
            //    IScheduler scheduler;
            //    ISchedulerFactory factory = new StdSchedulerFactory();
            //    scheduler = factory.GetScheduler().Result;
            //    scheduler.Start();

            //    //创建触发器(也叫时间策略)
            //    var trigger = TriggerBuilder.Create()
            //                    //.WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(2, 30))
            //                    .WithSimpleSchedule(x => x.WithIntervalInSeconds(1000000).RepeatForever())
            //                    .Build();
            //    //创建作业实例
            //    //Jobs即我们需要执行的作业
            //    var jobDetail = JobBuilder.Create<TimerAddCategoryMovie>()
            //                    .UsingJobData("Url", "https://www.ekmov.com/vodshow/1-----------.html")
            //                     .UsingJobData("BaseUrl", "https://www.ekmov.com/")
            //                    .WithIdentity("Myjob3", "group3")//我们给这个作业取了个“Myjob”的名字，并取了个组名为“group”
            //                    .Build();
            //    //将触发器和作业任务绑定到调度器中
            //    scheduler.ScheduleJob(jobDetail, trigger);
            //}


            #endregion
        }
    }
}
