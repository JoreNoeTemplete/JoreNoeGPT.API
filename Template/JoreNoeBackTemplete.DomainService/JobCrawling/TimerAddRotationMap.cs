using Exceptionless;
using HtmlAgilityPack;
using JoreNoe.JoreHttpClient;
using Quartz;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JoreNoeBackTemplete.DomainService.JobCrawling
{
    /// <summary>
    /// 爬取轮播图
    /// </summary>
    /// IJob定时
    public class TimerAddRotationMap : IJob
    {
        //private readonly IRepository<Guid, RotationMap> RotationMapRepository;
        //public TimerAddRotationMap(  BaseRepository,
        //    IUnitOfWork unitOfWork,
        //    IRepository<Guid, RotationMap> RotationMapRepository) : base(unitOfWork)
        //{
        //    this.RotationMapRepository = RotationMapRepository;
        //}

        //public async Task Execute(IJobExecutionContext context)
        //{
        //    var Job = context.JobDetail.JobDataMap;
        //    string Url = Job.GetString("Url");
        //    string BaseUrl = Job.GetString("BaseUrl");
        //    ExceptionlessClient.Default.SubmitLog("1.开始爬取轮播数据");
        //    var GetHTML = await HttpClientApi.GetASync(Url, "utf-8").ConfigureAwait(false);
        //    var Doc = new HtmlDocument();
        //    Doc.LoadHtml(GetHTML); //加载HTML到HTMLDocument
        //    ExceptionlessClient.Default.SubmitLog("2.开始爬取轮播数据,拿到数据");
        //    var data = Doc.DocumentNode.SelectNodes("//div[@class='wide']");
        //    int a = 0;
        //    JoreNoeBackTemplete. .JoreNoeBackTempleteDBCntext ZerroDbContext = new JoreNoeBackTemplete.Repository.JoreNoeBackTempleteDBCntext();
        //    foreach (var item in data)
        //    {
        //        var UrlData = item.FirstChild.Attributes["style"].Value;
        //        string[] Arr = UrlData.Split(new string[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
        //        //ExceptionlessClient.Default.SubmitLog("3.开始爬取轮播数据,解析成功");
        //        if (ZerroDbContext.RotationMap.Where(d => d.MovieName == item.FirstChild.InnerText) == null ||
        //            ZerroDbContext.RotationMap.Where(d => d.MovieName == item.FirstChild.InnerText).Count() == 0)
        //            ZerroDbContext.Set<RotationMap>().Add(new RotationMap
        //            {
        //                MovieName = item.FirstChild.InnerText,
        //                Like = string.Concat(Url, item.FirstChild.Attributes["href"].Value),
        //                Order = a,
        //                ImgUrl = string.Concat(BaseUrl, Arr[1])
        //            });
        //        a++;
        //    }

        //    ZerroDbContext.SaveChanges();
        //    //ZerroDbContext.Add<RotationMap>


        //    //_ = await this.RotationMapRepository.AddRangeAsync(RotatiMapData).ConfigureAwait(false);
        //    //this.SaveChanges();
        //    ExceptionlessClient.Default.SubmitLog("4.开始爬取轮播数据,完成");
        //}
        public Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
