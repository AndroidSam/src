using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessEntities;
using WcfGetService.DAL_Logic;

namespace WcfGetService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Getservice : BaseClass, IGetService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<UserGroupEntities> GetAllUserGroup()
        {
            try
            {
                DALSelectUserGroup _ObjData = new DALSelectUserGroup();
                return _ObjData.GetAllUserGroup();
            }
            catch (Exception ex)
            {
                throw ConstructFaultException(ex);
            }
        }

        public int InsertUpdateUserGroup(UserGroupEntities UserGroup_entity)
        {
            try
            {
                DALCRUDUserGroup _ObjData = new DALCRUDUserGroup();
                return _ObjData.InsertUpdateUserGroup(UserGroup_entity);
            }
            catch (Exception ex)
            {
                throw ConstructFaultException(ex);
            }
        }

        public List<UserTypeEntities> GetAllUserType()
        {
            try
            {
                DALSelectUserGroup _ObjData = new DALSelectUserGroup();
                return _ObjData.GetAllUserType();
            }
            catch (Exception ex)
            {
                throw ConstructFaultException(ex);
            }
        }

        public int InsertUpdateUserType(UserTypeEntities UserType_Entity)
        {
            try
            {
                DALCRUDUserGroup _ObjData = new DALCRUDUserGroup();
                return _ObjData.InsertUpdateuserType(UserType_Entity);
            }
            catch (Exception ex)
            {
                throw ConstructFaultException(ex);
            }
        }

        public List<MenuEntities> GetMenuAll()
        {
            try
            {
                DAL_Base _ObjData = new DAL_Base();
                return _ObjData.GetMenuAll();
            }
            catch (Exception ex)
            {
                throw ConstructFaultException(ex);
            }
        }

        public List<UserEntities> GetAllUsers()
        {
            try
            {
                DAL_Base _ObjData = new DAL_Base();
                return _ObjData.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw ConstructFaultException(ex);
            }
        }

        public List<BloodGroupEntities> GetAllBloodGroup()
        {
            try
            {
                DAL_Base _ObjData = new DAL_Base();
                return _ObjData.GetAllBloodGroup();
            }
            catch (Exception ex)
            {
                throw ConstructFaultException(ex);
            }
        }
        public List<EmployeeDesigEntities> GetAllDesignation()
        {
            try
            {
                DAL_Base _ObjData = new DAL_Base();
                return _ObjData.GetAllDesignation();
            }
            catch (Exception ex)
            {
                throw ConstructFaultException(ex);
            }
        }
        public int InsertUpdateUsers(UserEntities User_Entity)
        {
            try
            {
                DALCRUDUserGroup _ObjData = new DALCRUDUserGroup();
                return _ObjData.InsertUpdateUsers(User_Entity);
            }
            catch (Exception ex)
            {
                throw ConstructFaultException(ex);
            }
        }
    }
}
