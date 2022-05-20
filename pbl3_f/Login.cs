using BUS;
using DTO;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace pbl3_f
{
    public partial class Login : Form
    {
        int i = 0;
        public Login()
        {
            InitializeComponent();

        }
        private void Login_btn_Click(object sender, EventArgs e)
        {
            AccountDTO account = new AccountDTO(txtUser.Text, txtPass.Text);
            object kq = AccountBUS.Instance.CheckLogin(account);
            int code = Convert.ToInt32(kq);
            if (code == 0)
            {
                lblAnnouce.Text = "Đăng nhập thành công !!";
                Thread.Sleep(100);
                QL ql = new QL();
                this.Hide();
                ql.ShowDialog();
                this.Show();
                txtUser.Text = "";
                txtPass.Text = "";
                lblAnnouce.Text = "";
                txtUser.Focus();
            }
            else if (code == 1)
            {
                lblAnnouce.Text = "Đăng nhập thành công !!";
                Thread.Sleep(100);
                NV nv = new NV();
                this.Hide();
                nv.ShowDialog();
                this.Show();
                txtUser.Text = "";
                txtPass.Text = "";
                lblAnnouce.Text = "";
                txtUser.Focus();
            }
            else MessageBox.Show("Vui lòng nhập đúng tài khoản hoặc mật khẩu", "Cảnh báo đăng nhập!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pass_txt_OnValueChanged_1(object sender, EventArgs e)
        {
            txtPass.isPassword = true;
        }

        private void display_btn_Click(object sender, EventArgs e)
        {

            i++;
            if (i % 2 != 0)
            {
                txtPass.isPassword = false;
            }
            else
            {
                txtPass.isPassword = true;
            }
        }
        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                Login_btn_Click(sender, e);
            }
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
