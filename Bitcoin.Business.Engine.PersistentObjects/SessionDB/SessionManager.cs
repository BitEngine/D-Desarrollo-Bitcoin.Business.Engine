using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using System.Configuration;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo.DB;
using Bitcoin.Business.Engine.PersistentObjects.Betting.T_W;
using System.Collections;

namespace Bitcoin.Business.Engine.PersistentObjects.SessionDB
{
    public class SessionManager
    {
        #region SESION PROPIA
        public static Session GetNewSession()
        {
            return new Session(DataLayer);
        }
       
        /// <summary>
        /// Genera el data unidad de trabajo para los objetos de negocio del ESB
        /// </summary>
        /// <returns></returns>
        public static UnitOfWork GetNewUnitOfWork()
        {
            return new UnitOfWork(DataLayer);
        }

        private readonly static object lockObject = new object();

        static volatile IDataLayer fDataLayer;
        static IDataLayer DataLayer
        {

            get
            {
                if (fDataLayer == null)
                {
                    lock (lockObject)
                    {
                        if (fDataLayer == null)
                        {

                            fDataLayer = GetDataLayer();
                            using (Session session = new Session(fDataLayer))
                            {
                                /// Se agrega para que se actualice el esquema de la BD solamente con los XPO contenidos en el Assembly 
                                /// al cual pertenece la clase FxOrders. XPO de otros Assemblies no serán actualizados automáticamente.
                                System.Reflection.Assembly[] assemblies = new System.Reflection.Assembly[] 
                                    {
                                       typeof(Users).Assembly
                                    };

                                session.UpdateSchema(assemblies);
                                session.CreateObjectTypeRecords(assemblies);
                            }
                            ICollection Classes = fDataLayer.Dictionary.Classes;
                        }
                    }
                }
                return fDataLayer;
            }
        }

        private static IDataLayer GetDataLayer()
        {
            try
            {
                XpoDefault.Session = null;

                String conn = ConfigurationManager.ConnectionStrings["BitcoinBusinessEngine"].ConnectionString;

                XPDictionary dict = new ReflectionDictionary();

                IDataStore store = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.DatabaseAndSchema);

                dict.GetDataStoreSchema(typeof(Users).Assembly);

                IDataLayer dl = new ThreadSafeDataLayer(dict, store);

                return dl;
            }
            catch (Exception)
            {
                throw;
            }
        }      

        #endregion
    }
}
