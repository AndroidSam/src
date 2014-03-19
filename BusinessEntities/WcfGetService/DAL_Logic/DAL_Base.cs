using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities;
using WcfGetService.BL_Logic.Classes;
using System.Data;

namespace WcfGetService.DAL_Logic
{
    public class DAL_Base :BaseClass
    {
        private readonly SelectDAL objSelectDAL = new SelectDAL();
        private readonly System.Globalization.CultureInfo enGB = new System.Globalization.CultureInfo("en-GB");

        public List<MenuEntities> GetMenuAll()
        {
            try
            {
                return (from DataRow drItem in objSelectDAL.Retrieve(Params.Parameters.GetMenuAll).Rows
                        select new MenuEntities()
                        {

                            MenuId = new Guid(drItem["MenuID"].ToString()),
                            MenuName = drItem["MenuName"].ToString(),
                            MainMenuId = string.IsNullOrEmpty(drItem["MainMenuid"].ToString()) ? Guid.Empty : new Guid(drItem["MainMenuid"].ToString()),
                            View = drItem["View"].ToString(),
                            Controller = drItem["Controller"].ToString(),
                            level = Convert.ToInt32(drItem["Level"].ToString()),
                            Active = drItem["Active"].ToString().ToLower() == "true" ? true : false
                        }).ToList();
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
                return (from DataRow drItem in objSelectDAL.Retrieve(Params.Parameters.GetAllDesignation).Rows
                        select new EmployeeDesigEntities()
                        {
                            EmployeeDesigId = new Guid(drItem["EMP_DESG_ID"].ToString()),
                            EmployeeDesigName = drItem["EMP_DESG_NAME"].ToString(),
                            Active = drItem["ACTIVE"].ToString().ToLower() == "true" ? true : false
                        }).ToList();
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
                return (from DataRow drItem in objSelectDAL.Retrieve(Params.Parameters.GetAllBloodGroup).Rows
                        select new BloodGroupEntities()
                        {
                            BloodGroupID = new Guid(drItem["BLOOD_GROUPID"].ToString()),
                            BloodGroupName = drItem["BLOOD_GROUP"].ToString(),
                            Active = drItem["ACTIVE"].ToString().ToLower() == "true" ? true : false
                        }).ToList();
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
                return (from DataRow drItem in objSelectDAL.Retrieve(Params.Parameters.GetAllUsers).Rows
                        select new UserEntities()
                        {
                            UserId = new Guid(drItem["USER_ID"].ToString()),
                            EmployeeId = (!string.IsNullOrEmpty(drItem["Employee_ID"].ToString())) ? Convert.ToInt32(drItem["Employee_ID"]) : (int?)null,
                            Username = drItem["USERNAME"].ToString(),
                            Password = drItem["PASSWORD"].ToString(),
                            EmailAddress = drItem["EMAILADDRESS"].ToString(),
                            FirstName = drItem["FIRSTNAME"].ToString(),
                            LastName = drItem["LASTNAME"].ToString(),
                            //_DOB = (!string.IsNullOrEmpty(drItem["DOB"].ToString())) ? drItem["DOB"].ToString() : string.Empty,
                            //_DOJ = (!string.IsNullOrEmpty(drItem["DOJ"].ToString())) ? drItem["DOJ"].ToString() : string.Empty,
                            DOB = (!string.IsNullOrEmpty(drItem["DOB"].ToString())) ? Convert.ToDateTime(drItem["DOB"]).Date : (DateTime?)null,
                            DOJ = (!string.IsNullOrEmpty(drItem["DOJ"].ToString())) ? Convert.ToDateTime(drItem["DOJ"]).Date : (DateTime?)null,
                            PFNumber = drItem["PFNUMBER"].ToString(),
                            ContactNumber = (!string.IsNullOrEmpty(drItem["CONTACT_NUMBER"].ToString())) ? drItem["CONTACT_NUMBER"].ToString() : string.Empty,
                            Address = (!string.IsNullOrEmpty(drItem["ADDRESS"].ToString())) ? drItem["ADDRESS"].ToString() : string.Empty,
                            UserGroupEntity = new UserGroupEntities()
                            {
                                UserGroupId = (!string.IsNullOrEmpty(drItem["USERGROUP_ID"].ToString())) ? new Guid(drItem["USERGROUP_ID"].ToString()) : Guid.Empty,
                                UserGroupName = (!string.IsNullOrEmpty(drItem["F_USERGROUP_NAME"].ToString())) ? drItem["F_USERGROUP_NAME"].ToString() : string.Empty
                            },
                            UserTypeEntity = new UserTypeEntities()
                            {
                                UserTypeId = (!string.IsNullOrEmpty(drItem["USER_TYPE_ID"].ToString())) ? new Guid(drItem["USER_TYPE_ID"].ToString()) : Guid.Empty,
                                UserTypeName = (!string.IsNullOrEmpty(drItem["F_USER_TYPE_NAME"].ToString())) ? drItem["F_USER_TYPE_NAME"].ToString() : string.Empty
                            },
                            BloodGroupEntity = new BloodGroupEntities()
                            {
                                BloodGroupID = (!string.IsNullOrEmpty(drItem["BLOOD_GROUPID"].ToString())) ? new Guid(drItem["BLOOD_GROUPID"].ToString()) : Guid.Empty,
                                BloodGroupName = (!string.IsNullOrEmpty(drItem["BLOOD_GROUP"].ToString())) ? drItem["BLOOD_GROUP"].ToString() : string.Empty
                            },
                            DesignationEntity = new EmployeeDesigEntities()
                            {
                                EmployeeDesigId = (!string.IsNullOrEmpty(drItem["EMP_DESG_ID"].ToString())) ? new Guid(drItem["EMP_DESG_ID"].ToString()) : Guid.Empty,
                                EmployeeDesigName = (!string.IsNullOrEmpty(drItem["EMP_DESG_NAME"].ToString())) ? drItem["EMP_DESG_NAME"].ToString() : string.Empty
                            },
                            Avatar = (!string.IsNullOrEmpty(drItem["AVATAR"].ToString())) ? drItem["AVATAR"].ToString() : string.Empty,
                            Active = drItem["ACTIVE"].ToString().ToLower() == "true" ? true : false
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ConstructFaultException(ex);
            }
        }
    }
}