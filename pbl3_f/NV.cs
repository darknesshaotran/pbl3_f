using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAO;
using BUS;
using System.Globalization;
using System.Threading;
using BillDAO = DAO.BillDAO;

namespace pbl3_f
{
    public partial class NV : Form
    {
        public NV()
        {
            InitializeComponent();
            LoadTable();    
            LoadCatergory();
        }
        #region methods
        void LoadCatergory()
        {
            List<CategoryDTO> listCategory = CategoryBUS.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }
        void LoadItemListByIDCategory(int id)
        {
            List<ItemDTO> listItem = ItemBUS.Instance.GetItemByIDCategory(id);
            cbItem.DataSource = listItem;
            cbItem.DisplayMember = "Name";
        }
        void LoadTable()
        {
            List<TableDTO> tableList = TableBUS.Instance.GetListTable();
            foreach(TableDTO item in tableList)
            {
                Button btn = new Button() { Width = TableBUS.TableWidth, Height = TableBUS.TableHeight};
                btn.Text = item.Name + "\n" + item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;
                switch(item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.AliceBlue;
                        break;
                    default:
                        btn.BackColor = Color.Red;
                        break;

                }
                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lvBill.Items.Clear();
            List<TempBillDTO> listBillInfor = TempBillBUS.Instance.GetListTempBillByTableID(id);
            float TotalPrice = 0;
            foreach(TempBillDTO item in listBillInfor)
            {
                ListViewItem listView = new ListViewItem(item.ItemName.ToString());
                listView.SubItems.Add(item.AmountItem.ToString());
                listView.SubItems.Add(item.Price.ToString());
                listView.SubItems.Add(item.TotalPrice.ToString());
                TotalPrice += item.TotalPrice;
                lvBill.Items.Add(listView);
            }    
            CultureInfo culture = new CultureInfo("vi-VN");

            

            txbTotalPrice.Text = TotalPrice.ToString("c", culture);
        }
        #endregion methods

        #region events
        private void Btn_Click(object sender, EventArgs e)
        {
            int IDTable = ((sender as Button).Tag as TableDTO).ID;
            lvBill.Tag = (sender as Button).Tag;
            ShowBill(IDTable);
            
        }
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Home_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            color_home.Normalcolor = Color.OrangeRed;
            color_order.Normalcolor = Color.Black;
            color_infor.Normalcolor = Color.Black;
            Home_btn.Textcolor = Color.OrangeRed;
            bunifuFlatButton2.Textcolor = Color.White;
            bunifuFlatButton3.Textcolor = Color.White;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            color_home.Normalcolor = Color.Black;
            color_order.Normalcolor = Color.OrangeRed;
            color_infor.Normalcolor = Color.Black;
            bunifuFlatButton2.Textcolor = Color.OrangeRed;
            Home_btn.Textcolor = Color.White;
            bunifuFlatButton2.Textcolor = Color.OrangeRed;
            bunifuFlatButton3.Textcolor = Color.White;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            color_home.Normalcolor = Color.Black;
            color_order.Normalcolor = Color.Black;
            color_infor.Normalcolor = Color.OrangeRed;
            Home_btn.Textcolor = Color.White;
            bunifuFlatButton2.Textcolor = Color.White;
            bunifuFlatButton3.Textcolor = Color.OrangeRed;
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Form f = new Profile();
            f.ShowDialog();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Form f = new ChangePass();
            f.ShowDialog();
        }

        #endregion events

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            CategoryDTO category = cb.SelectedItem as CategoryDTO;
            id = category.ID;

            LoadItemListByIDCategory(id);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            
            TableDTO tableDTO = lvBill.Tag as TableDTO;
            int idBill = BillDAO.Instance.GetUnCheckIDBillByIDTable(tableDTO.ID);
            int idItem = (cbItem.SelectedItem as ItemDTO).ID;
            int amount = (int)nmItemAmount.Value;
            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(tableDTO.ID);
                BillInforDAO.Instance.InsertBillInfor(BillDAO.Instance.GetMaxIDBill(), idItem, amount);
            }
            else
            {
                BillInforDAO.Instance.InsertBillInfor(idBill, idItem, amount);
            }
            ShowBill(tableDTO.ID);
        }
    }
}
