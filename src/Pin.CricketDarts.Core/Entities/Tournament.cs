using Pin.CricketDarts.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Entities
{
    public class Tournament : BaseEntity
    {
        public bool IsOngoing { get; set; } = false;
        public ICollection<Game> Games { get; set; }
    }
}
