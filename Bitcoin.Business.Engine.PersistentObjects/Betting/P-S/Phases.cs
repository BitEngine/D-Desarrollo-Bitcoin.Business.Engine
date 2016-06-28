using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.NonPersistent;
using DevExpress.Xpo;
using Bitcoin.Business.Engine.PersistentObjects.Betting.T_W;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.P_S
{
    /// <summary>
    /// Clase que representa las  fases de una competencia
    /// </summary>
    public class Phases : NonPersistentEntity
    {
        /// <summary>
        /// Nombre de la fase
        /// </summary>
        private string name;
        public string Name
        {
            get { return name; }
            set { SetPropertyValue<string>("Name", ref name, value); }
        }

        private Tournaments tournament;
        [Association("Tournaments-Phases")]
        public Tournaments Tournament
        {
            get { return tournament; }
            set { SetPropertyValue<Tournaments>("Tournament", ref tournament, value); }
        }

        public Phases(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
