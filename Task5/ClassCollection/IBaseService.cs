namespace ClassCollection
{
    using System;
    using System.Collections.Generic;

    public interface IBaseService<T> where T : class, new() //todo pn формулировка задания изменилась, поэтому IBaseService нужно переименовать
    {
        T Get(int id);

        List<T> GetAll();

        bool Save(T entity);

        bool Delete(int id);
    }

    public class Repos<T> : IBaseService<T> where T : class, new() //todo pn в отдельный файл
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
                Console.WriteLine("couldn't delete the item");
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
                Console.WriteLine("item search failed");
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
                Console.WriteLine("couldn't found the List");
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
                Console.WriteLine("item addition failed");
                return false;
            }
        }
    }
}
