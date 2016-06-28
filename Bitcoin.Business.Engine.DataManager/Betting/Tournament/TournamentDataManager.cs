using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.BO.Transversal;
using Business.DataAccessLayer.Consultants;
using Business.DataAccessLayer.Consultants.Factory;
using Bitcoin.Business.Engine.BO.Betting;
using Bitcoin.Business.Engine.PersistentObjects.Betting.P_S;

namespace Bitcoin.Business.Engine.DataManager.Betting.Tournament
{
    public class TournamentDataManager
    {
        #region Public Methods
        /// <summary>
        /// Metoo que permite consultar la lista de tipos
        /// de deportes
        /// </summary>
        /// <returns></returns>
        public List<SportsBO> GetSports()
        {
            try
            {
                IConsultant<Sports, SportsBO> consultant = ConsultantFactory.Create<Sports, SportsBO>();
                return consultant.GetCollection();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        /// <summary>
        /// Metodo que crea los tipos de deportes
        /// </summary>
        /// <param name="listSportsTypes"></param>
        public void CreateSport(SportsBO sport)
        {
            try
            {
                IConsultant<Sports, SportsBO> consultant = ConsultantFactory.Create<Sports, SportsBO>();
                consultant.CreateObject(sport);
            }
            catch (Exception)
            {                
                throw;
            }
        }
        #endregion
    }
}
