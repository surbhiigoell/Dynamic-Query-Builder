using Microsoft.AspNetCore.Mvc;
using QueryBuilder.Models;
using QueryBuilder.Services;
using System;
using System.Collections.Generic;

namespace QueryBuilder.Controllers
{
    public class QueryTemplateController : Controller
    {
        private readonly QueryTemplateService _queryTemplateService;
        private readonly QueryService _queryService;

        public QueryTemplateController(QueryTemplateService queryTemplateService, QueryService queryService)
        {
            _queryTemplateService = queryTemplateService;
            _queryService = queryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("querytemplate/api/querytemplate/getalltemplate/{templateId}")]
        public IActionResult GetAllQueryTemplate()
        {
            try
            {
            var result = _queryTemplateService.GetAllTemplates();
            return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        [Route("querytemplate/api/querytemplate/gettemplate/{templateId}")]
        public IActionResult GetQueryTemplate(int templateID)
        {
            try
            {
                var query = _queryTemplateService.GetQueryTemplate(templateID);
                var result = _queryService.ExecuteQuery(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost]
        [Route("querytemplate/api/querytemplate/savetemplate/{templateId}")]
        public IActionResult SaveQueryTemplate([FromBody] QueryElements request)
        {
            string query = _queryService.GenerateQuery(request.TableName, request.columns, request.conditions);
            try
            {
                _queryTemplateService.SaveQueryTemplate(request.templateName, query);
                return Ok("Query template saved successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpDelete]
        [Route("querytemplate/api/querytemplate/deletetemplate")]
        public IActionResult DeleteQueryTemplate(int id)
        {
            try
            {
                bool deleted = _queryTemplateService.DeleteQueryTemplate(id);
                if (deleted)
                    return Ok("Query template saved successfully.");
                else
                    return StatusCode(500, $"Internal server error: Error Occured");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPut]
        [Route("api/querytemplate/updatetemplate/{templateId}")]
        public IActionResult UpdateQueryTemplate(int queryTemplateID, [FromBody] QueryElements request)
        {
            string query = _queryService.GenerateQuery(request.TableName, request.columns, request.conditions);
            try
            {
                _queryTemplateService.UpdateQueryTemplate(queryTemplateID, query);
                return Ok("Query template updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost]
        [Route("querytemplate/api/querytemplate/getheader")]
        public IActionResult GetHeader([FromBody] string query)
        {
            try
            {
                var columns = _queryService.GetColumnsFromQuery(query);
                var result = new {columns = columns};
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
