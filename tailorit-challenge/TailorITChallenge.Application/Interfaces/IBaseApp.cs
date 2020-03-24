using System;
using System.Collections.Generic;
using System.Text;
using TailorITChallenge.Application.DTO;
using TailorITChallenge.Domain.Entities;

namespace TailorITChallenge.Application.Interfaces
{
    public interface IBaseApp<T, TDTO>
        where T : BaseEntity
        where TDTO : BaseDTO
    {
        int Insert(TDTO obj);

        T Update(TDTO obj);

        void DeleteById(int id);

        void Delete(TDTO obj);

        TDTO SelectById(int id);

        IEnumerable<TDTO> SelectAll();
    }
}
