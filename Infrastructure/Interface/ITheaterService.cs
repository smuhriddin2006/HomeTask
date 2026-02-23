using Domain.Models;

namespace Infrastructure.Interface;

public interface ITheaterService
{
    void AddTheater(Theater theater);
    List<Theater> GetAllTheaters();
    void DeleteTheater(int id);
    void UpdateTheater(Theater theater);
}
