using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private CFcontext _dbcontext;
        public CustomerRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(Customer  entity)
        {
            try
            {
                _dbcontext.Customers.Add(entity);
                _dbcontext.SaveChanges();
                try
                {
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(Customer  entity)
        {
            try
            {
                _dbcontext.Customers.Remove(entity);
                _dbcontext.SaveChanges();
                try
                {
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Customer > getAll()
        {
            try
            {
                List<Customer > rs = _dbcontext.Customers.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer  read(int id)
        {
            try
            {
                var rs = _dbcontext.Customers.FirstOrDefault(t => t.UserId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer read(string name)
        {
            try
            {
                var rs = _dbcontext.Customers.FirstOrDefault(t => t.FullName == name);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Customer read(string mail, string password, int roleId)
        {
            try
            {
                var rs = _dbcontext.Customers.FirstOrDefault(t => t.Email == mail && t.Password == password && t.RoleId == roleId);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(Customer  entity)
        {
            try
            {
                _dbcontext.Customers.Add(entity);
                _dbcontext.SaveChanges();
                try
                {
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
