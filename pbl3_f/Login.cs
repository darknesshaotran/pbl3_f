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
using BUS;
using System.Threading;

namespace pbl3_f
{
    public partial class Form1 : Form
    {
        int i = 0;
        public Form1()
        {
            InitializeComponent();
           
        }


        private void Login_btn_Click(object sender, EventArgs e)
        {
            //AccountDTO accountDTO = new AccountDTO(txtUser.Text, txtPass.Text);
            //if(AccountBUS.Instance.CheckLogin(accountDTO))
            //{
            //    AccountDTO account = AccountBUS.Instance.GetAccountByUserName(accountDTO.UserName);
            //    lblAnnouce.Text = "Đăng nhập thành công !!!";
            //    Thread.Sleep(500);
            //    QL ql = new QL();
            //    this.Hide();
            //    ql.ShowDialog();
            //    this.Show();
            //    txtUser.Text = "";
            //    txtPass.Text = "";
            //    lblAnnouce.Text = "";
            //    txtUser.Focus();
            //}
            //else
            //{
            //    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            AccountDTO accountDTO = new AccountDTO(txtUser.Text, txtPass.Text);
            if(AccountBUS.Instance.CheckLoginTypeID(accountDTO) == true)
            {
                AccountDTO account = AccountBUS.Instance.GetAccountByTypeID(accountDTO.TypeID);
                lblAnnouce.Text = "oke";
            }
            else
            {
                lblAnnouce.Text = "sai";
            }

        }

        private void pass_txt_OnValueChanged_1(object sender, EventArgs e)
        {
            txtPass.isPassword = true;
        }

        private void display_btn_Click(object sender, EventArgs e)
        {
            
            i++;
            if(i%2 != 0 )
            {
                txtPass.isPassword=false;
            }
            else
            {
                txtPass.isPassword=true;
            }
        }

        

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                Login_btn_Click(sender, e);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
           this.KeyPress += Form1_KeyPress;

        }

        private void exit_btn_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
            {
                this.Close();
            }
        }
    }
}
