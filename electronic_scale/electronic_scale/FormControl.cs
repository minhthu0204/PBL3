using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace electronic_scale
{

    public partial class FormControl : Form
    {
        private Form activeForm;
        public FormControl()
        {
            InitializeComponent();
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;         // loại  bỏ đi các đường viền để cho form con giống với form cha
            childForm.Dock = DockStyle.Fill;                          // thuộc tính dock fill lấp đầy toàn bộ không gian của form cha
            this.panel_Body.Controls.Add(childForm);
            this.panel_Body.Tag = childForm;                              // thêm form con vào trong panel 4
            childForm.BringToFront();                                 // đẩy form con mới lên dể nó hiển thị phía trước 
            childForm.Show();                                         // hiển thị lên màn hình ở trong panel 4
        }



        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            OpenChildForm(new SaleManager(), sender);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            OpenChildForm(new FormHome(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;
            OpenChildForm(new FormProduct(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button4.Height;
            SidePanel.Top = button4.Top;
            OpenChildForm(new FormUpdate(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to close the application?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
