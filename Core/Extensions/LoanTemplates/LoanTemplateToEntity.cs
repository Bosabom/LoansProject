using Core.Entities;
using Core.Models.LoanTemplate;

namespace Core.Extensions.LoanTemplates
{
    public static class LoanTemplateToEntity
    {
        public static LoanTemplateSummaryDTO ToModel(this LoanTemplate loanTemplate)
        {
            var model = new LoanTemplateSummaryDTO
            {
                Id = loanTemplate.Id,
                CreationDate = loanTemplate.CreationDate,
                Name = loanTemplate.Name
            };
            return model;
        }
    }
}
