using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFIParcial.Services.Contracts.Responses;

namespace TFIParcial.UI.Process
{
    public class DistanceProcess : ProcessComponent
    {
        public string GetDistance(string from, string to)
        {
            var param = new Dictionary<string, object>();
            param.Add("from", from);
            param.Add("to", to);

            var resp = HttpGet<FindResponse<string>>("rest/distance/getDistance", param, MediaType.Json);

            return resp.Result;
        }
    }
}
