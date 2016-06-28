using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.NonPersistent;
using DevExpress.Xpo;
using Bitcoin.Business.Engine.PersistentObjects.Betting.P_S;
using Bitcoin.Business.Engine.PersistentObjects.Betting.T_W;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.E_H
{
    /// <summary>
    /// Entidad que representa los partidos
    /// y/o juegos de un torneo
    /// </summary>
    public class Games : NonPersistentEntity
    {

        /// <summary>
        /// Identifica a que fase del torneo pertenece
        /// el juego
        /// </summary>
        private Phases phase;
        public Phases Phase
        {
            get { return phase; }
            set { SetPropertyValue<Phases>("Phase", ref phase, value); }
        }

        /// <summary>
        /// Identifica el equipo uno para apostar
        /// </summary>
        private Teams teamOne;
        public Teams TeamOne
        {
            get { return teamOne; }
            set { SetPropertyValue<Teams>("TeamOne", ref teamOne, value); }
        }

        /// <summary>
        /// Identifica el equipo dos para apostar
        /// </summary>
        private Teams teamTwo;
        public Teams TeamTwo
        {
            get { return teamTwo; }
            set { SetPropertyValue<Teams>("TeamTwo", ref teamTwo, value); }
        }

        public Games(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
