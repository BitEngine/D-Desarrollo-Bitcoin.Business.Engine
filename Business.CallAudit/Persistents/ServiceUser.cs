using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;

namespace Business.CallAudit.Persistents
{
    public class ServiceUser : XPCustomObject
    {
        private Int64 oid;
        [Key(true)]
        public Int64 Oid
        {
            get
            {
                return oid;
            }
            set
            {
                SetPropertyValue<Int64>("Oid", ref oid, value);
            }
        }

        private string ip;
        public string IP
        {
            get
            {
                return ip;
            }
            set
            {
                SetPropertyValue<string>("IP", ref ip, value);
            }
        }

        private string responsible;
        public string Responsible
        {
            get
            {
                return responsible;
            }
            set
            {
                SetPropertyValue<string>("Responsible", ref responsible, value);
            }
        }

        public ServiceUser(Session session)
            : base(session)
        {
        }
    }
}
