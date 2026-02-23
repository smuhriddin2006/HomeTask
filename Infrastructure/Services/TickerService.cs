using Domain.Models;
using Infrastructure.Interface;
using Npgsql;
namespace Infrastructure.Services;

public class TicketService : ITicketService
{
    const string connectionString = $@"Host=localhost;
                                       Database=TheatreDB;
                                       Username=postgres;
                                       Password=umed008";

    public void AddTicket(Ticket ticket)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string aTK = @"Insert into tickets (screening_id, customer_name, seat_number, price)
                               Values (@ScreeningId, @CustomerName, @SeatNumber, @Price)";
                NpgsqlCommand cTA = new NpgsqlCommand(aTK, connection);

                cTA.Parameters.AddWithValue("ScreeningId", ticket.ScreeningId);
                cTA.Parameters.AddWithValue("CustomerName", ticket.CustomerName);
                cTA.Parameters.AddWithValue("SeatNumber", ticket.SeatNumber);
                cTA.Parameters.AddWithValue("Price", ticket.Price);

                var insert = cTA.ExecuteNonQuery();
                System.Console.WriteLine($"Inserted successfully {insert}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Inserted Failed {ex.Message}");
        }
    }

    public void DeleteTicket(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string dTK = @"Delete from tickets where id = @id";
                NpgsqlCommand cTD = new NpgsqlCommand(dTK, connection);

                cTD.Parameters.AddWithValue("id", id);

                var delete = cTD.ExecuteNonQuery();
                System.Console.WriteLine($"Deleted successfully {delete}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Deleted Failed {ex.Message}");
        }
    }

    public List<Ticket> GetAllTickets()
    {
        List<Ticket> tickets = new List<Ticket>();
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string gAT = "select * from tickets";
                NpgsqlCommand cTG = new NpgsqlCommand(gAT, connection);

                var reader = cTG.ExecuteReader();

                while (reader.Read())
                {
                    Ticket ticket = new Ticket()
                    {
                        Id = reader.GetInt32(0),
                        ScreeningId = reader.GetInt32(1),
                        CustomerName = reader.GetString(2),
                        SeatNumber = reader.GetString(3),
                        Price = reader.GetDecimal(4)
                    };
                    tickets.Add(ticket);
                }
                return tickets;
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        return null;
    }

    public void UpdateTicket(Ticket ticket)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string uTK = @"Update tickets
                               Set screening_id = @ScreeningId,
                               customer_name = @CustomerName,
                               seat_number = @SeatNumber,
                               price = @Price
                               where id = @id";

                NpgsqlCommand cTU = new NpgsqlCommand(uTK, connection);

                cTU.Parameters.AddWithValue("ScreeningId", ticket.ScreeningId);
                cTU.Parameters.AddWithValue("CustomerName", ticket.CustomerName);
                cTU.Parameters.AddWithValue("SeatNumber", ticket.SeatNumber);
                cTU.Parameters.AddWithValue("Price", ticket.Price);
                cTU.Parameters.AddWithValue("id", ticket.Id);

                var update = cTU.ExecuteNonQuery();
                System.Console.WriteLine($"Updated successfully {update}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Updated Failed {ex.Message}");
        }
    }

    public Ticket GetTicketById(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            string gTI = @"select * from tickets where id = @id";
            NpgsqlCommand cTG = new NpgsqlCommand(gTI, connection);

            cTG.Parameters.AddWithValue("id", id);
            var reader = cTG.ExecuteReader();

            while (reader.Read())
            {
                Ticket ticket = new()
                {
                    Id = reader.GetInt32(0),
                    ScreeningId = reader.GetInt32(1),
                    CustomerName = reader.GetString(2),
                    SeatNumber = reader.GetString(3),
                    Price = reader.GetDecimal(4)
                };
                return ticket;
            }
        }

        return null;
    }
}
