using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Factory_and_Abstract
{
    public class MySQlServerFactory : IDatabaseFactory
    {
        public IDbConnection GetDbConnector()
        {
            throw new NotImplementedException();
        }

        public IExecuteCommand GetExecutor()
        {
            throw new NotImplementedException();
        }

        public string SaveCurrentQuery()
        {
            throw new NotImplementedException();
        }
    }

    public class MySqlServerConnector : IDbConnection
    {
        public void CloseConnection()
        {
            throw new NotImplementedException();
        }

        public void CreateDbConnection()
        {
            throw new NotImplementedException();
        }
    }

    public class MySqlServerExecutor : IExecuteCommand
    {
        public bool Execute()
        {
            throw new NotImplementedException();
        }
    }
}
