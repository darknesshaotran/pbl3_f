using DTO;
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
        public List<ItemDTO> getAllItem()
        {
            List<ItemDTO> data  = new List<ItemDTO>();
            string query = "select * from Item";
            foreach(DataRow  i in DataProvider.Instance.ExecuteQuery(query).Rows)
            {
                data.Add(getItemByDataRow(i));
            } 
            return data;

        }
        public ItemDTO getItemByDataRow(DataRow i)
        {
            
                return new ItemDTO
                {

                    ID = Convert.ToInt32(i["ID"].ToString()),
                    Name = i["Name"].ToString(),
                    IDCategory = Convert.ToInt32(i["IDCategory"].ToString()),
                    Price = (float)Convert.ToDouble(i["Price"].ToString())
                 };
           
            
        }
        public void AddItemDAO(ItemDTO item)
        {
            string query = "insert into Item values( @Name , @IDCategory , @Price )";
            DataProvider.Instance.ExecuteNonQuery(query,new Object []{  item.Name, item.IDCategory, item.Price});
            
        }
        public void updateItemDAO(ItemDTO item)
        {
            string query = "update Item set Name = @Name , IDCategory = @IDCategory , Price = @Price where ID = @ID";
            DataProvider.Instance.ExecuteNonQuery(query, new Object[] {  item.Name, item.IDCategory, item.Price , item.ID });
        }
        public void deleteItemDAO(int ID)
        {
            string query = "delete from Item where ID =" + ID ;
           DataProvider.Instance.executeDB(query);
        }
    }
}
