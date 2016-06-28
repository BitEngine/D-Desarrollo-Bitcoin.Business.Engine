using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.DataAccessLayer.Consultants
{
    /// <summary>
    /// Interfaz que determina los metodos CRUD para comunicación 
    /// con la base de datos
    /// </summary>
    /// <typeparam name="Persistent">Objeto de persistencia del ORM</typeparam>
    /// <typeparam name="BusinessObject">Objeto de negocio (BO)</typeparam>
    public interface IConsultant<Persistent, BusinessObject>
    {
        #region Consultation
        #region Consultas
        List<BusinessObject> GetCollection(string filter, params object[] parameters);

        List<BusinessObject> GetCollection();

        List<BusinessObject> GetProcedure(string procedureName, params object[] list);

        BusinessObject GetObjectByOid(object oid);

        BusinessObject GetObject(string filter, params object[] parameters);
        #endregion

        #region Create
        BusinessObject CreateToReturnObject(BusinessObject oObject);

        void CreateObject(BusinessObject oObject);
        #endregion

        #endregion

        #region Update
        BusinessObject UpdateObject(BusinessObject oObject, object oid);
        #endregion

        #region Detele
        void DeleteObject(object oid);

        void DeleteObject();
        #endregion
    }
}
