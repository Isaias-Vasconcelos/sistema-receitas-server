using SistemaReceitas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReceitas.Application.InputModel
{
    public class AdicionarReceitaInputModel
    {
        public string Imagem { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public string[] Ingredientes { get; set; }
        public string Preparo { get; set; }

        public Receita ToEntity()
            => new(0,Imagem,Titulo,Descricao,Autor,Ingredientes,Preparo,0,0,DateTime.UtcNow);
    }
}
