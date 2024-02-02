namespace DesafioPetshopp.Models
{
    public class Layout
    {
        private static List<Agendamento> agendamentos = new();
        private static int opcao = 0;

        public static void TelaPrincipal()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("========================[ Sistema de Agendamento ]========================\n");

                Console.WriteLine("Digite a opção desejada: \n");
                Console.WriteLine("1 - Entrar no sistema");
                Console.WriteLine("2 - Sair do sistema\n");

                opcao = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        TelaLogar();
                        break;
                    case 2:
                        Console.WriteLine("Você saiu do sistema!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        TelaPrincipal();
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"erro: {erro}");
                TelaPrincipal();
            }
        }

        private static void TelaLogar()
        {
            Login login = new();

            Console.WriteLine("========================[ Sistema de Agendamento ]========================");

            Console.WriteLine("\nDigite seu email: ");
            login.Email = Console.ReadLine();

            Console.WriteLine("\nDigite sua senha: ");
            login.Senha = Console.ReadLine();


            if (login.Email == "admin@admin.com.br" && login.Senha == "admin123")
            {
                Console.WriteLine("\nLogin efetuado com sucesso.");
                Thread.Sleep(2000);
                Console.Clear();

                Menu();
            }
            else
            {
                Console.WriteLine("login/senha incorreto, tente novamente");
                Thread.Sleep(2000);
                Console.Clear();

                TelaPrincipal();
            }
        }

        private static void Menu()
        {
            try
            {
                Console.WriteLine("========================[ Menu de Agendamento ]========================\n");

                Console.WriteLine("1 - Listar agendamentos");
                Console.WriteLine("2 - Cadastrar novo agendamento");
                Console.WriteLine("3 - Sair");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        ListarAgendamento();
                        break;

                    case 2:
                        MenuCadastro();
                        break;

                    case 3:
                        TelaPrincipal();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"erro: {erro}");
                Menu();
            }
        }

        private static void MenuCadastro()
        {
            Agendamento novoAgendamento = new();
            Console.Clear();

            Console.WriteLine("========================[ Menu de Cadastro ]========================\n");

            Console.WriteLine("Digite seu nome: ");
            novoAgendamento.NomeDono = Console.ReadLine();

            Console.WriteLine("\nDigite seu contato: ");
            novoAgendamento.ContatoDono = Console.ReadLine();

            Console.WriteLine("\nDigite o nome do seu cachorro: ");
            novoAgendamento.NomeCachorro = Console.ReadLine();

            Console.WriteLine("\nDigite a cor do seu cachorro: ");
            novoAgendamento.CorCachorro = Console.ReadLine();

            Console.WriteLine("\nDigite a data do agendamento: ");
            novoAgendamento.DataAgendamento = Console.ReadLine();

            agendamentos.Add(novoAgendamento);

            Console.Clear();
            Menu();
        }

        private static void ListarAgendamento()
        {
            if (agendamentos.Count() <= 0)
            {
                Console.Clear();
                Console.WriteLine("Ainda não há agendamentos cadastrados\n");
                Menu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("========================[ Lista de Agendamento ]========================\n");

                foreach (var agendamento in agendamentos)
                {
                    Console.WriteLine($"Nome: {agendamento.NomeDono}\nContato: {agendamento.ContatoDono}\nNome do Cachorro: {agendamento.NomeCachorro}\nCor do Cachorro: {agendamento.CorCachorro}\nData do Agendamento: {agendamento.DataAgendamento}\n");
                }

                Menu();
            }
        }
    }
}
