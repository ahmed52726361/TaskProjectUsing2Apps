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
    public partial class frmAddTask : Form
    {
        public string TaskTitle => txtdescription.Text;
        public frmAddTask()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtdescription.Text))
            {
                MessageBox.Show("Task is empty, you should input a task");
                return;
            }
            this.DialogResult = DialogResult.OK;

        }
    }
}
