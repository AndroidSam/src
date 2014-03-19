using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities; 
using System.IO;
using System.Drawing; 

namespace PMS_MVC.Controllers.Admin
{
    public class UserGroupController : Controller
    {
       /// <summary>
       /// declare WCF service object
       /// </summary>
        WcfGetService.Getservice _OBJService = new WcfGetService.Getservice();
        #region "User Group"
        /// <summary>
        /// Get all values from UserGroup
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewUserGroup()
        {
            ViewBag.UserGroup = _OBJService.GetAllUserGroup();
            return View();
        }

        /// <summary>
        /// Get UserGroup based on the search text typed
        /// </summary>
        /// <param name="F_USERGROUP_NAME"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SearchUserGroup(string UserGroupName)
        {
            ViewBag.UserGroup = _OBJService.GetAllUserGroup().Where(m => m.UserGroupName.ToLower().Contains(UserGroupName.ToLower())).ToList();
             return View("ViewUserGroup"); 
        }

       /// <summary>
       /// Get UserGroup Based on the Grid Edit click
       /// </summary>
       /// <param name="UserGroupID"></param>
       /// <returns></returns>
        [OutputCache(Duration = 0)]
        [HttpGet]
        public ViewResult CRUDUserGroup(Guid UserGroupID)
        {
            if (UserGroupID != Guid.Empty)
            {
                UserGroupEntities UserGroup_Entity = _OBJService.GetAllUserGroup().Where(m => m.UserGroupId == UserGroupID).FirstOrDefault();
                return View(UserGroup_Entity); 
            }
            else
            {
                ViewBag.UserGroup = new SelectList(_OBJService.GetAllUserGroup(), "UserGroupId", "UserGroupName");
                var UserGroup = _OBJService.GetAllUserGroup().Where(m => m.UserGroupId == UserGroupID).FirstOrDefault();
                return View(UserGroup);
            }
        }
        /// <summary>
        /// CRUD ERROR MSG DISPLAY
        /// </summary>
        /// <returns></returns>
        public ActionResult CRUDUserGroup()
        {
            return View();
        }
        /// <summary>
        /// CRUD User Group based on the primary key value
        /// Method calls stored Procedure
        /// </summary>
        /// <param name="UserGroup_Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CRUDUserGroup(UserGroupEntities UserGroup_Entity)
        {
            try
            {
                var result = 0;
                if (ModelState.IsValid)
                { 
                    if (UserGroup_Entity.UserGroupId != Guid.Empty)
                    {
                        result = _OBJService.InsertUpdateUserGroup(UserGroup_Entity);
                        if (result == 1)
                        {   
                            ViewBag.SuccessMessage = "Updated successfully";
                           
                        }
                    }
                    else
                    {
                        UserGroup_Entity.UserGroupId = Guid.NewGuid();
                        result = _OBJService.InsertUpdateUserGroup(UserGroup_Entity);
                        {
                            ViewBag.SuccessMessage = "Updated successfully";
                          
                        }
                    }
                }
                else
                {
                    if (result == 0)
                        ViewBag.SuccessMessage = "Error : Try After sometime";

                    ViewBag.UserGroup = new SelectList(_OBJService.GetAllUserGroup(), "UserGroupId", "UserGroupName");
                    return View("CRUDUserGroup");
                }
                return View("CRUDUserGroup");
                //return RedirectToAction("ViewUserGroup");
            }

            catch (Exception ex)
            {
                ViewBag.SuccessMessage = ex.Message;
                return View("CRUDUserGroup");
            }
        }
        #endregion

