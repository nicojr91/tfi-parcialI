using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace TFIParcial.Services.Contracts
{
    /// <summary>
    /// Response message wrapper class for All
    /// </summary>
    [DataContract]
    public partial class AllResponse<T>
    {
        [DataMember]
        public List<T> Result { get; set; }
    }
}

