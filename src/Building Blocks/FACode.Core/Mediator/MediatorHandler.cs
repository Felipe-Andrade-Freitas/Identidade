using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FACode.Core.Messages;
using MediatR;

namespace FACode.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ValidationResult EnviarComando<T>(T comando) where T : Command
        {
            return _mediator.Send(comando);
        }

        public void PublicarEvento<T>(T evento) where T : Event
        {
            _mediator.Publish(evento);
        }
    }
}