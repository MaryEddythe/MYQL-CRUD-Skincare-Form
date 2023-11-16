﻿using System;
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
    public partial class mainpane1 : Form
    {
        public mainpane1()
        {
            InitializeComponent();
        }
        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
            {
                this.mainpanel.Controls.RemoveAt(0);
            }

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            pictureBox3.Hide();

            f.Show();
        }



        private void home_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadform(new Form1());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadform(new Collection());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadform(new About_Us());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadform(new User());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
