using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReceitas.Infra.Repositories
{
    public class ReceitaRespQuery
    {
        public int Id { get;  set; }
        public string Imagem { get;  set; }
        public string Titulo { get;  set; }
        public string Descricao { get;  set; }
        public string Autor { get;  set; }
        public string Preparo { get; set; }
        public int Gostei { get;  set; }
        public int Odiei { get;  set; }
        public DateTime Created { get;  set; }
    }
}
