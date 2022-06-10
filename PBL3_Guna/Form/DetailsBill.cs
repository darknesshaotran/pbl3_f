using BUS;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_Guna
{
    public partial class DetailsBill : Form
    {
        public DetailsBill()
        {
            InitializeComponent();
            GUI();
            showBill();
        }

        private void DetailsBill_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        public void GUI()
        {
            bool a = true;
            int id = UC_Revenue._id;
            if (UC_Revenue._id == 0)
            {
                a = false;
                id = UC_Information._id;
            }

            DataTable dt = BillInforBUS.Instance.GetListBillInfor(id);
            DataTable dt2 = DataProvider.Instance.ExecuteQuery("SELECT IDTable FROM dbo.Bill WHERE ID = " + id);
            int table = Convert.ToInt32(dt2.Rows[0]["IDTable"].ToString());
            txtTable.Text = table.ToString();
            txt_id.Text =  id.ToString();
            BillDTO bill = BillBUS.Instance.getBillByID(id);
            txtDate.Text = bill.DateCheckOut.ToString();

            if (a)
            {
                txtToTal.Text = UC_Revenue._total + " đ";
            }
            else txtToTal.Text = UC_Information._total + " đ";

        }
        void showBill()
        {

            int id = UC_Revenue._id;
            if (UC_Revenue._id == 0)
            {
                id = UC_Information._id;
            }

            lvBill.Items.Clear();
            List<BillInforDTO> list = BillInforBUS.Instance.getListInforBill(id);
            foreach (BillInforDTO b in list)
            {
                ItemDTO item = ItemBUS.Instance.getItemByID(Convert.ToInt32(b.IDItem.ToString()));

                ListViewItem listview = new ListViewItem(item.Name.ToString());
                listview.SubItems.Add(b.Amount.ToString());
                listview.SubItems.Add(item.Price.ToString());
                listview.SubItems.Add((Convert.ToInt32(item.Price.ToString()) * Convert.ToInt32(b.Amount.ToString())).ToString());
                lvBill.Items.Add(listview);


            }



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
