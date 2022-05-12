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
    public partial class Form1 : Form
    {
        int i = 0;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void User_TXT_OnValueChanged(object sender, EventArgs e)
        {
           

        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            annouce_lbl.ForeColor = Color.Red;
            if (User_TXT.Text == "admin" && pass_txt.Text == "1")
            {
                annouce_lbl.ForeColor = Color.SteelBlue;
                annouce_lbl.Text = "đăng nhập thành công !";
                Form form = new QL();
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            else if (User_TXT.Text == "NV1" && pass_txt.Text == "1")
            {
                annouce_lbl.ForeColor = Color.SteelBlue;
                annouce_lbl.Text = "đăng nhập thành công !";
                Form form = new NV();
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            else if (pass_txt.Text == "" && User_TXT.Text == "")
            {
                annouce_lbl.Text = "không để trống tên đăng nhập và mật khẩu!! ";
            }
            else
            {
                annouce_lbl.Text = "nhập sai mật khẩu hoặc tên tài khoản!! ";
            }
        }

        private void pass_txt_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void pass_txt_OnValueChanged_1(object sender, EventArgs e)
        {
            pass_txt.isPassword = true;
        }

        private void display_btn_Click(object sender, EventArgs e)
        {
            
            i++;
            if(i%2 != 0 )
            {
                pass_txt.isPassword=false;
            }
            else
            {
                pass_txt.isPassword=true;
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
