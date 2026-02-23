using Domain.Models;

namespace Infrastructure.Interface;

public interface IScreeningService
{
    void AddScreening(Screening screening);
    List<Screening> GetAllScreening();
    void DeleteScreening(int id);
    void UpdateScreening(Screening screening);
}
