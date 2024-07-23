using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _49_Anh_N1_KinhDoanhQuanAn
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // Application.EnableVisualStyles(); Xóa dòng này để đổi màu đc progressbar 
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmDangNhap_49_Anh());
           //Application.Run(new FrmTroChoi_49_Anh());
            //Application.Run(new FrmKhoNguyenLieu_49_Anh());
           
          
        }
    }
}
