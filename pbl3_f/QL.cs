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
            showDTG_Staff("");
            
        }
        void LoadCatergory()
        {
            cbb_itemCategory.Items.Clear();
            cbb_itemCategory.Items.AddRange(CategoryBUS.Instance.GetListCategory().ToArray());
            cbb_itemCategory.DisplayMember = "Name";
            cbb_itemCategory.SelectedIndex = 0;
        }
        public void showDTG_Item(string name)
        {
            item_dgv.DataSource = ItemBUS.Instance.GetItemByName(name);


        }
        public void showDTG_Staff(string name)
        {
            dgv_Staff.DataSource = StaffBUS.Instance.GetStaffByName(name);
        }
        public ItemDTO getItemDataToAdd()
        {
            ItemDTO item = new ItemDTO();
            item.Name = txt_ItemName.Text;
            item.IDCategory = (CategoryDAO.Instance.GetIDbyNameCategory(cbb_itemCategory.Text));
            item.Price = Convert.ToInt32(txt_PriceItem.Text);
            return item;

        }
        public StaffDTO getStaffDataToAdd()
        {
            StaffDTO staff = new StaffDTO();
            staff.Name = txt_NameStaff.Text;
            staff.Address = txt_Address.Text;
            staff.Age = Convert.ToInt32(age_txt.Text);
            staff.PhoneNumber = txt_PhoneNumber.Text;
            return staff;

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
        public StaffDTO getStaffDataToUpdate()
        {
            StaffDTO staff = new StaffDTO();
            staff.ID = Convert.ToInt32(txt_IDstaff.Text);
            staff.Name = txt_NameStaff.Text;
            staff.Address = txt_Address.Text;
            staff.Age = Convert.ToInt32(age_txt.Text);
            staff.PhoneNumber = txt_PhoneNumber.Text;
            return staff;

        }
        public AccountDTO getDataToCreateAccount()
        {
            AccountDTO account = new AccountDTO();
            account.UserName = txt_UserName.Text;
            account.DisplayName = txt_NameStaff.Text;
            account.Password = txt_passwordStaff.Text;
            return account;
        }
////////////////////////////////////////////////////
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
        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            if (item_dgv.SelectedRows.Count == 1)
            {
                int DeleteID = Convert.ToInt32(item_dgv.CurrentRow.Cells[0].Value.ToString());
               
                ItemBUS.Instance.DeleteItem(DeleteID);
            }
            
            showDTG_Item("");
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

        private void btn_AddStaff_Click(object sender, EventArgs e)
        {
            if (txt_IDstaff.Text == "")
            {
                StaffDTO staff = getStaffDataToAdd();
                AccountDTO account = getDataToCreateAccount();
                StaffBUS.Instance.AddUpdateStaff(staff);
                showDTG_Staff("");
                account.IDStaff = Convert.ToInt32(dgv_Staff.Rows[dgv_Staff.Rows.Count - 1].Cells[0].Value.ToString());
                AccountBUS.Instance.AddAccountBUS(account);
                txt_passwordStaff.Text = "";

            }
            else
            {
                if (StaffBUS.Instance.Check(Convert.ToInt32(txt_IDstaff.Text)))
                {
                    StaffDTO staff = getStaffDataToAdd();
                    AccountDTO account = getDataToCreateAccount();
                    StaffBUS.Instance.AddUpdateStaff(staff);                  
                    showDTG_Staff("");
                    account.IDStaff = Convert.ToInt32(dgv_Staff.Rows[dgv_Staff.Rows.Count - 1].Cells[0].Value.ToString());
                    AccountBUS.Instance.AddAccountBUS(account);
                    txt_passwordStaff.Text = "";

                }
                else MessageBox.Show("nhan vien da ton tai !!");
            }
        }

        private void button_searchStaff_Click(object sender, EventArgs e)
        {
            string name = txt_searchStaff.text;
            showDTG_Staff(name);
        }

        private void btn_updateStaff_Click(object sender, EventArgs e)
        {
            

            StaffDTO staff = getStaffDataToUpdate();
           
            
                StaffBUS.Instance.AddUpdateStaff(staff);
            
            showDTG_Staff("");
        }

        private void btn_deleteStaff_Click(object sender, EventArgs e)
        {
            if (dgv_Staff.SelectedRows.Count == 1)
            {
                int DeleteID = Convert.ToInt32(dgv_Staff.CurrentRow.Cells[0].Value.ToString());
                StaffBUS.Instance.DeleteStaff(DeleteID);
                AccountBUS.Instance.DeleteAcount(DeleteID);
            }

            showDTG_Staff("");
        }

        private void btn_showStaff_Click(object sender, EventArgs e)
        {
            showDTG_Staff("");
            txt_searchStaff.text = "";
        }

        private void dgv_Staff_SelectionChanged(object sender, EventArgs e)
        {
            txt_IDstaff.Text = dgv_Staff.CurrentRow.Cells[0].Value.ToString();
            txt_NameStaff.Text = dgv_Staff.CurrentRow.Cells[1].Value.ToString();
            txt_Address.Text = dgv_Staff.CurrentRow.Cells[2].Value.ToString();
            age_txt.Text = dgv_Staff.CurrentRow.Cells[3].Value.ToString();
            txt_PhoneNumber.Text = dgv_Staff.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
