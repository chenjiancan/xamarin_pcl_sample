using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB.BusinessLayer;
using DB.DataAccessLayer;

namespace DB.BusinessLayer.Managers
{
    public class TaskManager
    {
        //protected static TaskRepository taskRepository;

        public static void SetPath(string path)
        {
            TaskRepository.SetPath(path);
        }

        static TaskManager()
        {
            //taskRepository = TaskRepository.Instance;
        }

        public static Task GetTask(int id)
        {
            //return taskRepository.GetTask(id);
            return TaskRepository.Instance.GetTask(id);
        }

        public static IList<Task> GetTasks()
        {
            //return new List<Task>(taskRepository.GetTasks());
            return new List<Task>(TaskRepository.Instance.GetTasks());
        }

        public static int SaveTask(Task task)
        {
            //return taskRepository.SaveTask(task);
            return TaskRepository.Instance.SaveTask(task);
        }

        public static int DeleteTask(int id)
        {
            //return taskRepository.DeleteTask(id);
            return TaskRepository.Instance.DeleteTask(id);
        }

    }
}
