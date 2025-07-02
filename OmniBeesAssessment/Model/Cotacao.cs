namespace OmniBeesAssessment.Model
{
    public class Cotacao
    {
        public int Id { get; set; } = 0;
        public required string Produto { get; set; }
        public int IdParceiro { get; set; }
        public required string NomeSegurado { get; set; }
        public int DDD { get; set; }
        public int Telefone { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public required string Documento { get; set; }
        public required string Nascimento { get; set; } = "dd-mm-aaaa";
        public Decimal Premio { get; set; }
        public Decimal ImportanciaSegurada { get; set; }
        public List<Beneficiario>? Beneficiarios { get; set; } = new List<Beneficiario>();
        public List<CotacaoCobertura> Cobertura { get; set; } = new List<CotacaoCobertura>();
    }
    public class CotacaoDel
    {
        public int Id { get; set; } = 0;
    }
    public class ListarCotacao
    {
        public int Id { get; set; }
        public int? IdParceiro { get; set; }
        public string NomeSegurado { get; set; }
        public string Documento { get; set; }
        public string Produto { get; set; }
    }
}
