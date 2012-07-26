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
    public partial class AddCustomer : Form
    {
        private IDbConnection _conn;
        private string _kodeSales;
        public AddCustomer(IDbConnection conn, string kodeSalesnya)
        {
            InitializeComponent();
            _conn = conn;
            combobox_jtk.Enabled = false;
            _kodeSales = kodeSalesnya;
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
            string penampung = datenya + "/" + monthnya + "/" + yearnya;
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
            string tmpJenKel = null;
            int tmpidCustomer=0;
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

                if (combobox_agama.SelectedIndex == -1)
                {
                    tmpAgama = "";
                }
                else
                {
                    tmpAgama = combobox_agama.SelectedItem.ToString();
                }

                if (radiobtn_pria.Checked)
                {
                    tmpJenKel = "Pria";
                }
                else if (radiobtn_wania.Checked)
                {
                    tmpJenKel = "Wanita";
                }
                else
                {
                    tmpJenKel = "Pria";
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
                    //Insert Biodata Customer
                    shipper.Add_Customer(_conn, _kodeSales, namacus.Text, tmpJenKel, alamat.Text, notlpn.Text,
                                        hp1.Text, hp2.Text, email.Text, tglLahirCustomer,
                                        tmpAgama, ak1.Text, ak2.Text,
                                        ak3.Text, ak4.Text, tglLahirKeluarga1, tglLahirKeluarga2,
                                        tglLahirKeluarga3, tglLahirKeluarga4);

                    //Get idCustomer
                    IDataReader reader = null;
                    try
                    {
                        reader = shipper.Cek_idCustomer(_conn,namacus.Text);

                        if (reader.Read())
                        {
                            tmpidCustomer = Convert.ToInt32( reader[0].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Faild to retrieve sales data", ex);
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                            reader.Dispose();
                        }
                    }

                    //Insert Transaksi
                    shipper.Add_Transaksi(_conn, tmpidCustomer, tipeMobilTxt.Text, warnaMobilTxt.Text, tanggaldo,
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
