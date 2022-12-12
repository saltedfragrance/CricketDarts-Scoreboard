using Pin.CricketDarts.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Entities
{
    public class Score : BaseEntity
    {
        public Guid PlayerId { get; set; }
        public int TotalScore { get; set; }
    }
}
