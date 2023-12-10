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
using Repositories_Do_An.IRepositories;
using Repositories_Do_An.IRepositories.Users;
using Services_Do_An.DTOModels;

namespace Services_Do_An.Services
{
    public class PublicService : IServices.IPublicService
    {
        private readonly IContactionRepository contactionDB;
        private readonly ICustomerRepository customerDB;
        private readonly IDriverRepository driverDB;
        private readonly IMapper mapper;
        private readonly IDriverRateRepository driverRateDB;
        public PublicService(IDriverRateRepository driverRateDB, IDriverRepository driverDB,ICustomerRepository customerDB,IMapper mapper, IContactionRepository contactionDB) {
            this.customerDB = customerDB;
            this.contactionDB = contactionDB;
            this.mapper = mapper;
            this.driverDB = driverDB;
            this.driverRateDB = driverRateDB;
        }
        public bool create(Object e) => false;
        public bool delete(Object e) => false;
        public bool update(Object e) => false;
        public Object read(int id) => null;
        public Object read(string name) => null;


        public CustomerModel getCustomer(int customerId)
        {
            try
            {
                Customer customer = customerDB.read(customerId);
                CustomerModel customerModel = mapper.Map<CustomerModel>(customer);
                return customerModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Comment_DriverModel getDriver(int driverId)
        {
            try
            {
                Driver driver = driverDB.read(driverId);
                DriverModel driverModel = mapper.Map<DriverModel>(driver);
                List<DriverRate> driverRates = driverRateDB.getAll(driverId);
                List<DriverRateModel> driverRateModels = new List<DriverRateModel>();
                foreach (var each in driverRates)
                {
                    driverRateModels.Add(mapper.Map<DriverRateModel>(each));
                }
                var rs = new Comment_DriverModel() { driver = driverModel, driverRateList = driverRateModels };
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public bool createContaction(ContactionModel contaction)
        {
            try
            {
                var rs = mapper.Map<Contaction>(contaction);
                Random random = new Random();
                rs.StaffId = random.Next(1, 4);
                return contactionDB.create(rs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
