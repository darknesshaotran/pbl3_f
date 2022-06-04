using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BillInforBUS
    {
        private static BillInforBUS instance;
        public static BillInforBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillInforBUS();
                return instance;
            }
        }
        public List<BillInforDTO> GetListBillInfor(int id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = BillInforDAO.Instance.GetListBillInfor(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            List<BillInforDTO> listBilInfor = new List<BillInforDTO>();
            foreach(DataRow dr in dataTable.Rows)
            {
                BillInforDTO billInfor = new BillInforDTO(dr);
                listBilInfor.Add(billInfor);
            }
            return listBilInfor;
        }
        public void InsertBillInfor(int idbill, int iditem, int amount)
        {
            try
            {
                BillInforDAO.Instance.InsertBillInfor(idbill, iditem, amount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
