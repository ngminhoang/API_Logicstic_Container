using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private CFcontext _dbcontext;
        public InvoiceRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(Invoice entity)
        {
            try
            {
                _dbcontext.Invoices.Add(entity);
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

        public bool delete(Invoice entity)
        {
            try
            {
                _dbcontext.Invoices.Remove(entity);
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

        public List<Invoice> getAll()
        {
            try
            {
                List<Invoice> rs = _dbcontext.Invoices.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Invoice read(int id)
        {
            try
            {
                var rs = _dbcontext.Invoices.FirstOrDefault(t => t.InvoiceId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Invoice read(string name) => null;

        public bool update(Invoice entity)
        {
            try
            {
                _dbcontext.Invoices.Update(entity);
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
