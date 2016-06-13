using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.NonPersistent;
using DevExpress.Xpo;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.T_W
{
    /// <summary>
    /// Clase que representa un usuario en el 
    /// sistema
    /// </summary>
    public class Users : NonPersistentEntity
    {
        private string names;        
        public string Names
        {
            get { return names; }
            set { SetPropertyValue<string>("Names", ref names, value); }
        }

        private string surnames;        
        public string Surnames
        {
            get { return surnames; }
            set { SetPropertyValue<string>("Surnames", ref surnames, value); }
        }

        private DateTime birthdate;        
        public DateTime Birthdate
        {
            get { return birthdate; }
            set { SetPropertyValue<DateTime>("Birthdate", ref birthdate, value); }
        }
       

        public Users(Session session) : base(session) { }       
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
