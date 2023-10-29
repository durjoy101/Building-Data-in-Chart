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
    public class BuildingService : IBuildingService
    {
        private readonly IDapperRepository _dapperRepository;
        public BuildingService(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<IList<BuildingDTO>> GetBuildingData()
        {
            string query = QueryHelper.GetQueryBuilding();
            var dto = await _dapperRepository.QueryAsync<BuildingDTO>(query);

            return dto.ToList();
        }
    }
}
