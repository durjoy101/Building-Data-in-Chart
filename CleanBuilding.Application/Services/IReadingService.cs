using CleanBuilding.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBuilding.Application.Services
{
    public interface IReadingService
    {
        Task<IList<ReadingDTO>> GetReadingData(int? buidlingID, int? objectID, int? dataFieldID, DateTime startTime, DateTime endTime);
    }
}
