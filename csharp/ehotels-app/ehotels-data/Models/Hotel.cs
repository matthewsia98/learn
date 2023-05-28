using System;
namespace ehotels_data.Models
{
	public class Hotel
	{
		public int Id { get; set; }
		public Address Address { get; set; }
		public int Stars { get; set; }
		public int NumRooms { get; set; }
		public int HotelChainId { get; set; }
		public HotelChain HotelChain { get; set; }
	}
}

