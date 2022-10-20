using System.Data.SqlClient;

namespace Selectt
{
    public partial class Form1 : Form
    {
        static string constr2 = @"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true;";
        SqlConnection  connection = new SqlConnection(constr2);
        SqlCommand command = new SqlCommand(constr2);
       string select_employee = "select * from Employees";
        
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //hangi sqlconnection ile calýþacaðýný bilmek ister.
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = select_employee;

            try
            {
                connection.Open();
                SqlDataReader rdr = command.ExecuteReader();

                if(rdr.HasRows) //eðer SqlDataReader içerisinde kayit ar ise donsun
                {
                    while(rdr.Read())
                    {
                        string str = rdr["EmployeeID"] + "" + rdr["FirstName"]+""+
                            rdr["LastName"] + "" + rdr["City"];

                        lstCalisanlar.Items.Add(str);
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
    }
}