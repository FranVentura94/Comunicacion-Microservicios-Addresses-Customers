using System.Reflection;
using Common.Attributes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Common.Behaviours
{
    public class AuditBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<AuditBehavior<TRequest, TResponse>> _logger;

        public AuditBehavior(ILogger<AuditBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();

            if (typeof(TRequest).GetCustomAttribute<AuditLogAttribute>() != null)
                _logger.LogInformation("AUDIT -> {Request} ejecutado", typeof(TRequest).Name);

            return response;
        }
    }
}