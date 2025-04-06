### Builder Design Pattern 🏗️:  
    - Creational design pattern
    - To create complex objects step by step
    - Instead of creating objects directly with a constructor, it allows you to construct them piece by piece and then "build" the final object.
    
    - Use Cases for Builder Pattern
    The builder pattern is ideal in situations where:
        1. Objects Are Complex: The object has many components, properties, or optional fields.
        2. Object Creation Should Be Flexible: Different configurations or variations of the object are needed.
        3. Readable Code: It improves code readability by separating the logic for constructing objects into manageable steps.
        4. Immutability: Once constructed, the object should not change.
    
    
    ```csharp C# Code 
    
    
    // Product class
    public class Car
    {
        public string Engine { get; private set; }
        public int Wheels { get; private set; }
        public string Color { get; private set; }
        // Private constructor to ensure object creation happens through the builder
        private Car() { }
        // Nested Builder class
        public class Builder
        {
            private readonly Car _car;
            public Builder()
            {
                _car = new Car();
            }
            public Builder SetEngine(string engine)
            {
                _car.Engine = engine;
                return this;
            }
            public Builder SetWheels(int wheels)
            {
                _car.Wheels = wheels;
                return this;
            }
            public Builder SetColor(string color)
            {
                _car.Color = color;
                return this;
            }
            public Car Build()
            {
                // Validation before object creation
                //if (string.IsNullOrEmpty(_car.Engine))
                //    throw new InvalidOperationException("Engine cannot be null or empty.");
                //if (_car.Wheels <= 0)
                //    throw new InvalidOperationException("A car must have at least one wheel.");
                return _car;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Building a car step by step
                var car = new Car.Builder()
                            .SetEngine("V8")
                            .SetWheels(4)
                            .SetColor("Red")
                            .Build();
                Console.WriteLine($"Car Details: Engine={car.Engine}, Wheels={car.Wheels}, Color={car.Color}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    
    ```
    

    Key Best Practices in the Example
        a. Encapsulation:
            § The Car constructor is private to enforce object creation only through the Builder.
            § Prevents accidental instantiation without validation.
        b. Validation:
            § Validation is added in the Build() method to ensure the final object has valid properties.
        c. Fluent Interface:
            § The Builder methods return the builder itself, allowing chaining of method calls for readability.
        d. Immutability:
            § Once the object is built, its properties are read-only (private set).
    
    Where Is This Useful in Industry?
        1. Configuration Objects:
            ○ When creating configuration objects with optional and mandatory fields in applications.
            ○ Example: Building database connection settings or API client configurations (e.g., HttpClient).
        2. Report Generation:
            ○ Creating complex reports by adding sections, tables, and graphs step by step.
        3. Game Development:
            ○ Constructing game characters, levels, or assets where each part (e.g., weapons, health, skills) can be customized.
        4. Enterprise Applications:
            ○ Building domain-specific entities like orders, invoices, or workflows.
    
    

    Example 1: Building Database Connection Settings
    ```csharp
    // Class representing database connection settings
    public class DatabaseConnectionSettings
    {
        public string Server { get; private set; }
        public string Database { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public int Timeout { get; private set; }
        private DatabaseConnectionSettings() { }
        public class Builder
        {
            private readonly DatabaseConnectionSettings _settings;
            public Builder()
            {
                _settings = new DatabaseConnectionSettings();
            }
            public Builder SetServer(string server)
            {
                _settings.Server = server;
                return this;
            }
            public Builder SetDatabase(string database)
            {
                _settings.Database = database;
                return this;
            }
            public Builder SetUsername(string username)
            {
                _settings.Username = username;
                return this;
            }
            public Builder SetPassword(string password)
            {
                _settings.Password = password;
                return this;
            }
            public Builder SetTimeout(int timeout)
            {
                _settings.Timeout = timeout;
                return this;
            }
            public DatabaseConnectionSettings Build()
            {
                // Validate essential settings
                if (string.IsNullOrEmpty(_settings.Server))
                    throw new InvalidOperationException("Server cannot be null or empty.");
                if (string.IsNullOrEmpty(_settings.Database))
                    throw new InvalidOperationException("Database cannot be null or empty.");
                return _settings;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dbSettings = new DatabaseConnectionSettings.Builder()
                                .SetServer("localhost")
                                .SetDatabase("MyDatabase")
                                .SetUsername("admin")
                                .SetPassword("password123")
                                .SetTimeout(30)
                                .Build();
            Console.WriteLine($"Database: {dbSettings.Database}, Server: {dbSettings.Server}, Timeout: {dbSettings.Timeout}");
        }
    }
    
    Example 2: Configuring an API Client
    
    // API Client configuration class
    public class ApiClientConfig
    {
        public string BaseUrl { get; private set; }
        public string ApiKey { get; private set; }
        public int Timeout { get; private set; }
        public bool UseSsl { get; private set; }
        private ApiClientConfig() { }
        public class Builder
        {
            private readonly ApiClientConfig _config;
            public Builder()
            {
                _config = new ApiClientConfig();
            }
            public Builder SetBaseUrl(string baseUrl)
            {
                _config.BaseUrl = baseUrl;
                return this;
            }
            public Builder SetApiKey(string apiKey)
            {
                _config.ApiKey = apiKey;
                return this;
            }
            public Builder SetTimeout(int timeout)
            {
                _config.Timeout = timeout;
                return this;
            }
            public Builder EnableSsl(bool useSsl)
            {
                _config.UseSsl = useSsl;
                return this;
            }
            public ApiClientConfig Build()
            {
                // Validate essential settings
                if (string.IsNullOrEmpty(_config.BaseUrl))
                    throw new InvalidOperationException("BaseUrl cannot be null or empty.");
                if (string.IsNullOrEmpty(_config.ApiKey))
                    throw new InvalidOperationException("API Key cannot be null or empty.");
                return _config;
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var apiConfig = new ApiClientConfig.Builder()
                             .SetBaseUrl("https://api.example.com")
                             .SetApiKey("123456789")
                             .SetTimeout(60)
                             .EnableSsl(true)
                             .Build();
            Console.WriteLine($"API Client Config: BaseUrl={apiConfig.BaseUrl}, Timeout={apiConfig.Timeout}, SSL={apiConfig.UseSsl}");
        }
    }
    ```
    Key Best Practices in These Examples
        1. Validation: Ensure all mandatory fields are checked before the object is built.
        2. Fluent Interface: Each method in the builder returns the builder itself, enabling clean, readable code.
        3. Immutability: Once the object is created, its properties cannot be modified, making it thread-safe.
        4. Reusability: The builder pattern ensures the code is modular and easy to extend for future requirements.
