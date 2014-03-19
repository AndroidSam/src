using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data; 

namespace WcfGetService.BL_Logic.Classes
{
    public class SelectDAL  
    {

        #region "Variable Declaration"
        Database dbSelect = DatabaseFactory.CreateDatabase("ApplicationServices");
        #endregion

        #region "User Defined Methods"
        /// <summary>
        /// To retrieve the data from the database
        /// </summary>
        /// <param name="spName">string</param>
        /// <returns>DataTable</returns>
        public DataTable Retrieve(string spName)
        {
            DbCommand cmdSelect = dbSelect.GetStoredProcCommand(spName);
            return dbSelect.ExecuteDataSet(cmdSelect).Tables[0];
        }

        /// <summary>
        /// To retrieve the data from the database
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParameters">object[]</param>
        /// <returns>DataTable</returns>
        public DataTable Retrieve(string spName, object[] spParameters)
        {
            DbCommand cmdSelect = dbSelect.GetStoredProcCommand(spName, spParameters);
            cmdSelect.CommandTimeout = 60000;
            return dbSelect.ExecuteDataSet(cmdSelect).Tables[0];
        }


        /// <summary>
        /// Retrieves the specified sp name.
        /// </summary>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="spParameters">The sp parameters.</param>
        /// <returns></returns>
        public DataTable Retrieve(string spName, SqlParameter[] spParameters)
        {
            DbCommand cmdSelect = dbSelect.GetStoredProcCommand(spName);
            cmdSelect.Parameters.AddRange(spParameters);
            cmdSelect.CommandTimeout = 60000;
            return dbSelect.ExecuteDataSet(cmdSelect).Tables[0];
        }

        /// <summary>
        /// To retrieve the data from the database
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParameters">object[]</param>
        /// <returns>DataTable</returns>
        public DataSet RetrieveDs(string spName, object[] spParameters)
        {
            DbCommand cmdSelect = dbSelect.GetStoredProcCommand(spName, spParameters);
            cmdSelect.CommandTimeout = 60000;
            return dbSelect.ExecuteDataSet(cmdSelect);
        }

        /// <summary>
        /// Retrieves the ds.
        /// </summary>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="spParameters">The sp parameters.</param>
        /// <returns></returns>
        public DataSet RetrieveDs(string spName, SqlParameter[] spParameters)
        {
            DbCommand cmdSelect = dbSelect.GetStoredProcCommand(spName);
            cmdSelect.Parameters.AddRange(spParameters);
            cmdSelect.CommandTimeout = 60000;
            return dbSelect.ExecuteDataSet(cmdSelect);
        }
        #endregion

    }
}