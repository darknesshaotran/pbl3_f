using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ItemDAO
    {
        private static ItemDAO instance;
        public static ItemDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ItemDAO();
                return instance;
            }
        }
        public DataTable GetItemByIDCategory(int id)
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("select * from Item where IDCategory = " + id);
            }    
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
