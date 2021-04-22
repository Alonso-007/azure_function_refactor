using azure_function_refactor.dados.Contextos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace azure_function_refactor.dados.Repositorios
{
    public class BaseRepositorio<TEntidade> where TEntidade : class
    {
        private readonly ApplicationDbContext _contexto;

        public BaseRepositorio(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<TEntidade> Find(Expression<Func<TEntidade, bool>> predicate)
        {
            return await _contexto.Set<TEntidade>().AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        public void Add(TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Add(entidade);
        }

        public IQueryable<TEntidade> List()
        {
            return _contexto.Set<TEntidade>().AsNoTracking();
        }

        public void Delete(TEntidade entidade)
        {
            _contexto.Set<TEntidade>().Remove(entidade);
        }

        public async Task Commit()
        {
            await _contexto.SaveChangesAsync();
        }
    }
}