using BUS;
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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string s = bunifuMaterialTextbox1.Text;
            string s2 = s.Trim();
            
            if (s2  != "")
            {
                CategoryDTO CT = new CategoryDTO();
                CT.Name = bunifuMaterialTextbox1.Text;

                CategoryBUS.Instance.AddCategory(CT);
                this.Close();
            }
            else MessageBox.Show(" vui lòng nhập lại !");
            
        }
    }
}
