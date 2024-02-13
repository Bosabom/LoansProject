using Core.Enums;
using Core.Interfaces.Core;
using Core.Models.LoanTemplate;
using LoansApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoansApi.Controllers
{
    public class LoanTemplateController : BaseApiController
    {
        private readonly ILoanTemplateService _loanTemplateService;
        public LoanTemplateController(ILoanTemplateService loanTemplateService)
        {
            _loanTemplateService = loanTemplateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredTemplatesAsync(
            string searchString, string orderByColumn = "Name", int pageSize = 10,
            SortOrder order = SortOrder.Desc, int pageIndex = 1)
        {
            LoanTemplateSummaryResponse templates = await _loanTemplateService.GetFilteredTemplatesAsync(
                searchString, orderByColumn, pageSize, order, pageIndex);

            return Ok(templates);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetFullTemplateByIdAsync(int id)
        {
            LoanTemplateDTO result = await _loanTemplateService.GetWithDetailsByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] LoanTemplateCreateDTO request)
        {
            LoanTemplateSummaryDTO result = await _loanTemplateService.CreateAsync(request);
            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteLoanTemplateDTO dTO)
        {
            await _loanTemplateService.MarkAsRemoved(dTO.Ids);
            return Ok();
        }
    }
}
