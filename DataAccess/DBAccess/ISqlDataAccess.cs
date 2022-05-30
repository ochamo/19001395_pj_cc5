using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T, P>(string sql, P parameters, string connectionId = "Default") where T : class, new();

        Task<int> SaveData<T>(string sql, T data, string connectionId = "Default");
        Task<int> UpdateData<T>(string sql, T data, string connectionId = "Default");

        Task<T> Single<T, P>(string sql, P parameters, string connectionId = "Default") where T : class, new();
        
        Task DeleteSingle<P>(string sql, P parameters, string connectionId = "Default");

    }
}
