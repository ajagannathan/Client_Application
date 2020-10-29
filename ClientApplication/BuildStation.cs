using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwissRanks.Orion.API;
namespace ClientApp
{
    public class BuildStation : StationModule
    {
        public string name { get; set; }
        public void test()
        {
            Console.WriteLine("This is test message from BS");
        }
    }
}
