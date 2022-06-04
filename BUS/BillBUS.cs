using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BillBUS
    {
        private static BillBUS instance;
        public static BillBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillBUS();
                return instance;
            }
        }
        public int GetUnCheckIDBillByIDTable(int id)
        {
            try
            {
                return BillDAO.Instance.GetUnCheckIDBillByIDTable(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetDateByID(int id)
        {
            return BillDAO.Instance.GetDateByID(id);
        }
        public DataTable GetListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            try
            {
                return BillDAO.Instance.GetListBillByDate(checkIn, checkOut);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertBill(int id)
        {
            try
            {
                BillDAO.Instance.InsertBill(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetMaxIDBill()
        {
            try
            {
                return BillDAO.Instance.GetMaxIDBill();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void CheckOut(int id, int discount, double TotalPrice)
        {
            try
            {
                BillDAO.Instance.CheckOut(id, discount, TotalPrice);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
