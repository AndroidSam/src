using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessEntities;
using System.Data;
using WcfGetService.BL_Logic.Classes;


namespace WcfGetService.DAL_Logic
{
    public class DALSelectUserGroup :BaseClass
    {
        private readonly SelectDAL objSelectDAL = new SelectDAL();

        public List<UserGroupEntities> GetAllUserGroup()
        {
            try
            {

                return (from DataRow drItem in objSelectDAL.Retrieve(Params.Parameters.GetAllUserGroup).Rows
                        select new UserGroupEntities()
                        {
                            UserGroupId = new Guid(drItem["F_USERGROUP_ID"].ToString()),
                            UserGroupName = drItem["F_USERGROUP_NAME"].ToString(),
                            Active = drItem["F_ACTIVE"].ToString().ToLower() == "true" ? true : false
                        }).ToList();
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
                return (from DataRow drItem in objSelectDAL.Retrieve(Params.Parameters.GetAllUserType).Rows
                        select new UserTypeEntities()
                        {
                            UserTypeId = new Guid(drItem["F_USER_TYPE_ID"].ToString()),
                            UserTypeName = drItem["F_USER_TYPE_NAME"].ToString(),
                            Active = drItem["F_ACTIVE"].ToString().ToLower() == "true" ? true : false
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ConstructFaultException(ex);
            }
        } 
      
    }
}