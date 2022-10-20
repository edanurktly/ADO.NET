using System.Data;
using System.Data.SqlClient;

namespace Disconnected1
{
    public partial class Form1 : Form
    {

        static string constr2 = @"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UrunleriYukle();
        }

        private void UrunleriYukle()
        {
            string sql = @"select p.ProductID,p.ProductName,s.CompanyName,c.CategoryName,p.UnitPrice,p.UnitsInStock
from Products p
inner join Categories c on c.CategoryID=p.CategoryID
inner join Suppliers s on s.SupplierID=p.SupplierID";
            //Burada SqlConnection Nesnesi scrope'larýn bittiði yerde imha olur
            //omru biter.
            using (SqlConnection conn = new SqlConnection(constr2))
            {
                SqlDataAdapter adaptor = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adaptor.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }
        public void edanur(string sql)
        {
            using (SqlConnection conn = new SqlConnection(constr2))
            {
                SqlDataAdapter adaptor = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adaptor.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edanur("Select * from Customers");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            edanur("Select * from Suppliers");
        }

       
        private void button3_Click(object sender, EventArgs e)
        {

            edanur("Select * from Products");

        }


        
    }
}
    
