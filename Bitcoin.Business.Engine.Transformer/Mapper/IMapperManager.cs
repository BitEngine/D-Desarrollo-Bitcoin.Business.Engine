using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Contexts;
using DevExpress.Xpo;

namespace Bitcoin.Business.Engine.Transformer.Mapper
{
    interface IMapperManager<Persistent, BusinessObject>
    {
        BusinessObject MapperPersistent2BO(Persistent oObject);
        Persistent MapperBO2Persistent(BusinessObject objeto, UnitOfWork unit);
    }
}
