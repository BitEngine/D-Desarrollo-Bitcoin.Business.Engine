using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using Business.CallAudit.Persistents;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Diagnostics;
using Business.CallAudit.SessionAudit;

namespace Business.CallAudit
{
    public class CalledRegister
    {
        public static void AuditPersistent()
        {
            try
            {
                string ipCliente = GetIP();
                using (UnitOfWork unit = SessionManager.GetNewUnitOfWork())
                {
                    Calls audit = new Calls(unit);
                    audit.User = ObtenerClienteServicio(unit);
                    AsignarInformacionLlamado(audit);
                    unit.CommitChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        private static void AsignarInformacionLlamado(Calls audit)
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame[] stackFrames = stackTrace.GetFrames();

            if (stackFrames != null)
            {
                int traceMethods = stackFrames.Length;
                var currentDLL = typeof(CalledRegister).Module;
                var callDLL = currentDLL;
                var invokedMethodName = string.Empty;
                int calledMethods= 0;
                do
                {
                    var traza = stackFrames[calledMethods];
                    invokedMethodName = traza.GetMethod().Name;

                    callDLL = traza.GetMethod().Module;
                    calledMethods++;
                } while (calledMethods < traceMethods && callDLL == currentDLL);

                audit.InvokedDLL = Convert.ToString(callDLL);
                audit.InvokedMethod = invokedMethodName;
            }
        }

        private static string GetIP()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint =
            prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string ip = endpoint.Address;
            return ip;
        }

        private static ServiceUser ObtenerClienteServicio(UnitOfWork unit)
        {
            string userIP = GetIP();
            XPCollection<ServiceUser> objectCollection = new XPCollection<ServiceUser>(unit);
            var element = objectCollection.Where<ServiceUser>
                                           (client => client.IP == userIP)
                                           .FirstOrDefault<ServiceUser>();

            if (element != null && element.Oid != 0)
            {
                return element;
            }
            else
            {
                return new ServiceUser(unit) { IP = userIP, Responsible = "No registrado" };
            }
        }
    }
}
