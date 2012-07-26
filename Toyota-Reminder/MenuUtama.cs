using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using ToyotaDAL;

namespace Toyota_Reminder
{
    public partial class MenuUtama : Form
    {
       
        private IDbConnection _conn = null;
        private DateTime current;
        private string GKodeSales;
        public MenuUtama(IDbConnection conn)
        {
            InitializeComponent();
            _conn = conn;
            
            DAL shipper = null;
            IDataReader reader = null;
            current = DateTime.Now;
     
            try
            {
                shipper = new DAL();
                reader = shipper.Cek_Sales(_conn);

                if (reader.Read())
                {
                    Hide();
                    using (Login l = new Login(_conn)) //if data ok, form will close it self!
                    {
                        if (l.ShowDialog() == DialogResult.OK)
                        {
                            this.Visible = true;
                        }
                        else
                        {
                            _conn.Close();
                            _conn.Dispose();
                            Application.Exit();
                        }
                    }
                }
                else
                {
                    Hide();
                    using (Register c = new Register(_conn)) //if data ok, form will close it self!
                    {
                        if (c.ShowDialog() == DialogResult.OK)
                        {
                            this.Visible = true;
                        }
                        else
                        {
                            _conn.Close();
                            _conn.Dispose();
                            Application.Exit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
            }
            retrieve_salesData();
            retrieve_pageData(current);
        }

        private void retrieve_salesData()
        {
            DAL toyota = new DAL();
            IDataReader reader = null;
            //SALES DATA
            try
            {
            statusData.Text = "Retreiving sales data";
            reader = toyota.Get_Sales_Data(_conn);
            
            if (reader.Read())
            {
                labelKodeSales.Text = reader[0].ToString();
                GKodeSales = reader[0].ToString();
                labelNamaSales.Text = reader[1].ToString();
                labelAlamat.Text = reader[2].ToString();
                labelNoTelepon.Text = reader[3].ToString();
                labelEmail.Text = reader[4].ToString();
            }
            }
            catch(Exception ex)
            {
                throw new Exception("Faild to retrieve sales data", ex);
            }
        }

        private void retrieve_pageData(DateTime currentDate)
        {
            DAL toyota = new DAL();
            DateTime shortDate = Convert.ToDateTime(currentDate.ToShortDateString());
            int amount = 0;
            try
            {
                //BIRTHDAY DATA
                try
                {
                    statusData.Text = "Retreiving birthday data";
                    DataSet bds = toyota.Get_Birthday_Data(_conn, currentDate);

                    if (bds != null && bds.Tables.Count > 0)
                    {
                        listViewBirthday.Items.Clear();
                        DataTable bdt = bds.Tables[0];

                        foreach (DataRow bdr in bdt.Rows)
                        {
                            ListViewItem blvi = new ListViewItem();
                            blvi.Text = bdr["namaCustomer"].ToString();
                            blvi.SubItems.Add(bdr["noTelp"].ToString());
                            blvi.SubItems.Add(bdr["noHP1"].ToString());
                            blvi.SubItems.Add(bdr["noHP2"].ToString());
                            listViewBirthday.Items.Add(blvi);
                            amount++;
                        }
                        
                    }
                    else
                    {
                        lblJmlBirthday.Text = "No birthday found";
                    }
                    lblJmlBirthday.Text = amount.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to retrieve birthday data", ex);
                }


                //STNK DATA
                try
                {
                    statusData.Text = "Retreiving STNK data";
                    DataSet sds = toyota.Get_STNK_Data(_conn, currentDate);
                    amount = 0;
                    
                    if (sds != null && sds.Tables.Count > 0)
                    {
                        listViewSTNK.Items.Clear();
                        DataTable sdt = sds.Tables[0];
                        foreach (DataRow sdr in sdt.Rows)
                        {
                            String stnkTimeLeft = null;
                            int hitunganLeftSTNK = 0;
                            DateTime datelineSTNK = Convert.ToDateTime(sdr["habisSTNK"].ToString());
                            hitunganLeftSTNK = (6 - Convert.ToInt32(currentDate.DayOfWeek)) + Convert.ToInt32(datelineSTNK.DayOfWeek);
                            if (hitunganLeftSTNK > 6)
                                stnkTimeLeft = (Convert.ToInt32(datelineSTNK.DayOfWeek) - Convert.ToInt32(currentDate.DayOfWeek)).ToString() + " days left";
                            else if (currentDate.ToShortDateString().Equals(datelineSTNK.ToShortDateString()))
                                stnkTimeLeft = "Last Date";
                            else
                                stnkTimeLeft = hitunganLeftSTNK.ToString() + " days left";

                            ListViewItem slvi = new ListViewItem();
                            slvi.Text = sdr["namaCustomer"].ToString();
                            slvi.SubItems.Add(sdr["noTelp"].ToString());
                            slvi.SubItems.Add(sdr["noHP1"].ToString());
                            slvi.SubItems.Add(sdr["noHP2"].ToString());
                            slvi.SubItems.Add(stnkTimeLeft);
                            listViewSTNK.Items.Add(slvi);
                            amount++;
                        }
                        
                    }
                    else
                    {
                        ListViewItem slvi = new ListViewItem();
                        slvi.Text = "No";
                        slvi.SubItems.Add("STNK");
                        slvi.SubItems.Add("Data");
                        slvi.SubItems.Add("Found");
                        listViewSTNK.Items.Add(slvi);
                    }
                    lblJmlSTNK.Text = amount.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to retrieve STNK data", ex);
                }

                //ASURANSI DATA
                try
                {
                    statusData.Text = "Retreiving asuransi data";
                    DataSet ads = toyota.Get_Asuransi_Data(_conn, currentDate);
                    amount = 0;

                    if (ads != null && ads.Tables.Count > 0)
                    {
                        listViewAsuransi.Items.Clear();
                        DataTable adt = ads.Tables[0];

                        foreach (DataRow adr in adt.Rows)
                        {
                            String asuransiTimeLeft = null;
                            int hitunganLeftAsuransi = 0;
                            DateTime datelineAsuransi = Convert.ToDateTime(adr["habisAsuransi"].ToString());
                            hitunganLeftAsuransi = (6 - Convert.ToInt32(currentDate.DayOfWeek)) + Convert.ToInt32(datelineAsuransi.DayOfWeek);
                            if (hitunganLeftAsuransi > 6)
                                asuransiTimeLeft = (Convert.ToInt32(datelineAsuransi.DayOfWeek) - Convert.ToInt32(currentDate.DayOfWeek)).ToString() + " days left";
                            else if (currentDate == datelineAsuransi)
                                asuransiTimeLeft = "Last Date";
                            else
                                asuransiTimeLeft = hitunganLeftAsuransi.ToString() + " days left";

                            ListViewItem alvi = new ListViewItem();
                            alvi.Text = adr["namaCustomer"].ToString();
                            alvi.SubItems.Add(adr["noTelp"].ToString());
                            alvi.SubItems.Add(adr["noHP1"].ToString());
                            alvi.SubItems.Add(adr["noHP2"].ToString());
                            alvi.SubItems.Add(asuransiTimeLeft);
                            listViewAsuransi.Items.Add(alvi);
                            amount++;
                        }
                    }
                    else
                    {
                        ListViewItem alvi = new ListViewItem();
                        alvi.Text = "No";
                        alvi.SubItems.Add("ASURANSI");
                        alvi.SubItems.Add("Data");
                        alvi.SubItems.Add("Found");
                        listViewAsuransi.Items.Add(alvi);
                    }
                    lbljmlAsuransi.Text = amount.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to retrieve asuransi data", ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to retrieve home data", ex);
            }

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultnya = MessageBox.Show("Do you want to exit ?","Exit Dialog", MessageBoxButtons.YesNo);
            if (resultnya == DialogResult.Yes)
            {
                _conn.Close();
                _conn.Dispose();
                Application.Exit(); 
            }
              
        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            listViewBirthday.Items.Clear();
            listViewSTNK.Items.Clear();
            listViewAsuransi.Items.Clear();

            retrieve_pageData(e.Start);
            
        }

        private void settingAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingSales frm = new SettingSales(_conn);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                retrieve_salesData();
            }
        }

        private void markToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerList frm = new CustomerList(_conn, GKodeSales);
            frm.Show();
        }
    }
}
