using ProjetoAula05.Controllers;
using System;

namespace ProjetoAula05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nSISTEMA DE CONTROLE DE EMPRESAS E FUNCIONÁRIOS\n");

            var empresaController = new EmpresaController();
            var funcionarioController = new FuncionarioController();

            Console.WriteLine("(1) Cadastrar empresa");
            Console.WriteLine("(2) Atualizar empresa");
            Console.WriteLine("(3) Excluir empresa");
            Console.WriteLine("(4) Consultar empresas");
            Console.WriteLine("(5) Cadastrar funcionário");
            Console.WriteLine("(6) Atualizar funcionário");
            Console.WriteLine("(7) Excluir funcionário");
            Console.WriteLine("(8) Consultar funcionário");
            Console.WriteLine("(9) Consultar funcionários por empresa");
            Console.WriteLine("(0) Sair");

            try
            {
                Console.Write("\nEscolha a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        empresaController.CadastrarEmpresa();
                        Main(args); //recursividade
                        break;

                    case 2:
                        empresaController.AtualizarEmpresa();
                        Main(args); //recursividade
                        break;

                    case 3:
                        empresaController.ExcluirEmpresa();
                        Main(args); //recursividade
                        break;

                    case 4:
                        empresaController.ConsultarEmpresas();
                        Main(args); //recursividade
                        break;

                    case 5:
                        funcionarioController.CadastrarFuncionario();
                        Main(args); //recursividade
                        break;

                    case 6:
                        funcionarioController.AtualizarFuncionario();
                        Main(args); //recursividade
                        break;

                    case 7:
                        funcionarioController.ExcluirFuncionario();
                        Main(args); //recursividade
                        break;

                    case 8:
                        funcionarioController.ConsultarFuncionarios();
                        Main(args); //recursividade
                        break;

                    case 9:
                        funcionarioController.ConsultarFuncionariosPorEmpresa();
                        Main(args); //recursividade
                        break;

                    case 0:
                        Console.WriteLine("\nFIM DO PROGRAMA!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
