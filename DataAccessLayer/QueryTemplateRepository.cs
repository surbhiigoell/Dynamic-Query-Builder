using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QueryBuilder.DbContexts;
using QueryBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueryBuilder.DataAccessLayer
{
    public class QueryTemplateRepository
    {
        private readonly AppDbContext _context;

        public QueryTemplateRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<TableRow> GetAllQueryTemplate()
        {
            try
            {
                // Ensure the connection is open
                _context.Database.OpenConnection();

                var conn = _context.Database.GetDbConnection();

                // Build the SQL query
                string sql = $"SELECT QueryTemplateId, Name, Query FROM QueryTemplate";

                // Execute the query and return the result
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    using (var reader = command.ExecuteReader())
                    {
                        List<TableRow> result = new List<TableRow>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var row = new TableRow();
                                row.Values = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row.Values[reader.GetName(i)] = Convert.ToString(reader[i]);
                                }
                                result.Add(row);
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

        public string GetQueryTemplate(int queryTemplateID)
        {
            try
            {
                // Ensure the connection is open
                _context.Database.OpenConnection();

                var conn = _context.Database.GetDbConnection();

                // Build the SQL query
                string sql = $"SELECT Query FROM QueryTemplate WHERE QueryTemplateID = {queryTemplateID}";

                // Execute the query and return the result
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    using (var reader = command.ExecuteReader())
                    {
                        string query = string.Empty;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                query = Convert.ToString(reader[0]);
                            }
                            
                        }
                        return query;
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


        public bool SaveQueryTemplate(string name, string query)
        {
            try
            {
                // Ensure the connection is open
                _context.Database.OpenConnection();

                var conn = _context.Database.GetDbConnection();

                string sql = "INSERT INTO QueryTemplate (Name, Query, DateCreated, DateModified) VALUES (@name, @query, @dateCreated, @dateModified)";

                // Execute the query with parameters
                _context.Database.ExecuteSqlRaw(sql,
                    new SqlParameter("@name", name),
                    new SqlParameter("@query", query),
                    new SqlParameter("@dateCreated", DateTime.UtcNow),
                    new SqlParameter("@dateModified", DateTime.UtcNow));

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

        public bool UpdateQueryTemplate(int queryTemplateID, string query)
        {
            try
            {
                // Ensure the connection is open
                _context.Database.OpenConnection();

                var conn = _context.Database.GetDbConnection();

                string sql = $"UPDATE QueryTemplate SET Query = @query, DateModified = @dateModified WHERE QueryTemplateId = @queryTemplateId";

                // Execute the query with parameters
                _context.Database.ExecuteSqlRaw(sql,
                    new SqlParameter("@query", query),
                    new SqlParameter("@dateModified", DateTime.UtcNow),
                    new SqlParameter("@queryTemplateId", queryTemplateID));

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

        public bool DeleteQueryTemplate(int id)
        {
            try
            {
                // Ensure the connection is open
                _context.Database.OpenConnection();

                // Build the parameterized SQL query
                string sql = "DELETE FROM QueryTemplate WHERE QueryTemplateID = @id";

                // Execute the parameterized query
                var rowsaffected = _context.Database.ExecuteSqlRaw(sql, new SqlParameter("@id", id));

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
    }
}
