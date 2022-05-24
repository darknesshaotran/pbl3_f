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
                //ItemDTO item = new ItemDTO(dr);
                //list.Add(item);
                list.Add(ItemDAO.Instance.getItemByDataRow(dr));
            }    
            return list;

        }
        public List<ItemDTO> GetItemByName(string name)
        {
            List<ItemDTO> li = new List<ItemDTO>();
            foreach(ItemDTO i in ItemDAO.Instance.getAllItem())
            {
                if(i.Name.Contains(name))
                {
                    li.Add(i);
                }
            }
            return li;
        }
        public bool Check(int id)
        {
            bool isAdded = true;
            foreach (ItemDTO i in ItemDAO.Instance.getAllItem())
            {
                if (id == i.ID)
                {
                    isAdded = false;
                }
            }
            return isAdded;
        }
        public void AddUpdateItem(ItemDTO item)
        {
            if (Check(item.ID))
            {

                ItemDAO.Instance.AddItemDAO(item);
            }
            else
            {
                ItemDAO.Instance.updateItemDAO(item);
            }
        }
        public void DeleteItem(int ItemtoDelete)
        {
            try
            {
                ItemDAO.Instance.deleteItemDAO(ItemtoDelete);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
