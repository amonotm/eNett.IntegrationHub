using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eNett.IntegrationHub.SharedInterfaces;

namespace eNett.IntegrationHub.UnitTest
{
    public class UnitTestLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Log(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}
