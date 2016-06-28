using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using Bitcoin.Business.Engine.Transformer.Factory;//fabrica que debe ser reemplazada para por la fabrica requerida para el proyecto
using Business.DataAccessLayer.SessionDB;
using Business.TransformerLayer.Mapper;


namespace Business.DataAccessLayer.Consultants
{
    public class Consultant<Persistent, BusinessObject> : IConsultant<Persistent, BusinessObject>
    {
        #region Public Methods
        /// <summary>
        /// Metodo que permite consultar una coleccion de objetos
        /// </summary>
        /// <param name="filter">filtro</param>
        /// <param name="parameters">paramtros</param>
        /// <returns></returns>
        public List<BusinessObject> GetCollection(string filter, params object[] parameters)
        {
            try
            {
                List<BusinessObject> outList = Activator.CreateInstance<List<BusinessObject>>();
                using (UnitOfWork unit = SessionManager<Persistent>.GetNewUnitOfWork())
                {
                    CriteriaOperator criteriaFilter = CriteriaOperator.Parse(filter, parameters);
                    XPCollection<Persistent> objectCollection = new XPCollection<Persistent>(unit, criteriaFilter);
                    MapperManager<Persistent, BusinessObject> mapper = TransformerFactory.Create<Persistent, BusinessObject>();
                    foreach (var item in objectCollection)
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

        /// <summary>
        /// Metodo que permite consultar una colección
        /// </summary>
        /// <returns></returns>
        public List<BusinessObject> GetCollection()
        {
            try
            {
                List<BusinessObject> outList = Activator.CreateInstance<List<BusinessObject>>();
                using (UnitOfWork unit = SessionManager<Persistent>.GetNewUnitOfWork())
                {
                    XPCollection<Persistent> objectCollection = new XPCollection<Persistent>(unit);
                    MapperManager<Persistent, BusinessObject> mapper = TransformerFactory.Create<Persistent, BusinessObject>();
                    foreach (var item in objectCollection)
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

        /// <summary>
        /// Metodo que permite consultar un procedimiento almacenado
        /// </summary>
        /// <param name="ProcedureName">nombre del procedimiento almacenado</param>
        /// <param name="list">lista de parametros</param>
        /// <returns></returns>
        public List<BusinessObject> GetProcedure(string procedureName, params object[] list)
        {
            try
            {
                List<BusinessObject> outList = Activator.CreateInstance<List<BusinessObject>>();
                using (UnitOfWork unit = SessionManager<Persistent>.GetNewUnitOfWork())
                {
                    OperandValue[] parametros = GetOperands(list);
                    ICollection<Persistent> response = new List<Persistent>();
                    response = unit.GetObjectsFromSproc<Persistent>(procedureName, parametros);
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

        /// <summary>
        /// Metodo que consulta un objeto por id
        /// </summary>
        /// <param name="oid">identificador del objeto "Llave primaria"</param>
        /// <returns></returns>
        public BusinessObject GetObjectByOid(object oid)
        {
            try
            {
                using (UnitOfWork unit = SessionManager<Persistent>.GetNewUnitOfWork())
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

        /// <summary>
        /// Metodo que consulta un objeto con filtro
        /// </summary>
        /// <param name="filter">filtro</param>
        /// <param name="parameters">parametros</param>
        /// <returns></returns>
        public BusinessObject GetObject(string filter, params object[] parameters)
        {
            try
            {
                BusinessObject outObjectBO = Activator.CreateInstance<BusinessObject>();
                using (UnitOfWork unit = SessionManager<Persistent>.GetNewUnitOfWork())
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

        /// <summary>
        /// Metodo que permite crear un objeto y retorna el
        /// registro creado
        /// </summary>
        /// <param name="oObject">objeto de negocio a crear</param>
        /// <returns></returns>
        public BusinessObject CreateToReturnObject(BusinessObject oObject)
        {
            try
            {
                using (UnitOfWork unit = SessionManager<Persistent>.GetNewUnitOfWork())
                {
                    MapperManager<Persistent, BusinessObject> mapper = TransformerFactory.Create<Persistent, BusinessObject>();
                    Persistent persistent = mapper.MapperBO2Persistent(oObject, unit);
                    unit.CommitChanges();
                    return mapper.MapperPersistent2BO(persistent);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo que crea un objeto
        /// </summary>
        /// <param name="oObject">objeto a crear</param>
        public void CreateObject(BusinessObject oObject)
        {
            try
            {
                using (UnitOfWork unit = SessionManager<Persistent>.GetNewUnitOfWork())
                {
                    MapperManager<Persistent, BusinessObject> mapper = TransformerFactory.Create<Persistent, BusinessObject>();
                    Persistent persistent = mapper.MapperBO2Persistent(oObject, unit);
                    unit.CommitChanges();                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo que actualiza un objeto de la base de datos
        /// </summary>
        /// <param name="oObject">información a actulizar</param>
        /// <param name="oid">identificador del registro</param>
        /// <returns></returns>
        public BusinessObject UpdateObject(BusinessObject oObject, object oid)
        {
            try
            {
                using (UnitOfWork unit = SessionManager<Persistent>.GetNewUnitOfWork())
                {
                    Persistent destination = unit.GetObjectByKey<Persistent>(oid);
                    MapperManager<Persistent, BusinessObject> mapper = TransformerFactory.Create<Persistent, BusinessObject>();
                    Persistent persistent = mapper.MapperBO2Persistent(oObject, destination);
                    unit.CommitChanges();
                    oObject = mapper.MapperPersistent2BO(persistent);
                    return oObject;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo que borra un registro por identificador
        /// </summary>
        /// <param name="oid">identificador del registro</param>
        public void DeleteObject(object oid)
        {
            try
            {
                using (UnitOfWork unit = SessionManager<Persistent>.GetNewUnitOfWork())
                {
                    Persistent persistent = unit.GetObjectByKey<Persistent>(oid);
                    unit.Delete(persistent);          
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo que borra los registros de la tabla
        /// </summary>
        public void DeleteObject()
        {
            try
            {
                using (UnitOfWork unit = SessionManager<Persistent>.GetNewUnitOfWork())
                {
                    XPCollection<Persistent> objectCollection = new XPCollection<Persistent>(unit);
                    unit.Delete(objectCollection);
                }
            }
            catch (Exception)
            {
                throw;
            }
            
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
