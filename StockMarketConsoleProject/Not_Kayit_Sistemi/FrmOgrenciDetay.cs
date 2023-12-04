using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Not_Kayit_Sistemi
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }


        public string numara, durum;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VTJLH0D;Initial Catalog=DbNotKayit;Integrated Security=True");

        private Label GetLblDurum()
        {
            return LblDurum;
        }


        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            
            LblNumara.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLDERS where OGRNUMARA = @p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                LblVize1.Text = dr[4].ToString();
                LblVize2.Text = dr[5].ToString();
                LblFinal.Text = dr[6].ToString();
                LblOrt.Text = dr[7].ToString();
                double deger = Convert.ToDouble(LblOrt.Text);
                if ( deger>= 50 )
                {
                    LblDurum.Text = "Geçti";
                }
                else
                {
                    LblDurum.Text = "Kaldı";
                }
            }
        }


    }
}
