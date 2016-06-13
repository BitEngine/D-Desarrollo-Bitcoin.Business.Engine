using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.NonPersistent;
using DevExpress.Xpo;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.A_D
{
    /// <summary>
    /// Clase que representa las apuestas que se
    /// crean en el sistema para un deporte
    /// </summary>
    public class Betting : NonPersistentEntity
    {
        public Betting(Session session) : base(session) { }       
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
