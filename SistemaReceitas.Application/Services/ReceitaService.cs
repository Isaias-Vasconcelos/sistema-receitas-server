using SistemaReceitas.Application.InputModel;
using SistemaReceitas.Application.ViewModel;
using SistemaReceitas.Core.Enums;
using SistemaReceitas.Core.Repositories;

namespace SistemaReceitas.Application.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly IReceitaRepository _receitaRepository;

        public ReceitaService(IReceitaRepository receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }
        public async Task<string> Create(AdicionarReceitaInputModel adicionarReceitaInputModel)
        {
            var receita = adicionarReceitaInputModel.ToEntity();
            var response = await _receitaRepository.Create(receita);
            return response;
        }

        public async Task<ICollection<ReceitaViewModel>> GetAll()
        {
            var receitas = await _receitaRepository.GetAll();

            return receitas.Select(ReceitaViewModel.ToViewModel).ToList();
        }

        public async Task<ReceitaViewModel> GetById(int id)
        {
            var receita = await _receitaRepository.GetById(id);

            return ReceitaViewModel.ToViewModel(receita);
        }

        public async Task<string> Update(int receitaId, Reacao reacao)
        {
            var response = await _receitaRepository.Update(receitaId, reacao);
            return response;
        }
    }
}
