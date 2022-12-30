using Pin.CricketDarts.Server.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Pin.CricketDarts.Server.Models
{
    public class Player : BaseModel
    {
        [Required(ErrorMessage = "Please fill in a name")]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
        public bool HasTurn { get; set; }
        public int CurrentAmountOfThrows { get; set; }
        public int CurrentTotalScore { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
    }
}
