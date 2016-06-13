using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.NonPersistent;
using DevExpress.Xpo;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.E_H
{
    /// <summary>
    /// Entidad que representa los partidos
    /// y/o juegos de un torneo
    /// </summary>
    public class Games : NonPersistentEntity
    {
        public Games(Session session) : base(session) { }       
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
