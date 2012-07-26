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
    public partial class UpdateCustomer : Form
    {
        private IDbConnection _conn;
        private string _kodeSales;
        private string _tipeMobil;
        private int _idCustomer;
        private DAL aksesLayer = null;

        public UpdateCustomer(IDbConnection conn, string kodeSales, int idCustomer, string tipeMobil)
        {
            InitializeComponent();
            _conn = conn;
            combobox_jtk.Enabled = false;
            _kodeSales = kodeSales;
            _tipeMobil = tipeMobil;
            _idCustomer = idCustomer;
            kodesales.Text = _kodeSales;
            groupBox2.Enabled = false;

            ak1.Enabled = false;
            ak2.Enabled = false;
            ak3.Enabled = false;
            ak4.Enabled = false;

            tgllahir1_hari.Enabled = false;
            tgllahir2_hari.Enabled = false;
            tgllahir3_hari.Enabled = false;
            tgllahir4_hari.Enabled = false;

            tgllahir1_bulan.Enabled = false;
            tgllahir2_bulan.Enabled = false;
            tgllahir3_bulan.Enabled = false;
            tgllahir4_bulan.Enabled = false;

            tgllahir1_tahun.Enabled = false;
            tgllahir2_tahun.Enabled = false;
            tgllahir3_tahun.Enabled = false;
            tgllahir4_tahun.Enabled = false;

            getCustomer();
        }

        private void getCustomer()
        {
            aksesLayer = new DAL();
            DataSet ds = null;
            DateTime dob;
            int jta;

            ds = aksesLayer.Get_Customer_Data(_conn, _idCustomer, _tipeMobil);

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    namacus.Text = dr["namaCustomer"].ToString();
                    dob = Convert.ToDateTime(dr["tglLahir"].ToString());
                    tgllahircus_hari.Text = dob.Day.ToString();
                    tgllahircus_bulan.Text = dob.Month.ToString();
                    tgllahircus_tahun.Text = dob.Year.ToString();
                    if (dr["jenisKelamin"].Equals("Pria"))
                    {
                        radiobtn_pria.Select();
                    }
                    else
                    {
                        radiobtn_wanita.Select();
                    }
                    if (dr["agama"].Equals("Katholik"))
                    {
                        combobox_agama.SelectedIndex = 1;
                    }
                    else if (dr["agama"].Equals("Kristen"))
                    {
                        combobox_agama.SelectedIndex = 2;

                    }
                     else if (dr["agama"].Equals("Islam"))
                    {
                        combobox_agama.SelectedIndex = 3;

                    }
                     else if (dr["agama"].Equals("Hindu"))
                    {
                        combobox_agama.SelectedIndex = 4;

                    }
                     else if (dr["agama"].Equals("Buddha"))
                    {
                        combobox_agama.SelectedIndex = 5;

                    }
                    alamat.Text = dr["alamat"].ToString();
                    notlpn.Text = dr["noTelp"].ToString();
                    hp1.Text = dr["noHP1"].ToString();
                    hp2.Text = dr["noHP2"].ToString();
                    email.Text = dr["email"].ToString();
                    ak1.Text = dr["anggotaKeluarga1"].ToString();
                    ak2.Text = dr["anggotaKeluarga2"].ToString();
                    ak3.Text = dr["anggotaKeluarga3"].ToString();
                    ak4.Text = dr["anggotaKeluarga4"].ToString();
                    if (dr["tglLahirKeluarga1"].ToString().Length == 0)
                    {
                        tgllahir1_hari.Text = null;
                        tgllahir1_bulan.Text = null;
                        tgllahir1_tahun.Text = null;
                    }
                    else
                    {
                        dob = Convert.ToDateTime(dr["tglLahirKeluarga1"].ToString());
                        tgllahir1_hari.Text = dob.Day.ToString();
                        tgllahir1_bulan.Text = dob.Month.ToString();
                        tgllahir1_tahun.Text = dob.Year.ToString();
                    }
                    if (dr["tglLahirKeluarga2"].ToString().Length == 0)
                    {
                        tgllahir2_hari.Text = null;
                        tgllahir2_bulan.Text = null;
                        tgllahir2_tahun.Text = null;
                    }
                    else
                    {
                        dob = Convert.ToDateTime(dr["tglLahirKeluarga2"].ToString());
                        tgllahir2_hari.Text = dob.Day.ToString();
                        tgllahir2_bulan.Text = dob.Month.ToString();
                        tgllahir2_tahun.Text = dob.Year.ToString();
                    }
                    if (dr["tglLahirKeluarga3"].ToString().Length == 0)
                    {
                        tgllahir3_hari.Text = null;
                        tgllahir3_bulan.Text = null;
                        tgllahir3_tahun.Text = null;
                    }
                    else
                    {
                        dob = Convert.ToDateTime(dr["tglLahirKeluarga3"].ToString());
                        tgllahir3_hari.Text = dob.Day.ToString();
                        tgllahir3_bulan.Text = dob.Month.ToString();
                        tgllahir3_tahun.Text = dob.Year.ToString();
                    }
                    if (dr["tglLahirKeluarga4"].ToString().Length == 0)
                    {
                        tgllahir4_hari.Text = null;
                        tgllahir4_bulan.Text = null;
                        tgllahir4_tahun.Text = null;
                    }
                    else
                    {
                        dob = Convert.ToDateTime(dr["tglLahirKeluarga4"].ToString());
                        tgllahir4_hari.Text = dob.Day.ToString();
                        tgllahir4_bulan.Text = dob.Month.ToString();
                        tgllahir4_tahun.Text = dob.Year.ToString();
                    }

                    tipeMobilTxt.Text = dr["tipeMobil"].ToString();
                    warnaMobilTxt.Text = dr["warnaMobil"].ToString();
                    dob = Convert.ToDateTime(dr["tglDelivery"].ToString());
                    tgldo_hari.Text = dob.Day.ToString();
                    tgldo_bulan.Text = dob.Month.ToString();
                    tgldo_tahun.Text = dob.Year.ToString();
                    dob = Convert.ToDateTime(dr["tglSTNK"].ToString());
                    tglstnk_hari.Text = dob.Day.ToString();
                    tglstnk_bulan.Text = dob.Month.ToString();
                    tglstnk_tahun.Text = dob.Year.ToString();
                    npa.Text = dr["namaAsuransi"].ToString();
                    dob = Convert.ToDateTime(dr["tglAsuransi"].ToString());
                    tglasuransi_hari.Text = dob.Day.ToString();
                    tglasuransi_bulan.Text = dob.Month.ToString();
                    tglasuransi_tahun.Text = dob.Year.ToString();
                    jta = Convert.ToInt32(dr["jmlTahunAsuransi"].ToString());
                    if (jta == 1)
                    {
                        combobox_jta.SelectedIndex = 1;
                    }
                    else if (jta == 2)
                    {
                        combobox_jta.SelectedIndex = 2;
                    }
                    else if (jta == 3)
                    {
                        combobox_jta.SelectedIndex = 3;
                    }
                    else if (jta == 4)
                    {
                        combobox_jta.SelectedIndex = 4;
                    }
                    else if (jta == 5)
                    {
                        combobox_jta.SelectedIndex = 5;
                    }
                    else
                    {
                        combobox_jta.SelectedIndex = 0;
                    }

                    if (dr["caraPembayaran"].ToString().Equals("cash") || dr["caraPembayaran"].ToString().Equals("Cash"))
                    {
                        radiobtn_cash.Select();
                    }
                    else
                    {
                        radiobtn_credit.Select();
                    }
                    if (dr["jmlTahunKredit"].ToString().Equals("1"))
                    {
                        combobox_jtk.SelectedIndex = 1;
                    }
                    else if (dr["jmlTahunKredit"].ToString().Equals("2"))
                    {
                        combobox_jtk.SelectedIndex = 2;
                    }
                    else if (dr["jmlTahunKredit"].ToString().Equals("3"))
                    {
                        combobox_jtk.SelectedIndex = 3;
                    }
                    else if (dr["jmlTahunKredit"].ToString().Equals("4"))
                    {
                        combobox_jtk.SelectedIndex = 4;
                    }
                    else if (dr["jmlTahunKredit"].ToString().Equals("5"))
                    {
                        combobox_jtk.SelectedIndex = 5;
                    }
                }
            }
        }

        private void npa_TextChanged(object sender, EventArgs e)
        {
            if (npa.Text.Length <= 3)
            {
                combobox_jta.Enabled = false;
                combobox_jta.SelectedIndex = 0;
                tglasuransi_hari.Enabled = false;
                tglasuransi_bulan.Enabled = false;
                tglasuransi_tahun.Enabled = false;

            }
            else
            {
                combobox_jta.Enabled = true;
                tglasuransi_hari.Enabled = true;
                tglasuransi_bulan.Enabled = true;
                tglasuransi_tahun.Enabled = true;
            }

        }
        private void combobox_jtk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radiobtn_credit.Checked)
            {
                combobox_jtk.Enabled = true;
            }
            else if (radiobtn_cash.Checked)
            {
                combobox_jtk.Enabled = false;
                combobox_jtk.SelectedIndex = 0;
            }
        }



        private void ak1_TextChanged(object sender, EventArgs e)
        {
            if (ak1.Text.Length > 0)
            {
                ak2.Enabled = true;
                tgllahir1_hari.Enabled = true;
                tgllahir1_bulan.Enabled = true;
                tgllahir1_tahun.Enabled = true;
            }
            else
            {
                ak2.Enabled = false;
                tgllahir1_hari.Enabled = false;
                tgllahir1_bulan.Enabled = false;
                tgllahir1_tahun.Enabled = false;
            }
        }

        private void ak2_TextChanged(object sender, EventArgs e)
        {
            if (ak2.Text.Length > 0)
            {
                ak3.Enabled = true;
                tgllahir2_hari.Enabled = true;
                tgllahir2_bulan.Enabled = true;
                tgllahir2_tahun.Enabled = true;
            }
            else
            {
                ak3.Enabled = false;
                tgllahir2_hari.Enabled = false;
                tgllahir2_bulan.Enabled = false;
                tgllahir2_tahun.Enabled = false;
            }
        }

        private void ak3_TextChanged(object sender, EventArgs e)
        {
            if (ak3.Text.Length > 0)
            {
                ak4.Enabled = true;
                tgllahir3_hari.Enabled = true;
                tgllahir3_bulan.Enabled = true;
                tgllahir3_tahun.Enabled = true;
            }
            else
            {
                ak4.Enabled = false;
                tgllahir3_hari.Enabled = false;
                tgllahir3_bulan.Enabled = false;
                tgllahir3_tahun.Enabled = false;
            }
        }

        private void ak4_TextChanged(object sender, EventArgs e)
        {
            if (ak4.Text.Length > 0)
            {
                tgllahir4_hari.Enabled = true;
                tgllahir4_bulan.Enabled = true;
                tgllahir4_tahun.Enabled = true;
            }
            else
            {
                tgllahir4_hari.Enabled = false;
                tgllahir4_bulan.Enabled = false;
                tgllahir4_tahun.Enabled = false;
            }
        }


        private void radiobtn_credit_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobtn_credit.Checked)
            {
                combobox_jtk.Enabled = true;
            }
            else
            {
                combobox_jtk.Enabled = false;
                combobox_jtk.SelectedIndex = 0;
            }
        }

        private void namacus_TextChanged(object sender, EventArgs e)
        {
            if (namacus.Text.Length > 0)
            {
                groupBox2.Enabled = true;
                ak1.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
                ak1.Enabled = false;
            }

        }

        private DateTime convertToDate(string datenya, string monthnya, string yearnya)
        {
            string penampung = monthnya + "/" + datenya + "/" + yearnya;
            DateTime tampung = DateTime.Parse(penampung);
            return tampung;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            DateTime? tglLahirKeluarga1 = null;
            DateTime? tglLahirKeluarga2 = null;
            DateTime? tglLahirKeluarga3 = null;
            DateTime? tglLahirKeluarga4 = null;
            String namaPerusahaanAsuransi = "";
            DateTime? tglAsuransi = null;
            string tmpAgama = null;
            string jenkel = null;
            int jumlahTahunAsuransi = 0;
            int tmpJmlTahunKredit =0;

            if (namacus.Text.Length == 0 || alamat.Text.Length == 0 || notlpn.Text.Length == 0 || hp1.Text.Length == 0 || tgllahircus_hari.Text.Length == 0 || tgllahircus_bulan.Text.Length == 0 || tgllahircus_tahun.Text.Length == 0 || tipeMobilTxt.Text == null || warnaMobilTxt.Text == null || tgldo_hari.Text.Length == 0 || tgldo_bulan.Text.Length == 0 || tgldo_tahun.Text.Length == 0 || tglstnk_hari.Text.Length == 0 || tglstnk_bulan.Text.Length == 0 || tglstnk_tahun.Text.Length == 0)
            {
                MessageBox.Show("There are some field that empty");
            }
            else
            {
                DAL shipper = null;

                DateTime tglLahirCustomer = convertToDate(tgllahircus_hari.Text, tgllahircus_bulan.Text, tgllahircus_tahun.Text);

                if (ak1.Text != "")
                    if (tgllahir1_hari.Text != "" && tgllahir1_bulan.Text != "" && tgllahir1_tahun.Text != "")
                        tglLahirKeluarga1 = convertToDate(tgllahir1_hari.Text, tgllahir1_bulan.Text, tgllahir1_tahun.Text);

                if (ak2.Text != "")
                    if (tgllahir2_hari.Text != "" && tgllahir2_bulan.Text != "" && tgllahir2_tahun.Text != "")
                        tglLahirKeluarga2 = convertToDate(tgllahir2_hari.Text, tgllahir2_bulan.Text, tgllahir2_tahun.Text);

                if (ak3.Text != "")
                    if (tgllahir3_hari.Text != "" && tgllahir3_bulan.Text != "" && tgllahir3_tahun.Text != "")
                        tglLahirKeluarga3 = convertToDate(tgllahir3_hari.Text, tgllahir3_bulan.Text, tgllahir3_tahun.Text);

                if (ak4.Text != "")
                    if (tgllahir4_hari.Text != "" && tgllahir4_bulan.Text != "" && tgllahir4_tahun.Text != "")
                        tglLahirKeluarga4 = convertToDate(tgllahir4_hari.Text, tgllahir4_bulan.Text, tgllahir4_tahun.Text);

                DateTime tanggaldelivery = convertToDate(tgldo_hari.Text, tgldo_bulan.Text, tgldo_tahun.Text);

                if (npa.Text != "")
                {
                    namaPerusahaanAsuransi = npa.Text;
                    if (tglasuransi_hari.Text != "" && tglasuransi_bulan.Text != "" && tglasuransi_tahun.Text != "")
                        tglAsuransi = convertToDate(tglasuransi_hari.Text, tglasuransi_bulan.Text, tglasuransi_tahun.Text);

                    if (combobox_jta.SelectedItem.ToString() != (""))
                        jumlahTahunAsuransi = Convert.ToInt32(combobox_jta.SelectedItem.ToString());
                }

                DateTime tanggalSTNK = convertToDate(tglstnk_hari.Text, tglstnk_bulan.Text, tglstnk_tahun.Text);

                if (radiobtn_pria.Checked)
                {
                    jenkel = "Pria";
                }
                else
                {
                    jenkel = "Wanita";
                }

                if (combobox_agama.SelectedIndex == -1)
                {
                    tmpAgama = "";
                }
                else
                {
                    tmpAgama = combobox_agama.SelectedItem.ToString();
                }

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

                    //Update Biodata Customer
                    shipper.Update_Customer_Data(_conn, _idCustomer, namacus.Text, alamat.Text, notlpn.Text,
                                        hp1.Text, hp2.Text, email.Text, tglLahirCustomer, jenkel,
                                        tmpAgama, ak1.Text, ak2.Text,
                                        ak3.Text, ak4.Text, tglLahirKeluarga1, tglLahirKeluarga2,
                                        tglLahirKeluarga3, tglLahirKeluarga4);

                    //Update Transaksi
                    shipper.Update_Customer_Car_Data(_conn, _idCustomer, _tipeMobil, tipeMobilTxt.Text, warnaMobilTxt.Text, tanggaldelivery,
                                          tanggalSTNK, tglAsuransi, namaPerusahaanAsuransi, jumlahTahunAsuransi, pembayaran,
                                          tmpJmlTahunKredit);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("Register Success");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
