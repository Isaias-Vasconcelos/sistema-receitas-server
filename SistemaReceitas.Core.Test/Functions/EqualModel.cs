using SistemaReceitas.Core.Entities;

namespace SistemaReceitas.Core.Test.Functions
{
    public static class EqualModel
    {
        public static bool Validate(int id, string imagem, string titulo, string descricao, string autor, string[] ingredientes, int gostei, int odiei, DateTime created)
        {
            var receita = new Receita(id, imagem, titulo, descricao, autor, ingredientes, gostei, odiei, created);

            return receita.Id == id &&
                receita.Imagem == imagem &&
                receita.Titulo == titulo &&
                receita.Descricao == descricao &&
                receita.Autor == autor &&
                receita.Ingredientes == ingredientes &&
                receita.Gostei == gostei &&
                receita.Odiei == odiei &&
                receita.Created == created;
        }
    }
}
