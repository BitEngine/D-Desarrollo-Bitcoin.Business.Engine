using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.DataManager.Betting.Tournament;
using Bitcoin.Business.Engine.BO.Transversal;
using Bitcoin.Business.Engine.BO.Betting;

namespace Bitcoin.Business.Engine.Manager.Betting.Tournament
{
    /// <summary>
    /// Capa de negocios de los torneos
    /// </summary>
    public class TournamentManager
    {
        #region Properties
        private TournamentDataManager dataManager;
        private TournamentDataManager DataManager
        {
            get
            {
                if (dataManager == null)
                {
                    dataManager = new TournamentDataManager();
                }
                return dataManager;
            }           
        }
        #endregion

        #region MyRegion
         /// <summary>
        /// Metodo que permite consultar la lista de tipos
        /// de deportes
        /// </summary>
        /// <returns></returns>
        public List<SportsBO> GetSports()
        {
            return DataManager.GetSports();
        }

        /// <summary>
        /// Metodo que crea los tipos de deportes
        /// </summary>
        /// <param name="listSportsTypes"></param>
        public void CreateSports(List<SportsBO> sportsList)
        {
            foreach (var item in sportsList)
            {
                DataManager.CreateSport(item);
            } 
        }
        #endregion
    }
}
