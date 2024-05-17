using Microsoft.Data.SqlClient;
using QueryBuilder.DataAccessLayer;
using QueryBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryBuilder.Services
{
    public class QueryService
    {
        private readonly QueryResponseProvider _queryResponseProvider;

        public QueryService(QueryResponseProvider queryResponseProvider)
        {
            _queryResponseProvider = queryResponseProvider;
        }

        public string GenerateQuery(string tableName, List<string> columns, List<Conditions>? conditions)
        {
            if (columns.Count == 0)
            {
                columns = GetColumns(tableName);
            }

            string columnBuilder = string.Join(", ", columns.Select(c => $"{c}"));
            StringBuilder conditionBuilder = new StringBuilder();
            if (conditions?.Count > 0)
            {
                conditionBuilder.Append(" WHERE");
                foreach (var c in conditions)
                {
                    string dataType = _queryResponseProvider.GetDataType(tableName, c.column);
                    if (dataType == "nvarchar" || dataType == "varchar" || dataType == "date" || dataType == "datetime")
                    {
                        c.data = "'" + c.data.ToString() + "'";
                    }

                    conditionBuilder.Append($" {c.column} {c.operation} {c.data}");

                    if (c.logicalOperator != "NONE")
                    {
                        conditionBuilder.Append($" {c.logicalOperator}");
                    }
                }
            }

            // Build the SQL query
            string sql = $"SELECT {columnBuilder} FROM {tableName}" + (conditionBuilder);
            return sql;
        }

        public List<List<string>> ExecuteQuery(string query)
        {
            return _queryResponseProvider.ExecuteQuery(query);
        }

        public List<string> GetColumns(string tableName)
        {
            var columns = _queryResponseProvider.GetAllColumns(tableName);
            columns.RemoveAll(s => string.Equals(s, "ObjectID", StringComparison.OrdinalIgnoreCase));
            return columns;
        }

        public string GetColumnsFromQuery(string query)
        {
            string word1 = "SELECT";
            string word2 = "FROM";
            int startIndex = query.IndexOf(word1);
            int endIndex = query.IndexOf(word2, startIndex + word1.Length);

            string columns = string.Empty;
            if (startIndex != -1 && endIndex != -1)
            {
                columns = query.Substring(startIndex + word1.Length, endIndex - (startIndex + word1.Length)).Trim();
            }
            if (columns == "*")
            {
                return columns;
            }
            else
            {
                return columns;
            }
        }

        public string GetColumnDataType(string tableName, string columnName)
        {
            return _queryResponseProvider.GetDataType(tableName, columnName);
        }

        public List<string> GetAllTables()
        {
            return _queryResponseProvider.GetAllTables();
        }
        public bool TemplateTableExist()
        {
            return _queryResponseProvider.TemplateTableExist();
        }
        public bool CreateTemplateTable()
        {
            return _queryResponseProvider.CreateTemplateTable();
        }
    }
}
