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
    public class FieldRepository : BaseEfRepository<Field>, IFieldRepository
    {
        public FieldRepository(AppDbContext appDbContext) : base(appDbContext) { }
       
    }
}