        #region  "User Type"
        /// <summary>
        /// display all user Type
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewUserType()
        {
            ViewBag.UserType = _OBJService.GetAllUserType();
            return View();
        }
        /// <summary>
        /// Search User Type Based on User type
        /// </summary>
        /// <param name="UserTypeName"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SearchUserType(string UserTypeName)
        {
            ViewBag.UserType = _OBJService.GetAllUserType().Where(m => m.UserTypeName.ToLower().Contains(UserTypeName.ToLower())).ToList();
            return View("ViewUserType");
        }
        /// <summary>
        /// Filter user type base on usertypeid
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CRUDUserType(Guid UserTypeId)
        {
            UserTypeEntities UserType_Entity = new UserTypeEntities(); 
            if (Request.IsAjaxRequest())
            {
                if (UserTypeId != Guid.Empty)
                {
                    UserType_Entity = _OBJService.GetAllUserType().Where(m => m.UserTypeId == UserTypeId).FirstOrDefault();
                    ViewBag.UserType = UserType_Entity;
                }
                else
                {
                    ViewBag.UserType = new SelectList(_OBJService.GetAllUserType(), "UserTypeId", "UserTypeName");
                    UserType_Entity = _OBJService.GetAllUserType().Where(m => m.UserTypeId == UserTypeId).FirstOrDefault();
                }
                return PartialView(UserType_Entity);
            }
            else
                return View(UserType_Entity);
        }
        /// <summary>
        /// update the user Type based on the Entity value
        /// </summary>
        /// <param name="UserType_Entity"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CRUDUserType(UserTypeEntities UserType_Entity)
        {
            try 
            {
                var result = 0;
                if (ModelState.IsValid)
                {
                    if (UserType_Entity.UserTypeId != Guid.Empty)
                    {
                        result = _OBJService.InsertUpdateUserType(UserType_Entity);
                        if (result == 1)
                        {
                            TempData["Msg"] = "Data updated Successfully";
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                        result = _OBJService.InsertUpdateUserType(UserType_Entity);
                        if (result == 1)
                        {
                            TempData["Msg"] = "Data saved Successfully";
                            ModelState.Clear();
                        }
                    }
                    return RedirectToAction("ViewUserType");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex) { throw ex; }

        }

        #endregion

        #region "User"
        /// <summary>
        /// View all users
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewUser()
        {
            ViewBag.User = _OBJService.GetAllUsers();
            return View();
        }
        /// <summary>
        /// Search User Based on Username
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SearchUsers(string Username)
        {
            ViewBag.User  = _OBJService.GetAllUsers().Where(m => m.Username.ToLower().Contains(Username.ToLower()) || m.EmailAddress.ToLower().Contains(Username.ToLower()) ).ToList();
            return View("ViewUser");
        }
        /// <summary>
        /// Filter user base on userid , Assigning Image value in the Avatar
        /// </summary>
        /// <param name="Userid"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CRUDUsers(Guid Userid)
        {
            UserEntities User_Entity = new UserEntities();
            if (Request.IsAjaxRequest())
            {
                if (Userid != Guid.Empty)
                {
                    BindDropDownList_CRUDUsers();
                    User_Entity =_OBJService.GetAllUsers().Where(m=>m.UserId == Userid).FirstOrDefault();
                    ViewBag.Avatar = User_Entity.Avatar;
                    User_Entity.Avatar = string.Format("data:image/gif;base64,{0}", ViewBag.Avatar);
                    ViewBag.User = User_Entity;
                }
                else
                {
                    BindDropDownList_CRUDUsers();
                    User_Entity = _OBJService.GetAllUsers().Where(m => m.UserId == Userid).FirstOrDefault();
                    ViewBag.Avatar = null;
                    
                }
                return PartialView(User_Entity);
            }
            else
                return View(User_Entity);
        }
        /// <summary>
        ///  update the user based on the Entity value
        /// </summary>
        /// <param name="User_Entity"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CRUDUsers(UserEntities User_Entity)
        {

            try
            {
                var result = 0;
                if (User_Entity.UserGroupEntity.UserGroupId != Guid.Empty)
                {
                    ModelState.Remove("UserGroupEntity.UserGroupName");
                }
                if (User_Entity.UserTypeEntity.UserTypeId != Guid.Empty)
                {
                    ModelState.Remove("UserTypeEntity.UserTypeName");
                }
                if (User_Entity.BloodGroupEntity.BloodGroupID != Guid.Empty)
                {
                    ModelState.Remove("BloodGroupEntity.BloodGroupName");
                } if (User_Entity.DesignationEntity.EmployeeDesigId!= Guid.Empty)
                {
                    ModelState.Remove("DesignationEntity.EmployeeDesigName");
                }
                if (ModelState.IsValid)
                {
                    if (User_Entity.UserId != Guid.Empty)
                    {
                      //  result = _OBJService.InsertUpdateUsers(User_Entity);
                        if (result == 1)
                        {
                            TempData["Msg"] = "Data updated Successfully";
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                       // result = _OBJService.InsertUpdateUsers(User_Entity);
                        if (result == 1)
                        {
                            TempData["Msg"] = "Data saved Successfully";
                            ModelState.Clear();
                        }
                    }
                    return RedirectToAction("ViewUser");
                }
                else
                {
                    BindDropDownList_CRUDUsers();
                    return View();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public void BindDropDownList_CRUDUsers()
        {
            ViewBag.UserGroup = new SelectList(_OBJService.GetAllUserGroup(), "UserGroupId", "UserGroupName");
            ViewBag.UserType = new SelectList(_OBJService.GetAllUserType(), "UserTypeId", "UserTypeName");
            ViewBag.Designation = new SelectList(_OBJService.GetAllDesignation(), "EmployeeDesigId", "EmployeeDesigName");
            ViewBag.BloodGroup = new SelectList(_OBJService.GetAllBloodGroup(), "BloodGroupID", "BloodGroupName"); 
        }
        #endregion
    }
}
