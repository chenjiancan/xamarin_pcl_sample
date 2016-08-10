using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DB.BusinessLayer;

namespace DB.DataAccessLayer
{
    /// <summary>
    /// PCL 的特点是代码是所有平台公用的，不能包含任何平台代码，也不支持编译时通过 宏定义来区分平台
    // 不同平台的文件路径不一样，所以这部分代码要移到 platform spec 项目中去完成
    // 这里数据库的路径要设置为从外部传入，对于安卓，就在 application 初始化中定义路径
    /// </summary>
    public class TaskRepository
    {
        DataLayer.Database<Task> db = null;
        protected static string dbLocation;
        protected static TaskRepository me;

        /// <summary>
        /// should be use be use Instance()
        /// </summary>
        /// <param name="path"></param>
        public static void SetPath(string path)
        {
            dbLocation = path;
        }

        public static TaskRepository Instance
        {
            get { return getInstance(); }
        }

        protected static TaskRepository getInstance()
        {
            if (me != null)
            {
                return me;
            }
            else
            {
                me = new TaskRepository();
                return me;
            }
        }

        protected TaskRepository()
        {
            // set the db location
            if (dbLocation == "")
            {
                throw new System.Exception("dbLocation member should be assign a value in advanced!");
            }
            // instantiate the database	
            db = new DataLayer.Database<Task>(dbLocation);
        }
         

        public Task GetTask(int id)
        {
            return db.GetItem(id);
        }

        public IEnumerable<Task> GetTasks()
        {
            return db.GetItems();
        }

        public int SaveTask(Task task)
        {
            return db.SaveItem(task);
        }

        public int DeleteTask(int id)
        {
            return db.DeleteItem(id);
        }
    }
}
