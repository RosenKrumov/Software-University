namespace BidSystem.RestServices.Controllers
{
    using System.Web.Http;
    using Data.Interfaces;

    public class BaseApiController : ApiController
    {
        public BaseApiController(IBidSystemData data)
        {
            this.Data = data;
        }

        protected IBidSystemData Data { get; set; }
    }
}
