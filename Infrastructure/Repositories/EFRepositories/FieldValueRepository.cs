using Core.Entities;
using Core.Interfaces.Infrastructure;
using Core.Models.LoanModels;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.EFRepositories
{
    public class FieldValueRepository : BaseEfRepository<FieldValue>, IFieldValueRepository
    {
        public FieldValueRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<FieldValue> GetFieldValueFromLoanByKey(string key, int loanId)
        {
            FieldValue fieldValue = await _appDbContext.FieldValues
                .Where(x => x.LoanId == loanId)
                .Include(x => x.Field)
                .FirstOrDefaultAsync(x => x.Field.Key == key);

            return fieldValue;
        }

        public async Task<FieldFullDataDTO> GetFieldFullData(int fieldId, int loanId)
        {
            FieldFullDataDTO fieldFullDataDTO = await _appDbContext.FieldValues
                .Where(x => x.LoanId == loanId)
                .Include(x => x.Field)
                .Select(fieldValue => new FieldFullDataDTO
                {
                    Id = fieldValue.Id,
                    Key = fieldValue.Field.Key,
                    Title = fieldValue.Field.Title,
                    Value = fieldValue.Value,
                    FieldValueId = fieldValue.Id,
                    Type = fieldValue.Field.Type,
                    OptionsUrl = fieldValue.Field.OptionsUrl,
                    Validation = fieldValue.Field.Validation,
                    Options = fieldValue.Field.Options,
                    Calculated = fieldValue.Field.Calculated,
                    Readonly = fieldValue.Field.Readonly
                })
                .FirstOrDefaultAsync(x => x.Id == fieldId);

            return fieldFullDataDTO;
        }
    }
}
