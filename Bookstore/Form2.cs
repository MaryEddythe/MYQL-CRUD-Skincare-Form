using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookstore
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_continue_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainpane1 form1 = new mainpane1();
            form1.ShowDialog();
            this.Show();
            this.Close(); 
        }
    }

}
