namespace SistemaReceitas.Core.Entities
{
    public class Receita
    {
        public int Id { get;private set; }
        public string Imagem { get;private set; }
        public string Titulo { get;private set; }
        public string Descricao { get;private set; }
        public string Autor { get;private set; }
        public string[] Ingredientes { get;private set; }
        public string Preparo { get;private set; }
        public int Gostei { get;private set; }
        public int Odiei { get;private set; }
        public DateTime Created { get;private set; }

        public Receita(int id, string imagem, string titulo, string descricacao,string autor,
            string[] ingredientes,string preparo, int gostei,int odiei,DateTime created)
        {
            Id = id;
            Imagem = imagem;
            Titulo = titulo;
            Descricao = descricacao;
            Autor = autor;
            Ingredientes = ingredientes;
            Preparo = preparo;
            Gostei = gostei;
            Odiei = odiei;
            Created = created;
        }
    }
}
