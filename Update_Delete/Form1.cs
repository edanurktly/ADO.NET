using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Update_Delete
{
    public partial class Form1 : Form
    {
        static string constr2 = @"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true;";
        SqlConnection connection = new SqlConnection(constr2);
        SqlCommand command = new SqlCommand(constr2);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KategorileriDoldur();
        }

        private void KategorileriDoldur()
        {
            string sql = "Select [CategoryName], [Description] from Categories";
            command.Connection= connection;
            command.CommandText = sql;
            command.CommandType = System.Data.CommandType.Text;
            try
            {
                if(connection.State== System.Data.ConnectionState.Closed)

                     connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                //Eðer DataReader içerisinde Row var ise
                if (reader.HasRows)
                {
                    //Combobox içerisindeki elemanlarý boþalt
                    cmbKategori.Items.Clear();

                    //Result içerisindeki row'lari tek tek oku
                    while (reader.Read())
                    {
                        cmbKategori.Items.Add(reader["CategoryName"].ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("hata oluþtu:" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            
        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKategori.Text=cmbKategori.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string updatesql = "Update Categories set CategoryName=@catname where categoryName=@name";
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = updatesql;
                command.Parameters.AddWithValue("@catname", txtKategori.Text);
                command.Parameters.AddWithValue("@name", cmbKategori.SelectedItem.ToString());

                connection.Open();
                int etkilenenkayitSayisi = command.ExecuteNonQuery();
                //if(etkilenenkayitSayisi>0)
                //{
                //    MessageBox.Show("Güncelleme Baþarýlýdýr");

                //}

                MessageBox.Show(etkilenenkayitSayisi > 0 ? "Güncelleme Baþarýlýdýr" : "Hata Oluþtu");
                //burayi çaðýrmaz isek combobox güncellenmez
                KategorileriDoldur();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata Oluþtu:" + ex.Message);
            }
           finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string deletesql = "Delete Categories where  CategoryName=@name" ;
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = deletesql;
                command.Parameters.AddWithValue("@name", cmbKategori.SelectedItem.ToString());

                connection.Open();
                int etkilenenkayitSayisi = command.ExecuteNonQuery();
                //if(etkilenenkayitSayisi>0)
                //{
                //    MessageBox.Show("Güncelleme Baþarýlýdýr");

                //}

                MessageBox.Show(etkilenenkayitSayisi > 0 ? "Silme Baþarýlýdýr" : "Hata Oluþtu");
                //burayi çaðýrmaz isek combobox güncellenmez
                KategorileriDoldur();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluþtu:" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}