using CMX.api.Oracle;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CMX.api.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        IConfiguration configuration;

        /// <summary>
        /// 
        /// </summary>
        public EmployeeRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("realtimedb").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public object GetEmployeeDetails(int empId)
        {
            object result = null;
            try
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("EMP_ID", OracleDbType.Int32, ParameterDirection.Input, (int)empId);
                parameters.Add("EMP_DETAIL_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                var connection = GetConnection();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                if (connection.State == ConnectionState.Open)
                {
                    result = SqlMapper.Query(connection, "USP_GETEMPLOYEEDETAILS", parameters, null, true, null, CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object GetEmployeeList()
        {
            object result = null;
            try
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                var connection = GetConnection();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                if (connection.State == ConnectionState.Open)
                {
                    result = SqlMapper.Query(connection, "USP_GETEMPLOYEES", parameters, null, true, null, CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }


}
