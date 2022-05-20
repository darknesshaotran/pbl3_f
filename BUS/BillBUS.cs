using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return instance;
            }
        }
        public int GetUnCheckIDBillByIDTable(int id)
        {
            try
            {
                return DAO.BillDAO.Instance.GetUnCheckIDBillByIDTable(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
