﻿using FluentValidation;
using FluentValidation.Results;

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
        public static List<T> ExceptionLists<T>(List<T> first, List<T> second) where T : class => first.Except(second).ToList();

        public static void Result(this ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.ToString("#"));
            }
        }
    }
}