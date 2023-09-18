namespace agrolugue_api.Domain.Auth
{
    public static class Settings
    {
        private static readonly string Secret = "tRW6SIjlidobW5iZCWLJWvYE51cL9UhycBfzKIH8jW9X+jBvF5KVYCAGZBMg5fVV";
        
        public static string Get()
        {
            return Secret;
        }
    }
}
