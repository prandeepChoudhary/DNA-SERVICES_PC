using System;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DNA_SERVICES.Infrastructure.Common
{
    public class OracleDynamicParameters : SqlMapper.IDynamicParameters
    {
        public readonly DynamicParameters _dynamicParameters = new DynamicParameters();
        public readonly List<OracleParameter> _oracleParameters = new List<OracleParameter>();

        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction, object? value = null)
        {
            OracleParameter _oracleParameter;
            if(value != null)
            {
                _oracleParameter = new OracleParameter(name, oracleDbType, value, direction);
            }
            else
            {
                _oracleParameter = new OracleParameter(name, oracleDbType, direction);
            }
        }

        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction, int size, object? value = null)
        {
            OracleParameter _oracleParameter;
            if (value != null)
            {
                _oracleParameter = new OracleParameter(name, oracleDbType, size, value, direction);
            }
            else
            {
                _oracleParameter = new OracleParameter(name, oracleDbType, size, direction);
            }
        }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            ((SqlMapper.IDynamicParameters)_dynamicParameters).AddParameters(command, identity);

            OracleCommand? _oracleCommand = command as OracleCommand;

            if(_oracleCommand != null)
            {
                _oracleCommand.Parameters.AddRange(_oracleParameters.ToArray());
            }
        }
    }
}

