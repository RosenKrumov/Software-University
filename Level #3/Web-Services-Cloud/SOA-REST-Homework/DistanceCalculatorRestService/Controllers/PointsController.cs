using System;
using System.Web.Http;

namespace DistanceCalculatorRestService.Controllers
{
    public class PointsController : ApiController
    {
        [Route("api/points/distance")]
        [HttpGet]
        public double Get(int startX, int startY, int endX, int endY)
        {
            var distance = Math.Sqrt(Math.Pow(endX - startX, 2) + Math.Pow(endY - startY, 2));
            return distance;
        }
    }
}
