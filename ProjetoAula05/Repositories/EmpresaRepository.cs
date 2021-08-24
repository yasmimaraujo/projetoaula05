using Dapper;
using ProjetoAula05.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjetoAula05.Repositories
{
    public class EmpresaRepository
    {
        //String de conexão do banco de dados
        public string ConnectionString { get; set; }

        public void Inserir(Empresa empresa)
        {
            var sql = @"
                    insert into Empresa(IdEmpresa, RazaoSocial, Cnpj)
                    values(NewId(), @RazaoSocial, @Cnpj)
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, empresa);
            }
        }

        public void Alterar(Empresa empresa)
        {
            var sql = @"
                    update Empresa set
                        RazaoSocial = @RazaoSocial,
                        Cnpj = @Cnpj
                    where
                        IdEmpresa = @IdEmpresa
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, empresa);
            }
        }

        public void Excluir(Empresa empresa)
        {
            var sql = @"
                    delete from Empresa
                    where IdEmpresa = @IdEmpresa
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, empresa);
            }
        }

        public List<Empresa> ObterTodos()
        {
            var sql = @"
                    select * from Empresa
                    order by RazaoSocial
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection
                    .Query<Empresa>(sql)
                    .ToList();
            }
        }

        public Empresa ObterPorId(Guid idEmpresa)
        {
            var sql = @"
                    select * from Empresa
                    where IdEmpresa = @idEmpresa
                ";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection
                    .Query<Empresa>(sql, new { idEmpresa })
                    .FirstOrDefault();
            }
        }
    }
}
