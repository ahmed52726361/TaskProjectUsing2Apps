using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayerOfTasks
{
    public class clsTaskServices: ITaskServices
    {
        private List<clsTask> ListOfTasks= new List<clsTask>();
        private readonly string _filePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "tasks.xml");
        public event Action OnTaskAdded;
        public clsTaskServices()
        {
            // Automatically load existing tasks on startup
            ListOfTasks = clsXmlPersistence.LoadFromFile(_filePath);
        }
        public void AddTask(clsTask task)
        {
            ListOfTasks.Add(task);
            clsXmlPersistence.SaveToFile(_filePath, ListOfTasks);
            OnTaskAdded?.Invoke();
        }
        public List<clsTask> GetAllTasks()
        {
            return ListOfTasks;
        }

        public void GetTaskDone(clsTask task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            if (task.IsCompleted)
                return; // already done

            task.IsCompleted = true;
            clsXmlPersistence.SaveToFile(_filePath, ListOfTasks);
        }
        public float GetTotalProgress()
        {
            int TotalTasks=ListOfTasks.Count;
            if (TotalTasks == 0)
                return 0;

            int Totalcompleted = 0;
            foreach (clsTask task in ListOfTasks)
            {
                if (task.IsCompleted)
                {
                    Totalcompleted++;
                }
            }

            return (float)Totalcompleted / TotalTasks;

        }

    }
}
