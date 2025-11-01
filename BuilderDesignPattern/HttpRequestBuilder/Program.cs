using HttpRequestBuilder;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        var httpRequest = HttpRequest.CreateHttpRequestBuilder()
            .SetUrl("https://www.google.com/todo/test")
            .SetMethod("GET")
            .Build();
        httpRequest.Send();
        
        
        Console.WriteLine("********* Http request with Get/ post methods");
        httpRequest = HttpRequest.Get("https://google.com/todo").Build();
        httpRequest.Send();
        
        httpRequest = HttpRequest.Post("https://toto.com/todo")
            .SetBody("{testing application}")
            .Build();
        httpRequest.Send();
    }
}