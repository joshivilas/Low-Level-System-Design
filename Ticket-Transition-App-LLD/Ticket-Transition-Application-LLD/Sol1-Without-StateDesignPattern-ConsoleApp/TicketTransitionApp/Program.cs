using TicketTransition;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        User user = new User("ABSc");
        TicketService ticketService= new TicketService();
        var ticket = ticketService.createTicket("This is first ticket", user);
        ticketService.ChangeTicketState(ticket, TicketState.Analysis);
        ticketService.ChangeTicketState(ticket, TicketState.Review);
        ticketService.ChangeTicketState(ticket, TicketState.Done);

    }
}