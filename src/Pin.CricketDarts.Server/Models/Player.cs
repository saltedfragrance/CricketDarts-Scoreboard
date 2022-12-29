using Pin.CricketDarts.Server.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Pin.CricketDarts.Server.Models
{
    public class Player : BaseModel
    {
        [Required(ErrorMessage = "Please fill in a name")]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
    }
}
