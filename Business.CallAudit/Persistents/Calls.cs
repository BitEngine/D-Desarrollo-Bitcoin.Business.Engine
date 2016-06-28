using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;

namespace Business.CallAudit.Persistents
{
    public class Calls : XPCustomObject
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

        private string serverIP;
        public string ServerIP
        {
            get
            {
                return serverIP;
            }
            set
            {
                SetPropertyValue<string>("ServerIP", ref serverIP, value);
            }
        }

        private string invokedMethod;
        public string InvokedMethod
        {
            get
            {
                return invokedMethod;
            }
            set
            {
                SetPropertyValue<string>("InvokedMethod", ref invokedMethod, value);
            }
        }

        private string invokedDLL;
        public string InvokedDLL
        {
            get
            {
                return invokedDLL;
            }
            set
            {
                SetPropertyValue<string>("InvokedDLL", ref invokedDLL, value);
            }
        }

        private ServiceUser user;
        public ServiceUser User
        {
            get
            {
                return user;
            }
            set
            {
                SetPropertyValue<ServiceUser>("User", ref user, value);
            }
        }

        private DateTime callDate;
        public DateTime CallDate
        {
            get
            {
                return callDate;
            }
            set
            {
                SetPropertyValue<DateTime>("CallDate", ref callDate, value);
            }
        }

        public Calls(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            CallDate = DateTime.Now;
            ServerIP = AssistantIP.LocalIPAddress();
        }
    }
}
