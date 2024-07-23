using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _49_Anh_N1_KinhDoanhQuanAn
{
    public partial class FrmTroChoi_49_Anh : Form
    {
        public FrmTroChoi_49_Anh()
        {
            InitializeComponent();
        }
        private Random rd_49_Anh = new Random();
        private String path_49_Anh; // đường dẫn hình ảnh ban đầu
        private List<(String tenmon_49_Anh, Image hinhanh_49_Anh)> listmonan_49_Anh; // Danh sách món ăn
        public FrmKhoNguyenLieu_49_Anh f_KhoNL_49_Anh; //Tạo đường dẫn cố định ( khi tắt form không mất các thao tác đang thực hiện)
        public int soluongmon_49_Anh;
        public int soban_49_Anh;
        public int luotthang_49_Anh, luotthua_49_Anh, luotdachoi_49_Anh;
        
        private void btnKhoNL_49_Anh_Click(object sender, EventArgs e)
        {

            if (f_KhoNL_49_Anh == null)//Nếu FrmKhoNL chưa được khởi tạo
            {
                //Truyền dữ liệu qua Form KhoNguyênLiệu 
                f_KhoNL_49_Anh = new FrmKhoNguyenLieu_49_Anh(lblTenMon_49_Anh.Text, soluongmon_49_Anh, prgbLuongHP_49_Anh, soban_49_Anh);
                f_KhoNL_49_Anh.RandomMonMoi_49_Anh += RandomMonMoi_49_Anh; //Truyền method RandomMonMoi_49_Anh() qua FrmNguyenLieu ;
                f_KhoNL_49_Anh.XuLyLuotChoi_49_Anh += XuLyCacLuot_49_Anh;//Truyền method XuLyCacLuot_49_Anh() qua FrmNguyenLieu
                f_KhoNL_49_Anh.ShowDialog();
            }
            else
            {
                f_KhoNL_49_Anh.Visible = true; //Cho form ẩn . Nhằm lưu các thao tác đang thực hiện 
            }
        }
        private void btnThoat_49_Anh_Click(object sender, EventArgs e)
        {
            DialogResult rel_49_Anh = MessageBox.Show("Bạn có muốn thoát khỏi trò chơi ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rel_49_Anh == DialogResult.OK)
            {
                Form f_DangNhap_49_Anh = new FrmDangNhap_49_Anh();
                this.Hide();
                f_DangNhap_49_Anh.ShowDialog();
            }
        }

        private void btnCaiDat_49_Anh_Click(object sender, EventArgs e)
        {
            pnlCaiDat_49_Anh.Visible=true;
            txtLuotDaChoi_49_Anh.Text = luotdachoi_49_Anh.ToString();
            txtLuotThang_49_Anh.Text = luotthang_49_Anh.ToString() ;
            txtLuotThua_49_Anh.Text = luotthua_49_Anh.ToString();
        }

        private void btnYeuCauKH_49_Anh_Click(object sender, EventArgs e)
        {
            pnlYeuCauKH_49_Anh.Visible = true;
        }

        private void FrmTroChoi_49_Anh_Load(object sender, EventArgs e)
        {
            pnlYeuCauKH_49_Anh.Visible = false;
            pnlCaiDat_49_Anh.Visible = false ;
            path_49_Anh = Application.StartupPath + @"\AnhCacMonAn\"; //Liên kết đến folder AnhCacMonAnh trong bin -> Debug
            
        }

        private void btnDongYCKH_49_Anh_Click(object sender, EventArgs e)
        {
            pnlYeuCauKH_49_Anh.Visible = false;
        }

        private void btnDongCaiDat_49_Anh_Click(object sender, EventArgs e)
        {
            pnlCaiDat_49_Anh.Visible = false;
        }

        private void btnXemYC_49_Anh_Click(object sender, EventArgs e)  
        {
            RandomMonMoi_49_Anh();
        }
        public void RandomMonMoi_49_Anh()
        {
            soluongmon_49_Anh = rd_49_Anh.Next(1, 6);
            soban_49_Anh= rd_49_Anh.Next(1, 11);
            lblSoBan_49_Anh.Text = "Bàn số : " + soban_49_Anh.ToString();
            lblSoLuongMon_49_Anh.Text = "Số lượng : " + soluongmon_49_Anh.ToString();
            listmonan_49_Anh = new List<(string tenmon_49_Anh, Image hinhanh_49_Anh)> 
                {
                    ("Cháo",Image.FromFile(path_49_Anh+"chao.png")),
                    ("Cơm chiên",Image.FromFile(path_49_Anh+"com.png")),
                    ("Cua hấp",Image.FromFile(path_49_Anh+"cua.png")),
                    ("Hàu nướng",Image.FromFile(path_49_Anh+"hau.png")),
                    ("Mì Ramen",Image.FromFile(path_49_Anh+"mi.png")),
                    ("Tôm hùm hấp",Image.FromFile(path_49_Anh+"tomhum.png")),
                    ("Bia Sài Gòn",Image.FromFile(path_49_Anh+"bia.png")),
                    ("Cơm lươn",Image.FromFile(path_49_Anh+"comluon.png")),
                    ("Cơm nắm",Image.FromFile(path_49_Anh+"comnam.png")),
                    ("Nước lọc",Image.FromFile(path_49_Anh+"nuocloc.png")),
                    ("Nước ngọt",Image.FromFile(path_49_Anh+"nuocngot.png")),
                    ("Vịt quay",Image.FromFile(path_49_Anh+"vitquay.png")),
                    ("Rượu Soju",Image.FromFile(path_49_Anh+"ruou.png"))
                };
            var monan_ngaunhien_49_Anh = listmonan_49_Anh[rd_49_Anh.Next(listmonan_49_Anh.Count)];// bằng list[index]. index = random từ 0 -> (số món ăn trong list - 1) .
            ptbMonAn_49_Anh.Image = monan_ngaunhien_49_Anh.hinhanh_49_Anh;  // lấy ra hình của món ăn ngẫu nhiên trong list món ăn
            lblTenMon_49_Anh.Text = monan_ngaunhien_49_Anh.tenmon_49_Anh;
            if (f_KhoNL_49_Anh != null) //Cập nhật lại món ăn sau khi bên Kho đã lên đúng món.
            {
                f_KhoNL_49_Anh.TenMonAn_49_Anh = lblTenMon_49_Anh.Text;
                f_KhoNL_49_Anh.SoLuongMon_49_Anh = soluongmon_49_Anh;
                f_KhoNL_49_Anh.SoBan_49_Anh = soban_49_Anh;
            }

        }
        public void XuLyCacLuot_49_Anh()
        {
            if(prgbLuongHP_49_Anh.Value == 100)// Đầy HP -> Thắng , reset_thangthua
            {
                MessageBox.Show("Bạn đã thắng ! ", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.None);
                luotthang_49_Anh++;
                luotdachoi_49_Anh++;
                f_KhoNL_49_Anh.ResetKhiThang_Thua_49_Anh();
                 
            }
            if (prgbLuongHP_49_Anh.Value == 0)//Hết HP -> Thua , reset_thangthua
            {
                MessageBox.Show("Bạn đã thua ! ", "Thông báo" ,MessageBoxButtons.OK, MessageBoxIcon.None );
                luotthua_49_Anh++;
                luotdachoi_49_Anh++;
                f_KhoNL_49_Anh.ResetKhiThang_Thua_49_Anh();

            }
        }
       
    }
    }
        
        
    
   

