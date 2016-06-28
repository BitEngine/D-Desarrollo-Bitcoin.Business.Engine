using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.Betting.T_W;
using DevExpress.Xpo;
using Bitcoin.Business.Engine.PersistentObjects.Betting.P_S;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.E_H
{
    /// <summary>
    /// Lista de las apuestas "Pollas"
    /// que realiza un usuario.
    /// </summary>
    public class GeneratorUsers : Users
    {
        [Association("GeneratorUsers-Pullets")]
        public XPCollection<Pullets> ListPullets
        {
            get { return GetCollection<Pullets>("ListTeams"); }
        }

        public GeneratorUsers(Session session) : base(session) { }       
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
