using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using System.Globalization;

namespace PBL3_Guna
{
    public partial class UC_Revenue : UserControl
    {
        public static int _id = 0;
        public static int _total;

        public UC_Revenue()
        {
            InitializeComponent();
            
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillBUS.Instance.GetListBillByDate(checkIn, checkOut);
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            ShowBill(dtpkFromDate.Value, dtpkToDate.Value);
        }
        public void ShowBill(DateTime checkIn, DateTime checkOut)
        {
            double total = 0;
            for (int i = 0; i < dtgvBill.Rows.Count - 1; i++)
            {
                total += Convert.ToDouble(dtgvBill.Rows[i].Cells[1].Value.ToString());
            }
            double total2 = Double.Parse(total.ToString(), NumberStyles.Currency, new CultureInfo("vi-VN"));

            lblTotalPrice.Text = total2.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDetialsBill_Click(object sender, EventArgs e)
        {
            //_id = Convert.ToInt32(dtgvBill.CurrentRow.Cells[0].Value.ToString());
            //_total = Convert.ToInt32(dtgvBill.CurrentRow.Cells[1].Value.ToString());
           
            
            //DetailsBill detailsBill = new DetailsBill();
            //detailsBill.ShowDialog();
        }
    }
}
