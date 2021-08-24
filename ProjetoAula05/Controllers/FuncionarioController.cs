using ProjetoAula05.Entities;
using ProjetoAula05.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAula05.Controllers
{
    public class FuncionarioController
    {
        //atributo para armazenar a string de conexão do banco de dados
        private string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BDAula05;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void CadastrarFuncionario()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE FUNCIONÁRIO\n");

                var funcionario = new Funcionario();

                Console.Write("Nome do Funcionário.....: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("CPF.....................: ");
                funcionario.Cpf = Console.ReadLine();

                Console.Write("Matrícula...............: ");
                funcionario.Matricula = Console.ReadLine();

                Console.Write("Data de Admissão........: ");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                Console.Write("Id da Empresa...........: ");
                funcionario.IdEmpresa = Guid.Parse(Console.ReadLine());

                //gravar no banco de dados..
                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.ConnectionString = connectionString;

                funcionarioRepository.Inserir(funcionario);

                Console.WriteLine("\nFuncionário cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        public void AtualizarFuncionario()
        {
            try
            {
                Console.WriteLine("\nATUALIZAÇÃO DE FUNCIONÁRIO\n");

                Console.Write("Informe o ID do funcionário: ");
                var idFuncionario = Guid.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.ConnectionString = connectionString;

                var funcionario = funcionarioRepository.ObterPorId(idFuncionario);

                //verificando se o funcionario foi encontrado
                if (funcionario != null)
                {
                    Console.Write("Nome do Funcionário.....: ");
                    funcionario.Nome = Console.ReadLine();

                    Console.Write("CPF.....................: ");
                    funcionario.Cpf = Console.ReadLine();

                    Console.Write("Matrícula...............: ");
                    funcionario.Matricula = Console.ReadLine();

                    Console.Write("Data de Admissão........: ");
                    funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                    Console.Write("Id da Empresa...........: ");
                    funcionario.IdEmpresa = Guid.Parse(Console.ReadLine());

                    //atualizando o funcionario
                    funcionarioRepository.Alterar(funcionario);

                    Console.WriteLine("\nFuncionário atualizado com sucesso.");
                }
                else
                {
                    Console.WriteLine("\nFuncionário não encontrado. Tente novamente.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        public void ExcluirFuncionario()
        {
            try
            {
                Console.WriteLine("\nEXCLUSÃO DE FUNCIONÁRIO\n");

                Console.Write("Informe o ID do funcionário: ");
                var idFuncionario = Guid.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.ConnectionString = connectionString;

                var funcionario = funcionarioRepository.ObterPorId(idFuncionario);

                //verificando se o funcionario foi encontrado
                if (funcionario != null)
                {
                    //excluindo o funcionario
                    funcionarioRepository.Excluir(funcionario);

                    Console.WriteLine("\nFuncionário excluído com sucesso.");
                }
                else
                {
                    Console.WriteLine("\nFuncionário não encontrado. Tente novamente.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        public void ConsultarFuncionarios()
        {
            try
            {
                Console.WriteLine("\nCONSULTA DE FUNCIONÁRIOS\n");

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.ConnectionString = connectionString;

                var funcionarios = funcionarioRepository.ObterTodos();

                foreach (var item in funcionarios)
                {
                    Console.WriteLine("Id do Funcionário...: " + item.IdFuncionario);
                    Console.WriteLine("Nome................: " + item.Nome);
                    Console.WriteLine("Cpf.................: " + item.Cpf);
                    Console.WriteLine("Matricula...........: " + item.Matricula);
                    Console.WriteLine("Data de admissão....: " + item.DataAdmissao.ToString("dddd, dd/MM/yyyy"));
                    Console.WriteLine("Id da Empresa.......: " + item.IdEmpresa);
                    Console.WriteLine("---");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
        }

        public void ConsultarFuncionariosPorEmpresa()
        {
            try
            {
                Console.WriteLine("\nCONSULTA DE FUNCIONÁRIOS POR EMPRESA\n");

                Console.Write("Informe o Id da Empresa..: ");
                var idEmpresa = Guid.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.ConnectionString = connectionString;

                //consultar os funcionarios da empresa informada..
                var funcionarios = funcionarioRepository.ObterPorEmpresa(idEmpresa);

                foreach (var item in funcionarios)
                {
                    Console.WriteLine("Id do Funcionário...: " + item.IdFuncionario);
                    Console.WriteLine("Nome................: " + item.Nome);
                    Console.WriteLine("Cpf.................: " + item.Cpf);
                    Console.WriteLine("Matricula...........: " + item.Matricula);
                    Console.WriteLine("Data de admissão....: " + item.DataAdmissao.ToString("dddd, dd/MM/yyyy"));
                    Console.WriteLine("Id da Empresa.......: " + item.IdEmpresa);
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
