using CleanBuilding.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace CleanBuilding.Application.Repository
{
    public interface IDapperRepository
    {
        public IDbConnection Connection { get; }
        Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default);
    }
}
