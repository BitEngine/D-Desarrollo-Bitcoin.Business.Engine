using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.Betting.T_W;
using DevExpress.Xpo;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.E_H
{
    /// <summary>
    /// Clase que representa los usuarios
    /// que generar las apuestas o pollas 
    /// en el sistema
    /// </summary>
    public class GeneratorUsers : Users
    {
        public GeneratorUsers(Session session) : base(session) { }       
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
