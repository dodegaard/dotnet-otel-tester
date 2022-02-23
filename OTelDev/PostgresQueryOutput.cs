using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTelDev
{
    public class PostgresQueryOutput
    {
        public string table_name { get; set; }

        public string table_schema { get; set; }

        public string table_catalog { get; set; }
    }
}
