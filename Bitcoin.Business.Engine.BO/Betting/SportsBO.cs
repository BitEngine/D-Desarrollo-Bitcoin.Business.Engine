using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Bitcoin.Business.Engine.BO.Betting
{
    [DataContract]
    public class SportsBO
    {
        [DataMember]
        public Int64 Oid { get; set; }

        [DataMember]
        public string Name { get; set; }

        private List<TournamentsBO> tournamentList;
        [DataMember]
        public List<TournamentsBO> TournamentList
        {
            get 
            {
                if (tournamentList == null)
                {
                    tournamentList = new List<TournamentsBO>();
                }
                return tournamentList; 
            }
            set { tournamentList = value; }
        }
    }
}
