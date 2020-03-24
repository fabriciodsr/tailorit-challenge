using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TailorITChallenge.Application.DTO;
using TailorITChallenge.Application.Interfaces;
using TailorITChallenge.Domain.Entities;
using TailorITChallenge.Domain.Interfaces.Services;

namespace TailorITChallenge.Application.Services
{
    public class BaseApp<T, TDTO> : IBaseApp<T, TDTO>
        where T : BaseEntity
        where TDTO : BaseDTO
    {
        protected readonly IBaseService<T> service;
        protected readonly IMapper iMapper;

        public BaseApp(IMapper iMapper, IBaseService<T> service)
            : base()
        {
            this.service = service;
            this.iMapper = iMapper;
        }

        public void Delete(TDTO obj)
        {
            service.Delete(iMapper.Map<T>(obj));
        }

        public void DeleteById(int id)
        {
            service.DeleteById(id);
        }

        public int Insert(TDTO obj)
        {
            return service.Insert(iMapper.Map<T>(obj));
        }

        public IEnumerable<TDTO> SelectAll()
        {
            return iMapper.Map<IEnumerable<TDTO>>(service.SelectAll());
        }

        public TDTO SelectById(int id)
        {
            return iMapper.Map<TDTO>(service.SelectById(id));
        }

        public T Update(TDTO obj)
        {
            return service.Update(iMapper.Map<T>(obj));
        }
    }
}
