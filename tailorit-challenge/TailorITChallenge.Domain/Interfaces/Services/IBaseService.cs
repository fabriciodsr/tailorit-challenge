using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TailorITChallenge.Domain.Entities;

namespace TailorITChallenge.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        int Insert(T obj);
        T Update(T obj);
        void DeleteById(int id);
        void Delete(T obj);
        T SelectById(int id);
        IEnumerable<T> SelectAll();
    }
}
