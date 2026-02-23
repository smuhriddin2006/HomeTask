using Domain.Models;
using Infrastructure.Interface;
using Npgsql;
namespace Infrastructure.Services;
   
public class ScreeningService : IScreeningService
{
    const string connectionString = $@"Host=localhost;
                                       Database=TheatreDB;
                                       Username=postgres;
                                       Password=umed008";

    public void AddScreening(Screening screening)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string aSS = @"Insert into screenings (movie_id, theater_id, screening_time, ticket_price, available_seats)
                               Values (@MovieId, @TheaterId, @ScreeningTime, @TicketPrice, @AvailableSeats)";
                NpgsqlCommand cTA = new NpgsqlCommand(aSS, connection);

                cTA.Parameters.AddWithValue("MovieId", screening.MovieId);
                cTA.Parameters.AddWithValue("TheaterId", screening.TheaterId);
                cTA.Parameters.AddWithValue("ScreeningTime", screening.ScreeningTime);
                cTA.Parameters.AddWithValue("TicketPrice", screening.TicketPrice);
                cTA.Parameters.AddWithValue("AvailableSeats", screening.AvailableSeats);

                var insert = cTA.ExecuteNonQuery();
                System.Console.WriteLine($"Inserted successfully {insert}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Inserted Failed {ex.Message}");
        }
    }

    public void DeleteScreening(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string dSS = @"Delete from screenings where id = @id";
                NpgsqlCommand cTD = new NpgsqlCommand(dSS, connection);

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

    public List<Screening> GetAllScreening()
    {
        List<Screening> screenings = new List<Screening>();
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string gAS = "select * from screenings";
                NpgsqlCommand cTG = new NpgsqlCommand(gAS, connection);

                var reader = cTG.ExecuteReader();

                while (reader.Read())
                {
                    Screening screening = new Screening()
                    {
                        Id = reader.GetInt32(0),
                        MovieId = reader.GetInt32(1),
                        TheaterId = reader.GetInt32(2),
                        ScreeningTime = reader.GetDateTime(3),
                        TicketPrice = reader.GetDecimal(4),
                        AvailableSeats = reader.GetInt32(5)
                    };
                    screenings.Add(screening);
                }
                return screenings;
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        return null;
    }

    public void UpdateScreening(Screening screening)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string uSS = @"Update screenings
                               Set movie_id = @MovieId,
                               theater_id = @TheaterId,
                               screening_time = @ScreeningTime,
                               ticket_price = @TicketPrice,
                               available_seats = @AvailableSeats
                               where id = @id";

                NpgsqlCommand cTU = new NpgsqlCommand(uSS, connection);

                cTU.Parameters.AddWithValue("MovieId", screening.MovieId);
                cTU.Parameters.AddWithValue("TheaterId", screening.TheaterId);
                cTU.Parameters.AddWithValue("ScreeningTime", screening.ScreeningTime);
                cTU.Parameters.AddWithValue("TicketPrice", screening.TicketPrice);
                cTU.Parameters.AddWithValue("AvailableSeats", screening.AvailableSeats);
                cTU.Parameters.AddWithValue("id", screening.Id);

                var update = cTU.ExecuteNonQuery();
                System.Console.WriteLine($"Updated successfully {update}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Updated Failed {ex.Message}");
        }
    }

    public Screening GetScreeningById(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            string gSI = @"select * from screenings where id = @id";
            NpgsqlCommand cTG = new NpgsqlCommand(gSI, connection);

            cTG.Parameters.AddWithValue("id", id);
            var reader = cTG.ExecuteReader();

            while (reader.Read())
            {
                Screening screening = new()
                {
                    Id = reader.GetInt32(0),
                    MovieId = reader.GetInt32(1),
                    TheaterId = reader.GetInt32(2),
                    ScreeningTime = reader.GetDateTime(3),
                    TicketPrice = reader.GetDecimal(4),
                    AvailableSeats = reader.GetInt32(5)
                };
                return screening;
            }
        }

        return null;
    }
}

