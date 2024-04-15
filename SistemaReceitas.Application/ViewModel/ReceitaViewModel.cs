using SistemaReceitas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReceitas.Application.ViewModel
{
    public class ReceitaViewModel
    {
        public int Id { get; private set; }
        public string Imagem { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Autor { get; private set; }
        public string[] Ingredientes { get; private set; }
        public string Preparo { get; set; }
        public int Gostei { get; private set; }
        public int Odiei { get; private set; }
        public DateTime Created { get; private set; }

        public ReceitaViewModel(int id, string imagem, string titulo, string descricao, string autor, string[] ingredientes,string preparo, int gostei, int odiei, DateTime created)
        {
            Id = id;
            Imagem = imagem;
            Titulo = titulo;
            Descricao = descricao;
            Autor = autor;
            Ingredientes = ingredientes;
            Preparo = preparo;
            Gostei = gostei;
            Odiei = odiei;
            Created = created;
        }

        public static ReceitaViewModel ToViewModel(Receita receita)
            => new(receita.Id, receita.Imagem, receita.Titulo, receita.Descricao, receita.Autor, receita.Ingredientes,receita.Preparo, receita.Gostei, receita.Odiei, receita.Created);
    }
}
