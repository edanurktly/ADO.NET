using System.Data.SqlClient;

namespace insert
{
    public partial class Form1 : Form
    {
        static string constr2 = @"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true;";
        SqlConnection connection = new SqlConnection(constr2);
        SqlCommand command = new SqlCommand(constr2);
        string select_employee = "select * from EmpYedek";
      

        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insert_employee = "insert into employees(firstname,LastName,City)";
            insert_employee += "  Values('" + txtAdi.Text + "','" + txtSoyadi.Text + "', '" + txtsehir.Text + "')";
            command.Connection = connection;
            command.CommandText = insert_employee;
            command.CommandType = System.Data.CommandType.Text;
          

            try
            {
                connection.Open();
                int kayitSayisi = command.ExecuteNonQuery();
                if (kayitSayisi > 0)
                    MessageBox.Show("kayit Baþarýlý þekilde eklenmiþtir");
                else
                    MessageBox.Show("bilinmeyen hata oluþtu");
            }
            catch(Exception ex)
            {
                MessageBox.Show("hata oluþtu"+ ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string insert_employee = "insert into employees(firstname,LastName,City) Values(@ad,@soyad,@sehir)";
           // insert_employee += "  Values('" + txtAdi.Text + "','" + txtSoyadi.Text + "', '" + txtsehir.Text + "')";
            command.Connection = connection;
            command.CommandText = insert_employee;
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.AddWithValue("@ad", txtAdi.Text);
            command.Parameters.AddWithValue("@soyad", txtSoyadi.Text);
            command.Parameters.AddWithValue("@sehir", txtsehir.Text);

            try
            {
                connection.Open();
                int kayitSayisi = command.ExecuteNonQuery();
                if (kayitSayisi > 0)
                    MessageBox.Show("kayit Baþarýlý þekilde eklenmiþtir");
                else
                    MessageBox.Show("bilinmeyen hata oluþtu");
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluþtu" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string insert_employee = "insert into employees(firstname,LastName,City) Values(@ad,@soyad,@sehir) Select @@IDENTITY";
            // insert_employee += "  Values('" + txtAdi.Text + "','" + txtSoyadi.Text + "', '" + txtsehir.Text + "')";
            command.Connection = connection;
            command.CommandText = insert_employee;
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.AddWithValue("@ad", txtAdi.Text);
            command.Parameters.AddWithValue("@soyad", txtSoyadi.Text);
            command.Parameters.AddWithValue("@sehir", txtsehir.Text);

            try
            {
                connection.Open();
                Decimal kayitSayisi = (decimal)command.ExecuteScalar();
                if (kayitSayisi > 0)
                    MessageBox.Show("kayit Baþarýlý þekilde eklenmiþtir.Kayit numaraniz:"+kayitSayisi);
                else
                    MessageBox.Show("bilinmeyen hata oluþtu");
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluþtu" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string insert_employee = "CalisanEkle";
            // insert_employee += "  Values('" + txtAdi.Text + "','" + txtSoyadi.Text + "', '" + txtsehir.Text + "')";
            command.Connection = connection;
            command.CommandText = insert_employee;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ad", txtAdi.Text);
            command.Parameters.AddWithValue("@soyad", txtSoyadi.Text);
            command.Parameters.AddWithValue("@sehir", txtsehir.Text);

            try
            {
                connection.Open();
                Decimal kayitSayisi = (decimal)command.ExecuteNonQuery();
                if (kayitSayisi > 0)
                    MessageBox.Show("kayit Baþarýlý þekilde eklenmiþtir.Kayit numaraniz:" + kayitSayisi);
                else
                    MessageBox.Show("bilinmeyen hata oluþtu");
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata oluþtu" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
    }
    

