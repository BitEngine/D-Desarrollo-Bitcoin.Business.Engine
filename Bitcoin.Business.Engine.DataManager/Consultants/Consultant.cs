using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using Bitcoin.Business.Engine.PersistentObjects.SessionDB;
using DevExpress.Data.Filtering;
using Bitcoin.Business.Engine.Transformer.Mapper;
using Bitcoin.Business.Engine.Transformer.Mapper.Factory;

namespace Bitcoin.Business.Engine.DataManager.Consultants
{
    public class Consultant<Persistent, BusinessObject> : IConsultant<Persistent, BusinessObject>
    {
        #region Public Methods
        public List<BusinessObject> GetColeccion(string filter, params object[] parameters)
        {
            try
            {
                List<BusinessObject> outList = Activator.CreateInstance<List<BusinessObject>>();
                using (UnitOfWork unit = SessionManager.GetNewUnitOfWork())
                {
                    CriteriaOperator criteriaFilter = CriteriaOperator.Parse(filter, parameters);
                    XPCollection<Persistent> coleccionObjeto = new XPCollection<Persistent>(unit, criteriaFilter);
                    MapperManager<Persistent, BusinessObject> mapper = TransformerFactory.Create<Persistent, BusinessObject>();
                    foreach (var item in coleccionObjeto)
                    {
                        outList.Add(mapper.MapperPersistent2BO(item));
                    }
                    return outList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<BusinessObject> GetColeccion()
        {
            try
            {
                List<BusinessObject> outList = Activator.CreateInstance<List<BusinessObject>>();
                using (UnitOfWork unit = SessionManager.GetNewUnitOfWork())
                {                    
                    XPCollection<Persistent> coleccionObjeto = new XPCollection<Persistent>(unit);
                    MapperManager<Persistent, BusinessObject> mapper = TransformerFactory.Create<Persistent, BusinessObject>();
                    foreach (var item in coleccionObjeto)
                    {
                        outList.Add(mapper.MapperPersistent2BO(item));
                    }
                    return outList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<BusinessObject> GetProcedure(string ProcedureName, params object[] list)
        {
            try
            {
                List<BusinessObject> outList = Activator.CreateInstance<List<BusinessObject>>();
                using (UnitOfWork unit = SessionManager.GetNewUnitOfWork())
                {
                    OperandValue[] parametros = GetOperands(list);
                    ICollection<Persistent> response = new List<Persistent>();
                    response = unit.GetObjectsFromSproc<Persistent>(ProcedureName, parametros);
#if DEBUG
                    var tipoRecibido = typeof(Persistent).GetType().Name;
                    var totalElementos = response.Count;
                    var totalParametrosProcedimiento = list.Count();
#endif

                    MapperManager<Persistent, BusinessObject> mapper = TransformerFactory.Create<Persistent, BusinessObject>();
                    foreach (var item in response.ToList<Persistent>())
                    {
                        outList.Add(mapper.MapperPersistent2BO(item));
                    }
                }
                return outList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BusinessObject GetObjectByOid(object oid)
        {
            try
            {
                using (UnitOfWork unit = SessionManager.GetNewUnitOfWork())
                {
                    BusinessObject outObjectBO = Activator.CreateInstance<BusinessObject>();
                    Persistent persistenObject = unit.GetObjectByKey<Persistent>(oid);
                    if (persistenObject != null)
                    {
                        MapperManager<Persistent, BusinessObject> mapper = TransformerFactory.Create<Persistent, BusinessObject>();
                        outObjectBO = mapper.MapperPersistent2BO(persistenObject);
                        return outObjectBO;
                    }
                    else
                    {
                        return default(BusinessObject);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BusinessObject GetObject(string filter, params object[] parameters)
        {
            try
            {
                BusinessObject outObjectBO = Activator.CreateInstance<BusinessObject>();
                using (UnitOfWork unit = SessionManager.GetNewUnitOfWork())
                {
                    CriteriaOperator criteriaFilter = CriteriaOperator.Parse(filter, parameters);
                    Persistent persistentObject = unit.FindObject<Persistent>(criteriaFilter);
                    if (persistentObject != null)
                    {
                        MapperManager<Persistent, BusinessObject> mapper = TransformerFactory.Create<Persistent, BusinessObject>();
                        outObjectBO = mapper.MapperPersistent2BO(persistentObject);
                    }
                    return outObjectBO;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BusinessObject CreateToReturnObject(BusinessObject oObject)
        {
            throw new NotImplementedException();
        }

        public void CreateObject(BusinessObject oObject)
        {
            throw new NotImplementedException();
        }

        public BusinessObject UpdateObject(BusinessObject oObject, object oid)
        {
            throw new NotImplementedException();
        }

        public void DeleteObject(object oid)
        {
            throw new NotImplementedException();
        }

        public void DeleteObject()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Metodo que ternona los parametros de entrada del 
        /// SP
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private OperandValue[] GetOperands(object[] list)
        {
            if (list != null && list.Length > 0)
            {
                var parametersLegth = list.Length;
                OperandValue[] parameters = new OperandValue[parametersLegth];

                for (int parameter = 0; parameter < parametersLegth; parameter++)
                {
                    parameters[parameter] = new OperandValue(list[parameter]);
                }
                return parameters;
            }
            else
                return null;
        }
        #endregion
    }
}
