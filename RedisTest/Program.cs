using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisHelper.Set<String>("aa", DateTime.Now.ToString());
            var str = RedisHelper.Get<string>("aa");
           
        }
    }
}
