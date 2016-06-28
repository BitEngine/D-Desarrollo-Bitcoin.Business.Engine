using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.NonPersistent;
using DevExpress.Xpo;
using Bitcoin.Business.Engine.PersistentObjects.Betting.A_D;
using Bitcoin.Business.Engine.PersistentObjects.Betting.E_H;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.M_O
{
    /// <summary>
    /// Clase que representa las apuestas 
    /// realizadas a un marcador
    /// </summary>
    public class MarkerBets : Bets
    {
        /// <summary>
        /// Juego al que se apuesta por marcador
        /// </summary>
        private Games game;
        public Games Game
        {
            get { return game; }
            set { SetPropertyValue<Games>("Game", ref game, value); }
        }

        public MarkerBets(Session session) : base(session) { }       
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
