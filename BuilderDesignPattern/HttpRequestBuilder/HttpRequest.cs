namespace HttpRequestBuilder
{
    public class HttpRequest
    {
        private string Url { get; set; }
        private string Method { get; set; }
        private string Body { get; set; }
        private Dictionary<string, string> Headers { get; set; }
        private int Timeout { get; set; }
        private HttpRequest() { }

        public void Send()
        {
            Console.WriteLine("Sending request...");
            Console.WriteLine($"Url: {Url}");
            Console.WriteLine($"Method: {Method}");

        }
        public static HttpRequestBuilder CreateHttpRequestBuilder()
        {
            return new HttpRequestBuilder();
        }

        public static HttpRequestBuilder Get(string url)
        {
            return HttpRequest.CreateHttpRequestBuilder().SetMethod("GET").SetUrl(url);
        }
        public static HttpRequestBuilder Post(string url)
        {
            return HttpRequest.CreateHttpRequestBuilder().SetMethod("POST").SetUrl(url);
        }

        public class HttpRequestBuilder
        {
            private string _url = string.Empty;
            private string _method = string.Empty;
            private string _body;
            private Dictionary<string, string> _headers = new Dictionary<string, string>();
            private int _timeout = 10;

            internal HttpRequestBuilder() { }

            public HttpRequestBuilder SetUrl(string url)
            {
                _url = url;
                return this;
            }

            public HttpRequestBuilder SetMethod(string method)
            {
                _method = method;
                return this;
            }

            public HttpRequestBuilder SetBody(string body)
            {
                _body = body;
                return this;
            }

            public HttpRequestBuilder SetHeader(string name, string value)
            {
                _headers.Add(name, value);
                return this;
            }

            public HttpRequestBuilder SetTimeout(int timeout)
            {
                _timeout = timeout;
                return this;
            }

            private bool validUrl(string url)
            {
                var uri = new Uri(url, UriKind.Absolute);
                return uri.IsAbsoluteUri;
            }

            private bool validMethod(string method)
            {
                method = method.ToUpper();
                return method == "GET" || method == "POST" || method == "PUT" || method == "DELETE" || method == "PATCH";
            }

            public HttpRequest Build()
            {
                //validations here 
                var errors = new List<string>();

                if (string.IsNullOrEmpty(_url))
                {
                    errors.Add("Url can not be empty.");
                }

                if (!validUrl(_url))
                {
                    errors.Add($"Url is not valid absolute URL. Given : {_url}");
                }

                if (string.IsNullOrEmpty(_method))
                {
                    errors.Add("Method can not be empty.");
                }

                if (!validMethod(_method))
                {
                    errors.Add($"Method must be one of the following: GET, POST, PUT, DELETE, PATCH. Given {_method}.");
                }

                if (_method == "GET" &&  !string.IsNullOrEmpty(_body))
                {
                    errors.Add($"Body can not be added for a GET request.");
                }

                if (_method == "POST" && string.IsNullOrEmpty(_body))
                {
                    errors.Add("Body can not be empty for POST method.");
                }
                
                if (errors.Any())
                {
                    throw new Exception($"Invalid HttpRequest details provided: {string.Join(", ", errors)}");
                }

                var httpRequest = new HttpRequest
                {
                    Url = _url,
                    Method = _method,
                    Body = _body,
                    Headers = _headers,
                    Timeout = _timeout
                };

                return httpRequest;
            }

        }
    }
}