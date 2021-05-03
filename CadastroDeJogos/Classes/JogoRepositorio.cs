using System;
using System.Collections.Generic;
using CadastroDeJogos.Interfaces;

namespace CadastroDeJogos
{
	public class JogoRepositorio : IRepositorio<Jogo>
	{
        private List<Jogo> listaJogos = new List<Jogo>();

        public List<Jogo> Lista()
        {
            return listaJogos;
        }

        public Jogo GetTById(int id)
        {
            return listaJogos[id];
        }

        public void Create(Jogo objeto)
        {
            listaJogos.Add(objeto);
        }

        public void Delete(int id)
        {
            listaJogos[id].Excluir();
        }

        public void Update(int id, Jogo objeto)
        {
            listaJogos[id] = objeto;
        }

        public int NextId()
        {
            return listaJogos.Count;
        }
    }
}