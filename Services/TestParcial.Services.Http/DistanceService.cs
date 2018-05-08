using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TFIParcial.Services.Contracts.Responses;

namespace TFIParcial.Services.Http
{
    [RoutePrefix("rest/distance")]
    public class DistanceService : ApiController
    {
        private string GmapsURL = "https://maps.googleapis.com/maps/api/distancematrix/json?key=AIzaSyDtJ9ref3ICzSP_28zOlGMOXSl4bnsyKHk&origins={0}&destinations={1}";

        [HttpGet]
        [Route("getDistance")]
        public FindResponse<string> GetDistance(string from, string to)
        {
            string uri = string.Format(GmapsURL, Uri.EscapeDataString(from), Uri.EscapeDataString(to));

            HttpClient client = new HttpClient();
            var resp = client.GetAsync(uri);
            var result = resp.Result.Content.ReadAsStringAsync();
            var qwe = JObject.Parse(result.Result);
            string km = string.Empty;

            float kilometers = -1;
            string status = (string)qwe["status"];
            if (status != "OK")
            {
                throw new Exception(status);
            }
            km = (string)qwe["rows"][0]["elements"][0]["distance"]["text"];
            km = km.Split(' ')[0];
            km = km.Replace('.', ',');
            kilometers = float.Parse(km);

            var response = new FindResponse<string>();
            response.Result = kilometers.ToString();

            return response;
        }
    }
}
