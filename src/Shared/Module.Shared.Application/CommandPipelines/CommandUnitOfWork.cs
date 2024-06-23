using MediatR;
using Module.Shared.Application.Intefaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Shared.Application.CommandPipelines
{
    public class CommandUnitOfWork<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public IEnumerable<IUnitOfWork> _uows { get; set; }
        public CommandUnitOfWork(IEnumerable<IUnitOfWork> uows)
        {
            _uows = uows;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();
            if (request is IUnitOfWorkCommand)
                foreach (var uow in _uows)
                    if (uow.HasChanges())
                        await uow.SaveEntitiesAsync(cancellationToken);
            return response;

        }
    }
}
