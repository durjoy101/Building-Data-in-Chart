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
    public class DataFieldService : IDataFieldService
    {
        private readonly IDapperRepository _dapperRepository;
        public DataFieldService(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<IList<DataFieldDTO>> GetDataFieldData()
        {
            string query = QueryHelper.GetQueryDataField();
            var dto = await _dapperRepository.QueryAsync<DataFieldDTO>(query);

            return dto.ToList();
        }
    }
}
