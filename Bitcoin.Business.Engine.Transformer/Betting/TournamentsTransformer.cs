using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.TransformerLayer.Mapper;
using Bitcoin.Business.Engine.PersistentObjects.Betting.T_W;
using Bitcoin.Business.Engine.BO.Betting;
using Bitcoin.Business.Engine.PersistentObjects.Betting.P_S;
using Bitcoin.Business.Engine.Transformer.Transversal;

namespace Bitcoin.Business.Engine.Transformer.Betting
{
    public class TournamentsTransformer : MapperManager<Tournaments, TournamentsBO>
    {
        public override TournamentsBO MapperPersistent2BO(Tournaments oObject)
        {
            #region  Additional Transformers
            LiteTransformer<Phases> phasesTransformer =new LiteTransformer<Phases>();
            #endregion

            TournamentsBO tournamentsBO = base.MapperPersistent2BO(oObject);
            foreach (var item in oObject.ListPhases)
	        {
                tournamentsBO.PhasesList.Add(phasesTransformer.MapperPersistent2BO(item));
	        }            
            return tournamentsBO;
        }
    }
}
