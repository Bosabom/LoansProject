using System;
using System.Threading.Tasks;

namespace Core.Interfaces.Infrastructure
{
    public interface IRepositoryProvider: IDisposable
    {
        ILoanRepository Loans { get; }
        ILoanTemplateRepository LoanTemplates { get; }
        ICarBrandRepository CarBrands { get; }
        IFieldValueRepository FieldValues { get; }
        IFieldRepository Fields { get; }
        Task SaveAsync();
    }
}
