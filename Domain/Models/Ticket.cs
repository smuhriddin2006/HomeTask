namespace Domain.Models;

public class Ticket
{
    public int Id { get; set; }

    public int ScreeningId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string SeatNumber { get; set; }

    public decimal Price { get; set; }
}
