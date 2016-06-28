using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.TransformerLayer.Mapper;

namespace Bitcoin.Business.Engine.Transformer.Mapper.Factory
{
    public class TransformerFactory
    {
        public static MapperManager<Persistent, BusinessObject> Create<Persistent, BusinessObject>()
        {
            Type modelType = typeof(BusinessObject);
            //if (tipoModeloPersistente == typeof(ParametrosTipoProducto))
            //        {
            //            return new TransformadorParametrosTipo() as MapperManager<Persistente, ObjetoNegocio>;

            return null;
        }
    }
}
