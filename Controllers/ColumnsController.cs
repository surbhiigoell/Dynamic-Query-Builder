using Microsoft.AspNetCore.Mvc;
using QueryBuilder.Models;
using QueryBuilder.Services;
using System;
using System.Collections.Generic;

namespace QueryBuilder.Controllers
{
    public class ColumnsController : Controller
    {
        private readonly QueryService _queryService;

        public ColumnsController(QueryService queryService)
        {
            _queryService = queryService;
        }

        public IActionResult Index()
        {
            if (!_queryService.TemplateTableExist())
            {
                try
                {
                    _queryService.CreateTemplateTable();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex}");
                }
            }
            ViewData["tables"] = _queryService.GetAllTables();
            return View();
        }

        [HttpGet]
        [Route("api/columns/{tableName}")]
        public IActionResult GetColumns(string tableName)
        {
            var result = _queryService.GetColumns(tableName);
            return Ok(result);
        }

        [Route("api/data/{tableName}")]
        [HttpPost]
        public IActionResult GetTableData([FromBody] QueryElements request)
        {
            try
            {
                var query = _queryService.GenerateQuery(request.TableName, request.columns, request.conditions);
                var result = _queryService.ExecuteQuery(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("api/columns/{tableName}/datatype/{columnName}")]
        public IActionResult GetColumnDataType(string tableName, string columnName)
        {
            // Logic to get the data type of the column from the database
            var dataType = _queryService.GetColumnDataType(tableName, columnName);

            return Ok(dataType);
        }
    }
}
