using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.TransformerLayer.Mapper;
using Bitcoin.Business.Engine.BO.Betting;
using Bitcoin.Business.Engine.Transformer.Betting;
using Bitcoin.Business.Engine.BO.Transversal;
using Bitcoin.Business.Engine.Transformer.Transversal;
using Bitcoin.Business.Engine.Util.TransformerMessages;

namespace Bitcoin.Business.Engine.Transformer.Factory
{
    /// <summary>
    /// Fabrica de transformación
    /// </summary>
    public class TransformerFactory
    {
        /// <summary>
        /// Metodo que crea las transformaciones
        /// de objetos
        /// </summary>
        /// <typeparam name="Persistent">Objeto de persistnecia</typeparam>
        /// <typeparam name="BusinessObject">Objeto de negocio "BO"</typeparam>
        /// <returns></returns>
        public static MapperManager<Persistent, BusinessObject> Create<Persistent, BusinessObject>()
        {
            Type modelType = typeof(BusinessObject);
            Type persistentType = typeof(Persistent);
            if (modelType == typeof(BetsBO))
            {
                return new BetsTransformer() as MapperManager<Persistent, BusinessObject>;
            }
            if (modelType == typeof(LiteBO))
            {
                return new LiteTransformer<Persistent>() as MapperManager<Persistent, BusinessObject>;
            }
            if (modelType == typeof(SportsBO))
            {
                return new SportsTransformer() as MapperManager<Persistent, BusinessObject>;
            }
            else
            {
                throw new Exception(string.Format(TransformerMessages.FactoryTrasnformationError, persistentType.Name));
            }
        }
    }
}
