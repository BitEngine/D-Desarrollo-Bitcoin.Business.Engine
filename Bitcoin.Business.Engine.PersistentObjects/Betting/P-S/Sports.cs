using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using Bitcoin.Business.Engine.PersistentObjects.NonPersistent;
using Bitcoin.Business.Engine.PersistentObjects.Betting.T_W;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.P_S
{
    /// <summary>
    /// Clase que representa los deportes
    /// </summary>
    public class Sports : NonPersistentEntity
    {
        /// <summary>
        /// Propiedad que identifica el nombre del deporte
        /// </summary>
        private string name;
        public string Name
        {
            get { return name; }
            set { SetPropertyValue<string>("Name", ref name, value); }
        }

        [Association("Sports-Tournaments")]
        public XPCollection<Tournaments> ListTournaments
        {
            get { return GetCollection<Tournaments>("ListTournaments"); }
        }


        public Sports(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
