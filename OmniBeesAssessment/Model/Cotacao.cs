namespace OmniBeesAssessment.Model
{
    public class Cotacao
    {
        public int Id { get; set; } = 0;
        public string Produto { get; set; }
        public int IdParceiro { get; set; }
        public string NomeSegurado { get; set; }
        public int DDD { get; set; }
        public int Telefone { get; set; }
        public string CEP { get; set; }
        public string Documento { get; set; }
        public string Nascimento { get; set; }
        public Decimal Premio { get; set; }
        public Decimal ImportanciaSegurada { get; set; }
        public List<Beneficiario>? Beneficiarios { get; set; } = new List<Beneficiario>();
        public List<CotacaoCobertura> Cobertura { get; set; } = new List<CotacaoCobertura>();
    }
    public class ListarCotacao
    {
        public int Id { get; set; }
        public string NomeSegurado { get; set; }
        public string Documento { get; set; }
        public string Produto { get; set; }
    }
}
