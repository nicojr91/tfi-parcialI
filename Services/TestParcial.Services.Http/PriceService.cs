using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TestParcial.Entities;
using TFIParcial.Business;
using TFIParcial.Services.Contracts;
using TFIParcial.Services.Contracts.Responses;

namespace TestParcial.Services.Http
{
    [RoutePrefix("rest/price")]
    public class PriceService : ApiController
    {
        private PriceBusiness priceBusiness;

        public PriceService()
        {
            priceBusiness = new PriceBusiness();
        }

        [HttpPost]
        [Route("add")]
        public Price Add(Price price)
        {
            priceBusiness.Add(price);

            return null;
        }

        [HttpPost]
        [Route("remove")]
        public void Delete(int Id)
        {
            priceBusiness.Remove(Id);
        }

        [HttpPost]
        [Route("update")]
        public Price Modify(Price price)
        {
            priceBusiness.Edit(price);

            return null;
        }

        [HttpGet]
        [Route("getByKm")]
        public FindResponse<Price> FindByKm(int km)
        {
            var resp = new FindResponse<Price>();
            resp.Result = priceBusiness.FindByKm(km);
            
            return resp;
        }

        [HttpGet]
        [Route("getAll")]
        public AllResponse<Price> List()
        {
            var resp = new AllResponse<Price>();
            resp.Result = priceBusiness.All();

            return resp;
        }
    }
}
