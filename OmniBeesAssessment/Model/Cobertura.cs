namespace OmniBeesAssessment.Model
{
    public class CotacaoCobertura
    {
        public required string Cobertura { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorAgravo { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
