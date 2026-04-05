using System;

class ConfigurationManager
{
    private static ConfigurationManager instance;

    public string ApplicationName { get; set; }
    public string Version { get; set; }
    public string DatabaseConnectionString { get; set; }

    // Private constructor prevents object creation using new
    private ConfigurationManager()
    {
        ApplicationName = "Inventory Management System";
        Version = "1.0";
        DatabaseConnectionString = "Server=localhost;Database=InventoryDB;";
    }

    public static ConfigurationManager GetInstance()
    {
        if (instance == null)
        {
            instance = new ConfigurationManager();
        }

        return instance;
    }
}

class Program
{
    static void Main()
    {
        var config1 = ConfigurationManager.GetInstance();
        var config2 = ConfigurationManager.GetInstance();

        Console.WriteLine("Application Name: " + config1.ApplicationName);
        Console.WriteLine("Version: " + config1.Version);
        Console.WriteLine("Database: " + config1.DatabaseConnectionString);

        Console.WriteLine("\nChecking Singleton Instance:");
        Console.WriteLine(object.ReferenceEquals(config1, config2));
    }
}