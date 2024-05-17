using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    public class TableRow
    {
        public TableRow()
        {
        }
        public Dictionary<string, object> Values { get; internal set; }
    }
}
