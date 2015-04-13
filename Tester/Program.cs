using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFleet.Data;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new RouteRepository(new SmartFleetContext());
            var routes = repository.GetRoutes();

        }
    }
}
