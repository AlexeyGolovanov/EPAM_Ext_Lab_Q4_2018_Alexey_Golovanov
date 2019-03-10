namespace Task9.Repos
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
