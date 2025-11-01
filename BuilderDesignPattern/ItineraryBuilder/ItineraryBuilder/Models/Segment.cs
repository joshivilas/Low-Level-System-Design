using System;

namespace ItineraryBuilder.Models;

public class Segment
{
    public string From { get; }
    public string To { get; }
    public DateTime DepartedAt { get; }
    public DateTime ArriveAt { get; }
    public string Carrier { get; }

    public Segment(string from, string to, string carrier, DateTime departedAt, DateTime arriveAt)
    {
        From = from;
        To = to;
        Carrier = carrier;
        DepartedAt = departedAt;
        ArriveAt = arriveAt;
    }

    public IEnumerable<string> Validate()
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(this.From))
            errors.Add("From should not be empty or null.");

        if (string.IsNullOrWhiteSpace(this.To))
            errors.Add("To field should not be empty or null.");

        if (!IsValidIata(this.From))
            errors.Add("From code is invalid. It should be 3 -letters code only");
        if (!IsValidIata(this.To))
            errors.Add("To code is invalid. It should be 3 letter only");

        if (this.ArriveAt < this.DepartedAt)
            errors.Add($"Arrive at {ArriveAt:yyyy-MM-dd} must be  after DepartAt {DepartedAt:yyyy-MM-dd}");

        return errors;
    }

    private bool IsValidIata(string code)
    {
        return code?.Length == 3 && code.All(char.IsLetter);
    }

}
