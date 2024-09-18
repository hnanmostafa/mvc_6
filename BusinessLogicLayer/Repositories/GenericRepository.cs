using Demo.BusinessLogicLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Repositories
{
    public class GenericRepository<TEntity> : IGendericRepository<TEntity> where TEntity : class
    {
        private DataContext _dataContext;
       protected DbSet<TEntity> _dbSet;
        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet=_dataContext.Set<TEntity>();
        }

        public void Create(TEntity entity)=> _dbSet.Add(entity);
            
       

        public void Delete(TEntity entity)=>_dbSet.Remove(entity);
          
        

        public TEntity? Get(int id)=>_dbSet.Find(id);
      

        public IEnumerable<TEntity> GetAll()=>_dbSet.ToList();
       

        public void Update(TEntity entity)=>  _dbSet.Update(entity);
           
        
    }
}
