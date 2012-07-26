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
    public partial class CustomerList : Form
    {
        IDbConnection _conn = null;
        private string keySort = null;
        private string queryPlus;
        private string wordSearch = null;
        private string keySearch = null;
        private string _kodesales = null;
        private DAL aksesLayer = null;

        public CustomerList(IDbConnection conn, string kodesalesnya)
        {
            InitializeComponent();
            _conn = conn;
            _kodesales = kodesalesnya;
            optionSearch();
            getData();       
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddCustomer frm = new AddCustomer(_conn,_kodesales);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                getData();
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(listView1.SelectedItems[0].Text);
            string tmpTipeMobil = listView1.SelectedItems[0].SubItems[6].Text;
            UpdateCustomer frm = new UpdateCustomer(_conn, _kodesales, id, tmpTipeMobil);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                getData();
            }
        }

        private void optionSearch()
        {
            comboBoxSearch.Items.Add(columnHeader1.Text);
            comboBoxSearch.Items.Add(columnHeader2.Text);
            comboBoxSearch.Items.Add(columnHeader3.Text);
            comboBoxSearch.Items.Add(columnHeader4.Text);
            comboBoxSearch.Items.Add(columnHeader5.Text);
            comboBoxSearch.Items.Add(columnHeader6.Text);
            comboBoxSearch.Items.Add(columnHeader7.Text);
            comboBoxSearch.Items.Add(columnHeader8.Text);
            comboBoxSearch.Items.Add(columnHeader9.Text);
            comboBoxSearch.Items.Add(columnHeader10.Text);
        }

        private string getsortingby(int index)
        {
            if (index == -1)
            {
                return "";
            }
            else if (index == 0)
            {
                return "c.idCustomer";
            }
            else if (index == 1)
            {
                return "namaCustomer";
            }
            else if (index == 2)
            {
                return "alamat";
            }
            else if (index == 3)
            {
                return "noTelp";
            }
            else if (index == 4)
            {
                return "noHP1";
            }
            else if (index == 5)
            {
                return "email";
            }
            else if (index == 6)
            {
                return "tipeMobil";
            }
            else if (index == 7)
            {
                return "tglDelivery";
            }
            else if (index == 8)
            {
                return "tglSTNK";
            }
            else if (index == 9)
            {
                return "caraPembayaran";
            }
            else return "";
        }

        private string getSearchBy()
        {
            if (comboBoxSearch.SelectedIndex == -1)
            {
                return "";
            }
            else if (comboBoxSearch.SelectedIndex == 0)
            {
                return "idCustomer";
            }
            else if (comboBoxSearch.SelectedIndex == 1)
            {
                return "namaCustomer";
            }
            else if (comboBoxSearch.SelectedIndex == 2)
            {
                return "alamat";
            }
            else if (comboBoxSearch.SelectedIndex == 3)
            {
                return "noTelp";
            }
            else if (comboBoxSearch.SelectedIndex == 4)
            {
                return "noHP1";
            }
            else if (comboBoxSearch.SelectedIndex == 5)
            {
                return "email";
            }
            else if (comboBoxSearch.SelectedIndex == 6)
            {
                return "tipeMobil";
            }
            else if (comboBoxSearch.SelectedIndex == 7)
            {
                return "tglDelivery";
            }
            else if (comboBoxSearch.SelectedIndex == 8)
            {
                return "tglSTNK";
            }
            else if (comboBoxSearch.SelectedIndex == 9)
            {
                return "caraPembayaran";
            }
            else return "";
            
        }

        private void getData()
        {
            try
            {
                aksesLayer = new DAL();
                DataSet ds = null;
                if (keySearch != null && wordSearch != null && keySort != null)
                {
                    if (keySearch.Equals("idCustomer"))
                    {
                        queryPlus = "AND c." + keySearch + " = " + wordSearch + " ORDER BY " + keySort;
                    }
                    else
                    {
                        queryPlus = "AND " + keySearch + " LIKE '" + wordSearch + "%'" + "ORDER BY " + keySort;
                    }
                }

                if (keySearch != null || wordSearch != null || keySort != null)
                {
                    ds = aksesLayer.Get_AllCustomer_Data(_conn, queryPlus);
                }
                else
                {
                    ds = aksesLayer.Get_AllCustomer_Data(_conn);
                }

                if (ds != null && ds.Tables.Count > 0)
                {
                    listView1.Items.Clear();
                    DataTable dt = ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = dr["idCustomer"].ToString();
                        lvi.SubItems.Add(dr["namaCustomer"].ToString());
                        lvi.SubItems.Add(dr["alamat"].ToString());
                        lvi.SubItems.Add(dr["noTelp"].ToString());
                        lvi.SubItems.Add(dr["noHP1"].ToString());
                        lvi.SubItems.Add(dr["email"].ToString());
                        lvi.SubItems.Add(dr["tipeMobil"].ToString());
                        lvi.SubItems.Add(dr["tglDelivery"].ToString());
                        lvi.SubItems.Add(dr["tglSTNK"].ToString());
                        lvi.SubItems.Add(dr["caraPembayaran"].ToString());
                        listView1.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            int idx = Int32.Parse(e.Column.ToString());
            keySort = getsortingby(idx);
            if (keySort != null)
            {
                queryPlus = "ORDER BY " + keySort;
            }
            else
            {
                queryPlus = "";
            }
            getData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wordSearch = null;
            keySearch = null;
            keySort = null;
            comboBoxSearch.SelectedIndex = -1;
            textBoxSearch.Text = "";
            getData();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            wordSearch = textBoxSearch.Text;
            keySearch = getSearchBy();

            if (keySearch != null && wordSearch != null)
            {
                if (keySearch.Equals("idCustomer"))
                {
                    int id = Convert.ToInt32(wordSearch);
                    queryPlus = "AND c." + keySearch + " = " + id;
                }
                else
                {
                    queryPlus = "AND " + keySearch + " LIKE '" + wordSearch + "%'";
                }
            }
            else
            {
                queryPlus = "";
            }
            getData();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void addCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tmpIDcus = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
            AddCarForm frm = new AddCarForm(_conn, tmpIDcus);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                getData();
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(listView1.SelectedItems[0].Text);
            aksesLayer.Delete_Customer_Data(_conn, id);
            MessageBox.Show("Delete data succeed");
            getData();
        }

        private void carToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(listView1.SelectedItems[0].Text);
            string tmpTipeMobil = listView1.SelectedItems[0].SubItems[6].Text;
            aksesLayer.Delete_Customer_CAR(_conn, id, tmpTipeMobil);
            MessageBox.Show("Delete Car succeed");
            getData();
        }
    }
}
