namespace AL_EmpFeedbackSystem.Extensions
{
    public static class StringManipulation
    {
        /// <summary>
        /// GetFullName
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static string GetFullName(this string firstName, string lastName)
        {
            // Check if FirstName is null or empty
            if (string.IsNullOrWhiteSpace(firstName))
            {
                return string.Empty;
            }

            // Check if LastName is null or empty
            if (string.IsNullOrWhiteSpace(lastName))
            {
                return firstName;
            }

            // Concatenate lastName and lastName with a space
            return $"{firstName} {lastName}";
        }
    }
}
