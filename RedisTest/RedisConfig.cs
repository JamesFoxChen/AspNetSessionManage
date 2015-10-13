
using ServiceStack.Redis;
using System.Configuration;
using System.Linq;

namespace RedisTest
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


        //public static RedisClient RedisDB6
        //{
        //    get
        //    {
        //        return (RedisClient)redisPools6.GetClient();
        //    }
        //}

        private static string[] hosts;
        private static PooledRedisClientManager reidsPools;
        //private static PooledRedisClientManager reidsPools4;
        //private static PooledRedisClientManager redisPools6;

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

            //reidsPools4 = new PooledRedisClientManager(hosts, hosts, new RedisClientManagerConfig
            //{
            //    MaxWritePoolSize = 10,//“写”链接池链接数
            //    MaxReadPoolSize = 10,//“写”链接池链接数
            //    AutoStart = true,
            //    DefaultDb = 4
            //});

            //redisPools6 = new PooledRedisClientManager(hosts, hosts, new RedisClientManagerConfig
            //{
            //    MaxWritePoolSize = 10,//“写”链接池链接数
            //    MaxReadPoolSize = 10,//“写”链接池链接数
            //    AutoStart = true,
            //    DefaultDb = 6
            //});
        }
    }
}
