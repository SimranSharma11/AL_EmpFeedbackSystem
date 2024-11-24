namespace AL_EmpFeedbackSystem
{
    public static class ContextExtension
    {
        public static int GetUserId(this HttpContext context)
        {
            try
            {
                int userId = 0;

                if (context == null) 
                    userId = 0;
                else
                    userId = Convert.ToInt32(context.User.Claims.Where(c => c.Type == "UniqueUserId").Select(c => c.Value).SingleOrDefault());

                return userId;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
