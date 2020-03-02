using Domain.Entities;
using Domain.Interfaces;
using Infra.Repository.Generic;

namespace Infra.Repository
{
    public class RepositoryUsuario : RepositoryGeneric<Usuario>, IUsuario
    {
    }
}
