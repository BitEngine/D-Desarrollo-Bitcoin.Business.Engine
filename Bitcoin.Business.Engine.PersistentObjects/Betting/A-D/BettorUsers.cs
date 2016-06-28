using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.Betting.T_W;
using DevExpress.Xpo;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.A_D
{
    /// <summary>
    /// clase que representa el usuario que realizará
    /// las apuestas en el sistema
    /// </summary>
    public class BettorUsers : Users
    {
        [Association("BettorUsers-Bets", typeof(Bets))]
        public XPCollection<Bets> ListBets
        {
            get { return GetCollection<Bets>("ListBets"); }
        }

        public BettorUsers(Session session) : base(session) { }       
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
