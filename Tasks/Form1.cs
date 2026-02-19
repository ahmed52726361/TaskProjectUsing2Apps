using businessLayerOfTasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    // Gemini Test
    //can you see this
    public partial class Form1 : Form
    {
        private ITaskServices taskServices;
        // subscribe to the TaskAdded event to refresh the DataGridView when a new task is added
        public Form1(ITaskServices service)
        {
            InitializeComponent();
            taskServices = service;
            // SUBSCRIBE to the event using a Lambda expression
            taskServices.OnDataChanged += () =>
            {
                // This code runs AUTOMATICALLY when AddTask is called
                RefreshDataGridView();
                RefreshPrograssBar();
            };
        }
        private void RefreshPrograssBar()
        {
                float Progress = taskServices.GetTotalProgress()*100;
                lblProgress.Text = Progress.ToString()+"%";
                prgBar.Minimum = 0;
                prgBar.Maximum = 100;
                prgBar.Value = (int)(Progress);

        }
        private void RefreshDataGridView()
        {
            if (taskServices.GetAllTasks() != null && taskServices.GetAllTasks().Count!=0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource= taskServices.GetAllTasks();

            }
        }
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            frmAddTask frmAdd=new frmAddTask();
            frmAdd.ShowDialog();
            if (frmAdd.DialogResult==DialogResult.OK)
            {
                taskServices.AddTask(new clsTask(frmAdd.TaskTitle));
            }

        }


        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.DataBoundItem is clsTask task)
                {
                    taskServices.GetTaskDone(task);

                }
            }


        }

    }
}
