using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Reflection;
using DevExpress.Xpo;

namespace Business.TransformerLayer.Mapper
{
    public class MapperManager<Persistent, BusinessObject> : IMapperManager<Persistent, BusinessObject>
    {
        #region Public Methods
        public virtual void AdditionalSettings(IMappingExpression<Persistent, BusinessObject> map, BusinessObject destination)
        {

        }

        #region Transform Persistent to BusinessObjects
        public virtual BusinessObject MapperPersistent2BO(Persistent oObject)
        {
            try
            {
                Type t = typeof(BusinessObject);
                var map = AutoMapper.Mapper.CreateMap<Persistent, BusinessObject>();
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
                BusinessObject destination = (BusinessObject)Activator.CreateInstance<BusinessObject>();
                AdditionalSettings(map, destination);
                var customerViewItem = AutoMapper.Mapper.Map(oObject, destination);
                return customerViewItem;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual BusinessObjectX MapperPersistent2BO<PersitentX, BusinessObjectX>(PersitentX oObject)
        {
            try
            {
                Type t = typeof(BusinessObjectX);
                var map = AutoMapper.Mapper.CreateMap<PersitentX, BusinessObjectX>();
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
                BusinessObjectX destination = (BusinessObjectX)Activator.CreateInstance<BusinessObjectX>();
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
        public Persistent MapperBO2Persistent(BusinessObject oObject, Persistent destination)
        {
            throw new NotImplementedException();
        }

        public virtual Persistent MapperBO2Persistent(BusinessObject oObject, UnitOfWork unit)
        {
            try
            {
                Type t = typeof(Persistent);
                var map = AutoMapper.Mapper.CreateMap<BusinessObject, Persistent>();
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

        public virtual void AdditionalSettings(IMappingExpression<BusinessObject, Persistent> map, BusinessObject objeto, UnitOfWork unit)
        {


        }

        protected void AdditionalSettings<PersistentX, BusinessObjectX>(IMappingExpression<BusinessObjectX, PersistentX> map, object objeto, UnitOfWork unit)
        {
            Type persistent = typeof(PersistentX);
            Type business = typeof(BusinessObjectX);

            foreach (PropertyInfo prop in persistent.GetProperties())
            {
                var propertyBusiness = business.GetType().GetProperty(prop.Name);
                if (propertyBusiness != null)
                {
                    var typePropertyBusiness = propertyBusiness.GetType().Name;
                    if (typePropertyBusiness != prop.GetType().Name)
                    {
                        throw new Exception(string.Format("Error Mapeo de Datos {0}", typePropertyBusiness, persistent.Name));
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
