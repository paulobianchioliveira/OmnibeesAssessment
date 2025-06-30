using Microsoft.Data.SqlClient;
using OmniBeesAssessment.Model;
using System.Security.Cryptography;
using System.Text;

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

        private static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes); // .NET 5 +
        }

        public static User ValidateUser(UserDto p_user)
        {
            User user = new User();

            using (SqlConnection sqlCnn = new SqlConnection(cnnString))
            {
                try
                {
                    sqlCnn.Open();
                    //Console.WriteLine("ServerVersion: {0}", sqlCnn.ServerVersion);Console.WriteLine("State: {0}", sqlCnn.State);

                    var myCommand = new SqlCommand();
                    var hashedPwd = CreateMD5(p_user.Password);
                    var SQL = string.Format("select FK_Key,Description from Parceiro where [User] = '{0}' and Password = '{1}'", p_user.Username, hashedPwd);

                    myCommand.Connection = sqlCnn;
                    myCommand.CommandText = SQL;

                    using (var myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            user.UserName = p_user.Username; user.Id = myReader.GetInt32(0); user.Name = myReader.GetString(1);
                        }
                    }
                    sqlCnn.Close();
                }
                catch (Exception ex)
                {
                }
            }

            return user;
        }

        public static User ValidateUser(int UserId)
        {
            User user = new User();

            using (SqlConnection sqlCnn = new SqlConnection(cnnString))
            {
                try
                {
                    sqlCnn.Open();
                    //Console.WriteLine("ServerVersion: {0}", sqlCnn.ServerVersion);Console.WriteLine("State: {0}", sqlCnn.State);

                    var myCommand = new SqlCommand();
                    var SQL = string.Format("select Description from Parceiro where FK_Key = '0'", UserId);

                    myCommand.Connection = sqlCnn;
                    myCommand.CommandText = SQL;

                    using (var myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            user.Id = UserId; user.Name = myReader.GetString(0);
                        }
                    }
                    sqlCnn.Close();
                }
                catch (Exception ex)
                {
                }
            }

            return user;
        }

    }
}
