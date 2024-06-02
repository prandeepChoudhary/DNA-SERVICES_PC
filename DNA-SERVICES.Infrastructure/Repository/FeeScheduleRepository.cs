using System;
using Dapper;
using DNA_SERVICES.Domain.Interfaces.Repository;
using DNA_SERVICES.Infrastructure.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using DNA_SERVICES.Domain.Models.FeeSchedule.Input;
using DNA_SERVICES.Domain.Models.FeeSchedule.Output;

namespace DNA_SERVICES.Infrastructure.Repository
{
	public class FeeScheduleRepository : IFeeScheduleRepository
	{
        public IConfiguration _configuration;
        ILogger<FeeScheduleRepository> _logger;
        DatabaseConnection db = new DatabaseConnection();
        
		public FeeScheduleRepository(ILogger<FeeScheduleRepository> logger, IConfiguration configuration)
		{
            _configuration = configuration;
            _logger = logger;
        }

        private OracleConnection GetConnection()
        {
            DatabaseConnection dbConn = new DatabaseConnection();
            string connectionString = dbConn.GetConnectionString(_configuration);
            OracleConnection conn = new OracleConnection(connectionString);
            return conn;

        }
        public async Task<List<FeeScheduleOutputModel>> GetData(FeeScheduleInputModel feeScheduleInput)
        {
            List<FeeScheduleOutputModel> lst = new();
            OracleConnection _conn = GetConnection();
            OracleDynamicParameters dynamicParameters = new OracleDynamicParameters();
            try
            {
                dynamicParameters.Add("p_cdt_ver", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
                using var objReader = await SqlMapper.ExecuteReaderAsync(_conn, DataContants.PROC_GET, param: dynamicParameters,
                    commandType: System.Data.CommandType.StoredProcedure);

                while(await objReader.ReadAsync())
                {
                    lst.Add(new FeeScheduleOutputModel()
                    {
                        FeeScheduleId = 1,
                        FeeScheduleName = "Testing",
                        FeeScheduleType = "Default"
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Error occurred in GetData. Message: "+ ex.Message.ToString());
            }
            finally
            {
                _conn.Close();
                _conn.Dispose();
            }
            return lst;
        }

        public async Task<int> update (FeeScheduleInputModel feeScheduleInput)
        {
            int response = 0;
            OracleConnection _conn = GetConnection();
            try
            {
                OracleDynamicParameters dynamicParameters = new OracleDynamicParameters();
                dynamicParameters.Add("p_fs_name", OracleDbType.Varchar2, System.Data.ParameterDirection.Input, feeScheduleInput.FeeScheduleName);
                dynamicParameters.Add("p_fs_type", OracleDbType.Varchar2, System.Data.ParameterDirection.Input, feeScheduleInput.FeeScheduleType);
                dynamicParameters.Add("p_cdt_ver", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
                using (var objReader = await SqlMapper.ExecuteReaderAsync(_conn, DataContants.PROC_Update, param: dynamicParameters,
                    commandType: System.Data.CommandType.StoredProcedure))
                {
                    if (dynamicParameters._oracleParameters[2].Value != null)
                    {
                        response = Convert.ToInt32(dynamicParameters._oracleParameters[2].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in update. Message: " + ex.Message.ToString());
            }
            finally
            {
                _conn.Close();
                _conn.Dispose();
            }
            return response;
        }
    }
}

