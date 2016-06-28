using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.NonPersistent;
using DevExpress.Xpo;
using Bitcoin.Business.Engine.PersistentObjects.Betting.A_D;
using Bitcoin.Business.Engine.PersistentObjects.Betting.E_H;
using Bitcoin.Business.Engine.PersistentObjects.Betting.T_W;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.P_S
{
    /// <summary>
    /// Clase que representa la
    /// polla que se crea en el sistema
    /// </summary>
    public class Pullets : NonPersistentEntity
    {

        /// <summary>
        /// Identifica el usuario que realiza la "Polla"      
        /// </summary>
        private GeneratorUsers generatorUser;
        [Association("GeneratorUsers-Pullets")]
        public GeneratorUsers GeneratorUser
        {
            get { return generatorUser; }
            set { SetPropertyValue<GeneratorUsers>("GeneratorUser", ref generatorUser, value); }
        }

        /// <summary>
        /// Relacion con el torneo
        /// </summary>
        private Tournaments tournament;
        public Tournaments Tournament
        {
            get { return tournament; }
            set { SetPropertyValue<Tournaments>("Tournament", ref tournament, value); }
        }

        /// <summary>
        /// Lista de las apuestas que se realiza en la polla
        /// </summary>
        [Association("Pullets-Bets")]
        public XPCollection<Bets> ListBets
        {
            get { return GetCollection<Bets>("ListBets"); }
        }

        public Pullets(Session session) : base(session) { }       
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
