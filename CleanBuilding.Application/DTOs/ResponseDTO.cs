using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBuilding.Application.DTOs
{
    public class ResponseDTO
    {
        public ResponseDTO()
        {
            Readings = new List<ReadingDTO>();
            Timestamps = new List<string>();
        }
        public IList<ReadingDTO> Readings { get; set; }
        public IList<string> Timestamps { get; set; }
    }
}
