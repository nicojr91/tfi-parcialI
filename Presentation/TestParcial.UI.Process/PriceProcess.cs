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
    public class PriceProcess : ProcessComponent
    {
        public Price Add(Price price)
        {
            var response = HttpPost<Price>("rest/price/add", price, MediaType.Json);

            return response;
        }

        public Price Remove(int Id)
        {
            return null;
        }

        public Price Edit(Price price)
        {
            var response = HttpPost<Price>("rest/price/update", price, MediaType.Json);

            return response;
        }

        public Price FindByKm(int km)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("km", km);
            var response = HttpGet<FindResponse<Price>>("rest/price/getByKm", parameters, MediaType.Json);

            return response.Result;
        }

        public List<Price> List()
        {
            var response = HttpGet<AllResponse<Price>>("rest/price/getAll", new Dictionary<string, object>(), MediaType.Json);

            return response.Result;
        }
    }
}
