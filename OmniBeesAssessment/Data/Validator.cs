using OmniBeesAssessment.Model;
using System.Globalization;

namespace OmniBeesAssessment.Data
{
    public static class Validator
    {
        public static int ValidateSecret(string secret)
        {
            var Partner = Access.ValidateSecret(secret);
            return Partner;
        }
        public static decimal Agravo(int age)
        {
            decimal agravo = Access.Agravo(age);
            return agravo;
        }
        public static User ValidateUser(UserDto p_user)
        {
            User user = Access.ValidateUser(p_user);
            return user;
        }
        public static User ValidateUser(int UserId)
        {
            User user = Access.ValidateUser(UserId);
            return user;
        }
        public static int ValidateProdutoSegurado(string Produto, decimal ImportanciaSegurada)
        {
            int idProduto = Access.ValidateProdutoSegurado(Produto,ImportanciaSegurada);
            return idProduto;
        }
        public static (int,Decimal) ValidateCobertura(string Cobertura, string tipo)
        {
            int idCobertura; decimal value;
            return (idCobertura,value) = Access.ValidateCobertura(Cobertura, tipo);
        }
        public static List<Cotacao> ListData(ListarCotacao cotacaoPesq)
        {
            return Access.ListData(cotacaoPesq);
        }
        public static DateTime ValidateNasc(string Nasc)
        {
            DateTime nascimento = DateTime.MinValue;
            try
            {
                nascimento = DateTime.ParseExact(Nasc, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
            }
            
            return nascimento;
        }
        public static int ValidateDel(CotacaoDel cotacao)
        {
            return Access.ValidateDel(cotacao);
        }
        public static string ValidateAllRules(Cotacao cotacao)
        {
            string message = "";

            var nascimento = ValidateNasc(cotacao.Nascimento);
            if (nascimento == DateTime.MinValue)
                message = "Nascimento invalido";

            cotacao.Nascimento = nascimento.ToString("yyyy-MM-dd");

            var timeSpan = DateTime.Now - nascimento;
            int idade = new DateTime(timeSpan.Ticks).Year - 1;

            var agravo = Agravo(idade);

            if (agravo.Equals(-1))
                message = "Intervalo de idade nao encontrado";

            int idProduto = ValidateProdutoSegurado(cotacao.Produto, cotacao.ImportanciaSegurada);

            if (idProduto.Equals(0))
                message = "Produto nao encontrado/fora do range";

            if ((cotacao.DDD != 0) && (cotacao.Telefone == 0))
                message = "Se informado DDD telefone deve ser informado";
            if ((cotacao.DDD == 0) && (cotacao.Telefone != 0))
                message = "Se informado telefone DDD deve ser informado";

            if (cotacao.Beneficiarios != null)
            {
                var percSum = cotacao.Beneficiarios.Sum(d => d.Percentual);
                if (percSum != 100) message = "Soma deve ser 100%";
            }
            if (cotacao.Beneficiarios != null)
            {
                var percSum = cotacao.Beneficiarios.Sum(d => d.Percentual);
                if (percSum != 100) message = "Soma deve ser 100%";
            }

            int basica = 0; int adicional = 0;
            
            if (cotacao.Cobertura != null)
            {
                int idCobertura; decimal valor;
                
                foreach (var item in cotacao.Cobertura)
                {
                    (idCobertura, valor) = ValidateCobertura(item.Cobertura, "basica");
                    if (idCobertura > 0)
                    {
                        basica++;
                        item.ValorAgravo = (agravo / 100) * valor;
                        item.ValorDesconto = (agravo / 100);
                        item.ValorTotal = valor + item.ValorAgravo;
                    }

                    (idCobertura, valor) = ValidateCobertura(item.Cobertura, "adicional");
                    if (idCobertura > 0)
                    {
                        adicional++;
                        item.ValorTotal = valor;
                    }
                }
            }

            if (basica==0)      message = "Uma cobertura do tipo Basica deve ser informada";
            if (adicional == 0) message = "Uma cobertura do tipo Adicional deve ser informada";


            return message;
        }

        public static int InsertCotacao(Cotacao cotacao)
        {
            int idProduto = Access.InsertCotacao(cotacao);
            return idProduto;
        }
        public static int UpdateCotacao(Cotacao cotacao)
        {
            int idProduto = Access.UpdateCotacao(cotacao);
            return idProduto;
        }
    }
}
