using Core.Entities;
using System.Collections.Generic;

namespace Core.Models.LoanTemplate
{
    public class FieldValidationDTO
    {
        public IList<Validation> Validations { get; set; }
    }
}
