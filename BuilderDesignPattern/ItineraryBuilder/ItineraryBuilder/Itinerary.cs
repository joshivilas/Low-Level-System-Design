using System;

namespace ItineraryBuilder;

public class Itinerary
{

    public string TravelerName { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string Origin { get; private set; }
    public string Destination { get; private set; }

    private Itinerary(
    )
    { }


    public void ShowItineraryInfo()
    {
        Console.WriteLine($"Itinerary Information");
        Console.WriteLine($"Traveler Name: {TravelerName}");
        System.Console.WriteLine($"Between {StartDate} - {EndDate}");
        System.Console.WriteLine($"From: {Origin} , to : {Destination}");
    }

    public static class Builder
    {
        public static ItineraryBuilder Create() => new ItineraryBuilder();
        public class ItineraryBuilder
        {
            private string _travelerName;
            private DateTime? _startTime;
            private DateTime? _endTime;
            private string _origin;
            private string _destination;

            public ItineraryBuilder SetTravelerName(string travelerName)
            {
                _travelerName = travelerName;
                return this;
            }

            public ItineraryBuilder SetStartTime(DateTime startTime)
            {
                _startTime = startTime;
                return this;
            }
            public ItineraryBuilder SetEndTime(DateTime endDateTime)
            {
                _endTime = endDateTime;
                return this;
            }
            public ItineraryBuilder SetOrigin(string origin)
            {
                _origin = origin;
                return this;
            }
            public ItineraryBuilder SetDestination(string destination)
            {
                _destination = destination;
                return this;
            }
            public Itinerary Build()
            {
                var errors = new List<string>();
                if (string.IsNullOrWhiteSpace(_travelerName))
                    errors.Add("TravelerName is required");

                if (!_startTime.HasValue)
                    errors.Add("StartDate is required");

                if (!_endTime.HasValue)
                    errors.Add("EndDate is required");

                if (string.IsNullOrWhiteSpace(_origin) || _origin.Length > 3 || !_origin.All(char.IsLetter))
                    errors.Add("Origin should be 3 character string of characters only");

                if (string.IsNullOrWhiteSpace(_destination) || _destination.Length > 3 || !_destination.All(char.IsLetter))
                    errors.Add("destination should be 3 character string of characters only");

                if (errors.Any())
                {
                    throw new Exception($"Invalid itineraray with : {string.Join("; ", errors)}");
                }

                var itinerary = new Itinerary();
                itinerary.TravelerName = _travelerName;
                itinerary.StartDate = (DateTime)_startTime;
                itinerary.EndDate = (DateTime)_endTime;
                itinerary.Origin = _origin;
                itinerary.Destination = _destination;
                return itinerary;
            }

        }
    }
}
