using System.Data.SqlClient;

namespace BaglantiCumlesi
{
    internal class Program
    {
        //sql Server daki Database'e bağlanmaya yarar
        //tek görevi vardır. sql server ile programımız arasında köprü vazifesi görür
        static SqlConnection connection;

        //sql Connection String sadece sql server'a değil bütün database ler için gerekli bir yapısı vardır.
        //Yapi:"Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;"
        static string constr =@"Server=(localdb)\mssqllocaldb;Database=Northwind;User Id=edanur;Password=123;";
       
        //windows Authentication için aşağıdaki yapı kullanılır
        static string constr2 = @"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true;";

        /// <summary>
        /// server=sql serer'in hangi ip adresinde çalıştığını bildirir.
        /// database=çalışan sql server üzerinde hangi database'e bağlancağını belirtir.
        /// user Id:Sql server üzerinde tanımlı kullanıcı Id'sidir.
        /// password:Bu kullanıcıya ait şifre;
        /// </summary>
        /// <param name="args"></param>



        static void Main(string[] args)
        {
            connection = new SqlConnection(constr);

            //baglantiyi acmak icin kontrol etmek lazim
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                Console.WriteLine("Baglantı Kuruldu");
            }
            else
            {
                Console.WriteLine("Bu bağlantı zaten açık");
            }
            
        }
    }
}