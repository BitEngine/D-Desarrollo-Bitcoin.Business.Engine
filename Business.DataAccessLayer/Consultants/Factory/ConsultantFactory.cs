using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.DataAccessLayer.Consultants.Factory
{
    public class ConsultantFactory
    {
        public static IConsultant<Persistent, BusinessObject> Create<Persistent, BusinessObject>()
        {
            return new Consultant<Persistent, BusinessObject>() as IConsultant<Persistent, BusinessObject>;
        }
    }
}
