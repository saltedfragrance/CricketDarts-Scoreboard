using Pin.CricketDarts.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public Guid PersonalStatisticsId { get; set; }
        public PersonalStatistics PersonalStatistics { get; set; }
    }
}
