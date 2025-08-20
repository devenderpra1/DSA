using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Factory_and_Abstract
{
    public interface IDatabaseFactory
    {
        public IDbConnection GetDbConnector();

        public IExecuteCommand  GetExecutor();

        public string SaveCurrentQuery();
    }
    
    public interface IDbConnection
    {
        public void CreateDbConnection();

        void CloseConnection();
    }
    
    public interface IExecuteCommand
    {
        bool Execute();
    }
}



