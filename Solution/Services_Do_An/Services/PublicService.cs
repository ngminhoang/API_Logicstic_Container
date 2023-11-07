using AutoMapper;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories.Others;
using Services_Do_An.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services_Do_An.Services
{
    public class PublicService : IServices.IPublicService
    {
        private readonly IContactionRepository contactionDB;
        private readonly IMapper mapper;
        public PublicService(IMapper mapper, IContactionRepository contactionDB) {
            this.contactionDB = contactionDB;
            this.mapper = mapper;
        }
        public bool create(Object e) => false;
        public bool delete(Object e) => false;
        public bool update(Object e) => false;
        public Object read(int id) => null;
        public Object read(string name) => null;
        public bool createContaction(Contaction contaction)
        {
            try
            {
                return contactionDB.create(contaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
