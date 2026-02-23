using Domain.Models;
using Infrastructure.Interface;
using Npgsql;
namespace Infrastructure.Services;

public class TheaterService : ITheaterService
{
    const string connectionString = $@"Host=localhost;
                                       Database=TheatreDB;
                                       Username=postgres;
                                       Password=umed008";

    public void AddTheater(Theater theater)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string aST = @"Insert into theaters (name, location, manager, phone, capacity)
                                Values (@Name, @Location, @Manager, @Phone, @Capacity)";
                NpgsqlCommand cTA = new NpgsqlCommand(aST, connection);

                cTA.Parameters.AddWithValue("Name", theater.Name);
                cTA.Parameters.AddWithValue("Location", theater.Location);
                cTA.Parameters.AddWithValue("Manager", theater.Manager);
                cTA.Parameters.AddWithValue("Phone", theater.Phone);
                cTA.Parameters.AddWithValue("Capacity", theater.Capacity);

                var insert = cTA.ExecuteNonQuery();
                System.Console.WriteLine($"Inserted successfully {insert}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Inserted Failed {ex.Message}");
        }
    }

    public void DeleteTheater(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string dST = @"Delete from theaters where id = @id";
                NpgsqlCommand cTD = new NpgsqlCommand(dST, connection);

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

    public List<Theater> GetAllTheaters()
    {
        List<Theater> theaters = new List<Theater>();
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string gAT = "select * from theaters";
                NpgsqlCommand cTG = new NpgsqlCommand(gAT, connection);

                var reader = cTG.ExecuteReader();

                while (reader.Read())
                {
                    Theater theater = new Theater()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Location = reader.GetString(2),
                        Manager = reader.GetString(3),
                        Phone = reader.GetString(4),
                        Capacity = reader.GetInt32(5)
                    };
                    theaters.Add(theater);
                }
                return theaters;
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        return null;
    }

    public void UpdateTheater(Theater theater)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string uST = @"Update theaters
                               Set name = @Name,
                               location = @Location,
                               manager = @Manager,
                               phone = @Phone,
                               capacity = @Capacity
                               where id = @id";

                NpgsqlCommand cTU = new NpgsqlCommand(uST, connection);

                cTU.Parameters.AddWithValue("Name", theater.Name);
                cTU.Parameters.AddWithValue("Location", theater.Location);
                cTU.Parameters.AddWithValue("Manager", theater.Manager);
                cTU.Parameters.AddWithValue("Phone", theater.Phone);
                cTU.Parameters.AddWithValue("Capacity", theater.Capacity);
                cTU.Parameters.AddWithValue("id", theater.Id);

                var update = cTU.ExecuteNonQuery();
                System.Console.WriteLine($"Updated successfully {update}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Updated Failed {ex.Message}");
        }
    }

    public Theater GetTheaterById(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            string gTI = @"select * from theaters where id = @id";
            NpgsqlCommand cTG = new NpgsqlCommand(gTI, connection);

            cTG.Parameters.AddWithValue("id", id);
            var reader = cTG.ExecuteReader();

            while (reader.Read())
            {
                Theater theater = new()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Location = reader.GetString(2),
                    Manager = reader.GetString(3),
                    Phone = reader.GetString(4),
                    Capacity = reader.GetInt32(5)
                };
                return theater;
            }
        }

        return null;
    }
}
