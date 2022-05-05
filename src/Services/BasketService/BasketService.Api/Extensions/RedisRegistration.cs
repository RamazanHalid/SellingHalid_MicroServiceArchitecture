using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketService.Api.Extensions.Registration
{
    public static class RedisRegistration
    {
        public static ConnectionMultiplexer ConfigureRedis(this IServiceProvider services, IConfiguration configuration)
        {
            var a = configuration["RedisSettings:ConnectionString"];
            var redisConf = ConfigurationOptions.Parse(a, true);
            redisConf.ResolveDns = true;
            return ConnectionMultiplexer.Connect(redisConf);
        }
    }
}
