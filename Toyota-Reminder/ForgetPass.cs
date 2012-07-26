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
    public partial class ForgetPass : Form
    {
        IDbConnection _conn = null;
        private int flagPass = 0;
        private int flagConPass = 0;

        public ForgetPass(IDbConnection conn)
        {
            InitializeComponent();
            _conn = conn;

            DAL shipper = null;
            IDataReader reader = null;

            try
            {
                shipper = new DAL();
                reader = shipper.Cek_Sales(_conn);

                if (reader.Read())
                {
                    textBoxUsername.Text = reader[0].ToString();
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

        private void ForgetPass_Load(object sender, EventArgs e)
        {

        }

        private void buttonChange_Click(object sender, EventArgs e)
        {

            if (flagPass == 1 && flagConPass == 1 && textBoxUsername.Text.Length != 0 && textBoxNPass.Text.Length != 0 && textBoxCNPass.Text.Length != 0)
            {
                DAL shipper = null;

                try
                {
                    shipper = new DAL();
                    shipper.updateSales(_conn, textBoxUsername.Text, textBoxCNPass.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("Password Change Succeed.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Errors Occured");
            }
        }

        private void textBoxNPass_Enter(object sender, EventArgs e)
        {
            labelNotePass.ForeColor = Color.Blue;
            labelNotePass.Text = "Password at least 7 chararcter and 1 number";
        }

        private void textBoxNPass_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNPass.Text.Length < 7)
            {
                flagPass = 0;
            }
            else if (textBoxNPass.Text.Length >= 7)
            {
                flagPass = 1;
            }
            if (flagPass == 0)
            {
                labelNotePass.Text = "Password only contain " + textBoxNPass.Text.Length + " character";
                flagPass = 0;
            }
            else if (flagPass == 1)
            {
                labelNotePass.Text = "";
            }
        }

        private void textBoxNPass_Leave(object sender, EventArgs e)
        {
            if (flagPass == 0)
            {
                labelNotePass.ForeColor = Color.Red;
                labelNotePass.Text = "Password only contain " + textBoxNPass.Text.Length + " character";
            }
            else if (flagPass == 1 || textBoxNPass.Text.Length == 0)
            {
                labelNotePass.ForeColor = Color.Blue;
                labelNotePass.Text = "";
            }
        }

        private void textBoxCNPass_Leave(object sender, EventArgs e)
        {
            if (flagConPass == 0)
            {
                labelNoteConPass.ForeColor = Color.Red;
                labelNoteConPass.Text = "Password not match";
            }
            else if (flagConPass == 1)
            {
                labelNoteConPass.ForeColor = Color.Blue;
                labelNoteConPass.Text = "";
            }
        }

        private void textBoxCNPass_TextChanged_1(object sender, EventArgs e)
        {
            if (textBoxCNPass.Text.Equals(textBoxNPass.Text))
            {
                flagConPass = 1;
            }
            else
            {
                flagConPass = 0;
            }
            if (flagConPass == 0)
            {
                labelNoteConPass.ForeColor = Color.Blue;
                labelNoteConPass.Text = "Password not match";
                flagConPass = 0;
            }
            else if (flagConPass == 1)
            {
                labelNoteConPass.Text = "Password match";
                flagConPass = 1;
            }
        }

        private void ForgetPass_Load_1(object sender, EventArgs e)
        {

        }
    }
}
