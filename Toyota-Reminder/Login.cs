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
    public partial class Login : Form
    {
        private IDbConnection _conn = null;
        
        public Login(IDbConnection conn)
        {
            InitializeComponent();
            _conn = conn;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            DAL shipper = null;
            IDataReader reader = null;

            try
            {
                shipper = new DAL();
                reader = shipper.Cek_Sales(_conn);

                if (reader.Read())
                {
                    if (!textBoxUsername.Text.Equals(reader.GetString(0)) || !textBoxPassword.Text.Equals(reader.GetString(1)) )
                    {
                        MessageBox.Show("Username atau Password Salah");

                    }                    
                    else
                    {
                        MessageBox.Show("Login Berhasil");
                        this.DialogResult = DialogResult.OK;
                        
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
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _conn.Close();
            _conn.Dispose();
            this.Close();
            Application.Exit();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == (Keys.Control | Keys.Alt) && e.KeyCode == Keys.P)
            {
                Hide();
                ForgetPass frm = new ForgetPass(_conn);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Visible = true;
                }
                else
                {
                    this.Visible = true;
                }

            }
        }

        private void buttonForget_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tekan CTRL + ALT + P untuk membuka form merubah password.");
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                _conn.Close();
                _conn.Dispose();
                Application.Exit();
            }
        }
    }
}
