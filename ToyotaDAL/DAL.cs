using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace ToyotaDAL
{
    public class DAL
    {

// SALES DAL ---------------------------------------------------------------------------------------------------------------------
        public IDataReader Cek_Sales(IDbConnection conn)
        {
            IDbCommand _comm = null;

            try
            {
                _comm = new OleDbCommand();
                _comm.CommandText = @"SELECT username,password FROM sales";
                _comm.Connection = conn;
                return _comm.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("fail to execute getitems()", ex);
            }
        }

        public void Register_Sales(IDbConnection conn, String KodeSales, String Username, String Password, String NamaSales, String Alamat, String NoTelpon, String Email)
        {
            IDbCommand _comm = null;

            try
            {
                _comm = new OleDbCommand();
                _comm.CommandText = @"INSERT INTO sales VALUES('" + KodeSales + "','" + Username + "','" + Password + "','" + NamaSales + "', 1 ,'" + Alamat + "','" + NoTelpon + "','" + Email + "')";
                _comm.Connection = conn;
                _comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to register", ex);
            }
        }

        public void updateSales(IDbConnection conn, string u_username, string u_pass)
        {
            IDbCommand _conn = null;
            try
            {
                _conn = new OleDbCommand();
                _conn.Connection = conn;
                _conn.CommandText = @"UPDATE sales SET sales.[password] = '"+u_pass+"' where username='"+ u_username +"';";
                _conn.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update data" + _conn.CommandText, ex);
            }
        }

        public void update_Setting_Sales(IDbConnection conn, string uKodesales, string uUsername, string uPass, string uNamasales, string uAlamat, string uNotlp, string uEmail)
        {
            IDbCommand _conn = null;
            try
            {
                _conn = new OleDbCommand();
                _conn.Connection = conn;
                _conn.CommandText = @"UPDATE sales SET sales.[username]='" + uUsername + "', sales.[password]='" + uPass + "', sales.[namaSales]= '" + uNamasales + "', sales.[alamat]= '" + uAlamat + "', sales.[noTelp] = '" + uNotlp + "', email='" + uEmail + "' WHERE kodeSales = '" + uKodesales +"';";
                _conn.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update data" + _conn.CommandText, ex);
            }
        }

        public IDataReader Get_Sales_Data(IDbConnection conn)
        {
            IDbCommand _comm = null;
            try
            {
                _comm = new OleDbCommand();
                _comm.CommandText = @"SELECT kodeSales, namaSales, alamat, noTelp, email FROM sales";
                _comm.Connection = conn;
                return _comm.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve sales data", ex);
            }
        }

        public DataSet Get_Sales_Data_Full(IDbConnection conn)
        { 
            IDbCommand _comm = null; 
            OleDbDataAdapter _adapter = null; 
            DataSet _dataset = null; 

            try
            {
                _comm = new OleDbCommand();
                _comm.Connection = conn;
                _comm.CommandText = @"SELECT kodeSales, username, password, namaSales, alamat, noTelp, email FROM sales";

                _dataset = new DataSet();
                _adapter = new OleDbDataAdapter();
                _adapter.SelectCommand = (OleDbCommand)_comm;
                _adapter.Fill(_dataset); 
                return _dataset;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve sales data", ex);
            }
        }
//---------------------------------------------------------------------------------------------------------------------        
//CUSTOMER DAL--------------------------------------------------------------------------------------------------------------------  
        public void Add_Customer(IDbConnection conn, String KodeSales, String namaCustomer, String jenKel, String Alamat, String noTelp, String noHP1, String noHP2, String Email, DateTime tglLahir, String Agama, String anggotaKeluarga1, String anggotaKeluarga2, String anggotaKeluarga3, String anggotaKeluarga4, DateTime? tglLahirKeluarga1, DateTime? tglLahirKeluarga2, DateTime? tglLahirKeluarga3, DateTime? tglLahirKeluarga4)
        {
            IDbCommand _comm = null;

            String tanggalHabisAsuransi = "NULL";
            String tanggalLahirKeluarga1 = "NULL";
            String tanggalLahirKeluarga2 = "NULL";
            String tanggalLahirKeluarga3 = "NULL";
            String tanggalLahirKeluarga4 = "NULL";
            //tanggal lahir
            String tanggalLahir = tglLahir.ToShortDateString();

            //tanggal lahir keluarga 1
            if (tglLahirKeluarga1.HasValue)
                tanggalLahirKeluarga1 = "'"+tglLahirKeluarga1.Value.ToShortDateString()+"'";
            //tanggal lahir keluarga 2
            if (tglLahirKeluarga2.HasValue)
                tanggalLahirKeluarga2 = "'"+tglLahirKeluarga2.Value.ToShortDateString()+"'";
            //tanggal lahir keluarga 3
            if (tglLahirKeluarga3.HasValue)
                tanggalLahirKeluarga3 = "'"+tglLahirKeluarga3.Value.ToShortDateString()+"'";
            //tanggal lahir keluarga 4
            if (tglLahirKeluarga4.HasValue)
                tanggalLahirKeluarga4 = "'"+tglLahirKeluarga4.Value.ToShortDateString()+"'";

            try
            {
                _comm = new OleDbCommand();
                _comm.Connection = conn;
                _comm.CommandText = @"INSERT INTO customer(kodeSales,namaCustomer,jenisKelamin, alamat, noTelp, noHP1, noHP2, email, tglLahir, agama, anggotaKeluarga1, anggotaKeluarga2, anggotaKeluarga3, anggotaKeluarga4, tglLahirKeluarga1, tglLahirKeluarga2, tglLahirKeluarga3, tglLahirKeluarga4)
                                     VALUES('" + KodeSales + "','" + namaCustomer + "','" + jenKel + "','" + Alamat + "','" + noTelp + "','" + noHP1 + "','" + noHP2 + "','" + Email + "','" + tglLahir + "','" + Agama + "','" + anggotaKeluarga1 + "','" + anggotaKeluarga2 + "','" + anggotaKeluarga3 + "','" + anggotaKeluarga4 + "'," + tanggalLahirKeluarga1 + "," + tanggalLahirKeluarga2 + "," + tanggalLahirKeluarga3 + "," + tanggalLahirKeluarga4 + ")";

                _comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add new customer", ex);
            }
        }

        public IDataReader Cek_idCustomer(IDbConnection conn, string namaCust)
        {
            IDbCommand _comm = null;

            try
            {
                _comm = new OleDbCommand();
                _comm.CommandText = @"SELECT idCustomer FROM customer WHERE namaCustomer ='" + namaCust + "'";
                _comm.Connection = conn;
                return _comm.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("fail to execute getitems()", ex);
            }
        }

        public void Add_Transaksi(IDbConnection conn, int idCustomer, String tipeMobil, String warnaMobil, DateTime tglDeli, DateTime tglSTNK, DateTime? tglAsuransi, String namaAsuransi, int jmlTahunAsuransi, String caraPembayaran, int jmlTahunKredit)
        {
            IDbCommand _comm = null;

            String tanggalAsuransi = "NULL";
            String tanggalHabisAsuransi = "NULL";

            //STNK
            String tanggalSTNK = tglSTNK.ToShortDateString();
            String tanggalHabisSTNK = tglSTNK.AddYears(1).ToShortDateString();
            //asuransi
            if (tglAsuransi.HasValue)
            {
                tanggalAsuransi = "'" + tglAsuransi.Value.ToShortDateString() + "'";
                tanggalHabisAsuransi = "'" + tglAsuransi.Value.AddYears(jmlTahunAsuransi).ToShortDateString() + "'";
            }
            //tanggal DO
            String tanggalDeli = tglDeli.ToShortDateString();

            try
            {
            _comm = new OleDbCommand();
            _comm.Connection = conn;
            _comm.CommandText = @"INSERT INTO transaksi(idCustomer,tipeMobil, warnaMobil, tglDelivery, tglSTNK, tglAsuransi, namaAsuransi, jmlTahunAsuransi, caraPembayaran, jmlTahunKredit, habisSTNK, habisAsuransi)
                                     VALUES('" + idCustomer + "','" + tipeMobil + "','" + warnaMobil + "','" + tanggalDeli + "','" + tanggalSTNK + "'," + tanggalAsuransi + ",'" + namaAsuransi + "'," + jmlTahunAsuransi + ",'" + caraPembayaran + "', " + jmlTahunKredit + ",'" + tanggalHabisSTNK + "', " + tanggalHabisAsuransi + ")";

            
            _comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add new customer", ex);
            }
        }

        public DataSet Get_AllCustomer_Data(IDbConnection conn)
        {
            IDbCommand _comm = null;
            OleDbDataAdapter _adapter = null;
            DataSet _dataset = null;

            try
            {
                _comm = new OleDbCommand();
                _comm.CommandText = @"SELECT c.idCustomer, namaCustomer, alamat, noTelp, noHP1, noHP2, email, tglLahir, agama, anggotaKeluarga1, anggotaKeluarga2, anggotaKeluarga3, anggotaKeluarga4, tglLahirKeluarga1, tglLahirKeluarga2, tglLahirKeluarga3, tglLahirKeluarga4, tipeMobil, warnaMobil, tglDelivery, tglSTNK, tglAsuransi, jmlTahunAsuransi, caraPembayaran FROM customer c,transaksi t WHERE c.idCustomer = t.idCustomer";
                _comm.Connection = conn;

                _adapter = new OleDbDataAdapter();
                _adapter.SelectCommand = (OleDbCommand)_comm;

                _dataset = new DataSet();
                _adapter.Fill(_dataset);
                return _dataset;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve all customer data", ex);
            }
        }

        //overide get all customer data
        public DataSet Get_AllCustomer_Data(IDbConnection conn, String outer_command)
        {
            IDbCommand _comm = null;
            OleDbDataAdapter _adapter = null;
            DataSet _dataset = null;

            try
            {
                _comm = new OleDbCommand();
                _comm.CommandText = @"SELECT c.idCustomer, namaCustomer, jenisKelamin, alamat, noTelp, noHP1, noHP2, email, tglLahir, agama, anggotaKeluarga1, anggotaKeluarga2, anggotaKeluarga3, anggotaKeluarga4, tglLahirKeluarga1, tglLahirKeluarga2, tglLahirKeluarga3, tglLahirKeluarga4, tipeMobil, warnaMobil, tglDelivery, tglSTNK, tglAsuransi, jmlTahunAsuransi, caraPembayaran FROM customer c, transaksi t WHERE c.idCustomer = t.idCustomer " + outer_command;
                _comm.Connection = conn;

                _adapter = new OleDbDataAdapter();
                _adapter.SelectCommand = (OleDbCommand)_comm;

                _dataset = new DataSet();
                _adapter.Fill(_dataset);
                return _dataset;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve all customer data", ex);
            }
        }

        public DataSet Get_Customer_Data(IDbConnection conn, int userID, String tipeMobil)
        {
            IDbCommand _comm = null;
            OleDbDataAdapter _adapter = null;
            DataSet _dataset = null;

            try
            {
                _comm = new OleDbCommand();
                _comm.CommandText = @"SELECT namaCustomer, jenisKelamin, alamat, noTelp, noHP1, noHP2, email, tglLahir, agama, anggotaKeluarga1, anggotaKeluarga2, anggotaKeluarga3, anggotaKeluarga4, tglLahirKeluarga1, tglLahirKeluarga2, tglLahirKeluarga3, tglLahirKeluarga4, tipeMobil, warnaMobil, tglDelivery, tglSTNK, namaAsuransi, tglAsuransi, jmlTahunAsuransi, caraPembayaran, jmlTahunKredit FROM customer c, transaksi t WHERE c.idCustomer = t.idCustomer AND c.idCustomer = " + userID + " AND t.tipeMobil LIKE '" + tipeMobil + "%'";
                _comm.Connection = conn;

                _adapter = new OleDbDataAdapter();
                _adapter.SelectCommand = (OleDbCommand)_comm;

                _dataset = new DataSet();
                _adapter.Fill(_dataset);
                return _dataset;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve customer data", ex);
            }
        }

        public void Update_Customer_Data(IDbConnection conn, int customerID, String namaCustomer, String Alamat, String noTelp, String noHP1, String noHP2, String Email, DateTime tglLahir, String jenKel, String Agama, String anggotaKeluarga1, String anggotaKeluarga2, String anggotaKeluarga3, String anggotaKeluarga4, DateTime? tglLahirKeluarga1, DateTime? tglLahirKeluarga2, DateTime? tglLahirKeluarga3, DateTime? tglLahirKeluarga4)
        {
            IDbCommand _comm = null;
            String tanggalLahirKeluarga1 = "NULL";
            String tanggalLahirKeluarga2 = "NULL";
            String tanggalLahirKeluarga3 = "NULL";
            String tanggalLahirKeluarga4 = "NULL";
            //tanggal lahir
            String tanggalLahir = tglLahir.ToShortDateString();

            //tanggal lahir keluarga 1
            if (tglLahirKeluarga1.HasValue)
                tanggalLahirKeluarga1 = "'" + tglLahirKeluarga1.Value.ToShortDateString() + "'";
            //tanggal lahir keluarga 2
            if (tglLahirKeluarga2.HasValue)
                tanggalLahirKeluarga2 = "'" + tglLahirKeluarga2.Value.ToShortDateString() + "'";
            //tanggal lahir keluarga 3
            if (tglLahirKeluarga3.HasValue)
                tanggalLahirKeluarga3 = "'" + tglLahirKeluarga3.Value.ToShortDateString() + "'";
            //tanggal lahir keluarga 4
            if (tglLahirKeluarga4.HasValue)
                tanggalLahirKeluarga4 = "'" + tglLahirKeluarga4.Value.ToShortDateString() + "'";

            try
            {
                _comm = new OleDbCommand();
                _comm.CommandText = @"UPDATE customer SET namaCustomer = '" + namaCustomer + "', alamat = '" + Alamat + "', noTelp = '" + noTelp + "', noHP1 = '" + noHP1 + "', noHP2 = '" + noHP2 + "', email = '" + Email + "', tglLahir = '" + tanggalLahir + "', jenisKelamin = '" + jenKel + "', agama = '" + Agama + "', anggotaKeluarga1 ='" + anggotaKeluarga1 + "', anggotaKeluarga2 = '" + anggotaKeluarga2 +
                                     "', anggotaKeluarga3 = '" + anggotaKeluarga3 + "', anggotaKeluarga4 = '" + anggotaKeluarga4 + "', tglLahirKeluarga1 = " + tanggalLahirKeluarga1 + ", tglLahirKeluarga2 = " + tanggalLahirKeluarga2 + ", tglLahirKeluarga3 = " + tanggalLahirKeluarga3 + ", tglLahirKeluarga4 = " + tanggalLahirKeluarga4 + " WHERE idCustomer = " + customerID;
                _comm.Connection = conn;
                _comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update customer data", ex);
            }
        }

        public void Update_Customer_Car_Data(IDbConnection conn, int customerID, String tipeMobilLama, String tipeMobilBaru, String warnaMobil, DateTime tglDelivery, DateTime tglSTNK, DateTime? tglAsuransi, String namaAsuransi, int jmlTahunAsuransi, String caraPembayaran, int jmlTahunKredit)
        {
            IDbCommand _comm = null;

            String tanggalAsuransi = "NULL";
            String tanggalHabisAsuransi = "NULL";

            //STNK
            String tanggalSTNK = tglSTNK.ToShortDateString();
            String tanggalHabisSTNK = tglSTNK.AddYears(1).ToShortDateString();
            //asuransi
            if (tglAsuransi.HasValue)
            {
                tanggalAsuransi = "'" + tglAsuransi.Value.ToShortDateString() + "'";
                tanggalHabisAsuransi = "'" + tglAsuransi.Value.AddYears(jmlTahunAsuransi).ToShortDateString() + "'";
            }
            //tanggal DO
            String tanggalDeli = tglDelivery.ToShortDateString();

            try
            {
                _comm = new OleDbCommand();
                _comm.CommandText = @"UPDATE transaksi SET tipeMobil = '" + tipeMobilBaru + "', warnaMobil = '" + warnaMobil + "', tglDelivery = '" + tanggalDeli + "', tglSTNK = '" + tanggalSTNK + "', tglAsuransi = " + tanggalAsuransi + ", namaAsuransi = '" + namaAsuransi + "', jmlTahunAsuransi = " + jmlTahunAsuransi + ", caraPembayaran = '" + caraPembayaran + "', jmlTahunKredit = " + jmlTahunKredit + ", habisSTNK = '" + tanggalHabisSTNK + "', habisAsuransi = " + tanggalHabisAsuransi + " WHERE idCustomer = " + customerID + " AND tipeMobil = '" + tipeMobilLama + "'";
                _comm.Connection = conn;
                _comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update customer car data", ex);
            }
        }

        public DataSet Get_Customer_Data_ADDCAR(IDbConnection conn, int userID)
        {
            IDbCommand _comm = null;
            OleDbDataAdapter _adapter = null;
            DataSet _dataset = null;

            try
            {
                _comm = new OleDbCommand();
                _comm.CommandText = @"SELECT namaCustomer, alamat, noTelp, noHP1, noHP2, email, tglLahir, agama FROM customer WHERE idCustomer = "+ userID;
                _comm.Connection = conn;

                _adapter = new OleDbDataAdapter();
                _adapter.SelectCommand = (OleDbCommand)_comm;

                _dataset = new DataSet();
                _adapter.Fill(_dataset);
                return _dataset;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve customer data", ex);
            }
        }

        public void Update_Customer_Data(IDbConnection conn, int customerID, String namaCustomer, String Alamat, String noTelp, String noHP1, String noHP2, String Email, String tglLahir, String Agama, String anggotaKeluarga1, String anggotaKeluarga2, String anggotaKeluarga3, String anggotaKeluarga4, DateTime tglLahirKeluarga1, DateTime tglLahirKeluarga2, DateTime tglLahirKeluarga3, DateTime tglLahirKeluarga4, DateTime tglAsuransi, int jmlTahunAsuransi)
        {
            IDbCommand _comm = null;
            DateTime tglHabisAsuransi = tglAsuransi.AddYears(jmlTahunAsuransi);

            try
            {
                _comm = new OleDbCommand();
                _comm.CommandText = @"UPDATE customer SET namaCustomer = '" + namaCustomer + "', alamat = '" + Alamat + "', noTelp = '" + noTelp + "', noHP1 = '" + "', noHP2 = '" + noHP2 + "', email = '" + Email + "', tglLahir = '" + tglLahir + "', agama = '" + Agama + "', anggotaKeluarga1 ='" + anggotaKeluarga1 + "', anggotaKeluarga2 = '" + anggotaKeluarga2 +
                                     "', anggotaKeluarga3 = '" + anggotaKeluarga3 + "', anggotaKeluarga4 = '" + anggotaKeluarga4 + "', tglLahirKeluarga1 = '" + tglLahirKeluarga1 + "', tglLahirKeluarga2 = '" + tglLahirKeluarga2 + "', tglLahirKeluarga3 = '" + tglLahirKeluarga3 + "', tglLahirKeluarga4 = '" + tglLahirKeluarga4 + "', tglAsuransi = '" + tglAsuransi + "', jmlTahunAsuransi = " + jmlTahunAsuransi + ", habisAsuransi = '" + tglHabisAsuransi + "'" +
                                     "WHERE idCustomer = " + customerID;
                _comm.Connection = conn;
                _comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update customer data", ex);
            }
        }

        public void Delete_Customer_Data(IDbConnection conn, int idCustomer)
        {
            IDbCommand _comm = null;

            try
            {
                _comm = new OleDbCommand();
                _comm.CommandText = @"DELETE FROM customer WHERE idCustomer = " + idCustomer;
                _comm.Connection = conn;
                _comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete customer data", ex);
            }

        }

        public void Delete_Customer_CAR(IDbConnection conn, int idCustomer , string tmpTipeMobil)
        {
            IDbCommand _comm = null;

            try
            {
                _comm = new OleDbCommand();
                _comm.CommandText = @"DELETE FROM transaksi WHERE idCustomer = " + idCustomer + " AND tipeMobil = '"+ tmpTipeMobil +"'";
                _comm.Connection = conn;
                _comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete customer data", ex);
            }

        }



//---------------------------------------------------------------------------------------------------------------------    
//EVENT DAL---------------------------------------------------------------------------------------------------------------------    
        public void Initialize_Data_Update(IDbConnection conn)
        {
            IDbCommand _comm = null;

            //updating STNK
            try
            {
                _comm = new OleDbCommand();
                _comm.CommandText = @"UPDATE customer SET Year([habisSTNK]) = Year(Now())+1 WHERE Now() = habisSTNK+1";
                _comm.Connection = conn;
                _comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to initialize customer data", ex);
            }
        }

        public DataSet Get_Birthday_Data(IDbConnection conn, DateTime selectedDate)
        {
            IDbCommand _comm = null;
            OleDbDataAdapter _adapter = null;
            DataSet _dataset = null;

            try
            {

            _comm = new OleDbCommand();
            _comm.Connection = conn;
            _comm.CommandText = @"SELECT namaCustomer, noTelp, noHP1, noHP2 FROM customer 
                                      WHERE Day([tglLahir]) = '" + selectedDate.Day + "' AND Month([tglLahir]) = '" + selectedDate.Month + "'";

            _adapter = new OleDbDataAdapter();
            _dataset = new DataSet();
            _adapter.SelectCommand = (OleDbCommand)_comm;


            _adapter.Fill(_dataset);
            return _dataset;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve birthday data", ex);
            }
        }

        public DataSet Get_STNK_Data(IDbConnection conn, DateTime selectedDate)
        {
            IDbCommand _comm = null;
            OleDbDataAdapter _adapter = null;
            DataSet _dataset = null;

            String date = "#" + selectedDate.ToShortDateString() + "#";

            try
            {
            _comm = new OleDbCommand();
            _comm.CommandText = @"SELECT namaCustomer, noTelp, noHP1, noHP2, habisSTNK FROM customer c INNER JOIN transaksi t
                                     ON c.idCustomer = t.idCustomer WHERE " + date + " Between t.habisSTNK AND t.habisSTNK-7 ORDER BY t.habisSTNK DESC;";
            _comm.Connection = conn;

            _adapter = new OleDbDataAdapter();
            _adapter.SelectCommand = (OleDbCommand)_comm;

            _dataset = new DataSet();
            _adapter.Fill(_dataset);
            return _dataset;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retireve STNK data", ex);
            }
        }

        public DataSet Get_Asuransi_Data(IDbConnection conn, DateTime selectedDate)
        {
            IDbCommand _comm = null;
            OleDbDataAdapter _adapter = null;
            DataSet _dataset = null;

            String date = "#" + selectedDate + "#";

            try
            {
            _comm = new OleDbCommand();
            _comm.CommandText = @"SELECT namaCustomer, noTelp, noHP1, noHP2, habisAsuransi FROM customer c, transaksi t
                                     WHERE c.idCustomer = t.idCustomer AND " + date + " Between habisAsuransi AND habisAsuransi-30 ORDER BY habisAsuransi DESC";
            _comm.Connection = conn;

            _adapter = new OleDbDataAdapter();
            _adapter.SelectCommand = (OleDbCommand)_comm;

            _dataset = new DataSet();
            _adapter.Fill(_dataset);
            return _dataset;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve Asuransi data", ex);
            }
        }
    }
}