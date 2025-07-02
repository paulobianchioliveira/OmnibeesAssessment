using Microsoft.AspNetCore.DataProtection;
using Microsoft.Data.SqlClient;
using OmniBeesAssessment.Model;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace OmniBeesAssessment.Data
{
    public static class Access
    {
        private static string cnnString = "Integrated Security=SSPI;Initial Catalog=Omnibees;Data Source=localhost\\SQLEXPRESS;TrustServerCertificate=True;";
        public static int ValidateDel(CotacaoDel cotacao)
        {
            int del=0;
            using (SqlConnection sqlCnn = new SqlConnection(cnnString))
            {
                try
                {
                    sqlCnn.Open();
                    //Console.WriteLine("ServerVersion: {0}", sqlCnn.ServerVersion);Console.WriteLine("State: {0}", sqlCnn.State);

                    var myCommand = new SqlCommand();
                    var SQL = $"delete from CotacaoCobertura where IdCotacao = {cotacao.Id}";

                    myCommand.Connection = sqlCnn;
                    myCommand.CommandText = SQL;
                    myCommand.ExecuteNonQuery();

                    SQL = $"delete from CotacaoBeneficiario where IdCotacao = {cotacao.Id}";
                    myCommand.CommandText = SQL;
                    myCommand.ExecuteNonQuery();

                    SQL = $"delete from Cotacao where Id = {cotacao.Id}";
                    myCommand.CommandText = SQL;
                    myCommand.ExecuteNonQuery();
                    
                    sqlCnn.Close();
                }
                catch (Exception ex)
                {
                }
            }

            return del;
        }
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

        public static List<Cotacao> ListData(ListarCotacao cotacaoPesq)
        {
            var data = new List<Cotacao>();

            using (SqlConnection sqlCnn = new SqlConnection(cnnString))
            {
                try
                {
                    sqlCnn.Open();
                    string SQL = "select IdParceiro,IdCotacao,NomeSegurado,Endereco,CEP,DDD,Telefone,Nascimento,Premio,ImportanciaSegurada,IdProduto,Produto,Documento from V_COTACAO where IdParceiro = " + cotacaoPesq.IdParceiro;

                    var myCommand = new SqlCommand();
                    if (cotacaoPesq.Id != 0)
                        SQL+= $" and IdCotacao = {cotacaoPesq.Id}";

                    if (cotacaoPesq.NomeSegurado != "")
                        SQL += $" and NomeSegurado like '%{cotacaoPesq.NomeSegurado}%'";

                    if (cotacaoPesq.Documento != "")
                        SQL += $" and Documento like '%{cotacaoPesq.Documento}%'";

                    myCommand.Connection = sqlCnn;
                    myCommand.CommandText = SQL;

                    SqlDataAdapter adapter = new SqlDataAdapter(myCommand);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);
                    int tot = -1;
                    foreach (DataRow row in dataset.Tables[0].Rows)
                    {
                        tot++;
                        int IdCotacao = row.Field<int>("IdCotacao");
                        string NomeSegurado = row.Field<string>("NomeSegurado")!;
                        string Endereco = row.Field<string>("Endereco")!;
                        string CEP = row.Field<string>("CEP")!;
                        string Documento = row.Field<string>("Documento")!;
                        DateTime Nascimento = row.Field<DateTime>("Nascimento");
                        string Produto = row.Field<string>("Produto")!;
                        decimal ImportanciaSegurada = row.Field<decimal>("ImportanciaSegurada");
                        decimal Premio = row.Field<decimal>("Premio");

                        data.Add(new Cotacao { CEP = CEP, Documento = Documento, Nascimento = Nascimento.ToString("yyyy-MM-dd"), NomeSegurado = NomeSegurado, Produto = Produto, ImportanciaSegurada = ImportanciaSegurada, Premio = Premio });

                        SqlDataAdapter adapCob = new SqlDataAdapter(myCommand);

                        SQL = "select c.ValorAgravo,c.ValorDesconto,c.ValorTotal,c.Description,c.Type,c.Value from V_CotacaoCobertura c where c.IdCotacao = " + IdCotacao.ToString();

                        myCommand.CommandText = SQL;
                        DataSet dsCob = new DataSet();
                        adapCob.Fill(dsCob);
                        Console.WriteLine(dsCob.Tables.Count);
                        foreach (DataRow rowCob in dsCob.Tables[0].Rows)
                        {
                            data[tot].Cobertura.Add(new CotacaoCobertura { Cobertura = rowCob.Field<string>("Description")!, ValorAgravo = rowCob.Field<Decimal>("ValorAgravo") });
                        }
                    }
                    sqlCnn.Close();
                }
                catch (Exception ex)
                {
                }
            }

            return data;
        }

        public static (int,decimal) ValidateCobertura(string cobertura, string tipo)
        {
            int idCobertura = 0; decimal value = 0;

            using (SqlConnection sqlCnn = new SqlConnection(cnnString))
            {
                try
                {
                    sqlCnn.Open();
                    //Console.WriteLine("ServerVersion: {0}", sqlCnn.ServerVersion);Console.WriteLine("State: {0}", sqlCnn.State);

                    var myCommand = new SqlCommand();
                    var SQL = string.Format("SELECT [FK_Key],Value from Cobertura Where Description = '{0}' and Type = '{1}'", cobertura, tipo);

                    myCommand.Connection = sqlCnn;
                    myCommand.CommandText = SQL;

                    using (var myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            idCobertura = myReader.GetInt32(0);
                            value = myReader.GetDecimal(1);
                        }
                    }
                    sqlCnn.Close();
                }
                catch (Exception ex)
                {
                }
            }

            return (idCobertura, value);
        }

        public static decimal Agravo(int age)
        {
            decimal Agravo = -1;

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
                            Agravo = myReader.GetDecimal(0);
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

        public static int ValidateProdutoSegurado(string Produto, decimal ImportanciaSegurada)
        {
            int idProduto = 0;
            
            using (SqlConnection sqlCnn = new SqlConnection(cnnString))
            {
                try
                {
                    sqlCnn.Open();
                    //Console.WriteLine("ServerVersion: {0}", sqlCnn.ServerVersion);Console.WriteLine("State: {0}", sqlCnn.State);

                    var myCommand = new SqlCommand();
                    var SQL = string.Format("select FK_Key from Produto where Description = '{0}' and {1} between Minimum and Limit", Produto, ImportanciaSegurada);

                    myCommand.Connection = sqlCnn;
                    myCommand.CommandText = SQL;

                    using (var myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            idProduto = myReader.GetInt32(0);
                        }
                    }
                    sqlCnn.Close();
                }
                catch (Exception ex)
                {
                }

                return idProduto;
            }
        }

        public static int InsertCotacao(Cotacao cotacao)
        {
            decimal id = 0;

            using (SqlConnection sqlCnn = new SqlConnection(cnnString))
            {
                try
                {
                    sqlCnn.Open();
                    //Console.WriteLine("ServerVersion: {0}", sqlCnn.ServerVersion);Console.WriteLine("State: {0}", sqlCnn.State);

                    var myCommand = new SqlCommand();
                    var SQL = string.Format("insert into Cotacao(IdProduto,DataCriacao,DataAtualizacao,IdParceiro,NomeSegurado,DDD,Telefone,Endereco,CEP,Documento,Nascimento,Premio,ImportanciaSegurada) values ((select FK_Key from Produto where Description = '{0}'),GETDATE(),GETDATE(),{1},'{2}',{3},{4},'{5}','{6}','{7}','{8}',{9},{9});", cotacao.Produto, cotacao.IdParceiro, cotacao.NomeSegurado, cotacao.DDD, cotacao.Telefone, cotacao.Endereco, cotacao.CEP, cotacao.Documento, cotacao.Nascimento, cotacao.Premio, cotacao.ImportanciaSegurada);

                    myCommand.Connection = sqlCnn;
                    myCommand.CommandText = SQL;
                    if (myCommand.ExecuteNonQuery() > 0)
                    {
                        myCommand.CommandText = "select @@IDENTITY id;";
                        using (var myReader = myCommand.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                id = myReader.GetDecimal(0);
                            }
                        }
                    }                    

                    if (id>0)
                    {
                        foreach (var item in cotacao.Cobertura)
                        {
                            SQL = string.Format("insert into CotacaoCobertura(IdCotacao,ValorDesconto,ValorAgravo,ValorTotal,IdCobertura) values ({0},{1},{2},{3},(select FK_Key from Cobertura where Description='{4}'))", id, item.ValorDesconto.ToString("#0.00").Replace(",", "."), item.ValorAgravo.ToString("#0.00").Replace(",","."), item.ValorTotal.ToString("#0.00").Replace(",", "."),item.Cobertura);
                            myCommand.CommandText = SQL;
                            myCommand.ExecuteNonQuery();
                        }
                        foreach (var item in cotacao.Beneficiarios)
                        {
                            SQL = string.Format("insert into CotacaoBeneficiario(IdCotacao,Nome,Percentual,IdParentesco) values ({0},'{1}',{2},(select FK_Key from TipoParentesco where Description = '{3}'))", id, item.Nome, item.Percentual.ToString("#0.00").Replace(",", "."), item.Parentesco);
                            myCommand.CommandText = SQL;
                            myCommand.ExecuteNonQuery();
                        }
                    }                    

                    sqlCnn.Close();
                }
                catch (Exception ex)
                {
                }
            }

            return int.Parse(id.ToString());
        }

        public static int UpdateCotacao(Cotacao cotacao)
        {
            decimal id = cotacao.Id;

            using (SqlConnection sqlCnn = new SqlConnection(cnnString))
            {
                try
                {
                    sqlCnn.Open();
                    //Console.WriteLine("ServerVersion: {0}", sqlCnn.ServerVersion);Console.WriteLine("State: {0}", sqlCnn.State);

                    var myCommand = new SqlCommand();
                    var SQL = string.Format("update Cotacao set DataAtualizacao=GetDate(),IdParceiro={0},NomeSegurado={1},DDD={2},Telefone={3},Endereco='{4}',CEP={5},Documento={6},Nascimento={7},Premio={8},ImportanciaSegurada={9}) where Id = {10}", cotacao.IdParceiro, cotacao.NomeSegurado, cotacao.DDD, cotacao.Telefone, cotacao.Endereco, cotacao.CEP, cotacao.Documento, cotacao.Nascimento, cotacao.Premio, cotacao.ImportanciaSegurada);

                    myCommand.Connection = sqlCnn;
                    myCommand.CommandText = SQL;
                    if (myCommand.ExecuteNonQuery() > 0)
                    {
                        myCommand.CommandText = "delete from CotacaoCobertura where IdCotacao = " + id;
                        myCommand.ExecuteNonQuery();

                        foreach (var item in cotacao.Cobertura)
                        {
                            SQL = string.Format("insert into CotacaoCobertura(IdCotacao,ValorDesconto,ValorAgravo,ValorTotal,IdCobertura) values ({0},{1},{2},{3},(select FK_Key from Cobertura where Description='{4}'))", id, item.ValorDesconto.ToString("#0.00").Replace(",", "."), item.ValorAgravo.ToString("#0.00").Replace(",", "."), item.ValorTotal.ToString("#0.00").Replace(",", "."), item.Cobertura);
                            myCommand.CommandText = SQL;
                            myCommand.ExecuteNonQuery();
                        }

                        myCommand.CommandText = "delete from CotacaoBeneficiario where IdCotacao = " + id;
                        myCommand.ExecuteNonQuery();

                        foreach (var item in cotacao.Beneficiarios)
                        {
                            SQL = string.Format("insert into CotacaoBeneficiario(IdCotacao,Nome,Percentual,IdParentesco) values ({0},'{1}',{2},(select FK_Key from TipoParentesco where Description = '{3}'))", id, item.Nome, item.Percentual.ToString("#0.00").Replace(",", "."), item.Parentesco);
                            myCommand.CommandText = SQL;
                            myCommand.ExecuteNonQuery();
                        }

                    }

                    sqlCnn.Close();
                }
                catch (Exception ex)
                {
                }
            }

            return int.Parse(id.ToString());
        }
    }
}
