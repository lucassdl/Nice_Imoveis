using System.Collections.Generic;

namespace Domain.Interfaces.Generic
{
    public interface IGeneric<T> where T : class
    {
        void Adicionar(T entitie);
        void Editar(T entitie);
        void Excluir(int id);
        List<T> Listar();
    }
}
