using System;

namespace PrimeiroProjetoDotNet
{
	class Program
	{ 
		static void Main(string[] args)
		{
			Jogo[] jogos = new Jogo[5];
			int intResp, index = 0;
			intResp = obterOpcaoPorMenu();
			while(intResp != 4)
			{
				switch (intResp)
				{
					case 1:
						if(index < 5)
                        {
							Console.Write("Informe o nome do jogo: ");
							Jogo jogo = new Jogo();
							jogo.nome = Console.ReadLine();
							Console.Write("Informe a avaliação do jogo: ");
							if (float.TryParse(Console.ReadLine(), out float nota))
							{
								jogo.avaliacao = nota;
							}
							else
							{
								throw new ArgumentException("Valor da nota deve ser decimal separado por ,");
							}
							jogos[index] = jogo;
							index++;
						}
                        else
                        {
							Console.WriteLine("Sua lista está cheia!\n");
                        }
						break;
					case 2:
						if(index != 0)
                        {
							foreach (var item in jogos)
							{
								EQualidade qualidade;
								if (!string.IsNullOrEmpty(item.nome))
								{
									qualidade = verificarQualidade(item.avaliacao);
									Console.WriteLine($"JOGO: {item.nome} ---> NOTA: {item.avaliacao:0.00} ---> QUALIDADE: {qualidade}");
								}
								else
									break;
							}
						}
                        else
                        {
							Console.WriteLine("Sua lista está vazia!\n");
                        }
						break;
					case 3:
						if (index == 0) 
							break;
						int indexJogoMenNota=0, indexJogoMaiNota=0;
						float maiNota = -1, menNota = 11;
						for(int i=0;i < jogos.Length;i++)
                        {
							if (!string.IsNullOrEmpty(jogos[i].nome))
                            {
								if(jogos[i].avaliacao > maiNota)
                                {
									maiNota = jogos[i].avaliacao;
									indexJogoMaiNota = i;
                                }
								if (jogos[i].avaliacao < menNota)
								{
									menNota = jogos[i].avaliacao;
									indexJogoMenNota = i;
								}
							}
                            else
                            {
								break;
                            }
						}
						Console.WriteLine($"\nJogo de maior avaliação: {jogos[indexJogoMaiNota].nome}: {maiNota:0.00}");
						Console.WriteLine($"Jogo de menor avaliação: {jogos[indexJogoMenNota].nome}: {menNota:0.00}");
						break;
					default:
						throw new ArgumentOutOfRangeException("Opção inválida! Tente novamente.");
				}
				intResp = obterOpcaoPorMenu();
			}
		}

		static public int obterOpcaoPorMenu()
		{
			int intResp;
			string resp;
			Console.WriteLine("\nEscolha uma opção a ser realizada:");
			Console.WriteLine("1 - Adicionar novo jogo");
			Console.WriteLine("2 - Listar jogos");
			Console.WriteLine("3 - Mostrar notáveis");
			Console.WriteLine("4 - Fechar programa\n");
			resp = Console.ReadLine();
			Console.WriteLine();
			intResp = int.Parse(resp);
			return intResp;
		}

		static public EQualidade verificarQualidade(float nota)
        {
			EQualidade qualidade;
			if (nota <= 2)
			{
				qualidade = EQualidade.Pessimo;
			}
			else if (nota <= 4)
			{
				qualidade = EQualidade.Ruim;
			}
			else if (nota <= 6)
			{
				qualidade = EQualidade.Medio;
			}
			else if (nota <= 8)
			{
				qualidade = EQualidade.Bom;
			}
			else
			{
				qualidade = EQualidade.Excelente;
			}
			return qualidade;
		}
	}
}
