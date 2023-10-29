using CleanBuilding.Application;
using CleanBuilding.Application.DTOs;
using CleanBuilding.Application.Repository;
using CleanBuilding.Application.Services;
using CleanBuilding.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBuilding.Infrastructure.Services
{
    public class ObjectService : IObjectService
    {
        private readonly IDapperRepository _dapperRepository;
        public ObjectService(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<IList<ObjectDTO>> GetObjectData()
        {
            string query = QueryHelper.GetQueryObject();
            var dto = await _dapperRepository.QueryAsync<ObjectDTO>(query);

            return dto.ToList();
        }
    }
}
