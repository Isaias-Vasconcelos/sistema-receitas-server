using SistemaReceitas.Application.InputModel;
using SistemaReceitas.Application.ViewModel;
using SistemaReceitas.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReceitas.Application.Services
{
    public interface IReceitaService
    {
        Task<ICollection<ReceitaViewModel>> GetAll();
        Task<ReceitaViewModel> GetById(int id);
        Task<string> Create(AdicionarReceitaInputModel adicionarReceitaInputModel);
        Task<string> Update(int receitaId, Reacao reacao);
    }
}
