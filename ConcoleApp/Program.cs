

using System.Runtime.Intrinsics.Arm;
using Domain.Models;
using Infrastructure.Services;

MovieService movieService = new();
TheaterService theaterService = new();
ScreeningService screeningService = new();
TicketService ticketService = new();

while (true)
{
    System.Console.WriteLine("Press 1 - To use Movie Service");
    System.Console.WriteLine("Press 2 - To use Theater Service");
    System.Console.WriteLine("Press 3 - To use Screening Service");
    System.Console.WriteLine("Press 4 - To use Ticket Service");
    System.Console.WriteLine("Press 0 - For Exit");

    int select = int.Parse(System.Console.ReadLine());

    switch(select)
    {
        case 1:
        MService();
        break;
        case 2:
        TService();
        break;
        case 3:
        SService();
        break;
        case 4:
        TicketServiceMenu();
        break;
        case 0:
        return;
    }

}
void MService()
{
    while(true){
    System.Console.WriteLine("Enter 1 to Add Movie");
    System.Console.WriteLine("Enter 2 to Delete Movie");
    System.Console.WriteLine("Enter 3 to Update Movie");
    System.Console.WriteLine("Enter 4 to Show all movies");
    System.Console.WriteLine("Enter 5 to Get Movie by Id");
    System.Console.WriteLine("Enter 0 to Back");

    int select = int.Parse(System.Console.ReadLine());

        switch (select)
        {
            case 1:
            AddMovie();
            break;
            case 2:
            DeleteMovie();
            break;
            case 3:
            UpdateMovie();
            break;
            case 4:
            ShowAllMovies();
            break;
            case 0:
            return;
        }
    }
}

void AddMovie()
{
    System.Console.WriteLine("Enter the information about movie");
    
    Movie movie = new();
    
    System.Console.Write("The Title of Movie: ");
    movie.Title = System.Console.ReadLine();
    
    System.Console.Write("The Director: ");
    movie.Director = System.Console.ReadLine();

    System.Console.Write("The Year: ");
    movie.Year = int.Parse(System.Console.ReadLine());

    System.Console.Write("Duration: ");
    movie.Duration = int.Parse(System.Console.ReadLine());

    System.Console.Write("Genre: ");
    movie.Genre = System.Console.ReadLine();

    System.Console.Write("Desription: ");
    movie.Description = System.Console.ReadLine();

    movieService.AddMovie(movie);
}

void DeleteMovie()
{
    System.Console.Write("Enter the movie id you wanna delete: ");
    int id = int.Parse(System.Console.ReadLine());

    movieService.DeleteMovie(id);
}

void UpdateMovie()
{
    System.Console.Write("Enter the id of a movie you wanna update: ");
    int id = int.Parse(System.Console.ReadLine());
    System.Console.WriteLine("Enter new information for update movie");
    Movie movie = new();


    movie.Id = id;
    System.Console.Write("The title od Movie: ");
    movie.Title = System.Console.ReadLine();
    System.Console.Write("The director: ");
    movie.Director = System.Console.ReadLine();
    System.Console.Write("The Year: ");
    movie.Year = int.Parse(System.Console.ReadLine());
    System.Console.Write("Duration: ");
    movie.Duration = int.Parse(System.Console.ReadLine());
    System.Console.Write("Genre: ");
    movie.Genre = System.Console.ReadLine();
    System.Console.Write("Description: ");
    movie.Description = System.Console.ReadLine();
    
    movieService.UpdateMovie(movie);
}

