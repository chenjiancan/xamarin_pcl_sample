using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace DB.DataLayer
{
    public class Database<T> : SQLiteConnection where T : DB.BusinessLayer.Contracts.IBusinessEntity, new()
    {
        static object locker = new object();

        // path 指定数据库文件路径和名字
        public Database(string path) : base(path)
        {
            CreateTable<T>();
        }

        public T GetItem(int id)
        {
            lock (locker)
            {
                return Table<T>().FirstOrDefault(x => x.ID == id);
            }
        }

        public IEnumerable<T> GetItems()
        {
            lock (locker)
            {
                return (from item in Table<T>() select item).ToList();
            }
        }

        public int SaveItem(T item)
        {
            lock (locker)
            {
                if(item.ID != 0)
                {
                    Update(item);
                    return item.ID;
                }else
                {
                    return Insert(item);
                }
            }
        } 

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return Delete(new T() { ID = id  });
            }
        }

    }
}
