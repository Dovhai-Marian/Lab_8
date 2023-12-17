using System;

class ConfigurationManager
{
    private static ConfigurationManager instance;
    private string loggingMode;
    private string databaseConnection;

    private ConfigurationManager()
    {
        loggingMode = "Debug";
        databaseConnection = "DefaultConnection";
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }

    public string LoggingMode
    {
        get { return loggingMode; }
        set
        {
            loggingMode = value;
            Console.WriteLine("Logging mode updated: " + loggingMode);
        }
    }

    public string DatabaseConnection
    {
        get { return databaseConnection; }
        set
        {
            databaseConnection = value;
            Console.WriteLine("Database connection updated: " + databaseConnection);
        }
    }
}

class Program
{
    static void Main()
    {
        ConfigurationManager configManager = ConfigurationManager.Instance;

        Console.WriteLine("Initial Configuration:");
        Console.WriteLine($"Logging Mode: {configManager.LoggingMode}");
        Console.WriteLine($"Database Connection: {configManager.DatabaseConnection}");

        Console.WriteLine("\nChange Configuration:");
        Console.Write("Enter new Logging Mode: ");
        configManager.LoggingMode = Console.ReadLine();

        Console.Write("Enter new Database Connection: ");
        configManager.DatabaseConnection = Console.ReadLine();

        Console.WriteLine("\nUpdated Configuration:");
        Console.WriteLine($"Logging Mode: {configManager.LoggingMode}");
        Console.WriteLine($"Database Connection: {configManager.DatabaseConnection}");

        Console.ReadLine();
    }
}
