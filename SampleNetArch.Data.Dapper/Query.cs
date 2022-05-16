using Dapper;
using System.Data;

namespace SampleNetArch.Data.Dapper
{
    public class Query : IDisposable, IQuery
    {
        private readonly IDbConnection _dbConnection;

        public IDbConnection DbConnection
        {
            get
            {
                return _dbConnection;
            }
        }

        public SqlBuilder SqlBuilder;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbConnection">Será inyectado por el proveedor del contenedor de dependencias.</param>
        public Query(IDbConnection dbConnection)
        {
            //Guard Clauses
            if (dbConnection == null)
            {
                throw new Exception("IDbConnection Not Defined");
            }

            _dbConnection = dbConnection;
        }

        #region scalar
        public int ExecuteScalar(string query)
        {
            return ExecuteScalar(query, null);
        }

        public int ExecuteScalar(string query, dynamic parameters)
        {
            return _dbConnection.ExecuteScalar<int>(sql: query, param: (object)parameters);
        }

        public int ExecuteScalar(string query, dynamic parameters, int timeout)
        {
            return _dbConnection.ExecuteScalar<int>(sql: query, param: (object)parameters, commandTimeout: timeout);
        }

        public async Task<int> ExecuteScalarAsync(string query)
        {
            return await ExecuteScalarAsync(query, null);
        }

        public async Task<int> ExecuteScalarAsync(string query, dynamic parameters)
        {
            return await _dbConnection.ExecuteScalarAsync<int>(query, (object)parameters);
        }        

        public async Task<int> ExecuteScalarAsync(string query, dynamic parameters, int timeout)
        {
            return await _dbConnection.ExecuteScalarAsync<int>(sql: query, param: (object)parameters, commandTimeout: timeout);
        }
        #endregion

        #region count

        public int ExecuteCount(string query, dynamic parameters)
        {            
            return _dbConnection.ExecuteScalar<int>(query, (object)parameters);
        }

        public int ExecuteCount(string query, dynamic parameters, int timeout)
        {
            return _dbConnection.ExecuteScalar<int>(sql: query, param: (object)parameters, commandTimeout: timeout);
        }

        public async Task<int> ExecuteCountAsync(string query, dynamic parameters)
        {
            return await _dbConnection.ExecuteScalarAsync<int>(query, (object)parameters);
        }

        public async Task<int> ExecuteCountAsync(string query, dynamic parameters, int timeout)
        {
            return await _dbConnection.ExecuteScalarAsync<int>(sql: query, param: (object)parameters, commandTimeout: timeout);
        }

        #endregion

        #region query
        public IEnumerable<T> ExecuteQuery<T>(string query)
        {
            return this.ExecuteQuery<T>(query, null);
        }

        public IEnumerable<T> ExecuteQuery<T>(string query, dynamic parameters)
        {
            return _dbConnection.Query<T>(query, (object)parameters);
        }

        public IEnumerable<T> ExecuteQuery<T>(string query, dynamic parameters, int timeout)
        {
            return _dbConnection.Query<T>(sql: query, param: (object)parameters, commandTimeout: timeout);
        }
        
        public IEnumerable<object> ExecuteQuery(string query, dynamic parameters)
        {
            return _dbConnection.Query(sql: query, param: (object)parameters);
        }

        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query)
        {
            return await _dbConnection.QueryAsync<T>(query, null);
        }

        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, dynamic parameters)
        {
            return await _dbConnection.QueryAsync<T>(query, (object)parameters);
        }

        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, dynamic parameters, int timeout)
        {
            return await _dbConnection.QueryAsync<T>(sql: query, param: (object)parameters, commandTimeout: timeout);
        }

        public async Task<IEnumerable<object>> ExecuteQueryAsync(string query, dynamic parameters)
        {
            return await _dbConnection.QueryAsync(sql: query, param: (object)parameters);
        }
        #endregion

        #region stored procedure

        public IEnumerable<T> ExecuteStoreProcedure<T>(string procedure)
        {
            return ExecuteStoreProcedure<T>(procedure, null);
        }

        public IEnumerable<T> ExecuteStoreProcedure<T>(string procedure, dynamic parameters)
        {             
            return _dbConnection.Query<T>(procedure, (object)parameters, null,  true, null, CommandType.StoredProcedure);
        }

        public int ExecuteStoreProcedure(string procedure, dynamic parameters)
        {
            return _dbConnection.Execute(procedure, (object)parameters, null, null, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> ExecuteStoreProcedureAsync<T>(string procedure)
        {
            return await ExecuteStoreProcedureAsync<T>(procedure, null);
        }

        public async Task<IEnumerable<T>> ExecuteStoreProcedureAsync<T>(string procedure, dynamic parameters)
        {
            return await _dbConnection.QueryAsync<T>(procedure, (object)parameters, null, null, CommandType.StoredProcedure);
        }

        public async Task<int> ExecuteStoreProcedureAsync(string procedure, dynamic parameters)
        {
            return await _dbConnection.ExecuteAsync(procedure, (object)parameters, null, null, CommandType.StoredProcedure);
        }

        #endregion

        #region command
        public bool ExecuteCommand(string query, dynamic parameters)
        {
            var res = _dbConnection.Execute(query, (object)parameters);
            return (res > 0);            
        }
        
        public bool ExecuteCommand(string query, dynamic parameters, int timeout)
        {
            var res = _dbConnection.Execute(sql: query, param: (object)parameters, commandTimeout: timeout);
            return (res > 0);
        }

        public async Task<bool> ExecuteCommandAsync(string query, dynamic parameters)
        {
            var res = await _dbConnection.ExecuteAsync(query, (object)parameters);
            return (res > 0);
        }

        public async Task<bool> ExecuteCommandAsync(string query, dynamic parameters, int timeout)
        {
            var res = await _dbConnection.ExecuteAsync(sql: query, param: (object)parameters, commandTimeout: timeout);
            return (res > 0);
        }
        #endregion

        #region dynamic

        public async Task<IEnumerable<T>> ExecuteQueryBuilder<T>(string table,
                                                                 List<string> selectList,
                                                                 List<string> innerJoinList,
                                                                 List<string> whereList,
                                                                 List<string> leftJoinList,
                                                                 List<string> oRwhereList,
                                                                 dynamic parameters = null)
        {

            SqlBuilder sqlBuilder = new SqlBuilder();
            var builderTemplate = sqlBuilder.AddTemplate($"Select /**select**/ from {table} /**innerjoin**/ /**leftjoin**/ /**where**/ ");

            foreach (var select in selectList.EmptyIfNull())
            {
                sqlBuilder.Select(select);
            }

            foreach (var innerjoin in innerJoinList.EmptyIfNull())
            {
                sqlBuilder.InnerJoin(innerjoin);
            }

            foreach (var where in whereList.EmptyIfNull())
            {
                sqlBuilder.Where(where);
            }

            foreach (var where in oRwhereList.EmptyIfNull())
            {
                sqlBuilder.OrWhere(where);
            }

            foreach (var where in leftJoinList.EmptyIfNull())
            {
                sqlBuilder.LeftJoin(where);
            }

            return await _dbConnection.QueryAsync<T>(builderTemplate.RawSql, (object)parameters);
        }

        #endregion
        public void Dispose()
        {
            this.Dispose(true);
        }
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._dbConnection != null) this._dbConnection.Dispose();
            }
        }
    }
}
