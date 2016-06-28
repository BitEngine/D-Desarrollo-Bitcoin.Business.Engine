using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Bitcoin.Business.Engine.Manager.Betting.Tournament;
using Bitcoin.Business.Engine.BO.Transversal;
using Bitcoin.Business.Engine.BO.Betting;
using System.Configuration;
using Business.CallAudit;

namespace Bitcoin.Business.Engine.Tournament
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TournamentService" in code, svc and config file together.
    public class TournamentService : ITournamentService
    {

        #region Properties
        private TournamentManager manager;
        private TournamentManager Manager
        {
            get
            {
                if (manager == null)
                {
                    manager = new TournamentManager();
                }
                return manager;
            }            
        }
        
        public bool Audit
        {
            get             
            { 
                return Convert.ToBoolean(ConfigurationManager.AppSettings["Audit"]); 
            }            
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Metoo que permite consultar la lista de tipos
        /// de deportes
        /// </summary>
        /// <returns></returns>
        public List<SportsBO> GetSports()
        {
            #region Audit
            if (Audit)
            {
                CalledRegister.AuditPersistent();
            }
            #endregion
				
            return Manager.GetSports();
        }

        /// <summary>
        /// Metodo que crea los tipos de deportes
        /// </summary>
        /// <param name="listSportsTypes">lista de deportes a crear</param>
        public void CreateSports(List<SportsBO> sportsList)
        {
            #region Audit
            if (Audit)
            {
                CalledRegister.AuditPersistent();
            }
            #endregion
            Manager.CreateSports(sportsList);
        }
        #endregion
       
    }
}
