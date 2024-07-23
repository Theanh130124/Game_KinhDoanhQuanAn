using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _49_Anh_N1_KinhDoanhQuanAn
{
    public partial class FrmKhoNguyenLieu_49_Anh : Form
    {
        private int money_first_49_Anh = 100000000;//Tiền ban đầu
        private int time_first_49_Anh; //Thời gian ban đầu 
        public event Action RandomMonMoi_49_Anh; //Tạo sự kiện để truyền phương thức RandomMonMoi_49_Anh() từ Form Trò Chơi
        public event Action XuLyLuotChoi_49_Anh; //Tạo sự kiện để truyền phương thức XuLyCacLuot_49_Anh() từ Form Trò Chơi

        //Nhận các giá trị truyền từ Form Trò Chơi
        public string TenMonAn_49_Anh;
        public int SoLuongMon_49_Anh;
        public ProgressBar prgb_LuongHP_49_Anh;
        public int SoBan_49_Anh;
        public FrmKhoNguyenLieu_49_Anh()
        {
            InitializeComponent();
        }
        public FrmKhoNguyenLieu_49_Anh(String tenmon_49_Anh, int soluongmon_49_Anh, ProgressBar prbg_49_Anh, int soban_49_Anh)//Nhận và cập nhật các giá trị ở Form Trò Chơi
        {
            InitializeComponent();
            TenMonAn_49_Anh = tenmon_49_Anh;
            SoLuongMon_49_Anh = soluongmon_49_Anh;
            prgb_LuongHP_49_Anh = prbg_49_Anh;
            SoBan_49_Anh = soban_49_Anh;
        }


        private void btnThoatKhoNL_49_Anh_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void btnMua_49_Anh_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemShop_49_Anh in lsvShopNL_49_Anh.CheckedItems) //Duyệt từng item đang check trong ListView Shop NL
            {
                int money_hientai_49_Anh = int.Parse(lblTien_49_Anh.Text);
                int SoLuongSPShop_49_Anh = int.Parse(itemShop_49_Anh.SubItems[3].Text);
                int SoLuongSPChonMua_49_Anh = (int)nrcUDSoLuong_49_Anh.Value;
                int GiaCuaTungSPChonMua_49_Anh = (int.Parse(itemShop_49_Anh.SubItems[2].Text));
                int GiaCuaTatCaSPChonMua_49_Anh = 0;
                GiaCuaTatCaSPChonMua_49_Anh += GiaCuaTungSPChonMua_49_Anh;

                //Thực thi khi số lượng Món Ăn Trong ShopNL > 0 && Số tiền hiện tại của bạn phải > Giá của tất cả SP chọn && Phải chọn Số lượng lớn hơn 0 trước .
                if (SoLuongSPShop_49_Anh > 0 && money_hientai_49_Anh > GiaCuaTatCaSPChonMua_49_Anh && SoLuongSPChonMua_49_Anh > 0)
                {
                    itemShop_49_Anh.SubItems[3].Text = (SoLuongSPShop_49_Anh - SoLuongSPChonMua_49_Anh).ToString(); // Số Lương Món Ăn còn lại trong Shop = SL ban đầu - SL đã chọn 
                    lblTien_49_Anh.Text = (money_hientai_49_Anh - (SoLuongSPChonMua_49_Anh * GiaCuaTungSPChonMua_49_Anh)).ToString();//Tiền còn lại = Tiền ban đầu - SốLượngMua*GiáSP

                    //Item mới giống hệt item cũ . Chỉ có số lượng = SL đã chọn mua .
                    ListViewItem item_moi_49_Anh = new ListViewItem(itemShop_49_Anh.Text, (int)itemShop_49_Anh.ImageIndex);
                    item_moi_49_Anh.SubItems.Add(itemShop_49_Anh.SubItems[1].Text);
                    item_moi_49_Anh.SubItems.Add(itemShop_49_Anh.SubItems[2].Text);
                    item_moi_49_Anh.SubItems.Add((nrcUDSoLuong_49_Anh.Value).ToString());
                    lsvKho_49_Anh.Items.Add(item_moi_49_Anh);//Thêm item này vào listview Kho .

                }
                else if (int.Parse(lblTien_49_Anh.Text) < GiaCuaTatCaSPChonMua_49_Anh)//Không đủ tiền 
                {
                    MessageBox.Show("Bạn không đủ tiền ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (int.Parse(itemShop_49_Anh.SubItems[3].Text) < 0)//Hết món ăn trong shop
                {
                    MessageBox.Show("Số lượng trong shop đã hết ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else//Chọn chọn số lượng
                {
                    MessageBox.Show("Vui lòng chọn số lượng sản phẩm cần mua  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                itemShop_49_Anh.Checked = false; // Sau khi mua xong bỏ check món ăn đó bên listview Shop

            }
            timer_demnguoc_49_Anh.Enabled = true;//Khi bấm mua thì thời gian đếm ngược chạy .
            nrcUDSoLuong_49_Anh.Value = 0;//Mua xong số lượng chọn mua về 0 .
        }
        private void FrmKhoNguyenLieu_49_Anh_Load(object sender, EventArgs e)
        {

            lblTien_49_Anh.Text = money_first_49_Anh.ToString();
            time_first_49_Anh = 180;// 180s đã chỉnh Interval = 1000.
            lblThoiGian_49_Anh.Text = "03:00";
        }
        private void btnTraHetHang_49_Anh_Click(object sender, EventArgs e)
        {

            foreach (ListViewItem itemKho_49_Anh in lsvKho_49_Anh.CheckedItems) // duyệt từng item đang check chọn trong listview Kho
            {
                string tenItemKho_49_Anh = itemKho_49_Anh.SubItems[1].Text;
                int GiaCuaTungSPChonTraHet_49_Anh = (int.Parse(itemKho_49_Anh.SubItems[2].Text));
                int SoLuongSPKho_49_Anh = int.Parse(itemKho_49_Anh.SubItems[3].Text);
                int GiaCuaTatCaSPChonTraHet_49_Anh = 0;
                GiaCuaTatCaSPChonTraHet_49_Anh += GiaCuaTungSPChonTraHet_49_Anh;
                int money_hientai_49_Anh = int.Parse(lblTien_49_Anh.Text) + (GiaCuaTungSPChonTraHet_49_Anh * SoLuongSPKho_49_Anh);
                lsvKho_49_Anh.Items.Remove(itemKho_49_Anh);//Trả xong xóa itemKho đó khỏi Kho
                lblTien_49_Anh.Text = money_hientai_49_Anh.ToString(); // Cập nhật lại số tiền sau khi trả
                foreach (ListViewItem itemShop_49_Anh in lsvShopNL_49_Anh.Items) // duyệt hết các item trong Shop
                {
                    if (itemShop_49_Anh.SubItems[1].Text == tenItemKho_49_Anh)//Item nào trong Shop = tên itemKho trả
                    {
                        int SoLuongTra_49_Anh = int.Parse((itemShop_49_Anh.SubItems[3].Text));
                        itemShop_49_Anh.SubItems[3].Text = (SoLuongTra_49_Anh + SoLuongSPKho_49_Anh).ToString(); // Cập nhật số lượng cho itemShop đó
                        break;
                    }
                }
            }
        }


        private String FormatTime_49_Anh(int seconds_49_Anh)
        {
            //Cho thời gian đúng Format 
            int minutes_49_Anh = seconds_49_Anh / 60;
            seconds_49_Anh = seconds_49_Anh % 60;
            return string.Format("{0:00}:{1:00}", minutes_49_Anh, seconds_49_Anh);
        }

        private void timer_demnguoc_49_Anh_Tick(object sender, EventArgs e)
        {
            if (time_first_49_Anh > 0)
            {
                time_first_49_Anh--;//giảm 1s 
                lblThoiGian_49_Anh.Text = FormatTime_49_Anh(time_first_49_Anh);
            }
            else
            {
                timer_demnguoc_49_Anh.Stop();
                lblThoiGian_49_Anh.Text = " Hết giờ ";
                lblThoiGian_49_Anh.ForeColor = Color.Red;
                ResetTroChoi_49_Anh(); //Hết giờ đưa lượng HP về ban đầu = 50 ;
                lblThoiGian_49_Anh.ForeColor = Color.Blue;
                prgb_LuongHP_49_Anh.Value = 0;
                XuLyLuotChoi_49_Anh();


            }
        }
        public void ResetTroChoi_49_Anh()
        {
            DialogResult rel_49_Anh = MessageBox.Show("Hãy chơi lại ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (rel_49_Anh == DialogResult.OK)
            {
                lsvKho_49_Anh.Items.Clear(); //xóa hết item bên Kho
                time_first_49_Anh = 180;//đưa giá trị thời gian về ban đầu
                lblThoiGian_49_Anh.Text = "03:00";// đưa time trên form về ban đầu
                lblTien_49_Anh.Text = money_first_49_Anh.ToString();// đưa tiền về ban đầu
                nrcUDSoLuong_49_Anh.Value = 0;
                prgb_LuongHP_49_Anh.Value = 50; //Đưa lượng HP về ban đầu 


                foreach (ListViewItem item_49_Anh in lsvShopNL_49_Anh.Items)
                {
                    item_49_Anh.SubItems[3].Text = 9999.ToString(); // Đưa số lượng ShopNL ban đầu . 
                    item_49_Anh.Checked = false; // bỏ check bên ShopNL
                }
            }
        }
        public void ResetKhiThang_Thua_49_Anh() // Giống ResetTroChoi_49_Anh() ,nhưng nhằm bỏ thông báo hãy chơi lại .
        {
            lsvKho_49_Anh.Items.Clear();
            time_first_49_Anh = 180;
            lblThoiGian_49_Anh.Text = "03:00";
            timer_demnguoc_49_Anh.Enabled = false; // dừng tg chờ bấm Mua để tiếp tục chay
            lblTien_49_Anh.Text = money_first_49_Anh.ToString();
            nrcUDSoLuong_49_Anh.Value = 0;
            prgb_LuongHP_49_Anh.Value = 50;
            foreach (ListViewItem item_49_Anh in lsvShopNL_49_Anh.Items)
            {
                item_49_Anh.SubItems[3].Text = 9999.ToString();
                item_49_Anh.Checked = false;
            }
        }

        private void btnLenMon_49_Anh_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemKho_49_Anh in lsvKho_49_Anh.CheckedItems) // duyệt các itemKho đang check .
            {
                String tenmon_trongKho_49_Anh = itemKho_49_Anh.SubItems[1].Text;
                int soluongmon_trongKho_49_Anh = int.Parse(itemKho_49_Anh.SubItems[3].Text);
                int soban_ghichu_49_Anh = 0;
                if (txtSoBan_49_Anh.Text == "") //Tránh lỗi chưa nhập bàn trươc khi bấm lên món 
                {
                    MessageBox.Show("Vui lòng nhập số bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return; // dừng hàm tránh chạy các if else bên dưới 
                }
                else
                {
                    soban_ghichu_49_Anh = int.Parse(txtSoBan_49_Anh.Text);
                }
                //Tên món trong Random ra Tên món trong listview Kho  && số lượng món random = số lượng chọn  &&  Số bàn random = Số bàn ghi chú 
                if (TenMonAn_49_Anh == tenmon_trongKho_49_Anh && SoLuongMon_49_Anh == soluongmon_trongKho_49_Anh && SoBan_49_Anh == soban_ghichu_49_Anh) //Chuyển đúng món,số lượng,bàn

                {
                    MessageBox.Show("Bạn đã chuyển đúng món ăn cho khách hàng  (+10 Điểm HP) ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lsvKho_49_Anh.Items.Remove(itemKho_49_Anh);
                    prgb_LuongHP_49_Anh.Value += 10;
                    XuLyLuotChoi_49_Anh.Invoke();//Khi nào đầy,hết HP sẽ cập nhật các lượt chơi.
                    RandomMonMoi_49_Anh.Invoke();// Nếu chuyển đúng sẽ tiếp tục Random Món Ăn 
                    txtSoBan_49_Anh.Text = "";
                }
                // 
                else if (SoLuongMon_49_Anh != soluongmon_trongKho_49_Anh) //Sai số lượng
                {
                    MessageBox.Show("Bạn đã chuyển sai số lượng món ăn  (-10 Điểm HP) ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    prgb_LuongHP_49_Anh.Value -= 10;
                    XuLyLuotChoi_49_Anh.Invoke();
                    txtSoBan_49_Anh.Text = "";
                }
                else if (SoBan_49_Anh != soban_ghichu_49_Anh) //Sai số bàn
                {
                    MessageBox.Show("Bạn đã chuyển sai số bàn  (-10 Điểm HP) ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    prgb_LuongHP_49_Anh.Value -= 10;
                    XuLyLuotChoi_49_Anh.Invoke();
                    txtSoBan_49_Anh.Text = "";
                }
                else //Các TH sai còn lại
                {
                    MessageBox.Show("Bạn đã chuyển sai món ăn  (-10 Điểm HP) ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    prgb_LuongHP_49_Anh.Value -= 10;
                    XuLyLuotChoi_49_Anh.Invoke();
                    txtSoBan_49_Anh.Text = "";

                }
            }
        }


    }
}




