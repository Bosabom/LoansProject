using Core.CustomException;
using Core.Entities;
using Core.Enums;
using Core.Extensions.LoanTemplates;
using Core.Interfaces.Core;
using Core.Interfaces.Infrastructure;
using Core.Models.LoanTemplate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class LoanTemplateService : ILoanTemplateService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        public LoanTemplateService(IRepositoryProvider repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;
        }

        public IList<LoanTemplateSummaryDTO> GetAllAsync()
        {
            return _repositoryProvider.LoanTemplates.GetAllAsync()
                .Where(x=>x.IsRemoved ==false)
                .Select(x => new LoanTemplateSummaryDTO
                {
                    Id = x.Id,
                    CreationDate = x.CreationDate,
                    Name = x.Name
                }).ToList(); 
        }

        public async Task<LoanTemplateDTO> GetWithDetailsByIdAsync(int id)
        {
            LoanTemplate loanTemplate = await _repositoryProvider.LoanTemplates.GetWithDetailsByIdAsync(id);
            if(loanTemplate is null)
            {
                throw new LoanTemplateNotFoundException(id);
            }
            return loanTemplate.ToDTO();
        }
        public async Task<LoanTemplateSummaryDTO> CreateAsync(LoanTemplateCreateDTO createDTO)
        {
            LoanTemplate loanTemplate = createDTO.ToEntity();
            await _repositoryProvider.LoanTemplates.CreateAsync(loanTemplate);
            await _repositoryProvider.SaveAsync();
            
            return loanTemplate.ToModel();
        }

        public async Task MarkAsRemoved(IEnumerable<int> selectedIds)
        {
            foreach(int id in selectedIds)
            {
                LoanTemplate loanTemplate = await _repositoryProvider.LoanTemplates.GetByIdAsync(id);
                if (loanTemplate is null)
                {
                    throw new LoanTemplateNotFoundException(id);
                }
                _repositoryProvider.LoanTemplates.MarkAsRemoved(loanTemplate);
            }

            await _repositoryProvider.SaveAsync();
        }

        public async Task<LoanTemplateSummaryResponse> GetFilteredTemplatesAsync(
            string searchString, string orderByColumn, int pageSize, SortOrder order, int pageIndex)
        {
            var templates = await _repositoryProvider.LoanTemplates.GetFilteredTemplatesAsync(searchString, orderByColumn, pageSize, order, pageIndex);
            return templates;
        }
    }
}
