using OmniBeesAssessment.Model;

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
    }
}
