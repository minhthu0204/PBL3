using Microsoft.Reporting.WinForms;
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
    public partial class FrmInhoadon : Form
    {
        private  SaleManager saleManager;
        //private FormSale formSale;
        public FrmInhoadon(SaleManager saleManager)
        {
            InitializeComponent();
            this.saleManager = saleManager;
            //this.formSale = new FormSale();
        }

        private void FrmInhoadon_Load_1(object sender, EventArgs e)
        {
            double tongtienhang = this.saleManager.Tongtienhang;
            double tongkhoiluong = this.saleManager.Tongkhoiluong;
            string tenkhachhang = this.saleManager.TenKhachHang;
            string sodienthoai = this.saleManager.UID_Khachhang;
            //double tongtienhang = this.formSale.Tongtienhang;
            //double tongkhoiluong = this.formSale.Tongkhoiluong;
            //string tenkhachhang = this.formSale.TenKhachHang;
            //string sodienthoai = this.formSale.UID_Khachhang;

            ReportParameter Tongtienhang = new ReportParameter("Tongtienhang", tongtienhang.ToString());
            // tao cac paramerter hien thi dulieu vao bao cao report

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { Tongtienhang });
            ReportParameter Tongkhoiluong = new ReportParameter("Tongkhoiluong", tongkhoiluong.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { Tongkhoiluong });
            ReportParameter TenKhachHang = new ReportParameter("TenKhachHang", tenkhachhang);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { TenKhachHang });
            ReportParameter UID_Khachhang = new ReportParameter("UID_Khachhang", sodienthoai);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { UID_Khachhang });
            this.reportViewer1.RefreshReport();
        }
    }
}
