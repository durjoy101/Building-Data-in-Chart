using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBuilding.Domain
{
    public class Reading
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int ObjectId { get; set; }
        public int DataFieldId { get; set; }
        public decimal Value { get; set; }
        public DateTime TimeSpan { get; set; }
    }
}
