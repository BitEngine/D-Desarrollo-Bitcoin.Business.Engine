using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitcoin.Business.Engine.DataManager.Consultants
{
    /// <summary>
    /// Interfaz que determina los metodos CRUD para comunicación 
    /// con la base de datos
    /// </summary>
    /// <typeparam name="Persistent">Objeto de persistencia del ORM</typeparam>
    /// <typeparam name="BusinessObject">Objeto de negocio (BO)</typeparam>
    interface IConsultant<Persistent, BusinessObject>
    {
        #region Consultation
        #region Consultas
        List<BusinessObject> GetColeccion(string filter, params object[] parameters);

        List<BusinessObject> GetColeccion();

        List<BusinessObject> GetProcedure(string ProcedureName, params object[] list);

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
