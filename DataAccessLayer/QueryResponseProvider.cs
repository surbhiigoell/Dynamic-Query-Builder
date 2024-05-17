using Microsoft.EntityFrameworkCore;
using QueryBuilder.DbContexts;
using QueryBuilder.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QueryBuilder.DataAccessLayer
{
    public class QueryResponseProvider
    {
        private readonly AppDbContext _context;

        public QueryResponseProvider(AppDbContext context)
        {
            _context = context;
        }
        public List<List<string>> ExecuteQuery(string query)
        {
            try
            {
                // Ensure the connection is open
                _context.Database.OpenConnection();

                var conn = _context.Database.GetDbConnection();

                // Execute the query and return the result
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader())
                    {
                        List<List<string>> result = new List<List<string>>();
                        if (reader.Read())
                        {
                            do
                            {
                                List<string> row = new List<string>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row.Add(reader.GetValue(i).ToString());
                                }
                                result.Add(row);
                            } while (reader.Read());
                        }
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                // Close the connection after use
                _context.Database.CloseConnection();
            }
        }

        public List<string> GetAllColumns(string tableName)
        {
            try
            {
                _context.Database.OpenConnection(); // Ensure the connection is open

                var columns = _context.Database.GetDbConnection().GetSchema("Columns", new[] { null, null, tableName })
                    .AsEnumerable()
                    .Select(row => row.Field<string>("COLUMN_NAME"))
                    .OrderBy(col=>col)
                    .ToList();

                return columns;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _context.Database.CloseConnection(); // Close the connection after use
            }
        }

        public List<string> GetAllTables()
        {
            try
            {
                // Ensure the connection is open
                _context.Database.OpenConnection();

                var conn = _context.Database.GetDbConnection();

                // Build the SQL query
                string sql = @"SELECT name
FROM sys.tables 
ORDER BY
  CASE 
    WHEN name LIKE '[a-zA-Z]%' THEN 0 -- Alphabets first
    WHEN name LIKE '[0-9]%' THEN 1 -- Numbers next
    ELSE 2 -- Special characters last
  END,
  name";

                // Execute the query and return the result
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    using (var reader = command.ExecuteReader())
                    {
                        List<string> result = new List<string>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                result.Add(Convert.ToString(reader[0]));
                            }
                        }
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                // Close the connection after use
                _context.Database.CloseConnection();
            }
        }

        public bool TemplateTableExist()
        {
            string sql = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'QueryTemplate'";
            try
            {
                _context.Database.OpenConnection();
                var conn = _context.Database.GetDbConnection();
                bool exists = false;
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            exists = true;
                        }
                    }
                }
                return exists;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                // Close the connection after use
                _context.Database.CloseConnection();
            }
        }
        public bool CreateTemplateTable()
        {
            try
            {
                // Ensure the connection is open
                _context.Database.OpenConnection();
                var conn = _context.Database.GetDbConnection();
                string sql = @"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'QueryTemplate')
                    BEGIN
                    CREATE TABLE QueryTemplate (
                        QueryTemplateId INT IDENTITY PRIMARY KEY,
	                    Name VARCHAR(50) NOT NULL,
                        Query VARCHAR(8000) NOT NULL,
	                    DateCreated DateTime,
	                    DateModified DateTime
                    );
                    END";
                // Execute the query with parameters
                _context.Database.ExecuteSqlRaw(sql);
                // Return a success response
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                // Close the connection after use
                _context.Database.CloseConnection();
            }
        }

        public string GetDataType(string tableName, string columnName)
        {
            try
            {
                _context.Database.OpenConnection(); // Ensure the connection is open

                var dataType = _context.Database.GetDbConnection().GetSchema("Columns", new[] { null, null, tableName })
                    .AsEnumerable()
                    .Where(row => string.Equals(row.Field<string>("COLUMN_NAME"), columnName, StringComparison.OrdinalIgnoreCase))
                    .Select(row => row.Field<string>("DATA_TYPE"))
                    .FirstOrDefault(); // Get the first matching column's data type

                return dataType;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _context.Database.CloseConnection(); // Close the connection after use
            }
        }
    }
}
