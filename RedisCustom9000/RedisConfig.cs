
using ServiceStack.Redis;
using System.Configuration;
using System.Linq;

namespace RedisCustom9000
{
    internal class RedisConfig
    {
        public static RedisClient Redis
        {
            get
            {
                return (RedisClient)reidsPools.GetClient();
            }
        }

        private static string[] hosts;
        private static PooledRedisClientManager reidsPools;

        static RedisConfig()
        {
            var servers = ConfigurationManager.AppSettings["RedisServer"].Split(',');
            hosts = servers.Select(c => c + ":" + ConfigurationManager.AppSettings["RedisServerPort"]).ToArray();

            reidsPools = new PooledRedisClientManager(hosts, hosts, new RedisClientManagerConfig
            {
                MaxWritePoolSize = 10,//“写”链接池链接数
                MaxReadPoolSize = 10,//“写”链接池链接数
                AutoStart = true,
                DefaultDb = 0
            });
        }
    }
}
