
using JoreNoe;
using JoreNoe.Extend;
using JoreNoeBackTemplete.DomainService.Inteface;
using JoreNoeBackTemplete.OAL.Values;
using Microsoft.AspNetCore.Mvc;

namespace JoreNoeBackTemplete.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ItestDomainService t;
        public TestController(ItestDomainService t)
        {
            this.t = t;
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpGet("test")]
        public APIReturnInfo<int> test()
        {
            var test = false;
            test.BooleanToString();
            return APIReturnInfo<int>.Success(1);
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpGet("test1")]
        public ActionResult tes1t()
        {
            var test = false;
            return Content(test.BooleanToString("是吧","不是"));
        }

    }
}
