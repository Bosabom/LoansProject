using Core.CustomException;
using Core.Enums;
using Core.Interfaces.Infrastructure;
using Core.Models.LoanModels;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace LoansApi.Validation
{
    //public class FieldValueValidatorFV : AbstractValidator<FieldValueDTO>
    //{
    //    public FieldValueValidatorFV(FieldValueDTO valueDTO, IFieldValueRepository fieldValueRepository)
    //    {
    //        var validators = fieldValueRepository.GetFieldValidationAsync(valueDTO.FieldId).Result;
    //        if (validators is null)
    //        {
    //            throw new FieldValueNotFoundException(valueDTO.Id);
    //        }

    //        foreach (var rule in validators)
    //        {

    //            switch (rule.Type)
    //            {
    //                case ValidationType.Required:
    //                    RuleFor(x => x.Value).NotNull()
    //                        .WithMessage($"{valueDTO.Key} shouldn't be empty");
    //                    break;

    //                case ValidationType.Min:
    //                    RuleFor(x => x.Value).GreaterThanOrEqualTo((rule.Value).ToString())
    //                    .WithMessage($"{valueDTO.Key} must be greater or equal than {rule.Value}");
    //                    break;

    //                case ValidationType.Max:
    //                    RuleFor(x => Int32.Parse(x.Value)).LessThan(rule.Value)
    //                        .WithMessage($"{valueDTO.Key} must be less or equal {rule.Value}");
    //                    break;

    //                case ValidationType.Maxlength:
    //                    RuleFor(x => x.Value).MaximumLength(rule.Value)
    //                    .WithMessage($"{valueDTO.Key} must be less than or equal to {rule.Value} characters.");
    //                    break;

    //                case ValidationType.Condition:
    //                    if (rule.Condition.Operation == OperationType.MoreThanOrEquals)
    //                    {
    //                        RuleFor(x => Int32.Parse(x.Value)).Must(value => valueDTO.Income >= valueDTO.Payment)
    //                            .WithMessage($"{rule.Message}");
    //                    }
    //                    break;
    //            }
    //        }
    //        RuleFor(x => x.Id).NotEmpty();
    //    }
    //}
}
