using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Bitcoin.Business.Engine.BO.Transversal
{
    /// <summary>
    /// Objeto trasnversal
    /// </summary>
    [DataContract]
    public class LiteBO
    {
        /// <summary>
        /// Identificador del objeto
        /// </summary>
        [DataMember]
        public Int64 Oid { get; set; }

        /// <summary>
        /// Nombre del objeto
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
