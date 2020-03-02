using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Application.App
{
    public class AppUsuario : IAppUsuario
    {
        private readonly IUsuario _usuario;

        public AppUsuario(IUsuario usuario)
        {
            _usuario = usuario;
        }
            
        public void Adicionar(Usuario entitie)
        {
            _usuario.Adicionar(entitie);
        }

        public void Editar(Usuario entitie)
        {
            _usuario.Editar(entitie);
        }

        public void Excluir(int id)
        {
            _usuario.Excluir(id);
        }

        public List<Usuario> Listar()
        {
            return _usuario.Listar();
        }
    }
}
