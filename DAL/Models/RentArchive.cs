﻿using System.ComponentModel.DataAnnotations;

namespace DAL.Models;
public class RentArchive
{
	[Key]
	public int Id { get; set; }
	public string UserId { get; set; }
	public int CarId { get; set; }
	public DateTime RentStartDate {get; set;}
	public DateTime RentEndDate { get; set; }
}