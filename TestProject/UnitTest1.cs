namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void isNotValidSecret()
        {
            bool validate = OmniBeesAssessment.Data.Validator.ValidateSecret("teste").Equals(0);
            Assert.True(validate, "scret teste nao eh valido");
        }
        [Fact]
        public void isValidSecretXPTO2()
        {
            bool validate = !OmniBeesAssessment.Data.Validator.ValidateSecret("XPTO2").Equals(0);
            Assert.True(validate, "scret XPTO2 eh valido");
        }
        [Fact]
        public void isValidSecretIDKFA()
        {
            bool validate = !OmniBeesAssessment.Data.Validator.ValidateSecret("IDKFA").Equals(0);
            Assert.True(validate, "scret IDKFA eh valido");
        }
        [Fact]
        public void isValidSecretIDDQD()
        {
            bool validate = !OmniBeesAssessment.Data.Validator.ValidateSecret("IDDQD").Equals(0);
            Assert.True(validate, "scret IDDQD eh valido");
        }
    }
}
