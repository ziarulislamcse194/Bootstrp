using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp.Repository.Repository;
using WindowsFormsApp.Models.Models;

namespace WindowsFormsApp.BLL.Manager
{
    public class CategoryManager
    {
        CategoryyRepository _categoryyRepository = new CategoryyRepository();

        public int Insert(Category category)
        {
            return _categoryyRepository.Insert(category);
        }

        public int Update(Category category)
        {
            return _categoryyRepository.Update(category);
        }

        public DataTable View()
        {
            return _categoryyRepository.View();
        }

    }
}