void ShowAllMovies()
{
    List<Movie> getMovie = movieService.GetAllMovies();
    foreach(var movie in getMovie)
    {
        System.Console.WriteLine("===========================================================");

        System.Console.WriteLine($@"Id: {movie.Id}
Title: {movie.Title}
Director: {movie.Director}
Year: {movie.Year}
Duration: {movie.Duration}
Genre: {movie.Genre}
Description: {movie.Description}");
    }
     System.Console.WriteLine("===========================================================");

}


/* Theater Service */

void TService()
{
    while (true)
    {
        System.Console.WriteLine("Enter 1 to Add Theater");
        System.Console.WriteLine("Enter 2 to Delete Theater");
        System.Console.WriteLine("Enter 3 to Update Theater");
        System.Console.WriteLine("Enter 4 to Show all Theaters");
        System.Console.WriteLine("Enter 5 to Get Theater by Id");
        System.Console.WriteLine("Enter 0 to Back");

        int select = int.Parse(System.Console.ReadLine());

        switch (select)
        {
            case 1:
                AddTheater();
                break;
            case 2:
                DeleteTheater();
                break;
            case 3:
                UpdateTheater();
                break;
            case 4:
                ShowAllTheaters();
                break;
            case 5:
                GetTheaterById();
                break;
            case 0:
                return;
        }
    }
}

void AddTheater()
{
    Theater theater = new();

    System.Console.Write("The Name of Theater: ");
    theater.Name = System.Console.ReadLine();

    System.Console.Write("Location: ");
    theater.Location = System.Console.ReadLine();

    System.Console.Write("Manager: ");
    theater.Manager = System.Console.ReadLine();

    System.Console.Write("Phone: ");
    theater.Phone = System.Console.ReadLine();

    System.Console.Write("Capacity: ");
    theater.Capacity = int.Parse(System.Console.ReadLine());

    theaterService.AddTheater(theater);
}

void DeleteTheater()
{
    System.Console.Write("Enter the Theater id you wanna delete: ");
    int id = int.Parse(System.Console.ReadLine());
    theaterService.DeleteTheater(id);
}

void UpdateTheater()
{
    System.Console.Write("Enter the id of a theater you wanna update: ");
    int id = int.Parse(System.Console.ReadLine());
    Theater theater = new();
    theater.Id = id;

    System.Console.Write("The Name of Theater: ");
    theater.Name = System.Console.ReadLine();
    System.Console.Write("Location: ");
    theater.Location = System.Console.ReadLine();
    System.Console.Write("Manager: ");
    theater.Manager = System.Console.ReadLine();
    System.Console.Write("Phone: ");
    theater.Phone = System.Console.ReadLine();
    System.Console.Write("Capacity: ");
    theater.Capacity = int.Parse(System.Console.ReadLine());

    theaterService.UpdateTheater(theater);
}

void ShowAllTheaters()
{
    List<Theater> theaters = theaterService.GetAllTheaters();
    foreach (var theater in theaters)
    {
        System.Console.WriteLine("===========================================================");
        System.Console.WriteLine($@"Id: {theater.Id}
Name: {theater.Name}
Location: {theater.Location}
Manager: {theater.Manager}
Phone: {theater.Phone}
Capacity: {theater.Capacity}");
    }
    System.Console.WriteLine("===========================================================");
}

void GetTheaterById()
{
    System.Console.Write("Enter the Theater id: ");
    int id = int.Parse(System.Console.ReadLine());
    Theater theater = theaterService.GetTheaterById(id);
    if (theater != null)
    {
        System.Console.WriteLine($@"Id: {theater.Id}
Name: {theater.Name}
Location: {theater.Location}
Manager: {theater.Manager}
Phone: {theater.Phone}
Capacity: {theater.Capacity}");
    }
    else
    {
        System.Console.WriteLine("Theater not found!");
    }
}


/* Screening Service */ 
void SService()
{
    while (true)
    {
        System.Console.WriteLine("Enter 1 to Add Screening");
        System.Console.WriteLine("Enter 2 to Delete Screening");
        System.Console.WriteLine("Enter 3 to Update Screening");
        System.Console.WriteLine("Enter 4 to Show all Screenings");
        System.Console.WriteLine("Enter 5 to Get Screening by Id");
        System.Console.WriteLine("Enter 0 to Back");

        int select = int.Parse(System.Console.ReadLine());

        switch (select)
        {
            case 1:
                AddScreening();
                break;
            case 2:
                DeleteScreening();
                break;
            case 3:
                UpdateScreening();
                break;
            case 4:
                ShowAllScreenings();
                break;
            case 5:
                GetScreeningById();
                break;
            case 0:
                return;
        }
    }
}

void AddScreening()
{
    Screening screening = new();

    System.Console.Write("Movie Id: ");
    screening.MovieId = int.Parse(System.Console.ReadLine());

    System.Console.Write("Theater Id: ");
    screening.TheaterId = int.Parse(System.Console.ReadLine());

    System.Console.Write("Screening Time (yyyy-MM-dd HH:mm): ");
    screening.ScreeningTime = DateTime.Parse(System.Console.ReadLine());

    System.Console.Write("Ticket Price: ");
    screening.TicketPrice = decimal.Parse(System.Console.ReadLine());

    System.Console.Write("Available Seats: ");
    screening.AvailableSeats = int.Parse(System.Console.ReadLine());

    screeningService.AddScreening(screening);
}

void DeleteScreening()
{
    System.Console.Write("Enter the Screening id you wanna delete: ");
    int id = int.Parse(System.Console.ReadLine());
    screeningService.DeleteScreening(id);
}

void UpdateScreening()
{
    System.Console.Write("Enter the id of a screening you wanna update: ");
    int id = int.Parse(System.Console.ReadLine());
    Screening screening = new();
    screening.Id = id;

    System.Console.Write("Movie Id: ");
    screening.MovieId = int.Parse(System.Console.ReadLine());
    System.Console.Write("Theater Id: ");
    screening.TheaterId = int.Parse(System.Console.ReadLine());
    System.Console.Write("Screening Time (yyyy-MM-dd HH:mm): ");
    screening.ScreeningTime = DateTime.Parse(System.Console.ReadLine());
    System.Console.Write("Ticket Price: ");
    screening.TicketPrice = decimal.Parse(System.Console.ReadLine());
    System.Console.Write("Available Seats: ");
    screening.AvailableSeats = int.Parse(System.Console.ReadLine());

    screeningService.UpdateScreening(screening);
}

void ShowAllScreenings()
{
    List<Screening> screenings = screeningService.GetAllScreening();
    foreach (var screening in screenings)
    {
        System.Console.WriteLine("===========================================================");
        System.Console.WriteLine($@"Id: {screening.Id}
MovieId: {screening.MovieId}
TheaterId: {screening.TheaterId}
ScreeningTime: {screening.ScreeningTime}
TicketPrice: {screening.TicketPrice}
AvailableSeats: {screening.AvailableSeats}");
    }
    System.Console.WriteLine("===========================================================");
}

void GetScreeningById()
{
    System.Console.Write("Enter the Screening id: ");
    int id = int.Parse(System.Console.ReadLine());
    Screening screening = screeningService.GetScreeningById(id);
    if (screening != null)
    {
        System.Console.WriteLine($@"Id: {screening.Id}
MovieId: {screening.MovieId}
TheaterId: {screening.TheaterId}
ScreeningTime: {screening.ScreeningTime}
TicketPrice: {screening.TicketPrice}
AvailableSeats: {screening.AvailableSeats}");
    }
    else
    {
        System.Console.WriteLine("Screening not found!");
    }
}

/* Ticket Service */

void TicketServiceMenu()
{
    while (true)
    {
        System.Console.WriteLine("Enter 1 to Add Ticket");
        System.Console.WriteLine("Enter 2 to Delete Ticket");
        System.Console.WriteLine("Enter 3 to Update Ticket");
        System.Console.WriteLine("Enter 4 to Show all Tickets");
        System.Console.WriteLine("Enter 5 to Get Ticket by Id");
        System.Console.WriteLine("Enter 0 to Back");

        int select = int.Parse(System.Console.ReadLine());

        switch (select)
        {
            case 1:
                AddTicket();
                break;
            case 2:
                DeleteTicket();
                break;
            case 3:
                UpdateTicket();
                break;
            case 4:
                ShowAllTickets();
                break;
            case 5:
                GetTicketById();
                break;
            case 0:
                return;
        }
    }
}

void AddTicket()
{
    Ticket ticket = new();

    System.Console.Write("Screening Id: ");
    ticket.ScreeningId = int.Parse(System.Console.ReadLine());
    System.Console.Write("Customer Name: ");
    ticket.CustomerName = System.Console.ReadLine();
    System.Console.Write("Seat Number: ");
    ticket.SeatNumber = System.Console.ReadLine();
    System.Console.Write("Price: ");
    ticket.Price = decimal.Parse(System.Console.ReadLine());

    ticketService.AddTicket(ticket);
}

void DeleteTicket()
{
    System.Console.Write("Enter the Ticket id you wanna delete: ");
    int id = int.Parse(System.Console.ReadLine());
    ticketService.DeleteTicket(id);
}

void UpdateTicket()
{
    System.Console.Write("Enter the id of a ticket you wanna update: ");
    int id = int.Parse(System.Console.ReadLine());
    Ticket ticket = new();
    ticket.Id = id;

    System.Console.Write("Screening Id: ");
    ticket.ScreeningId = int.Parse(System.Console.ReadLine());
    System.Console.Write("Customer Name: ");
    ticket.CustomerName = System.Console.ReadLine();
    System.Console.Write("Seat Number: ");
    ticket.SeatNumber = System.Console.ReadLine();
    System.Console.Write("Price: ");
    ticket.Price = decimal.Parse(System.Console.ReadLine());

    ticketService.UpdateTicket(ticket);
}

void ShowAllTickets()
{
    List<Ticket> tickets = ticketService.GetAllTickets();
    foreach (var ticket in tickets)
    {
        System.Console.WriteLine("===========================================================");
        System.Console.WriteLine($@"Id: {ticket.Id}
ScreeningId: {ticket.ScreeningId}
CustomerName: {ticket.CustomerName}
SeatNumber: {ticket.SeatNumber}
Price: {ticket.Price}");
    }
    System.Console.WriteLine("===========================================================");
}

void GetTicketById()
{
    System.Console.Write("Enter the Ticket id: ");
    int id = int.Parse(System.Console.ReadLine());
    Ticket ticket = ticketService.GetTicketById(id);
    if (ticket != null)
    {
        System.Console.WriteLine($@"Id: {ticket.Id}
ScreeningId: {ticket.ScreeningId}
CustomerName: {ticket.CustomerName}
SeatNumber: {ticket.SeatNumber}
Price: {ticket.Price}");
    }
    else
    {
        System.Console.WriteLine("Ticket not found!");
    }
}