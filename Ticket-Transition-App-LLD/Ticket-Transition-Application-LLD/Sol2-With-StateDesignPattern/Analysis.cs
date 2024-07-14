
using TicketTransition;

class Analysis : IState
{
    public bool MarkDone(Ticket ticket, User user)
    {
        System.Console.WriteLine($"ticket is moved from {ticket.TicketState} -> {TicketState.Done}");
        return true;
    }

    public bool StartAnalysis(Ticket ticket, User user)
    {
      System.Console.WriteLine("Ticket is already in analysis state.");
      return false;
    }

    public bool StartReview(Ticket ticket, User user)
    {
        System.Console.WriteLine($"ticket is moved from {ticket.TicketState} -> {TicketState.Review}");
        return true;
    }
}