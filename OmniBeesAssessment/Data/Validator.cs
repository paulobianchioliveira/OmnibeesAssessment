namespace OmniBeesAssessment.Data
{
    public static class Validator
    {
        public static int ValidateSecret(string secret)
        {
            var Partner = Access.ValidateSecret(secret);
            return Partner;
        }
        public static int Agravo(int age)
        {
            int agravo = Access.Agravo(age);
            return agravo;
        }
    }
}
