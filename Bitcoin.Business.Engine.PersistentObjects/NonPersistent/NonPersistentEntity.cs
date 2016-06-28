using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;

namespace Bitcoin.Business.Engine.PersistentObjects.NonPersistent
{
    /// <summary>
    /// Clase que representa el elemento 
    /// comun en las demas clases persistentes
    /// </summary>
    [NonPersistent]
    public class NonPersistentEntity : XPCustomObject
    {
        private Int64 fId;
        [Key(true)]
        public Int64 Oid
        {
            get
            {
                return fId;
            }
            set
            {
                SetPropertyValue<Int64>("Oid", ref fId, value);
            }
        }

        public NonPersistentEntity(Session session) 
            : base(session) { }

    }
}
