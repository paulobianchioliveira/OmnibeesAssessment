using Microsoft.Data.SqlClient;

namespace OmniBeesAssessment.Data
{
    public static class Access
    {
        private static string cnnString = "Integrated Security=SSPI;Initial Catalog=Omnibees;Data Source=localhost\\SQLEXPRESS;TrustServerCertificate=True;";
        public static int ValidateSecret(string secret)
        {
            int Partner = 0;

            using (SqlConnection sqlCnn = new SqlConnection(cnnString))
            {
                try
                {
                    sqlCnn.Open();
                    //Console.WriteLine("ServerVersion: {0}", sqlCnn.ServerVersion);Console.WriteLine("State: {0}", sqlCnn.State);

                    var myCommand = new SqlCommand();
                    var SQL = string.Format("SELECT [FK_Key] from Parceiro Where Secret = '{0}'", secret);

                    myCommand.Connection = sqlCnn;
                    myCommand.CommandText = SQL;

                    using (var myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            Partner = myReader.GetInt32(0);
                        }
                    }
                    sqlCnn.Close();
                }
                catch (Exception ex)
                {
                }
            }

            return Partner;
        }

        public static int Agravo(int age)
        {
            int Agravo = -1;

            using (SqlConnection sqlCnn = new SqlConnection(cnnString))
            {
                try
                {
                    sqlCnn.Open();
                    //Console.WriteLine("ServerVersion: {0}", sqlCnn.ServerVersion);Console.WriteLine("State: {0}", sqlCnn.State);

                    var myCommand = new SqlCommand();
                    var SQL = string.Format("select Agravo from FaixaIdade where {0} between BaseValue and Limit", age);

                    myCommand.Connection = sqlCnn;
                    myCommand.CommandText = SQL;

                    using (var myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            Agravo = myReader.GetInt32(0);
                        }
                    }
                    sqlCnn.Close();
                }
                catch (Exception ex)
                {
                }
            }

            return Agravo;
        }

    }
}
