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
    public class ItemBUS
    {
        private static ItemBUS instance;
        public static ItemBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ItemBUS();
                return instance;
            }
        }
        public List<ItemDTO> GetItemByIDCategory(int id)
        {
            DataTable data;
            try
            {
                data = ItemDAO.Instance.GetItemByIDCategory(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            List<ItemDTO> list = new List<ItemDTO>();
            foreach (DataRow dr in data.Rows)
            {
                ItemDTO item = new ItemDTO(dr);
                list.Add(item);
            }    
            return list;

        }
    }
}
