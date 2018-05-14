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
    public class Sucursal
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
        public string Zona { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Longitud { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Latitud { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Direccion { get; set; }
    }
}
