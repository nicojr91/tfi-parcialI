using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestParcial.Entities;
using TFIParcial.Services.Contracts;
using TFIParcial.Services.Contracts.Responses;
using TFIParcial.UI.Process;

namespace TestParcial.UI.Process
{
    public class SucursalProcess : ProcessComponent
    {
        public Sucursal Add(Sucursal suc)
        {
            var response = HttpPost<Sucursal>("rest/sucursal/add", suc, MediaType.Json);

            return response;
        }

        public Sucursal Remove(int Id)
        {
            return null;
        }

        public Sucursal Edit(Sucursal suc)
        {
            var response = HttpPost<Sucursal>("rest/sucursal/update", suc, MediaType.Json);

            return response;
        }

        public List<Sucursal> List()
        {
            var response = HttpGet<AllResponse<Sucursal>>("rest/sucursal/getAll", new Dictionary<string, object>(), MediaType.Json);

            return response.Result;
        }

        public Sucursal FindById(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindResponse<Sucursal>>("rest/sucursal/findById", parameters, MediaType.Json);

            return response.Result;
        }
    }
}
