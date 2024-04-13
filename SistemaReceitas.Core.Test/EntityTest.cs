using SistemaReceitas.Core.Entities;
using SistemaReceitas.Core.Test.Functions;

namespace SistemaReceitas.Core.Test
{
    public class EnitityTest
    {
        [Fact]
        public void ModelEqualTest()
        {
            int id = 1;
            string imagem = "www.google.com";
            string titulo = "Torta de maça";
            string descricao = "Uma deliciosa torta de maça";
            string autor = "Master chef";
            string[] ingredientes = ["1 cebola","1 tomate"];
            int gostei = 0;
            int odiei = 0;
            DateTime created = DateTime.UtcNow;

            Assert.True(EqualModel.Validate(id, imagem, titulo, descricao, autor, ingredientes, gostei, odiei, created));

        }
    }
}