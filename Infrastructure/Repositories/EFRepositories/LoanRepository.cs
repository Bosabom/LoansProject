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
    public class LoanRepository : BaseEfRepository<Loan>, ILoanRepository
    {
        public LoanRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<LoanFullData> GetFullDataAsync(int id)
        {
            LoanFullData loanFullData = await _appDbContext.FieldValues
                .Where(l => l.LoanId == id)
                .Include(y => y.Loan)
                .Include(z => z.Field)
                .ThenInclude(s => s.Section)
                .ThenInclude(t => t.LoanTemplate)
                .Select(fieldValue => new LoanFullData
                {
                    Id = fieldValue.LoanId,
                    LoanTemplateName = fieldValue.Loan.LoanTemplateName,
                    LoanTemplateId = fieldValue.Loan.LoanTemplateId,
                    Status = fieldValue.Loan.Status,
                    Sections = fieldValue.Loan.Template.Sections.Select(section => new SectionFullData
                    {
                        Id = section.Id,
                        Title = section.Title
                    }).ToList()
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            var fieldsList = await GetListOfFields(loanFullData.LoanTemplateId, id);

            for (int i = 0; i < loanFullData.Sections.Count; i++)
            {
                loanFullData.Sections[i].Fields = fieldsList[i];
            }

            return loanFullData;
        }

        public async Task<List<List<FieldFullDataDTO>>> GetListOfFields(int templateId, int loanId)
        {
            var fieldsList = await _appDbContext.Sections
                .Where(l => l.LoanTemplateId == templateId)
                .Include(z => z.Fields)
                .Select(section => section.Fields.SelectMany(field => field.FieldValues
                .Where(x => x.LoanId == loanId), (field, fieldValue) =>
                  new FieldFullDataDTO
                  {
                      Id = field.Id,
                      Key = field.Key,
                      Title = field.Title,
                      Value = fieldValue.Value,
                      FieldValueId = fieldValue.Id,
                      SectionId = section.Id,
                      Type = field.Type,
                      Validation = field.Validation,
                      OptionsUrl = field.OptionsUrl,
                      Options = field.Options,
                      Calculated = field.Calculated,
                      Readonly = field.Readonly

                  }).ToList()
                )
                .ToListAsync();
            return fieldsList;
        }

        public Loan MarkAsRemoved(Loan loan)
        {
            loan.IsRemoved = true;
            return loan;
        }
        public async Task<LoanSummaryResponse> GetFilteredLoansAsync(IEnumerable<LoanStatus> selectedStatuses,
            string searchString, string orderByColumn, int pageSize, SortOrder order, int pageIndex)
        {
            IQueryable<LoanSummaryDTO> loans = _appDbContext.Loans
                .Where(x => x.IsRemoved == false)
                .Select(x => new LoanSummaryDTO
                {
                    Id = x.Id,
                    LoanTemplateId = x.LoanTemplateId,
                    LoanTemplateName = x.LoanTemplateName,
                    RequestDate = x.CreationDate,
                    Status = x.Status
                });

            if (selectedStatuses != null && selectedStatuses.Any())
            {
                loans = loans.Where(x => selectedStatuses.Contains(x.Status));
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                loans = loans.Where(s => (s.LoanTemplateName.Contains(searchString)));
            }

            switch (order)
            {
                case SortOrder.Asc:
                    loans = loans.OrderBy(GetPropertySelector<LoanSummaryDTO>(orderByColumn));
                    break;
                case SortOrder.Desc:
                    loans = loans.OrderByDescending(GetPropertySelector<LoanSummaryDTO>(orderByColumn));
                    break;
            }

            int count = await loans.CountAsync();

            var filteredLoans = await PaginatedList<LoanSummaryDTO>.CreateAsync(loans, pageIndex, pageSize);
            var response = new LoanSummaryResponse
            {
                LoanSummaryDTOs = filteredLoans,
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
