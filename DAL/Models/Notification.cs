namespace DAL.Models;

public class Notification
{
	public int Id { get; set; }
	public string UserId { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public DateTime CreatedDate { get; set;}
}

