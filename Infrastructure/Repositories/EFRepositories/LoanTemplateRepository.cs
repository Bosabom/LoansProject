using Core.Entities;
using Core.Enums;
using Core.Interfaces.Infrastructure;
using Core.Models.LoanModels;
using Core.Models.LoanTemplate;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.EFRepositories
{
    public class LoanTemplateRepository : BaseEfRepository<LoanTemplate>, ILoanTemplateRepository
    {
        public LoanTemplateRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<List<int>> GetFieldIdListAsync(int loanTemplateId)
        {
            List<int> fieldIds = await _appDbContext.Fields
                .Where(x => x.Section.LoanTemplateId == loanTemplateId)
                .Select(f => f.Id)
                .ToListAsync();

            return fieldIds;
        }

        public async Task<LoanTemplate> GetWithDetailsByIdAsync(int id)
        {
            LoanTemplate template = await _appDbContext.Set<LoanTemplate>()
                .Include(x => x.Sections)
                .ThenInclude(x => x.Fields)
                .FirstOrDefaultAsync(x => x.Id == id);
            return template;
        }

        public LoanTemplate MarkAsRemoved(LoanTemplate template)
        {
            template.IsRemoved = true;
            return template;
        }

        public async Task<LoanTemplateSummaryResponse> GetFilteredTemplatesAsync(string searchString,
            string orderByColumn, int pageSize, SortOrder order, int pageIndex)
        {

            IQueryable<LoanTemplateSummaryDTO> templates = _appDbContext.LoanTemplates
                .Where(x => x.IsRemoved == false)
                .Select(x => new LoanTemplateSummaryDTO
                {
                    Id = x.Id,
                    CreationDate = x.CreationDate,
                    Name = x.Name
                });

            if (!string.IsNullOrEmpty(searchString))
            {
                templates = templates.Where(s => (s.Name.Contains(searchString)));

            }

            switch (order)
            {
                case SortOrder.Asc:
                    templates = templates.OrderBy(GetPropertySelector<LoanTemplateSummaryDTO>(orderByColumn));
                    break;
                case SortOrder.Desc:
                    templates = templates.OrderByDescending(GetPropertySelector<LoanTemplateSummaryDTO>(orderByColumn));
                    break;
            }

            int count = await templates.CountAsync();

            var filteredTemplates = await PaginatedList<LoanTemplateSummaryDTO>.CreateAsync(templates, pageIndex, pageSize);
            var response = new LoanTemplateSummaryResponse
            {
                TemplateSummaryDTOs = filteredTemplates,
                TotalCount = count
            };
            return response;
        }

        public static Expression<Func<T, object>> GetPropertySelector<T>(string propertyName)
        {
            var arg = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(arg, propertyName);
            var conv = Expression.Convert(property, typeof(object));
            var exp = Expression.Lambda<Func<T, object>>(conv, new ParameterExpression[] { arg });
            return exp;
        }
    }
}
