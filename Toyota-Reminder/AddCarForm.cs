using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToyotaDAL;

namespace Toyota_Reminder
{
    public partial class AddCarForm : Form
    {
        IDbConnection _conn = null;

        public AddCarForm(IDbConnection conn, int tmpidCustomer)
        {
            InitializeComponent();
            _conn = conn;
            
            DAL shipper = null;

            try
            {
                shipper = new DAL();
                DataSet ds = shipper.Get_Customer_Data_ADDCAR(_conn, tmpidCustomer);

                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        tbidCustomer.Text = tmpidCustomer.ToString();
                        namacus_db.Text = dr["namaCustomer"].ToString();
                        DateTime dob = Convert.ToDateTime(dr["tglLahir"].ToString());
                        tgllahircus_db.Text = dob.ToString("dd MMMM yyyy");
                        tbAgama.Text = dr["agama"].ToString();
                        alamat_db.Text = dr["alamat"].ToString();
                        notlpn_db.Text = dr["noTelp"].ToString();
                        hp1_db.Text = dr["noHP1"].ToString();
                        hp2_db.Text = dr["noHP2"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        

        private DateTime convertToDate(string datenya, string monthnya, string yearnya)
        {
            string penampung = datenya + "/" + monthnya + "/" + yearnya;
            DateTime tampung = DateTime.Parse(penampung);
            return tampung;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            String namaPerusahaanAsuransi = "";
            DateTime? tglAsuransi = null;
            int jumlahTahunAsuransi = 0;
            int tmpJmlTahunKredit = 0;
            int tmpidCustomer = Convert.ToInt32(tbidCustomer.Text);

            if (tipeMobilTxt.Text == null || warnaMobilTxt.Text == null || tgldo_hari.Text.Length == 0 || tgldo_bulan.Text.Length == 0 || tgldo_tahun.Text.Length == 0 || tglstnk_hari.Text.Length == 0 || tglstnk_bulan.Text.Length == 0 || tglstnk_tahun.Text.Length == 0)
            {
                MessageBox.Show("There are some field that empty");
            }
            else
            {
                DAL shipper = null;

                DateTime tanggaldo = convertToDate(tgldo_hari.Text, tgldo_bulan.Text, tgldo_tahun.Text);

                if (npa.Text != "")
                {
                    namaPerusahaanAsuransi = npa.Text;
                    if (tglasuransi_hari.Text != "" && tglasuransi_bulan.Text != "" && tglasuransi_tahun.Text != "")
                        tglAsuransi = convertToDate(tglasuransi_hari.Text, tglasuransi_bulan.Text, tglasuransi_tahun.Text);

                    if (combobox_jta.SelectedItem.ToString() != "")
                        jumlahTahunAsuransi = Convert.ToInt32(combobox_jta.SelectedItem.ToString());
                }

                DateTime tanggalSTNK = convertToDate(tglstnk_hari.Text, tglstnk_bulan.Text, tglstnk_tahun.Text);

                try
                {
                    shipper = new DAL();
                    string pembayaran;

                    if (radiobtn_credit.Checked)
                    {
                        pembayaran = "Credit";
                        tmpJmlTahunKredit = Convert.ToInt32(combobox_jtk.SelectedItem.ToString());
                    }
                    else
                    {
                        pembayaran = "Cash";
                    }
                   

                    //Insert Transaksi
                    shipper.Add_Transaksi(_conn, tmpidCustomer, tipeMobilTxt.Text , warnaMobilTxt.Text, tanggaldo,
                                          tanggalSTNK, tglAsuransi, namaPerusahaanAsuransi, jumlahTahunAsuransi, pembayaran,
                                          tmpJmlTahunKredit);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("Add Car Success");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

      
    }
}
