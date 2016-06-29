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
    /// Clase que representa las apuestas que se
    /// crean en el sistema para un deporte
    /// </summary>
    public class Bets : NonPersistentEntity
    {

        /// <summary>
        /// asociación la polla
        /// </summary>
        private Pullets pullet;
        [Association("Pullets-Bets")]
        public Pullets Pullet
        {
            get { return pullet; }
            set { SetPropertyValue<Pullets>("Pullet", ref pullet, value); }
        }       

        /// <summary>
        /// Lista de los usuarios que realizan las apuestas
        /// </summary>
        [Association("Users-Bets", typeof(Users))]
        public XPCollection<Users> ListBettorUsers
        {
            get { return GetCollection<Users>("ListBettorUsers"); }
        }


        public Bets(Session session) : base(session) { }       
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
