using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Factory_and_Abstract
{
    public class SQLServerFactory : IDatabaseFactory
    {
        public IDbConnection GetDbConnector()
        {
            return new SQLServerDBConnector();
        }

        public string SaveCurrentQuery()
        {
            return "Query Saved";
        }

        IExecuteCommand IDatabaseFactory.GetExecutor()
        {
            return new SQlExecutor();
        }

    }

    public class SQLServerDBConnector : IDbConnection
    {

        public void CreateDbConnection()
        {
            Console.WriteLine("Connection Established with SQLServer");
        }
        public void CloseConnection()
        {
            Console.WriteLine("Connection Closed with SQLServer");
        }
    }

    public class SQlExecutor : IExecuteCommand
    {
        public bool Execute()
        {
            Console.WriteLine("Execution with MySQLServer");
            return true;
        }
    }
}
