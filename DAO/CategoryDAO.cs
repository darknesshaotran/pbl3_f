using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryDAO();
                return instance;
            }
        }
        public DataTable GetListCategory()
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("Select * from dbo.ItemCategory");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }
    }
}
