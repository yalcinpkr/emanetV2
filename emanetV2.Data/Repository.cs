using emanetV2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace emanetV2.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext db;
        private readonly DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            this.db = context;
            this.entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
        }

        public bool Draft(int? id)
        {
            try
            {
                var findEntity = entities.Find(id);
                findEntity.StatusId = (int)Statuses.Draft;
                db.Entry(findEntity).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public T GetWeb(int? id)
        {
            return entities.FirstOrDefault(x => x.Id == id && x.StatusId == (int)Statuses.Published);
        }

        public T GetAdmin(int? id)
        {
            return entities.FirstOrDefault(x => x.Id == id && x.StatusId != (int)Statuses.Removed);
        }
        public IList<T> GetAllByMemberIdWeb(int memberId)
        {
            return entities.Where(x => x.MemberId == memberId).ToList();
        }
        public IList<T> GetLastTenEntityWeb()
        {
            return entities.Take(10).Where(x => x.StatusId == (int)Statuses.Published).OrderByDescending(x => x.CreationDate).ToList();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return entities.Where(where).ToList();
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
        }

        public bool Publish(int? id)
        {
            try
            {
                var findEntity = entities.Find(id);
                findEntity.StatusId = (int)Statuses.Published;
                db.Entry(findEntity).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(int? id)
        {
            try
            {
                var findEntity = entities.Find(id);
                findEntity.StatusId = (int)Statuses.Removed;
                db.Entry(findEntity).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Update(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;
        }

       

        public IEnumerable<T> GetAllWeb()
        {
            return entities.Where(x => x.StatusId == (int)Statuses.Published).OrderByDescending(x => x.CreationDate).ToList();
        }

        public IEnumerable<T> GetAllAdmin()
        {
            return entities.Where(x => x.StatusId != (int)Statuses.Removed).OrderByDescending(x => x.CreationDate).ToList();
        }
    }
    public interface IRepository<T> where T : BaseEntity
    {
        IList<T> GetAllByMemberIdWeb(int memberId);
        IList<T> GetLastTenEntityWeb();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetWeb(int? id);
        T GetAdmin(int? id);
        IEnumerable<T> GetAllWeb();
        IEnumerable<T> GetAllAdmin();
        bool Publish(int? id);
        bool Draft(int? id);
        bool Remove(int? id);
       
    }
}

