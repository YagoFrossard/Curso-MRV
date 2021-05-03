using System.Collections.Generic;

namespace CadastroDeJogos.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T GetTById(int id);
        void Create(T entidade);
        void Delete(int id);
        void Update(int id, T entidade);
        int NextId();
    }
}