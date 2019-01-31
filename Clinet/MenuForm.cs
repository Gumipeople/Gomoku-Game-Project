using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinet
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }
    
        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        void ChildForm_Closed(object sender, FormClosedEventArgs e)
        {     
            Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void singlePlayButton_Click(object sender, EventArgs e)
        {
            Hide();
            SinglePlayForm singlePlayForm = new SinglePlayForm();
            singlePlayForm.Show();
            singlePlayForm.FormClosed += new FormClosedEventHandler(ChildForm_Closed);
        }

        private void multiPlayButton_Click(object sender, EventArgs e)
        {
            Hide();
            MultiPlayForm multiPlayForm = new MultiPlayForm();
            multiPlayForm.Show();
            multiPlayForm.FormClosed += new FormClosedEventHandler(ChildForm_Closed);
        }
    }
}
