using TicketTransition;

public class Ticket
{
    public string Description { get; private set; }
    private User CreatedBy { get; set; }
    public TicketState TicketState { get; set; }

    public Ticket(string description, User createdBy)
    {
        this.Description = description;
        this.CreatedBy = createdBy;
        this.TicketState = TicketState.Analysis;
    }
}