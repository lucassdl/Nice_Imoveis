using System.Collections.Generic;

namespace Application.Interfaces.Generic
{
    public interface IAppGeneric<T> where T : class
    {
        void Adicionar(T entitie);
        void Editar(T entitie);
        void Excluir(int id);
        List<T> Listar();
    }
}
