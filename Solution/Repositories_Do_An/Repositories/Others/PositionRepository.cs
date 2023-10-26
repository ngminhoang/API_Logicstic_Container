using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Do_An.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private CFcontext _dbcontext;
        public PositionRepository(CFcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool create(Position entity)
        {
            try
            {
                _dbcontext.Positions.Add(entity);
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

        public bool delete(Position entity)
        {
            try
            {
                _dbcontext.Positions.Remove(entity);
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

        public List<Position> getAll()
        {
            try
            {
                List<Position> rs = _dbcontext.Positions.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Position read(int id)
        {
            try
            {
                var rs = _dbcontext.Positions.FirstOrDefault(t => t.PositionId == id);
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Position read(string name) => null;

        public bool update(Position entity)
        {
            try
            {
                _dbcontext.Positions.Update(entity);
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
