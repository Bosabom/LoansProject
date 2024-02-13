using Core.CustomException;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.Core;
using Core.Interfaces.Infrastructure;
using Core.Models.LoanModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Services
{
    public class LoanService : ILoanService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IFieldValueService _fieldValueService;
        public LoanService(
            IRepositoryProvider repositoryProvider,
            IFieldValueService fieldValueService
            )
        {
            _repositoryProvider = repositoryProvider;
            _fieldValueService = fieldValueService;
        }

        public async Task<int> CreateAsync(LoanCreateRequest request)
        {
            LoanTemplate loanTemplate = await _repositoryProvider.LoanTemplates.GetByIdAsync(request.LoanTemplateId);
            if (loanTemplate is null)
            {
                throw new LoanTemplateNotFoundException(request.LoanTemplateId);
            }

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var loan = new Loan
                    {
                        CreationDate = DateTime.Now,
                        LoanTemplateId = request.LoanTemplateId,
                        Status = LoanStatus.InProcess,
                        LoanTemplateName = request.LoanTemplateName
                    };

                    await _repositoryProvider.Loans.CreateAsync(loan);
                    await _repositoryProvider.SaveAsync();

                    await _fieldValueService.GenerateFieldValue(loanTemplate.Id, loan.Id);
                    scope.Complete();
                    return loan.Id;
                }
                catch
                {
                    throw new LoanInvalidOperationException("Error in Loan.CreateAsync()");
                }
            }
        }

        public async Task ApplyAsync(int loanId)
        {
            Loan loan = await _repositoryProvider.Loans.GetByIdAsync(loanId);
            if (loan is null)
            {
                throw new LoanNotFoundException(loanId);
            }

            if (loan.Status != LoanStatus.InProcess)
            {
                throw new LoanInvalidOperationException(loan.Status);
            }

            loan.Status = LoanStatus.Applied;
            await _repositoryProvider.SaveAsync();
        }

        public List<LoanSummaryDTO> GetAllAsync()
        {
            return _repositoryProvider.Loans.GetAllAsync()
                .Where(x => x.IsRemoved == false)
                .Select(x => new LoanSummaryDTO
                {
                    Id = x.Id,
                    LoanTemplateName = x.LoanTemplateName,
                    LoanTemplateId = x.LoanTemplateId,
                    RequestDate = x.CreationDate,
                    Status = x.Status

                }).ToList();
        }

        public async Task MarkAsRemovedAsync(IEnumerable<int> ids)
        {
            foreach (int id in ids)
            {
                Loan loan = await _repositoryProvider.Loans.GetByIdAsync(id);
                if (loan is null)
                {
                    throw new LoanNotFoundException(id);
                }
                _repositoryProvider.Loans.MarkAsRemoved(loan);
            }
            await _repositoryProvider.SaveAsync();
        }

        public async Task<LoanFullData> GetFullDataAsync(int id)
        {
            LoanFullData fullLoan = await _repositoryProvider.Loans.GetFullDataAsync(id);
            if (fullLoan is null)
            {
                throw new LoanNotFoundException(id);
            }

            return fullLoan;
        }

        public async Task<LoanSummaryResponse> GetFilteredLoansAsync(IEnumerable<LoanStatus> selectedStatuses,
            string searchString, string orderByColumn, int pageSize, SortOrder order, int pageIndex)
        {
            var loans = await _repositoryProvider.Loans.GetFilteredLoansAsync(selectedStatuses,
                searchString, orderByColumn, pageSize, order, pageIndex);

            return loans;
        }
    }
}
