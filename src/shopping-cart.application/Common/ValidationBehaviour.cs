using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart.application.Common
{
    public class ValidationBehaviour<TRequests, TResponse> : IPipelineBehavior<TRequests, TResponse>
     where TRequests : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequests>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequests>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequests request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequests>(request);

                var validationResults = await Task.WhenAll(
                    _validators.Select(v =>
                        v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                    .Where(r => r.Errors.Any())
                    .SelectMany(r => r.Errors)
                    .ToList();

                if (failures.Any())
                    throw new ValidationException(failures);
            }
            return await next();
        }
    }
}
