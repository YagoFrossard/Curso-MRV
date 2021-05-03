using System;

namespace CadastroDeJogos
{
    class Program
    {
        static JogoRepositorio repositorio = new JogoRepositorio();

        static void Main(string[] args)
        {
            int resp = obterOpcaoUsuario();
            while(resp != 7)
            {
                switch (resp)
                {
                    case 1:
                        ListarJogos();
                        break;
                    case 2:
                        AdicionarJogo();
                        break;
                    case 3:
                        DeletarJogo();
                        break;
                    case 4:
                        AtualizarJogo();
                        break;
                    case 5:
                        VisualizarJogo();
                        break;
                    case 6:
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Comando inválido!");
                }
                resp = obterOpcaoUsuario();
            }
            Console.WriteLine("\nObrigado por utilizar meu programa!");
            Console.ReadLine();
        }

        private static void ListarJogos()
        {
            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum jogo cadastrado.");
                Console.WriteLine();
                return;
            }
            foreach(Jogo jogo in lista)
            {
                if(!jogo.getExcluido())
                    Console.WriteLine($"ID: {jogo.getId()} - {jogo.getTitulo()} {(jogo.getExcluido() ? "- *Excluído*":"")}");
            }
        }

        private static void AdicionarJogo()
        {
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine("\nDigite o número do gênero dentre as opções acima: ");
            int inGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDigite o nome do jogo: ");
            string inTitulo = Console.ReadLine();

            Console.WriteLine("\nInforme a descrição do jogo: ");
            string inDescricao = Console.ReadLine();

            Console.WriteLine("\nDigite o ano de lançamento: ");
            int inAnoLancamento = int.Parse(Console.ReadLine());

            Jogo novoJogo = new Jogo(id: repositorio.NextId(),
                titulo: inTitulo,
                genero: (Genero)inGenero,
                descricao: inDescricao,
                anoLancamento: inAnoLancamento);
            repositorio.Create(novoJogo);
        }

        private static void AtualizarJogo()
        {
            Console.WriteLine("Informe o ID do jogo que deseja modificar: ");
            int idMod = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine("\nDigite o número do gênero dentre as opções acima: ");
            int inGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDigite o nome do jogo: ");
            string inTitulo = Console.ReadLine();

            Console.WriteLine("\nInforme a descrição do jogo: ");
            string inDescricao = Console.ReadLine();

            Console.WriteLine("\nDigite o ano de lançamento: ");
            int inAnoLancamento = int.Parse(Console.ReadLine());

            Jogo novoJogo = new Jogo(id: idMod,
                titulo: inTitulo,
                genero: (Genero)inGenero,
                descricao: inDescricao,
                anoLancamento: inAnoLancamento);
            repositorio.Update(idMod, novoJogo);
        }

        private static void VisualizarJogo()
        {
            Console.WriteLine("Digite o ID do jogo que deseja visualizar: ");
            int intId = int.Parse(Console.ReadLine());
            var jogo = repositorio.GetTById(intId);
            Console.WriteLine($"ID: {jogo.getId()}");
            Console.WriteLine($"Título: {jogo.getTitulo()}");
            Console.WriteLine($"Gênero: {jogo.getGenero()}");
            Console.WriteLine($"Ano de Lançamento: {jogo.getAnoLancamento()}");
            Console.WriteLine($"Descrição: {jogo.getDescricao()}");
            Console.WriteLine($"Excluído: {(jogo.getExcluido() ? "Sim":"Não")}");
        }

        private static void DeletarJogo()
        {
            Console.WriteLine("Digite o ID do jogo que deseja visualizar: ");
            int intId = int.Parse(Console.ReadLine());
            var jogo = repositorio.GetTById(intId);
            jogo.Excluir();
        }

        private static int obterOpcaoUsuario()
        {
            string resp;
            Console.WriteLine();
            Console.WriteLine("Bem-Vindo ao Programa de Cadastramento de Jogos!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar jogos");
            Console.WriteLine("2 - Adicionar jogo");
            Console.WriteLine("3 - Remover jogo");
            Console.WriteLine("4 - Atualizar jogo");
            Console.WriteLine("5 - Visualizar jogo");
            Console.WriteLine("6 - Limpar tela");
            Console.WriteLine("7 - Fechar programa");
            resp = Console.ReadLine();
            Console.WriteLine();
            if(!int.TryParse(resp, out int intResp))
                throw new ArgumentException("Comando inválido!");
            return intResp;
        }
    }
}