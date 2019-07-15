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
using WindowsFormsApp.BLL.Manager;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        CategoryManager _categoryManager = new CategoryManager();
        Category category = new Category();
        List<DataRow> categoryList = new List<DataRow>(); 




        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                category.CatrgoryCode = textBoxCode.Text;
                category.CategoryName = textBoxName.Text;

                if (category.CatrgoryCode == "")
                {
                    MessageBox.Show("Insert A Category Code");
                    return;
                }


                if (category.CategoryName == "")
                {
                    MessageBox.Show("Insert A Category Name");
                    return;
                }

                else if (IsExsist(category) == false)
                {
                    if (buttonSave.Text == "Save")
                    {
                        int Isok = 0;
                        Isok = _categoryManager.Insert(category);

                        if (Isok > 0)
                        {
                            MessageBox.Show("Inserted");
                        }
                        else
                        {
                            MessageBox.Show("Not Inserted");
                        }

                        dataGridViewCategory.DataSource = _categoryManager.View();

                        foreach (DataRow dt in _categoryManager.View().Rows)
                        {
                            categoryList.Add(dt);
                        }
                    }

                    else
                    {
                        int Isok = 0;
                        Isok = _categoryManager.Update(category);

                        if (Isok > 0)
                        {
                            MessageBox.Show("Updated");
                            buttonSave.Text = "Save";
                        }
                        else
                        {
                            MessageBox.Show("Not Updated");
                        }
                        dataGridViewCategory.DataSource = _categoryManager.View();

                        foreach (DataRow dt in _categoryManager.View().Rows)
                        {
                            categoryList.Add(dt);
                        }
                    }

                }


                else if (IsExsist(category) == true)
                {
                    MessageBox.Show("Already Have!");
                }
                else
                {
                    MessageBox.Show("SomeThing unexpected!");
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        bool IsExsist(Category category)
        {
            bool isok = false;
            foreach (DataRow categoryrRow in categoryList)
            {
                if (category.CatrgoryCode == categoryrRow[1].ToString())
                {
                    isok = true;
                }
            }

            return isok;
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
