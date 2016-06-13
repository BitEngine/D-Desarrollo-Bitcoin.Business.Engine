using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.NonPersistent;
using DevExpress.Xpo;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.P_S
{
    /// <summary>
    /// Clase que representa la
    /// polla que se crea en el sistema
    /// </summary>
    public class Pullet : NonPersistentEntity
    {

        public Pullet(Session session) : base(session) { }       
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
