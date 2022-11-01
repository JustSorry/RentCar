using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
	public class RentTime
	{
        [Required][Key]
        public int UserId { get; set; }
        public User? User { get; set; }

        public int CarId { get; set; }
        public Car? Car { get; set; }
		
        public DateTime RentStartTime { get; set; }
        public DateTime RentEndTime { get; set; }

    }
}
