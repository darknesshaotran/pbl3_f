using BUS;
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
    public partial class UC_Information : UserControl
    {
        public UC_Information()
        {
            InitializeComponent();
            LoadListBillByDate(DateTime.Now, DateTime.Now);

        }

        void LoadListBillByDate(DateTime CheckIn, DateTime CheckOut)
        {
            dtgvInfor.DataSource = BillBUS.Instance.GetListBillByDate(CheckIn, CheckOut);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form f = new DetailsBill();
            f.ShowDialog();
        }
    }
}
