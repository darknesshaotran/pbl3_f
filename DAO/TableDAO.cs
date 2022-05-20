using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TableDAO();
                return instance;
            }
        }
        private TableDAO() { }
         
        public DataTable GetListTable()
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("USP_GetListTable");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
