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
    public partial class SettingSales : Form
    {

        private IDbConnection _conn = null;
        private int flagPassword = 0;
        private int flagRWPassword = 0;

        public SettingSales(IDbConnection conn)
        {
            InitializeComponent();
            _conn = conn;

            DAL shipper = null;

            try
            {
                shipper = new DAL();
                DataSet ds = shipper.Get_Sales_Data_Full(_conn);

                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        textBoxKodeSales.Text = dr["kodeSales"].ToString();
                        textBoxUsername.Text = dr["username"].ToString();
                        textBoxPassword.Text = dr["password"].ToString();
                        textBoxRWPassword.Text = dr["password"].ToString();
                        textBoxNamaSales.Text = dr["namaSales"].ToString();
                        textBoxAlamat.Text = dr["alamat"].ToString();
                        textBoxNoTelp.Text = dr["noTelp"].ToString();
                        textBoxEmail.Text = dr["email"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void SettingSales_Load(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Length < 7)
            {
                flagPassword = 0;
            }
            else if (textBoxPassword.Text.Length >= 7)
            {
                flagPassword = 1;
            }
            if (flagPassword == 0)
            {
                labelNotePassword.Text = "Password only contain " + textBoxPassword.Text.Length + " character";
                flagPassword = 0;
            }
            else if (flagPassword == 1)
            {
                flagPassword = 1;
                labelNotePassword.Text = "";
            }
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            labelNoteUsername.Text = "Username = Kode Sales + Date and month of birth. eg.ABC1708";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxKodeSales.Text.Length == 0 || textBoxNamaSales.Text.Length == 0 || textBoxNoTelp.Text.Length == 0 || textBoxPassword.Text.Length == 0 || textBoxRWPassword.Text.Length == 0 || textBoxUsername.Text.Length == 0)
            {
                MessageBox.Show("There are some field that empty");
            }
            else
            {
                DAL shipper = null;

                try
                {
                    shipper = new DAL();
                    shipper.update_Setting_Sales(_conn, textBoxKodeSales.Text, textBoxUsername.Text, textBoxPassword.Text, textBoxNamaSales.Text, textBoxAlamat.Text, textBoxNoTelp.Text, textBoxEmail.Text);
                    MessageBox.Show("Data have been update.");
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBoxUsername_MouseClick(object sender, MouseEventArgs e)
        {
            labelNoteUsername.Text = "Username = Kode Sales + Date and month of birth. eg.ABC1708";
        }

        private void textBoxUsername_CursorChanged(object sender, EventArgs e)
        {
            labelNoteUsername.Text = "";
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            labelNoteUsername.Text = "";
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            labelNoteUsername.Text = "Username = Kode Sales + Tgl dan bulan lahir.  eg.ABC1708";
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (flagPassword == 0)
            {
                labelNotePassword.ForeColor = Color.Red;
                labelNotePassword.Text = "Password only contain " + textBoxPassword.Text.Length + " character";
            }
            else if (flagPassword == 1 || textBoxPassword.Text.Length == 0)
            {
                flagPassword = 1;
                labelNotePassword.Text = "";
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            labelNotePassword.ForeColor = Color.Blue;
            labelNotePassword.Text = "Password at least 7 chararcter and 1 number";
        }

        private void textBoxRWPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRWPassword.Text.Equals(textBoxPassword.Text))
            {
                flagRWPassword = 1;
            }
            else
            {
                flagRWPassword = 0;
            }
            if (flagRWPassword == 0)
            {
                labelNoteRWPassword.ForeColor = Color.Blue;
                labelNoteRWPassword.Text = "Password not match";
                flagRWPassword = 0;
            }
            else
            {
                flagRWPassword = 1;
                labelNoteRWPassword.Text = "Password match";
            }
        }

        private void textBoxRWPassword_Leave(object sender, EventArgs e)
        {
            if (flagRWPassword == 0)
            {
                labelNoteRWPassword.ForeColor = Color.Red;
                labelNoteRWPassword.Text = "Password not match";
                flagRWPassword = 0;
            }
            else if (flagRWPassword == 1 || textBoxRWPassword.Text.Length == 0)
            {
                flagRWPassword = 1;
                labelNoteRWPassword.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       
    }
}
