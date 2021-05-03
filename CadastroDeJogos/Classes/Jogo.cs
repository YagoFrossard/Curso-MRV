using System;

namespace CadastroDeJogos
{
	public class Jogo : EntidadeBase
	{
		//Atributos
		private Genero Genero { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private int AnoLancamento { get; set; }
		private bool Excluido { get; set; }

		public Jogo(int id, string titulo, Genero genero, string descricao, int anoLancamento)
		{
			this.Id = id;
			this.Titulo = titulo;
			this.Genero = genero;
			this.Descricao = descricao;
			this.AnoLancamento = anoLancamento;
			this.Excluido = false;
		}
		/*
		public override string toString()
        {
			string retorno = "";
			retorno += $"Gênero: {this.Genero}{Environment.NewLine}";
			retorno += $"Título: {this.Titulo}{Environment.NewLine}";
			retorno += $"Gênero: {this.Genero}{Environment.NewLine}";
			retorno += $"Descrição: {this.Descricao}{Environment.NewLine}";
			retorno += $"Ano de Lançamento: {this.AnoLancamento}{Environment.NewLine}";
			return retorno;
		}
		*/
		public string getTitulo()
        {
			return this.Titulo;
        }

		public int getId()
        {
			return this.Id;
        }

		public string getDescricao()
        {
			return this.Descricao;
        }

		public int getAnoLancamento()
        {
			return this.AnoLancamento;
        }

		public Genero getGenero()
        {
			return this.Genero;
        }

		public bool getExcluido()
        {
			return this.Excluido;
        }

		public void Excluir()
        {
			this.Excluido = true;
        }
	}
}