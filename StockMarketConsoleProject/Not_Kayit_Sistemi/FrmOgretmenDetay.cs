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
using System.Security.Cryptography;

namespace Not_Kayit_Sistemi
{
    public partial class FrmOgretmenDetay : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VTJLH0D;Initial Catalog=DbNotKayit;Integrated Security=True");
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }

        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayitDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@P1,@P2,@P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", mskNumara.Text);
            komut.Parameters.AddWithValue("@P2", TxtAd.Text);
            komut.Parameters.AddWithValue("@P3", TxtSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            mskNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtVize1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtVize2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtFinal.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string durum;
            double ortalama, v1, v2, f3;
            v1 = Convert.ToDouble(TxtVize1.Text);
            v2 = Convert.ToDouble(TxtVize2.Text);
            f3 = Convert.ToDouble(TxtFinal.Text);
            ortalama = (v1 * 0.2 + v2 * 0.2 + f3 * 0.6);
            LblGOrt.Text=ortalama.ToString();

            if (ortalama>=50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLDERS set VIZE1 = @P1 ,VIZE2 = @P2 , FINAL = @P3, ORTALAMA =@P4, DURUM = @P5 WHERE OGRNUMARA = @P6",baglanti);
            komut.Parameters.AddWithValue("@P1",TxtVize1.Text);
            komut.Parameters.AddWithValue("@P2", TxtVize2.Text);
            komut.Parameters.AddWithValue("@P3", TxtFinal.Text);
            komut.Parameters.AddWithValue("@P4", decimal.Parse(LblGOrt.Text));
            komut.Parameters.AddWithValue("@P5", durum);
            komut.Parameters.AddWithValue("@P6", mskNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Notları Güncellendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayitDataSet.TBLDERS);
        }

    }
}
