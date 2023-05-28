using System;
using Microsoft.EntityFrameworkCore;

namespace ehotels_data.Models
{
	[Owned]
	public class Address
	{
		public string StreetNumber { get; set; }
		public string StreetName { get; set; }
		public string City { get; set; }
		public string ProvinceOrState { get; set; }
		public string Country { get; set; }
		public string ZipCode { get; set; }
	}
}

