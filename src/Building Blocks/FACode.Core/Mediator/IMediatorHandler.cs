using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FACode.Core.Messages;

namespace FACode.Core.Mediator
{
    public interface IMediatorHandler
    {
        void PublicarEvento<T>(T evento) where T : Event;
        ValidationResult EnviarComando<T>(T comando) where T : Command;
    }
}