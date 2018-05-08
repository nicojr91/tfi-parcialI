using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestParcial.Entities
{
    [Serializable]
    [DataContract]
    public class Price
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Kilometers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public double Value { get; set; }

    }
}
