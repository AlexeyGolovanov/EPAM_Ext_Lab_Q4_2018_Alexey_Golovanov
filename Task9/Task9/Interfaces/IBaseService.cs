﻿namespace Task9.Interfaces
{
    using System.Collections.Generic;

    public interface IBaseService<T> where T : class, new()
    {
        T Get(int id);

        List<T> GetAll();

        bool Save(T entity);

        bool Delete(int id);
    }
}
