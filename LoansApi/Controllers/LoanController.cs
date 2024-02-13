using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.Core;
using Core.Models.LoanModels;
using LoansApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace LoansApi.Controllers
{
    public class LoanController : BaseApiController
    {
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredLoansAsync(
            [FromQuery(Name = "statuses")] LoanStatus [] statuses,
            string searchString, string orderByColumn = "RequestDate", int pageSize = 10,
            SortOrder order = SortOrder.Desc, int pageIndex = 1)
        {
            LoanSummaryResponse response = await _loanService.GetFilteredLoansAsync(statuses,
                searchString, orderByColumn, pageSize, order, pageIndex);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] LoanCreateRequest request)
        {
            int loanId = await _loanService.CreateAsync(request);
            return Ok(loanId);
        }

        [HttpPut]
        public async Task<IActionResult> ApplyAsync(int id)
        {
            await _loanService.ApplyAsync(id);
            return Ok();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteLoanDTO dTO)
        {
            await _loanService.MarkAsRemovedAsync(dTO.Ids);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFullDataAsync(int id)
        {
            LoanFullData loan = await _loanService.GetFullDataAsync(id);
            return Ok(loan);
        }
    }
}
