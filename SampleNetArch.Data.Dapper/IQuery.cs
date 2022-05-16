using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SampleNetArch.Data.Dapper
{
    public interface IQuery
    {
        void Dispose();
        void Dispose(bool disposing);

        int ExecuteScalar(string query);
        int ExecuteScalar(string query, dynamic parameters);
        int ExecuteScalar(string query, dynamic parameters, int timeout);
        Task<int> ExecuteScalarAsync(string query);
        Task<int> ExecuteScalarAsync(string query, dynamic parameters);
        Task<int> ExecuteScalarAsync(string query, dynamic parameters, int timeout);

        int ExecuteCount(string query, dynamic parameters);
        int ExecuteCount(string query, dynamic parameters, int timeout);
        Task<int> ExecuteCountAsync(string query, dynamic parameters);
        Task<int> ExecuteCountAsync(string query, dynamic parameters, int timeout);

        IEnumerable<T> ExecuteQuery<T>(string query);
        IEnumerable<T> ExecuteQuery<T>(string query, dynamic parameters);
        IEnumerable<T> ExecuteQuery<T>(string query, dynamic parameters, int timeout);
        IEnumerable<object> ExecuteQuery(string query, dynamic parameters);
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query);
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, dynamic parameters);
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, dynamic parameters, int timeout);
        Task<IEnumerable<object>> ExecuteQueryAsync(string query, dynamic parameters);

        IEnumerable<T> ExecuteStoreProcedure<T>(string procedure);
        IEnumerable<T> ExecuteStoreProcedure<T>(string procedure, dynamic parameters);
        int ExecuteStoreProcedure(string procedure, dynamic parameters);
        Task<IEnumerable<T>> ExecuteStoreProcedureAsync<T>(string procedure);
        Task<IEnumerable<T>> ExecuteStoreProcedureAsync<T>(string procedure, dynamic parameters);
        Task<int> ExecuteStoreProcedureAsync(string procedure, dynamic parameters);

        bool ExecuteCommand(string query, dynamic parameters);
        bool ExecuteCommand(string query, dynamic parameters, int timeout);
        Task<bool> ExecuteCommandAsync(string query, dynamic parameters);
        Task<bool> ExecuteCommandAsync(string query, dynamic parameters, int timeout);


        Task<IEnumerable<T>> ExecuteQueryBuilder<T>(string table,
                                                    List<string> selectList,
                                                    List<string> innerJoinList,
                                                    List<string> whereList,
                                                    List<string> leftJoinList,
                                                    List<string> oRwhereList,
                                                    dynamic parameters = null);

        IDbConnection DbConnection { get; }
    }
}
