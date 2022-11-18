using System.ComponentModel.DataAnnotations;


namespace DAL.Models
{
    public class Compare
    {
        [Required][Key]
        public string UserId { get; set; }
        public int? CompareCar1ID { get; set; }
        public int? CompareCar2ID { get; set; }

    }
}
