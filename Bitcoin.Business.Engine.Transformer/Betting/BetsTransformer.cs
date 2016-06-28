using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.TransformerLayer.Mapper;
using Bitcoin.Business.Engine.PersistentObjects.Betting.A_D;
using Bitcoin.Business.Engine.BO.Betting;

namespace Bitcoin.Business.Engine.Transformer.Betting
{
    public class BetsTransformer : MapperManager<Bets, BetsBO>
    {
    }
}
