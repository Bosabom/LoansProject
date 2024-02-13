using System.Threading.Tasks;
using Core.Interfaces.Core;
using Core.Interfaces.Infrastructure;
using Core.Models.LoanModels;
using LoansApi.Controllers.Base;
using LoansApi.Validation;
using Microsoft.AspNetCore.Mvc;

namespace LoansApi.Controllers
{
    public class FieldValueController : BaseApiController
    {
        private readonly IFieldValueService _fieldValueService;
        public FieldValueController(IFieldValueService fieldValueService)
        {
            _fieldValueService = fieldValueService;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFieldValue([FromBody] FieldValueDTO fieldValueDTO)
        {
            FieldValueUpdateresponse response = await _fieldValueService.UpdateFieldValueAsync(fieldValueDTO);
            return Ok(response);
        }

        //Test Method
        [HttpGet]
        public async Task<IActionResult> GetValueBykey([FromBody] ValueDTO valueDTO)
        {
            var value = await _fieldValueService.GetValueFromLoanByKey(valueDTO.Key, valueDTO.LoanId);
            return Ok(value);
        }
    }
}
