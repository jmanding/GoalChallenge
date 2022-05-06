namespace GoalChallenge.Common
{
    public static class Tools
    {
        public static void ArgumentNull<T>(T argument) => _ = argument ?? throw new ArgumentNullException(nameof(argument));
    }
}