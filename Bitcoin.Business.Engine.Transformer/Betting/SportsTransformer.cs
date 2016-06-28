using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.Betting.P_S;
using Bitcoin.Business.Engine.BO.Betting;
using Business.TransformerLayer.Mapper;
using Bitcoin.Business.Engine.PersistentObjects.Betting.T_W;

namespace Bitcoin.Business.Engine.Transformer.Betting
{
    public class SportsTransformer : MapperManager<Sports, SportsBO>
    {
        public override SportsBO MapperPersistent2BO(Sports oObject)
        {
            #region Additional Transformers
            TournamentsTransformer tournametTransformer = new TournamentsTransformer();
            #endregion

            SportsBO sportBO = base.MapperPersistent2BO(oObject);            
            foreach (var item in oObject.ListTournaments)
            {
                sportBO.TournamentList.Add(tournametTransformer.MapperPersistent2BO(item));
            }
            return sportBO;

        }
    }
}
