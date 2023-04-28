using Microsoft.EntityFrameworkCore;
using RepositoryPatternTest.Interfaces;
using RepositoryPatternTest.Models;

namespace RepositoryPatternTest.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public ApplicationDbContext _dbContext { get; set; }
        DbSet<T> _dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            //Para adcionar no nosso banco de dados usamos o _dbSet que é nossa representação do BD.
            _dbSet.Add(entity);
            //Para Salvar a nossa adição no banco usamos o _dbCOntext
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
