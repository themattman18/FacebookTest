using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacebookTest
{
    public class SqlSettings
    {
        public SqlSettings(IConfiguration config)
        {
            ConnectionString = config["ConnectionString"];
        }
        public string ConnectionString { get; set; }
    }
}
