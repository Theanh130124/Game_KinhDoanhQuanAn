using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _49_Anh_N1_KinhDoanhQuanAn
{
    public partial class FrmDangNhap_49_Anh : Form
    {
        public FrmDangNhap_49_Anh()
        {
            InitializeComponent();
        }
        private void Init_49_Anh()
        {
            txtTenDN_49_Anh.Clear();
            txtMatKhau_49_Anh.Clear();
            txtTenDN_49_Anh.Focus();
        }
        private void DangNhap()
        {
            if (txtTenDN_49_Anh.Text == "player" && txtMatKhau_49_Anh.Text == "123456")
            {
                Form f_49_Anh = new FrmTroChoi_49_Anh();
                this.Hide();
                f_49_Anh.ShowDialog();
            }
            else if (txtTenDN_49_Anh.Text==""||txtMatKhau_49_Anh.Text=="") 
            {
                MessageBox.Show("Vui lòng không để trống tên tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Init_49_Anh();
                
            }
        }
        private void btnDangNhap_49_Anh_Click(object sender, EventArgs e)
        {
            DangNhap();
        }
        private void llbThoat_49_Anh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult rel_49_Anh = MessageBox.Show("Bạn có muốn thoát khỏi trò chơi ?","Thông báo",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rel_49_Anh == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void txtTenDN_49_Anh_TextChanged(object sender, EventArgs e)
        {
            if (txtTenDN_49_Anh.Text.Length > 20)
            {
                MessageBox.Show("Tên tài khoản không được vượt quá 20 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Init_49_Anh();
            }
        }
        private void txtMatKhau_49_Anh_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhau_49_Anh.Text.Length > 20)
            {
                MessageBox.Show("Mật khẩu không được vượt quá 20 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Init_49_Anh();
            }
        }
        //Khi người dùng ấn Enter -> Run method DangNhap()
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                DangNhap();
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
