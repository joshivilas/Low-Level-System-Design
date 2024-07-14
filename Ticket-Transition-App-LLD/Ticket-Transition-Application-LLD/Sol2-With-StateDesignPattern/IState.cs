public interface IState
{
    bool StartAnalysis(Ticket ticket, User user);
    bool StartReview(Ticket ticket, User user);
    bool MarkDone(Ticket ticket, User user);
}