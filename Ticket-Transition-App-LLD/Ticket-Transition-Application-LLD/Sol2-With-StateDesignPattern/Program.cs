internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        User user= new User("abc");
        Ticket ticket = new Ticket("Ticket111", user);

        TicketService ticketService= new TicketService();
        ticketService.StartAnalysis(ticket, user);

        ticketService.StartReview(ticket, user);
        Console.WriteLine($"{ticket.TicketState}");

        ticketService.MarkDone(ticket, user);
        System.Console.WriteLine($"{ticket.TicketState}");
    }
}