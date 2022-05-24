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

namespace pbl3_f
{
    public partial class QL : Form
    {
        public QL()
        {
            InitializeComponent();
            LoadCatergory();
            showDTG_Item("");
            
        }
        void LoadCatergory()
        {
            cbb_itemCategory.Items.AddRange(CategoryBUS.Instance.GetListCategory().ToArray());
            cbb_itemCategory.DisplayMember = "Name";
            cbb_itemCategory.SelectedIndex = 0;
        }
        public void showDTG_Item(string name)
        {
            item_dgv.DataSource = ItemBUS.Instance.GetItemByName(name);


        }
        public ItemDTO getItemDataToAdd()
        {
            ItemDTO item = new ItemDTO();
           // item.ID = Convert.ToInt32(bunifuMaterialTextbox1.Text);
            item.Name = txt_ItemName.Text;
            item.IDCategory = (CategoryDAO.Instance.GetIDbyNameCategory(cbb_itemCategory.Text));
            item.Price = Convert.ToInt32(txt_PriceItem.Text);
            return item;

        }
        public ItemDTO getItemDataToUpdate()
        {
            ItemDTO item = new ItemDTO();
             item.ID = Convert.ToInt32(txt_IDItem.Text);
            item.Name = txt_ItemName.Text;
            item.IDCategory = (CategoryDAO.Instance.GetIDbyNameCategory(cbb_itemCategory.Text));
            item.Price = Convert.ToInt32(txt_PriceItem.Text);
            return item;

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
          
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
        }
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
           

        }
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
          
        }
        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
        }

        private void bunifuGradientPanel1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void bunifuGradientPanel1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QL_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tab_Home;
            Home_btn.Textcolor = Color.OrangeRed;
            waiter_btn.Textcolor = Color.White;
            Item_btn.Textcolor = Color.White;
            doanhthu_btn.Textcolor= Color.White;
            

            
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabMenu;
            Home_btn.Textcolor = Color.White;
            waiter_btn.Textcolor = Color.White;
            Item_btn.Textcolor = Color.OrangeRed;
            doanhthu_btn.Textcolor = Color.White;

        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabWaiter;
            Home_btn.Textcolor = Color.White;
            waiter_btn.Textcolor = Color.OrangeRed;
            Item_btn.Textcolor = Color.White;
            doanhthu_btn.Textcolor = Color.White;

        }

        private void bunifuFlatButton4_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabRevenue;
            Home_btn.Textcolor = Color.White;
            waiter_btn.Textcolor = Color.White;
            Item_btn.Textcolor = Color.White;
            doanhthu_btn.Textcolor = Color.OrangeRed;
        }

        private void bunifuFlatButton5_Click_1(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Form f = new ChangePass();
            f.ShowDialog();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            if (item_dgv.SelectedRows.Count == 1)
            {
                int DeleteID = Convert.ToInt32(item_dgv.CurrentRow.Cells[0].Value.ToString());
               
                ItemBUS.Instance.DeleteItem(DeleteID);
            }
            
            showDTG_Item("");
        }

        private void bunifuMaterialTextbox3_OnValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            Form form = new Category();
            form.ShowDialog();
            LoadCatergory();
            showDTG_Item("");

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Form f = new Profile();
            f.ShowDialog();
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            string name = searchItem_txt.text;
            showDTG_Item(name);
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (txt_IDItem.Text == "")
            {
                ItemDTO item = getItemDataToAdd();
                ItemBUS.Instance.AddUpdateItem(item);
                showDTG_Item("");
            }
            else 
            {
                if (ItemBUS.Instance.Check(Convert.ToInt32(txt_IDItem.Text)))
                {
                    ItemDTO item = getItemDataToAdd();
                    ItemBUS.Instance.AddUpdateItem(item);
                    showDTG_Item("");
                }
                else MessageBox.Show("item da ton  tai !!");
            }   
           
            
           
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            ItemDTO item = getItemDataToUpdate();
            ItemBUS.Instance.AddUpdateItem(item);

            showDTG_Item("");
        }

        private void item_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void item_dgv_SelectionChanged(object sender, EventArgs e)
        {
           
           txt_IDItem.Text = item_dgv.CurrentRow.Cells[0].Value.ToString();
            txt_ItemName.Text = item_dgv.CurrentRow.Cells[1].Value.ToString();
            cbb_itemCategory.Text = CategoryDAO.Instance.GetNamebyIDCategory(Convert.ToInt32(item_dgv.CurrentRow.Cells[2].Value.ToString()));
            txt_PriceItem.Text = item_dgv.CurrentRow.Cells[3].Value.ToString();

        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            showDTG_Item("");
            searchItem_txt.text = "";
        }
    }
}
