using ProjetoAula05.Entities;
using ProjetoAula05.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ProjetoAula05.Controllers
{
    public class EmpresaController
    {
        //atributo privado..
        private string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BDAula05;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //método para executar a gravação de uma empresa no banco
        public void CadastrarEmpresa()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE EMPRESA\n");

                var empresa = new Empresa();

                Console.Write("Informe a Razão Social....: ");
                empresa.RazaoSocial = Console.ReadLine();

                Console.Write("Informe o CNPJ............: ");
                empresa.Cnpj = Console.ReadLine();

                var empresaRepository = new EmpresaRepository();

                empresaRepository.ConnectionString = connectionString;
                empresaRepository.Inserir(empresa);

                Console.WriteLine("\nEmpresa cadastrada com sucesso!");
            }
            catch (SqlException e) //somente para erros de SQL (banco)
            {
                Console.WriteLine("\nNão foi possível realizar o cadastro da empresa.");
                Console.WriteLine("Código do erro: " + e.Number);

                if (e.Number == 2627)
                {
                    Console.WriteLine("Verifique a Razão Social ou CNPJ informados. Estes valores não podem ser duplicados.");
                }
                else if (e.Number == 8152)
                {
                    Console.WriteLine("O limite de caracteres permitido para um campo foi excedido.");
                }
            }
            catch (Exception e) //qualquer outro tipo de erro
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        //método para executar a atualização de uma empresa no banco
        public void AtualizarEmpresa()
        {
            try
            {
                Console.WriteLine("\nATUALIZAÇÃO DE EMPRESA\n");

                Console.Write("Informe o ID da empresa: ");
                var idEmpresa = Guid.Parse(Console.ReadLine());

                //instanciando a classe EmpresaRepository
                var empresaRepository = new EmpresaRepository();
                empresaRepository.ConnectionString = connectionString;

                //buscar a empresa no banco de dados atraves do ID..
                var empresa = empresaRepository.ObterPorId(idEmpresa);

                //verificar se a empresa foi encontrada..
                if (empresa != null)
                {
                    Console.Write("Informe a Razão Social....: ");
                    empresa.RazaoSocial = Console.ReadLine();

                    Console.Write("Informe o CNPJ............: ");
                    empresa.Cnpj = Console.ReadLine();

                    //atualizando os dados da empresa
                    empresaRepository.Alterar(empresa);

                    Console.WriteLine("\nEmpresa atualizada com sucesso.");
                }
                else
                {
                    Console.WriteLine("\nEmpresa não encontrada. Tente novamente.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        //método para executar a exclusão de uma empresa no banco
        public void ExcluirEmpresa()
        {
            try
            {
                Console.WriteLine("\nEXCLUSÃO DE EMPRESA\n");

                Console.Write("Informe o ID da empresa: ");
                var idEmpresa = Guid.Parse(Console.ReadLine());

                //instanciando a classe EmpresaRepository
                var empresaRepository = new EmpresaRepository();
                empresaRepository.ConnectionString = connectionString;

                //buscar a empresa no banco de dados atraves do ID..
                var empresa = empresaRepository.ObterPorId(idEmpresa);

                //verificar se a empresa foi encontrada..
                if (empresa != null)
                {
                    //excluindo a empresa
                    empresaRepository.Excluir(empresa);

                    Console.WriteLine("\nEmpresa excluída com sucesso.");
                }
                else
                {
                    Console.WriteLine("\nEmpresa não encontrada. Tente novamente.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        //método para executar a consulta de empresas
        public void ConsultarEmpresas()
        {
            try
            {
                //executando a consulta de empresas
                var empresaRepository = new EmpresaRepository();
                empresaRepository.ConnectionString = connectionString;

                var empresas = empresaRepository.ObterTodos();

                foreach (var item in empresas)
                {
                    Console.WriteLine("Id da Empresa...: " + item.IdEmpresa);
                    Console.WriteLine("Razão Social....: " + item.RazaoSocial);
                    Console.WriteLine("CNPJ............: " + item.Cnpj);
                    Console.WriteLine("---");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

    }
}
