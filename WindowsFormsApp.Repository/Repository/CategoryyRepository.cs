using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp.Models.Models;

namespace WindowsFormsApp.Repository.Repository
{
    public class CategoryyRepository
    {
        String connectionString = @"Server=DESKTOP-L03CHE4;Database=BusinessManagment; Integrated Security=True;";
        SqlConnection sqlConnection;


        SqlCommand sqlCommand;


        public int Insert(Category category)
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"INSERT INTO Categories (Code, Name) VALUES ('" + category.Code + "', '" + category.Name + "')";

            sqlCommand = new SqlCommand(CommendString, sqlConnection);


            sqlConnection.Open();



            int isExecuted;
            isExecuted = sqlCommand.ExecuteNonQuery();
            //int IsOK = 0;



            //IsOK = sqlCommand.ExecuteNonQuery();

            //if (IsOK > 0)
            //{
            //    MessageBox.Show("Inserted");
            //}
            //else
            //    MessageBox.Show("Not Inserted");





            sqlConnection.Close();

            return isExecuted;

        }

        public int Update(Category category)
        {

            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"update Categories set Code ='" + category.Code + "', Name ='" + category.Name + "' Where ID='" + category.ID + "'";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);


            sqlConnection.Open();


            int IsOK = 0;



            IsOK = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return IsOK;

        }

        public DataTable View()
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"Select *From Categories";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);




            sqlConnection.Open();
            DataTable dataTable = new DataTable();

            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            if (dataReader.HasRows)
            {

                dataTable.Load(dataReader);
                //dataGridViewCompany.DataSource = dataTable;

                //foreach (DataRow dt in dataTable.Rows)
                //{
                //    CompanyList.Add(dt);
                //    richTextBox1.Text = richTextBox1.Text + dt;
                //}

            }

            sqlConnection.Close();
            return dataTable;

        }
    }
}
