using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers;

internal class ErrorHandler : IErrorHandler
{
    public void HandleError(Exception ex)
    {
        throw ex switch
        {
            null => new ArgumentNullException(nameof(ex)),
            ArgumentException => ex,
            DbOperationException => ex,
            OperationCanceledException => ex,
            DbUpdateException => new DomainException("Exception in domain layer.", ex),
            _ => ex,
        };
    }
}
