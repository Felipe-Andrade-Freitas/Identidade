using System.Threading.Tasks;

namespace FACode.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}