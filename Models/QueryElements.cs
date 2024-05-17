using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    public class QueryElements
    {
        public string TableName { get; set; }
        public List<string> columns { get; set; }
        public List<Conditions>? conditions { get; set; }
        public string? templateName { get; set; }
    }
    public class Conditions
    {
        public string column { get; set; }
        public string operation { get; set; }
        public string data { get; set; }
        public string logicalOperator { get; set; }
    }
}
