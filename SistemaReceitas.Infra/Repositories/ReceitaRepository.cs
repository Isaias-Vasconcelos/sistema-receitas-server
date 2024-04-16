using Dapper;
using SistemaReceitas.Core.Entities;
using SistemaReceitas.Core.Enums;
using SistemaReceitas.Core.Repositories;
using SistemaReceitas.Infra.Data;
using System.Data;
using System.Text.Json;

namespace SistemaReceitas.Infra.Repositories
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly IDbConnection _db;

        public ReceitaRepository()
        {
            _db = Connection.ConnectDatabase();
        }
        public async Task<string> Create(Receita receita)
        {
            string response;
            try
            {
                string sqlInsert = @"INSERT INTO receitas (imagem,titulo,descricao,preparo,autor,gostei,odiei,created) VALUES (@Imagem,@Titulo,@Descricao,@Preparo,@Autor,@Gostei,@Odiei,@Created)";
                await _db.ExecuteAsync(sql: sqlInsert, new
                {
                    receita.Imagem,
                    receita.Titulo,
                    receita.Descricao,
                    receita.Preparo,
                    receita.Autor,
                    receita.Odiei,
                    receita.Gostei,
                    receita.Created
                });

                var ultimoId = await _db.QueryFirstAsync<int>("SELECT id FROM receitas ORDER BY id DESC");

                foreach (var ingrediente in receita.Ingredientes)
                {
                    await _db.ExecuteAsync("INSERT INTO ingredientes (receitaId,nome) VALUES (@ReceitaId,@Nome)", new
                    {
                        ReceitaId = ultimoId,
                        Nome = ingrediente
                    });
                }

                response = "Receita adicionada com sucesso";

            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }

        public async Task<ICollection<Receita>> GetAll()
        {
            ICollection<Receita> receitas = [];
            try
            {
                var receitasDB = await _db.QueryAsync<ReceitaRespQuery>("SELECT * FROM receitas");

                foreach (var receita in receitasDB)
                {
                    var ingredientes = await _db.QueryAsync<string>("SELECT nome FROM ingredientes WHERE receitaId = @ReceitaId", new
                    {
                        ReceitaId = receita.Id,
                    });

                    receitas.Add(new Receita(
                        receita.Id,
                        receita.Imagem,
                        receita.Titulo,
                        receita.Descricao,
                        receita.Autor,
                        ingredientes.ToArray(),
                        receita.Preparo,
                        receita.Gostei,
                        receita.Odiei,
                        receita.Created

                        ));
                }

                Console.WriteLine(JsonSerializer.Serialize(receitas));

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar receitas : {ex.Message}");
            }
            return receitas;
        }

        public async Task<Receita> GetById(int id)
        {
            Receita receita;
            try
            {
                var receitaDb = await _db.QueryFirstAsync<ReceitaRespQuery>("SELECT * FROM receitas WHERE id = @ReceitaId", new
                {
                    ReceitaId = id
                });

                var ingredientes = await _db.QueryAsync<string>("SELECT nome FROM ingredientes WHERE receitaId = @ReceitaId", new
                {
                    ReceitaId = id
                });

                receita = new Receita(receitaDb.Id, receitaDb.Imagem, receitaDb.Titulo,
                    receitaDb.Descricao, receitaDb.Autor, ingredientes.ToArray(),receitaDb.Preparo, receitaDb.Gostei, receitaDb.Odiei, receitaDb.Created);

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar receita por id : {ex.Message}");
            }
            return receita;
        }

        public async Task<string> Update(int receitaId, Reacao reacao)
        {
            string response;
            try
            {

                if (reacao == Reacao.GOSTEI)
                {
                    int countGostei = await _db.QueryFirstAsync<int>("SELECT gostei FROM receitas WHERE id = @ReceitaId", new
                    {
                        ReceitaId = receitaId
                    });

                    await _db.ExecuteAsync("UPDATE receitas SET gostei = @Gostei WHERE id = @ReceitaId", new
                    {
                        ReceitaId = receitaId,
                        Gostei = countGostei + 1
                    });

                }
                else
                {
                    int countOdiei = await _db.QueryFirstAsync<int>("SELECT odiei FROM receitas WHERE id = @ReceitaId", new
                    {
                        ReceitaId = receitaId,
                    });

                    await _db.ExecuteAsync("UPDATE receitas SET odiei = @Odiei WHERE id = @ReceitaId", new
                    {
                        ReceitaId = receitaId,
                        Odiei = countOdiei + 1
                    });
                }

                response = "Reação computada com sucesso!";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }
    }
}
