using Angular_link_to_DB_API.Common;
using Microsoft.Data.SqlClient;
using Dapper;
using NLog;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace Angular_link_to_DB_API.Helpers
{
    public class DBHelper
    {
        private static readonly Logger Logger = LogManager.GetLogger(Constants.LoggerName);
        private readonly IConfiguration _configuration;
        private readonly string _connection;

        public DBHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("LinkToDbConnectionString");
        }

        public object GetSingleItem(string storedProcedure, object objParams)
        {
            using (var connection = new SqlConnection(_connection))
            {
                object dbResult = null;
                dbResult = connection.ExecuteScalar<object>(storedProcedure,
                                                            objParams,
                                                            commandType: CommandType.StoredProcedure);
                return dbResult;
            }
            
        }

        public IEnumerable<dynamic> Query(string storedProcedure,object objParams)
        {
            using(var connection = new SqlConnection(_connection))
            {
                IEnumerable<dynamic> dbResult = null;
                dbResult = connection.Query<dynamic>(storedProcedure,
                                                     objParams,
                                                     commandType: CommandType.StoredProcedure);

                return dbResult;
            }
        }

        public dynamic QueryFirstOrDefault(string storedProcedure, object objParams)
        {
            dynamic dbResult = null;

            using (var connection = new SqlConnection(_connection))
            {
                dbResult = connection.QueryFirstOrDefault<dynamic>(storedProcedure,
                                                                   objParams,
                                                                   commandType:CommandType.StoredProcedure);
                return dbResult;
            }
        }

        public int Execute(string storedProcedure, object objParams)
        {
            using(var connection = new SqlConnection(_connection))
            {
                var affectedRows = connection.Execute(storedProcedure, objParams, commandType: CommandType.StoredProcedure);

                return affectedRows;
            }
        }
    }
}
