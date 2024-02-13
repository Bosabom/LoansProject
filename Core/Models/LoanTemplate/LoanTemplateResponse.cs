using Core.Models.Base;

namespace Core.Models.LoanTemplate
{
    public class LoanTemplateResponse : BaseDTO
    {
        public bool IsRemoved { get; set; }
        public string Name { get; set; }
    }
}
