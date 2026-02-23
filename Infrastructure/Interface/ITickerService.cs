using Domain.Models;

namespace Infrastructure.Interface;

public interface ITicketService
{
    void AddTicket(Ticket ticket);
    List<Ticket> GetAllTickets();
    void DeleteTicket(int id);
    void UpdateTicket(Ticket ticket);
}
