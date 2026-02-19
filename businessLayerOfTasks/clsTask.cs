using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace businessLayerOfTasks
{
    public class clsTask
    {
        public string Title { get; set; }

        public bool IsCompleted { get; set; } = false;

        public clsTask() { }

        public clsTask(string title)
        {
            Title = title;
        }
    }
}
