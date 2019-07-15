using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.Models.Models;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button_Click(object sender, EventArgs e)
        {
            tabControl2.SelectTab(tabPage2);
            buttonTabpage1.BackColor = Color.LightGray;
            buttonTabPage2.BackColor = Color.LightSlateGray;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl2.SelectTab(tabPage2);
            buttonTabpage1.BackColor = Color.LightGray;
            buttonTabPage2.BackColor = Color.LightSlateGray;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            UserID userID = new UserID();
            userID.UserName = textBoxUser.Text;
            if (userID.UserName == "")
            {
                MessageBox.Show("Insert A User Name");
                return;
            }

            if (IsExsist() == true)
            {
                tabControl2.SelectTab(tabPage2);
                buttonTabpage1.BackColor = Color.LightGray;
                buttonTabpage1.Enabled = true;
                buttonTabPage2.Enabled = true;
            }

            else
            {
                MessageBox.Show("Wrong Password OR User");
            }
        }

        bool IsExsist()
        {
            bool isok = false;

            if (textBoxUser.Text == "admin" && Convert.ToInt32(textBoxPassword.Text) == 12345)
            {

                isok = true;
            }


            return isok;
        }
    }
}
