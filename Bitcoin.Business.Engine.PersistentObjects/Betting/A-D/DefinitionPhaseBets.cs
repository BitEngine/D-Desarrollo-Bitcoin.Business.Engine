using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.NonPersistent;
using DevExpress.Xpo;
using Bitcoin.Business.Engine.PersistentObjects.Betting.P_S;
using Bitcoin.Business.Engine.PersistentObjects.Betting.T_W;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.A_D
{
    /// <summary>
    /// Apuestas relizadas sobre la predicción de
    /// una fase
    /// </summary>
    public class DefinitionPhaseBets : Bets
    {
        /// <summary>
        /// Identifica a que fase del torneo pertenece
        /// la apuesta
        /// </summary>
        private Phases phase;
        public Phases Phase
        {
            get { return phase; }
            set { SetPropertyValue<Phases>("Phase", ref phase, value); }
        }

        /// <summary>
        /// Lista de equipos apostados
        /// en una fase. Identifica
        /// la predicción de que los equipos que estarán
        /// en una fase especifica
        /// </summary>
        [Association("DefinitionPhaseBets-Teams")]
        public XPCollection<Teams> ListTeams
        {
            get { return GetCollection<Teams>("ListTeams"); }
        }

        public DefinitionPhaseBets(Session session) : base(session) { }       
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
