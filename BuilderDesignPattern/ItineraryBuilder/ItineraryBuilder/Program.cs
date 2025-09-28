// See https://aka.ms/new-console-template for more information
using ItineraryBuilder;

Console.WriteLine("Hello, World!");

try
{
    var itineraray = Itinerary.Builder
                .Create()
                .SetTravelerName("AlgoCamp")
                .SetStartTime(new DateTime(2025, 10, 1))
                .SetEndTime(new DateTime(2025, 10, 20))
                .SetOrigin("MSTY")
                .SetDestination("GGL")
                .Build();

    itineraray.ShowItineraryInfo();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}