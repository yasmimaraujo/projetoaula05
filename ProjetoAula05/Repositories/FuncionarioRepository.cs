using Dapper;
using ProjetoAula05.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjetoAula05.Repositories
{
    public class FuncionarioRepository
    {
        //prop + 2x[tab]
        public string ConnectionString { get; set; }

        public void Inserir(Funcionario funcionario)
        {
            var sql = @"
                    insert into Funcionario(IdFuncionario, Nome, Cpf, Matricula, DataAdmissao, IdEmpresa)
                    values(NewId(), @Nome, @Cpf, @Matricula, @DataAdmissao, @IdEmpresa)
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, funcionario);
            }
        }

        public void Alterar(Funcionario funcionario)
        {
            var sql = @"
                    update Funcionario set
                        Nome = @Nome,
                        Cpf = @Cpf,
                        Matricula = @Matricula,
                        DataAdmissao = @DataAdmissao
                        IdEmpresa = @IdEmpresa
                    where
                        IdFuncionario = @IdFuncionario
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, funcionario);
            }
        }

        public void Excluir(Funcionario funcionario)
        {
            var sql = @"
                    delete from Funcionario
                    where IdFuncionario = @IdFuncionario
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, funcionario);
            }
        }

        public List<Funcionario> ObterTodos()
        {
            var sql = @"
                    select * from Funcionario
                    order by Nome
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection
                    .Query<Funcionario>(sql)
                    .ToList();
            }
        }

        public List<Funcionario> ObterPorEmpresa(Guid idEmpresa)
        {
            var sql = @"
                    select * from Funcionario
                    where IdEmpresa = @idEmpresa
                    order by Nome
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection
                    .Query<Funcionario>(sql, new { idEmpresa })
                    .ToList();
            }
        }

        public Funcionario ObterPorId(Guid id)
        {
            var sql = @"
                    select * from Funcionario
                    where IdFuncionario = @id
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection
                    .Query<Funcionario>(sql, new { id })
                    .FirstOrDefault();
            }
        }
    }
}