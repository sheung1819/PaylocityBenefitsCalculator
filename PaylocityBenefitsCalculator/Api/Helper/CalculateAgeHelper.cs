namespace Api.Helper
{
    public static class CalculateAgeHelper
    {
        public static int CalculateAge(DateTime birthday)
        {
            var today = DateTime.Today;
            var age = today.Year - birthday.Year;
            if (birthday.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
