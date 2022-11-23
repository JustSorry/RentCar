using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class RentTime
	{
        [Key]
        public string UserId { get; set; }
        public int CarId { get; set; }
		
        public DateTime RentStartTime { get; set; }
        public DateTime RentEndTime { get; set; }
    }
}
