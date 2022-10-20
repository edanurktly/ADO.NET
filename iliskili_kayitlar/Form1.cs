using System.Data.SqlClient;
using System.Data;

namespace iliskili_kayitlar
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
            GridDoldur("Select * from customers", dataGridView1);
        }

        private void GridDoldur(string sql, DataGridView gridView)
        {
            using (SqlConnection conn = new SqlConnection(constr2))
            {
                SqlDataAdapter adaptor = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adaptor.Fill(ds);

                gridView.DataSource = ds.Tables[0];
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dataGridView1.CurrentRow.Cells[0].Value;
            string sql = "select * from Orders Where CustomerId='" + id.ToString() + "' ";

            GridDoldur(sql, dataGridView2);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dataGridView2.CurrentRow.Cells[0].Value;
            string sql=@"Select od.OrderId,p.ProductName,od.UnitPrice,od.Quantity,
                           (od.UnitPrice*od.Quantity) as ToplamTutar
                          from [Order Details] od
                     inner join Products p on p.ProductId=od.ProductId
                     where OrderId=" + id.ToString() ;

            GridDoldur(sql, dataGridView3);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}