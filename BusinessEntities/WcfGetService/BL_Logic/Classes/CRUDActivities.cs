using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WcfGetService.BL_Logic.Classes
{
    public class CRUDActivities
    {
        #region "Variable Declarations"
        Database db = DatabaseFactory.CreateDatabase("ApplicationServices");
        #endregion

        #region "User Defined Methods"
        /// <summary>
        /// To Create, Read, Update and Delete the Rows from the Tables
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParameters">object[]</param>
        /// <returns>int</returns>
        public int CRUDActions(string spName, object[] spParameters)
        {
            int intInsertStatus = -1;
            DbCommand cmdCRUD = null;
            DbConnection dbConnection;
            try
            {
                dbConnection = db.CreateConnection();
                dbConnection.Open();
                cmdCRUD = db.GetStoredProcCommand(spName, spParameters);
                intInsertStatus = (int)db.ExecuteNonQuery(cmdCRUD);
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection = null;
            }
            return intInsertStatus;
        }

        /// <summary>
        /// To Create, Read, Update and Delete the Rows from the Tables
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParameters">object[]</param>
        /// <returns>int</returns>
        public int CRUDActions(string spName, SqlParameter[] spParameters)
        {
            int intInsertStatus = -1;
            DbCommand cmdCRUD = null;
            DbConnection dbConnection;
            try
            {
                dbConnection = db.CreateConnection();
                dbConnection.Open();
                cmdCRUD = db.GetStoredProcCommand(spName);
                cmdCRUD.Parameters.AddRange(spParameters);
                intInsertStatus = db.ExecuteNonQuery(cmdCRUD);
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection = null;
            }
            return intInsertStatus;
        }

        /// <summary>
        /// To Create, Read, Update and Delete the Rows from the Tables
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParameters">object[]</param>
        /// <returns>int</returns>
        public int CRUDActionsSelect(string spName, SqlParameter[] spParameters)
        {
            DbConnection dbConnection = null;
            DbCommand cmdCRUD = null;
            int intInsertStaus = -1;
            try
            {
                dbConnection = db.CreateConnection();
                dbConnection.Open();
                cmdCRUD = db.GetStoredProcCommand(spName, spParameters);
                intInsertStaus = Convert.ToInt32(db.ExecuteScalar(cmdCRUD));
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection = null;
            }
            return intInsertStaus;
        }

        /// <summary>
        /// To Create, Read, Update and Delete the Rows from the Tables
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParameters">object[]</param>
        /// <returns>int</returns>
        public string CRUDActionsUpdateString(string spName, object[] spParameters)
        {
            DbCommand cmdCRUD = null;
            DbConnection dbConnection = null;
            string InsertStaus = string.Empty;
            try
            {
                dbConnection = db.CreateConnection();
                dbConnection.Open();
                cmdCRUD = db.GetStoredProcCommand(spName, spParameters);
                InsertStaus = db.ExecuteNonQuery(cmdCRUD).ToString();
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection = null;
            }
            return InsertStaus;
        }

        /// <summary>
        /// To Create, Read, Update and Delete the Rows from the Tables
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParameters">object[]</param>
        /// <returns>int</returns>
        public int CRUDActionsSelect(string spName, object[] spParameters)
        {
            DbConnection dbConnection = null;
            DbCommand cmdCRUD = null;
            int intInsertStaus = -1;
            try
            {
                dbConnection = db.CreateConnection();
                dbConnection.Open();
                cmdCRUD = db.GetStoredProcCommand(spName, spParameters);
                intInsertStaus = Convert.ToInt32(db.ExecuteScalar(cmdCRUD));
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection = null;
            }
            return intInsertStaus;
        }


        /// <summary>
        /// To Create, Read, Update and Delete the Rows from the Tables
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParameters">object[]</param>
        /// <returns>int</returns>
        public Guid CRUDActionsSelectGUID(string spName, object[] spParameters)
        {
            DbCommand cmdCRUD = null;
            DbConnection dbConnection = null;
            Guid InsertStaus = Guid.Empty;
            try
            {
                dbConnection = db.CreateConnection();
                dbConnection.Open();
                cmdCRUD = db.GetStoredProcCommand(spName, spParameters);
                InsertStaus = new Guid(db.ExecuteScalar(cmdCRUD).ToString());
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection = null;
            }
            return InsertStaus;
        }


        /// <summary>
        /// To Create, Read, Update and Delete the Rows from the Tables
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParameters">object[]</param>
        /// <returns>int</returns>
        public string CRUDActionsSelectString(string spName, object[] spParameters)
        {
            DbCommand cmdCRUD = null;
            DbConnection dbConnection = null;
            string InsertStaus = string.Empty;
            try
            {
                dbConnection = db.CreateConnection();
                dbConnection.Open();
                cmdCRUD = db.GetStoredProcCommand(spName, spParameters);
                InsertStaus = db.ExecuteScalar(cmdCRUD).ToString();
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection = null;
            }
            return InsertStaus;
        }

        /// <summary>
        /// To Create, Read, Update and Delete the Rows from the Tables
        /// </summary>
        /// <param name="spName">string</param>
        /// <param name="spParameters">object[]</param>
        /// <returns>int</returns>
        public string CRUDActionsSelectString(string spName, SqlParameter[] spParameters)
        {
            DbCommand cmdCRUD = null;
            DbConnection dbConnection = null;
            string InsertStaus = string.Empty;
            try
            {
                dbConnection = db.CreateConnection();
                dbConnection.Open();
                cmdCRUD = db.GetStoredProcCommand(spName);
                cmdCRUD.Parameters.AddRange(spParameters);
                InsertStaus = db.ExecuteScalar(cmdCRUD).ToString();
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection = null;
            }
            return InsertStaus;
        }
        public DbCommand SetCommandParameterType(DbCommand cmdCRUD)
        {
            foreach (SqlParameter parameter in cmdCRUD.Parameters)
            {
                if (parameter.SqlDbType != SqlDbType.Structured)
                {
                    continue;
                }
                string name = parameter.TypeName;
                int index = name.IndexOf(".");
                if (index == -1)
                {
                    continue;
                }
                name = name.Substring(index + 1);
                if (name.Contains("."))
                {
                    parameter.TypeName = name;
                }
            }
            return cmdCRUD;
        }

        public DataTable CRUDActionsDT(string spName, SqlParameter[] spParameters)
        {
            DataTable dt = new DataTable();
            DbCommand cmdCRUD = null;
            DbConnection dbConnection;
            try
            {
                dbConnection = db.CreateConnection();
                dbConnection.Open();
                cmdCRUD = db.GetStoredProcCommand(spName);
                cmdCRUD.Parameters.AddRange(spParameters);
                dt.Load(db.ExecuteReader(cmdCRUD));
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection = null;
            }
            return dt;
        }
        #endregion
    }
}