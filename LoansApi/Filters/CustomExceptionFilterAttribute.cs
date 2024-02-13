using Core.CustomException;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace LoansApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case NotFoundException notFoundEx:
                    context.Result = new JsonResult(new { notFoundEx.Message })
                    {
                        StatusCode = (int)HttpStatusCode.NotFound
                    };
                    context.ExceptionHandled = true;
                    break;
                case InvalidOperationException operationException:
                    context.Result = new JsonResult(new { operationException.Message })
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    };
                    context.ExceptionHandled = true;
                    break;
                case ValidationException vex:
                    context.Result = new JsonResult(new ValidationResult(vex.Errors))
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                    context.ExceptionHandled = true;
                    break;
                case BadRequest badRequest:
                    context.Result = new JsonResult(new { badRequest.Message })
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                    context.ExceptionHandled = true;
                    break;
                default:
                    context.Result = new JsonResult(new { Message = "Server Error" })
                    {
                        StatusCode = (int)HttpStatusCode.InternalServerError
                    };
                    context.ExceptionHandled = true;
                    break;
            }
        }
    }
}
