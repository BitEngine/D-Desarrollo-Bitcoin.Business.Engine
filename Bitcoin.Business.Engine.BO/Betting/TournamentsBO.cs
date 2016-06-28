using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Bitcoin.Business.Engine.BO.Transversal;

namespace Bitcoin.Business.Engine.BO.Betting
{
    [DataContract]
    public class TournamentsBO
    {
        [DataMember]
        public Int64 Oid { get; set; }

        [DataMember]
        public string Name { get; set; }

        private List<LiteBO> phasesList;
        [DataMember]
        public List<LiteBO> PhasesList
        {
            get 
            {
                if (phasesList == null)
                {
                    phasesList = new List<LiteBO>();
                }
                return phasesList; 
            }
            set { phasesList = value; }
        }
    }
}
