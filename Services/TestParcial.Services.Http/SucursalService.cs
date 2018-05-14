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
    [RoutePrefix("rest/sucursal")]
    public class SucursalService : ApiController
    {
        private SucursalBusiness business;

        public SucursalService()
        {
            business = new SucursalBusiness();
        }

        [HttpPost]
        [Route("add")]
        public Sucursal Add(Sucursal price)
        {
            business.Add(price);

            return null;
        }

        [HttpPost]
        [Route("remove")]
        public void Delete(int Id)
        {
            business.Remove(Id);
        }

        [HttpGet]
        [Route("findById")]
        public FindResponse<Sucursal> FindById(int Id)
        {
            var resp = new FindResponse<Sucursal>();
            resp.Result = business.FindById(Id);

            return resp;
        }

        [HttpPost]
        [Route("update")]
        public Sucursal Modify(Sucursal price)
        {
            business.Edit(price);

            return null;
        }

        [HttpGet]
        [Route("getAll")]
        public AllResponse<Sucursal> List()
        {
            var resp = new AllResponse<Sucursal>();
            resp.Result = business.All();

            return resp;
        }
    }
}
