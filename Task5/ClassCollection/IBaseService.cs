namespace ClassCollection
{
    using System;
    using System.Collections.Generic;

    public interface IBaseService<T> where T : class, new()
    {
        T Get(int id);

        List<T> GetAll();

        bool Save(T entity);

        bool Delete(int id);
    }

    public class Repos<T> : IBaseService<T> where T : class, new()
    {
        private List<T> users = new List<T>();

        public bool Delete(int id)
        {
            try
            {
                this.users.RemoveAt(id);
                return true;
            }
            catch
            {
                Console.WriteLine("ERROR: can not delete an item");
                return false;
            }
        }

        public T Get(int id)
        {
            try
            {
                return this.users[id];
            }
            catch
            {
                Console.WriteLine("ERROR: item search failed");
                return new T();
            }
        }

        public List<T> GetAll()
        {
            try
            {
                return this.users;
            }
            catch
            {
                Console.WriteLine("ERROR: List not found");
                return new List<T>();
            }
        }

        public bool Save(T entity)
        {
            try
            {
                this.users.Add(entity);
                return true;
            }
            catch
            {
                Console.WriteLine("ERROR: can not add item");
                return false;
            }
        }
    }
}
