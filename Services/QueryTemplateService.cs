using QueryBuilder.DataAccessLayer;
using QueryBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueryBuilder.Services
{
    public class QueryTemplateService
    {
        private readonly QueryTemplateRepository _queryTemplateRepository;

        public QueryTemplateService(QueryTemplateRepository queryTemplateRepository)
        {
            _queryTemplateRepository = queryTemplateRepository;
        }
        public List<TableRow> GetAllTemplates()
        {
            return _queryTemplateRepository.GetAllQueryTemplate();
        }
        public string GetQueryTemplate(int queryTemplateId)
        {
            return _queryTemplateRepository.GetQueryTemplate(queryTemplateId);
        }
        public void SaveQueryTemplate(string name, string query)
        {
            _queryTemplateRepository.SaveQueryTemplate(name, query);
        }
        public void UpdateQueryTemplate(int queryTemplateId, string query)
        {
            _queryTemplateRepository.UpdateQueryTemplate(queryTemplateId, query);
        }
        public bool DeleteQueryTemplate(int id)
        {
            return _queryTemplateRepository.DeleteQueryTemplate(id);
        }
    }
}
