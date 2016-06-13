using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using AutoMapper;
using Bitcoin.Business.Engine.Util.TransformerMessages;
using DevExpress.Xpo;

namespace Bitcoin.Business.Engine.Transformer.Mapper
{
    public abstract class MapperManager<Persistent, BusinessObjects> : IMapperManager<Persistent, BusinessObjects>
    {
        #region Public Methods
        public virtual void AdditionalSettings(IMappingExpression<Persistent, BusinessObjects> map, BusinessObjects destination)
        {

        }

        #region Transform Persistent to BusinessObjects
        public virtual BusinessObjects MapperPersistent2BO(Persistent oObject)
        {
            try
            {
                Type t = typeof(BusinessObjects);
                var map = AutoMapper.Mapper.CreateMap<Persistent, BusinessObjects>();
                foreach (PropertyInfo prop in t.GetProperties())
                {
                    bool isPrimitive = IsPrimitive(prop.PropertyType);
                    bool isEnum = prop.PropertyType.IsEnum;
                    bool isList = IsList(prop);
                    if (!isPrimitive || isEnum && prop.CanRead && prop.CanWrite || isList)
                    {
                        map.ForMember(prop.Name, opt => opt.Ignore());
                    }
                }
                BusinessObjects destination = (BusinessObjects)Activator.CreateInstance<BusinessObjects>();
                AdditionalSettings(map, destination);
                var customerViewItem = AutoMapper.Mapper.Map(oObject, destination);
                return customerViewItem;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual BusinessObjectsX MapperPersistent2BO<PersitentX, BusinessObjectsX>(PersitentX oObject)
        {
            try
            {
                Type t = typeof(BusinessObjectsX);
                var map = AutoMapper.Mapper.CreateMap<PersitentX, BusinessObjectsX>();
                foreach (PropertyInfo prop in t.GetProperties())
                {
                    bool isPrimitive = IsPrimitive(prop.PropertyType);
                    bool isEnum = prop.PropertyType.IsEnum;
                    bool isList = IsList(prop);
                    if (!isPrimitive || isEnum && prop.CanRead && prop.CanWrite || isList)
                    {
                        map.ForMember(prop.Name, opt => opt.Ignore());
                    }
                }
                BusinessObjectsX destination = (BusinessObjectsX)Activator.CreateInstance<BusinessObjectsX>();
                var customerViewItem = AutoMapper.Mapper.Map(oObject, destination);
                return customerViewItem;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Transform BusinessObjects to Persistent
        public virtual Persistent MapperBO2Persistent(BusinessObjects oObject, UnitOfWork unit)
        {
            try
            {
                Type t = typeof(Persistent);
                var map = AutoMapper.Mapper.CreateMap<BusinessObjects, Persistent>();
                foreach (PropertyInfo prop in t.GetProperties())
                {
                    bool isPrimitive = IsPrimitive(prop.PropertyType);
                    bool isEnum = prop.PropertyType.IsEnum;
                    bool isList = IsList(prop);
                    if (!isPrimitive || isEnum && prop.CanRead && prop.CanWrite || isList)
                    {
                        map.ForMember(prop.Name, opt => opt.Ignore());
                    }
                }
                Persistent destination = (Persistent)Activator.CreateInstance(typeof(Persistent), unit);
                AdditionalSettings(map, oObject, unit);
                var customerViewItem =
                   AutoMapper.Mapper.Map(oObject, destination);
                return customerViewItem;
            }
            catch (Exception)
            {
                throw;
            }
        }

         public virtual void AdditionalSettings(IMappingExpression<BusinessObjects, Persistent> map, BusinessObjects objeto, UnitOfWork unit)
         {


         }

         protected void AdditionalSettings<PersistentX, BusinessObjectsX>(IMappingExpression<BusinessObjectsX, PersistentX> map, object objeto, UnitOfWork unit)
         {
             Type persistent = typeof(PersistentX);
             Type business = typeof(BusinessObjectsX);

             foreach (PropertyInfo prop in persistent.GetProperties())
             {
                 var propertyBusiness = business.GetType().GetProperty(prop.Name);
                 if (propertyBusiness != null)
                 {
                     var typePropertyBusiness = propertyBusiness.GetType().Name;
                     if (typePropertyBusiness != prop.GetType().Name)
                     {
                         throw new Exception(string.Format(TransformerMessages.TrasnformationError, typePropertyBusiness, persistent.Name));
                     }
                 }
             }
         }
        #endregion
        #endregion

        #region Private Methods
        private static bool IsPrimitive(Type t)
        {
            // TODO: put any type here that you consider as primitive as I didn't
            // quite understand what your definition of primitive type is
            return new[] { 
            typeof(string), 
            typeof(char),
            typeof(byte),
            typeof(sbyte),
            typeof(ushort),
            typeof(short),
            typeof(uint),
            typeof(int),
            typeof(ulong),
            typeof(long),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(DateTime),
            typeof(Boolean),
        }.Contains(t);
        }

        private bool IsList(PropertyInfo prop)
        {
            if (prop.PropertyType.FullName.Contains("List") || prop.PropertyType.FullName.Contains("XPCollection"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }       
        #endregion
    }
}
