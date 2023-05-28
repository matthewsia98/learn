namespace ehotels_data.Models;

public class HotelChain
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int NumHotels { get; set; }
    public List<Hotel> Hotels { get; set; } = new List<Hotel>();
}

