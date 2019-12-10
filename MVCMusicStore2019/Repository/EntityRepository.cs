using MVCMusicStore2019.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Repository
{
    public class EntityRepository<T>:IEntityRepository<T> where T:class, IEntity,new()
    {
        //private static IList<T> list;
        readonly DbContext _context;
        public EntityRepository(DbContext context)
        {
            //list = new List<T>();
            //T bo = new T();
            _context = context;
        }
        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
        public virtual void Create(T entity)
        {
            DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
        }
        public virtual void Save()
        {
            _context.SaveChanges();
        }
        public virtual void AddAndSave(T entity)
        {
            Create(entity);
            Save();
        }
        public virtual void Delete(int objectId)
        {
            var dbSet = _context.Set(typeof(T));
            var returnStatus = true;
            var returnMessage = "";
            var bo = dbSet.Find(objectId);
            if (bo == null)
            {
                returnStatus = false;
                returnMessage = "你所删除的数据不存在。";
            }
            else
            {
                if (returnStatus)
                {
                    try
                    {
                        dbSet.Remove(bo);
                        _context.SaveChanges();
                        returnMessage = "删除成功。";
                    }
                    catch
                    {
                        returnStatus = false;
                        returnMessage = "删除失败。";
                    }
                }
            }
        }
        public virtual T FindSingle(Guid Id)
        {
            return GetAll().FirstOrDefault(x => x.Id == Id);
        }
        public virtual void Edit(T entity)
        {
            DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
            Save();
        }
        public virtual T GetSingleById(Guid id)
        {
            return _context.Set<T>().Where(x => x.Id == id).First();
        }

        public T FindSingle(int objectId)
        {
            throw new NotImplementedException();
        }
        public bool Delete(Guid id)
        {
            var dbSet = _context.Set(typeof(T));//获取实体的数据集
            bool returnStatus = true;//定义状态值
            var entity = dbSet.Find(id);//根据id查找数据集中的一条
            if (entity == null)
            {
                returnStatus = false;//当查找结果为空时返回false
                return returnStatus;
            }
            else
            {
                if (returnStatus)
                {
                    try
                    {
                        dbSet.Remove(entity);//当查找结果为true，移除本次查找记录
                        _context.SaveChanges();//保持、存盘
                        return returnStatus;
                    }
                    catch
                    {
                        returnStatus = false;
                    }
                }
            }
            return returnStatus;
        }
        /// <summary>
        /// 获取关联类的数据集
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <returns></returns>

        public virtual IQueryable<T1> GetRelevance<T1>()
        {
            var dbList = _context.Set(typeof(T1));
            var query = dbList as IQueryable<T1>;
            return query;
        }
        public virtual T1 GetSingleRelevance<T1>(Guid id)
        {
            var dbSet = _context.Set(typeof(T1));
            return (T1)dbSet.Find(id);
        }
    }
}