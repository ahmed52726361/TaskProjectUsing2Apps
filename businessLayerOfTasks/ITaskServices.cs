using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayerOfTasks
{
    public interface ITaskServices
    {
        // The Delegate/Event
        event Action OnTaskAdded;
        void AddTask(clsTask task);
        List<clsTask> GetAllTasks();

        void GetTaskDone(clsTask task);
        float GetTotalProgress();
    }
}
