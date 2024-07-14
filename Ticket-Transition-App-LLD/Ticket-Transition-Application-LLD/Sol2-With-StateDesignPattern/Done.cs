
using TicketTransition;

class Done : IState
{
    public bool MarkDone(Ticket ticket, User user)
    {
        System.Console.WriteLine("Ticket is already in Dome state.");
        return false;

    }

    public bool StartAnalysis(Ticket ticket, User user)
    {
        System.Console.WriteLine($"ticket is moved from {ticket.TicketState} -> {TicketState.Analysis}");
        return true;
    }

    public bool StartReview(Ticket ticket, User user)
    {
        System.Console.WriteLine($"ticket is moved from {ticket.TicketState} -> {TicketState.Review}");
        return true;
    }
}