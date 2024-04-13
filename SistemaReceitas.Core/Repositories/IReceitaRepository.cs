using SistemaReceitas.Core.Entities;
using SistemaReceitas.Core.Enums;

namespace SistemaReceitas.Core.Repositories
{
    public interface IReceitaRepository
    {
        Task<ICollection<Receita>> GetAll();
        Task<Receita> GetById(int id);
        Task<string> Create(Receita receita);
        Task<string> Update(int receitaId,Reacao reacao);
    }
}
