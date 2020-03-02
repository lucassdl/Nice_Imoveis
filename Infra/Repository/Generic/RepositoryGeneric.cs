using Domain.Interfaces.Generic;
using Infra.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repository.Generic
{
    public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class
    {
        private DbContextOptionsBuilder<Context> _optionsBuilder;

        public RepositoryGeneric()
        {
            _optionsBuilder = new DbContextOptionsBuilder<Context>();
        }

        public void Adicionar(T entitie)
        {
            using (var banco = new Context(_optionsBuilder.Options))
            {
                banco.Set<T>().Add(entitie);
                banco.SaveChanges();
            }
        }

        public void Editar(T entitie)
        {
            using (var banco = new Context(_optionsBuilder.Options))
            {
                banco.Set<T>().Update(entitie);
                banco.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using(var banco = new Context(_optionsBuilder.Options))
            {
                var entitie = banco.Set<T>().Find(id);
                banco.Remove(entitie);
                banco.SaveChanges();
            }
        }

        public List<T> Listar()
        {
            using (var banco = new Context(_optionsBuilder.Options))
            {
                return banco.Set<T>().ToList();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
