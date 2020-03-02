using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsonCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = @"server=localhost;database=Business;userid=root;
        password=3281Greek";

            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                Console.WriteLine("MySQL DB Connected");

                string stm = "SELECT * FROM CustomerInfo WHERE location = 'Asia' AND purchasedDate=curDate();";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }

                //string version = Convert.ToString(cmd.ExecuteScalar());
                //Console.WriteLine("MySQL version : {0}", version);

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {

                if (conn != null)
                {
                    conn.Close();
                }

            }
        }
    }
}
