using System;
using System.Collections.Generic;
using System.Linq;
using TailorITChallenge.Domain.Entities;
using TailorITChallenge.Domain.Interfaces.Repositories;
using TailorITChallenge.Domain.Interfaces.Services;

namespace TailorITChallenge.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IBaseRepository<T> repository;

        public BaseService(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public void Delete(T obj)
        {
            repository.Delete(obj);
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public int Insert(T obj)
        {
            return repository.Insert(obj);
        }

        public IEnumerable<T> SelectAll()
        {
            return repository.SelectAll();
        }

        public T SelectById(int id)
        {
            return repository.SelectById(id);
        }

        public T Update(T obj)
        {
            return repository.Update(obj);
        }
    }
}
