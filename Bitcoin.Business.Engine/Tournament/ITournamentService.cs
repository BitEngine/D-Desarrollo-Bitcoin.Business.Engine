using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Bitcoin.Business.Engine.BO.Transversal;
using Bitcoin.Business.Engine.BO.Betting;

namespace Bitcoin.Business.Engine.Tournament
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITournamentService" in both code and config file together.
    [ServiceContract]
    public interface ITournamentService
    {
        [OperationContract]
        List<SportsBO> GetSports();

        [OperationContract]
        void CreateSports(List<SportsBO> sportsList);
    }
}
