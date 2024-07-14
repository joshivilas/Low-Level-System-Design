
using TicketTransition;

class Review : IState
{
    public bool MarkDone(Ticket ticket, User user)
    {
        System.Console.WriteLine($"ticket is moved from {ticket.TicketState} -> {TicketState.Done}");
        return true;
    }

    public bool StartAnalysis(Ticket ticket, User user)
    {
        System.Console.WriteLine($"ticket is moved from {ticket.TicketState} -> {TicketState.Analysis}");
        return true;
    }

    public bool StartReview(Ticket ticket, User user)
    {
        System.Console.WriteLine("Ticket is already in Review state.");
        return false;
    }
}