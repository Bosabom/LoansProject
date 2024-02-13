using Core.Interfaces.Infrastructure;
using Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.EFRepositories
{
    public class RepositoryProvider: IRepositoryProvider
    {
        private readonly AppDbContext _appDbContext;
        private LoanRepository _loanRepository;
        private LoanTemplateRepository _loanTemplateRepository;
        private CarBrandRepository _carBrandRepository;
        private FieldValueRepository _fieldValueRepository;
        private FieldRepository _fieldRepository;

        public RepositoryProvider(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ILoanRepository Loans
        {
            get
            {
                if(_loanRepository == null)
                {
                    _loanRepository = new LoanRepository(_appDbContext);
                }
                return _loanRepository;
            }
        }

        public IFieldRepository Fields
        {
            get
            {
                if(_fieldRepository == null)
                {
                    _fieldRepository = new FieldRepository(_appDbContext);
                }
                return _fieldRepository;
            }
        }

        public ILoanTemplateRepository LoanTemplates
        {
            get
            {
                if(_loanTemplateRepository == null)
                {
                    _loanTemplateRepository = new LoanTemplateRepository(_appDbContext);
                }
                return _loanTemplateRepository;
            }
        }

        public ICarBrandRepository CarBrands
        {
            get
            {
                if(_carBrandRepository == null)
                {
                    _carBrandRepository = new CarBrandRepository(_appDbContext);
                }
                return _carBrandRepository;
            }
        }
        
        public IFieldValueRepository FieldValues
        {
            get
            {
                if(_fieldValueRepository==null)
                {
                    _fieldValueRepository = new FieldValueRepository(_appDbContext);
                }
                return _fieldValueRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _appDbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
