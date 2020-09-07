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
    public class OutstandingBalanceRepository: IOutstandingBalanceRepository
    {
        IConfiguration configuration;

        /// <summary>
        /// 
        /// </summary>
        public OutstandingBalanceRepository(IConfiguration _configuration)
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
        public object GetOutstandingBalance(string invoiceNumber)
        {
            object result = null;
            try
            {
                var parameters = new OracleDynamicParameters();
                parameters.Add("vInvoiceNumber", OracleDbType.Varchar2, ParameterDirection.Input, invoiceNumber, null);
                parameters.Add("OUTSTANDING_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                var connection = GetConnection();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                if (connection.State == ConnectionState.Open)
                {
                    result = SqlMapper.Query(connection, "RT_OUTSTANDINGBALANCE", parameters, null, true, null, CommandType.StoredProcedure);
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
