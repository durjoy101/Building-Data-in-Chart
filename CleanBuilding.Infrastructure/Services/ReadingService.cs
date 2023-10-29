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
    public class ReadingService : IReadingService
    {
        private readonly IDapperRepository _dapperRepository;
        public ReadingService(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<IList<ReadingDTO>> GetReadingData(
            int? buidlingID,
            int? objectID,
            int? dataFieldID,
            DateTime startTime,
            DateTime endTime)
        {
            string query = QueryHelper.GetQuery(buidlingID, objectID, dataFieldID, startTime, endTime);
            var dto = await _dapperRepository.QueryAsync<ReadingDTO>(query);

            return dto.ToList();
        }
    }
}
