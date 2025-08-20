// See https://aka.ms/new-console-template for more information
using Design_Pattern_Factory_and_Abstract;

Console.WriteLine("Hello, World!");

IDatabaseFactory dbServerFactory = new SQLServerFactory();
dbServerFactory.GetDbConnector().CreateDbConnection();

IDatabaseFactory dbFactoryCreator = new DBFactoryCreator().CreateFactory("SQLServer");
dbServerFactory.GetDbConnector().CreateDbConnection();





