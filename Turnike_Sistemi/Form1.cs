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

namespace Turnike_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public clsData data = new clsData();

        private void hideIcons()
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            pictureBox3.Visible = true;
            Update();
        }
        private void showIcons(string io, bool status)

        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            pictureBox3.Visible = true;
            Update();
            if (io == "C")
            {
                if (status == true)
                {
                    panel2.Visible = false;
                    pictureBox3.Visible = false;

                }
                if (status == false)
                {
                    panel1.Visible = false;
                }
            }
            if (io == "G")
            {
                if (status == true)
                {
                    panel4.Visible = false;
                    pictureBox3.Visible = false;

                }
                if (status == false)
                {
                    panel3.Visible = false;
                }
            }
            if (io == "")
            {
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                Update();
            }

        }
        string workerCode = "";
        int workerId;
        string workerName = "";
        DateTime dt;


        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            DateTime dt = DateTime.Now.Date.AddHours(8);
            DateTime lastdt = dt;
            workerCode = textBox1.Text;
            string sql;
            //Son hareket sorgulama
            sql = "SELECT TOP 1 * FROM WORKERTRANSACTIONS WHERE WORKERID IN (SELECT ID FROM WORKERS WHERE WORKERBARCODE='" + workerCode + "') AND DATE_>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' ORDER BY DATE_ DESC, ID DESC";
            ds = data.fill(CommandType.Text, sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lastdt = Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_"]);
            }
            if (lastdt != null)
            {
                dt = lastdt.AddHours(0.3);
            }


            SqlParameter spWorkerBarcode = new SqlParameter("@WORKERBARCODE", SqlDbType.VarChar);
            spWorkerBarcode.Value = workerCode;

            SqlParameter spIOType = new SqlParameter("@IOTYPE", SqlDbType.VarChar);
            spIOType.Value = "G";

            SqlParameter spGateId = new SqlParameter("@GATEID", SqlDbType.Int);
            spGateId.Value = 1;
            SqlParameter spDate = new SqlParameter("@DATE", SqlDbType.DateTime);
            spDate.Value = dt;

            try
            {
                ds.Clear();
                ds.Reset();

                ds = data.fill(CommandType.StoredProcedure, "SP_WORKER_INOUT", spWorkerBarcode, spIOType, spDate, spGateId);
                lblWorkerName.Text = ds.Tables[0].Rows[0]["WORKERNAME"].ToString();
                lblDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_"]).ToString("yyyy-MM-dd HH:mm:ss");
                lblStatus.Text = "Giriş başarılı.";
                lblStatus.ForeColor = Color.Green;
                Update();
                showIcons("G", true);
                Update();
                System.Threading.Thread.Sleep(2000);
                lblStatus.Text = "";
                hideIcons();
                Update();
            }
            catch (Exception ex)
            {

                lblStatus.Text = ex.Message;
                lblStatus.ForeColor = Color.Red;
                Update();
                showIcons("G", false);
                Update();
                System.Threading.Thread.Sleep(2000);
                lblStatus.Text = "";
                lblDate.Text = "...";
                lblWorkerName.Text = "...";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            DateTime dt = DateTime.Now.Date.AddHours(8);
            DateTime lastdt = dt;
            workerCode = textBox1.Text;
            string sql;
            //Son hareket sorgulama
            sql = "SELECT TOP 1 * FROM WORKERTRANSACTIONS WHERE WORKERID IN (SELECT ID FROM WORKERS WHERE WORKERBARCODE='" + workerCode + "') AND DATE_>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' ORDER BY DATE_ DESC, ID DESC";
            ds = data.fill(CommandType.Text, sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lastdt = Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_"]);
            }
            if (lastdt != null)
            {
                dt = lastdt.AddHours(0.3);
            }


            SqlParameter spWorkerBarcode = new SqlParameter("@WORKERBARCODE", SqlDbType.VarChar);
            spWorkerBarcode.Value = workerCode;

            SqlParameter spIOType = new SqlParameter("@IOTYPE", SqlDbType.VarChar);
            spIOType.Value = "C";

            SqlParameter spDate = new SqlParameter("@DATE", SqlDbType.DateTime);
            spDate.Value = dt;
            SqlParameter spGateId = new SqlParameter("@GATEID", SqlDbType.Int);
            spGateId.Value = 1;
            try
            {
                ds = data.fill(CommandType.StoredProcedure, "SP_WORKER_INOUT", spWorkerBarcode, spIOType, spDate, spGateId);


                lblWorkerName.Text = ds.Tables[0].Rows[0]["WORKERNAME"].ToString();
                lblDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_"]).ToString("yyyy-MM-dd HH:mm:ss");
                lblStatus.Text = "Çıkış başarılı.";
                lblStatus.ForeColor = Color.Green;
                showIcons("C", true);
                Update();
                System.Threading.Thread.Sleep(2000);
                lblStatus.Text = "";
                hideIcons();

            }
            catch (Exception ex)
            {

                lblStatus.Text = ex.Message;
                lblStatus.ForeColor = Color.Red;
                showIcons("C", false);
                Update();
                System.Threading.Thread.Sleep(2000);
                lblStatus.Text = "";
                hideIcons();
                Update();
            }
        }
    }
}
