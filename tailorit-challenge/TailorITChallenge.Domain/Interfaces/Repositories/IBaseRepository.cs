using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TailorITChallenge.Domain.Entities;

namespace TailorITChallenge.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        int Insert(T obj);

        T Update(T obj);

        void DeleteById(int id);

        void Delete(T entity);

        T SelectById(int id);

        IEnumerable<T> SelectAll();
    }
}
