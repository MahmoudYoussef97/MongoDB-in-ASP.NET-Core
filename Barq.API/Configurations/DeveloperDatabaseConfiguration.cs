using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barq.API.Configurations
{
    public class DeveloperMongoDBConfiguration
    {
        public string PackageCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
