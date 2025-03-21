using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QLBanSach.Models;

namespace QLBanSach
{
    public partial class ThemSach : System.Web.UI.Page
    {
        SachDAO sachDAO = new SachDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btXuLy_Click(object sender, EventArgs e)
        {
            try
            {
                int macd = int.Parse(ddlChuDe.SelectedValue);
                string tensach = txtTen.Text;                
                int dongia = int.Parse(txtDonGia.Text);
                bool khuyemmai = chkKhuyenMai.Checked;

                //xu ly upload file anh
                string hinh = FHinh.FileName;
                string path = Server.MapPath("~/bia_sach") + "/" + FHinh.FileName;
                FHinh.SaveAs(path);


                //tao doi tuong can them 
                Sach sach = new Sach { TenSach = tensach, Dongia = dongia, MaCD = macd, Hinh = hinh, KhuyenMai = khuyemmai };
                //goi phuong thuc tu lop DAO de them vao CSDL
                sachDAO.Insert(sach);

                lbthongbao.Text = "Thao tác thêm sách thành công";

            }catch (Exception ex)
            {
                lbthongbao.Text = "Thao tác thêm sách thất bại";

            }

        }
    }
}