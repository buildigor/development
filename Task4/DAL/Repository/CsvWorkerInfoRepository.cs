using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Repository.Interfaces;
using Model;
using CsvWorkerInfo = DAL.Models.CsvWorkerInfo;

namespace DAL.Repository
{
    class CsvWorkerInfoRepository:IRepository<Models.CsvWorkerInfo>
    {
        private readonly DataModelContainer _context;

        public CsvWorkerInfoRepository(DataModelContainer context)
        {
            _context = context;
        }

        public void Create(CsvWorkerInfo csvWorkerInfo)
        {
            Mapper.Initialize(cfg=>cfg.CreateMap<Models.CsvWorkerInfo,Model.CsvWorkerInfo>());
            _context.CsvWorkerInfoes.Add(Mapper.Map<Models.CsvWorkerInfo, Model.CsvWorkerInfo>(csvWorkerInfo));
        }

        public int? GetId(CsvWorkerInfo item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CsvWorkerInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public CsvWorkerInfo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CsvWorkerInfo item)
        {
            throw new NotImplementedException();
        }
    }
}
