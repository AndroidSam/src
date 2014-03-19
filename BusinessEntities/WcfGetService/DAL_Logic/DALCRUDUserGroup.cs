using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities;
using WcfGetService.BL_Logic.Classes;
using WcfGetService.Params;

namespace WcfGetService.DAL_Logic
{
    public class DALCRUDUserGroup : BaseClass
    {
        private readonly CRUDActivities objCRUD = new CRUDActivities();
        object[] _arrParameter;
        public int InsertUpdateUserGroup(UserGroupEntities UserGroup_entity)
        {
            try 
            {
                _arrParameter = new object[3];
                if (UserGroup_entity.UserGroupId != Guid.Empty)
                    _arrParameter[0] = UserGroup_entity.UserGroupId;
                else
                    _arrParameter[0] = null;
                _arrParameter[1] = UserGroup_entity.UserGroupName;
                _arrParameter[2] = UserGroup_entity.Active;
                return objCRUD.CRUDActions(Parameters.InsertUpdateUserGroup, _arrParameter);
            }
            catch (Exception ex)
            {
                throw ConstructFaultException(ex);
            }
        }

        public int InsertUpdateuserType(UserTypeEntities USerType_Entity)
        {
            try
            {
                _arrParameter = new object[3];
                if (USerType_Entity.UserTypeId != Guid.Empty)
                    _arrParameter[0] = USerType_Entity.UserTypeId;
                else
                    _arrParameter[0] = null;
                _arrParameter[1] = USerType_Entity.UserTypeName;
                _arrParameter[2] = USerType_Entity.Active;
                return objCRUD.CRUDActions(Parameters.InsertUpdateUserType, _arrParameter);
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
                _arrParameter = new object[18];
                if (User_Entity.UserId!= Guid.Empty)
                    _arrParameter[0] = User_Entity.UserId;
                else
                    _arrParameter[0] = null;
                _arrParameter[1] = User_Entity.Username;
                _arrParameter[2] = User_Entity.Password; _arrParameter[3] = User_Entity.Active;
                _arrParameter[4] = User_Entity.EmployeeId;
                if (!string.IsNullOrEmpty(User_Entity.Avatar))
                {
                    _arrParameter[5] = User_Entity.Avatar.Split(',')[1].ToString();
                }
                else
                    _arrParameter[5] = null;
                _arrParameter[6] = User_Entity.EmailAddress;
                _arrParameter[7] = User_Entity.FirstName;
                _arrParameter[8] = User_Entity.LastName;
                _arrParameter[9] = User_Entity.DOB;
                _arrParameter[10] = User_Entity.DOJ;
                _arrParameter[11] = User_Entity.PFNumber;
                _arrParameter[12] = User_Entity.ContactNumber;
                _arrParameter[13] = User_Entity.Address;
                _arrParameter[14] = User_Entity.UserGroupEntity.UserGroupId;
                _arrParameter[15] = User_Entity.UserTypeEntity.UserTypeId;
                _arrParameter[16] = User_Entity.DesignationEntity.EmployeeDesigId;
                _arrParameter[17] = User_Entity.BloodGroupEntity.BloodGroupID;

                return objCRUD.CRUDActions(Parameters.InsertUpdateUsers, _arrParameter);
            }
            catch (Exception ex)
            {
                throw ConstructFaultException(ex);
            }
        }
    }
}