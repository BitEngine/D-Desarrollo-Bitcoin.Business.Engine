using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.NonPersistent;
using DevExpress.Xpo;
using Bitcoin.Business.Engine.PersistentObjects.Betting.P_S;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.T_W
{
    /// <summary>
    /// Clase que representa los torneos
    /// </summary>
    public class Tournaments : NonPersistentEntity
    {
        /// <summary>
        /// Nombre del torneo
        /// </summary>
        private string name;
        public string Name
        {
            get { return name; }
            set { SetPropertyValue<string>("Name", ref name, value); }
        }

        /// <summary>
        /// Identifica el deporte al que pertenece el 
        /// torneo
        /// </summary>
        private Sports sport;
        [Association("Sports-Tournaments")]
        public Sports Sport
        {
            get { return sport; }
            set { SetPropertyValue<Sports>("Sport", ref sport, value); }
        }

        /// <summary>
        /// Lista de fases del torneo
        /// </summary>
        [Association("Tournaments-Phases")]
        public XPCollection<Phases> ListPhases
        {
            get { return GetCollection<Phases>("ListPhases"); }
        }

        public Tournaments(Session session) : base(session) { }       
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
