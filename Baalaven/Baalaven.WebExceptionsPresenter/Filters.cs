using Baalaven.Entities.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalaven.WebExceptionsPresenter
{
    public static class Filters
    {
        public static void Register(MvcOptions options)
        {
            options.Filters.Add(new ApiExceptionFilterAttribute(new Dictionary<Type, IExceptionHandler>
                {
                    {typeof(GeneralException), new GeneralExceptionHandler()},
                    {typeof(ValidationException), new ValidationExceptionHandler() }
                }
                ));
        }
    }
}
