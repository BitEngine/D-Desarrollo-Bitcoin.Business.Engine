using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.BO.Transversal;
using Business.TransformerLayer.Mapper;

namespace Bitcoin.Business.Engine.Transformer.Transversal
{
    public class LiteTransformer<Persistent> : MapperManager<Persistent, LiteBO>
    {        
    }
}
