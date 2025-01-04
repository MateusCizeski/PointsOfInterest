using Domain.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace PointsOfInterest.Middlewares
{
    internal sealed class InvalidDataExceptionHandler
    {
        private readonly ILogger<InvalidDataExceptionHandler> _logger;

        public InvalidDataExceptionHandler(ILogger<InvalidDataExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHanldeAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not NotValidDataException notValidDataException) return false;

            _logger.LogError($"Exception occurred: {exception.Message}");

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "The proveided data is not valid.",
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
