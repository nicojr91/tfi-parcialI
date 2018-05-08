using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TFIParcial.Services.Contracts.Responses
{
    [DataContract]
    public class FindResponse<T>
    {
        [DataMember]
        public T Result { get; set; }
    }
}