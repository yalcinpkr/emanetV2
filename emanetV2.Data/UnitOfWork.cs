using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emanetV2.Data
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._db = context;
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }

    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}

