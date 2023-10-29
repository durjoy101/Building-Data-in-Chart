using CleanBuilding.Application.DTOs;
using CleanBuilding.Application.Repository;
using CleanBuilding.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace CleanBuilding.Infrastructure.Repository
{
    public class DapperRepository : IDapperRepository
    {
        private readonly MainDbContext _dbContext;

        public IDbConnection Connection => _dbContext.Database.GetDbConnection();

        public DapperRepository(MainDbContext dbContext) => _dbContext = dbContext;

        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            var list = await _dbContext.Connection.QueryAsync<T>(sql, param, transaction) as IReadOnlyList<T>;

            return list ?? new List<T>();
        }
    }
}
