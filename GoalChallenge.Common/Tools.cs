namespace GoalChallenge.Common
{
    public static class Tools
    {
        public static void ArgumentNull<T>(T argument) => _ = argument ?? throw new ArgumentNullException(nameof(argument));

        
        /// <summary>
        /// Elements in first that are not in second
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static List<T> ExceptionLists<T>(List<T> first, List<T> second) where T : class
        {
            return first.Except(second).ToList();
        }
    }
}