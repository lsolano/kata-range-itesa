using System;
using System.Collections.Generic;

namespace Range
{
    public class IntRange
    {
        int min;
        int max;

        public IntRange(string expression)
        {
            if (expression == null)
                throw new ArgumentNullException();

            if (expression == "")
                throw new ArgumentException();

            (min, max) = ParseExpression(expression);
        }

        private (int min, int max) ParseExpression(string expression)
        {
            char first = expression[0];
            char end = expression[expression.Length - 1];

            string rawEnds = expression
                .Replace("(", string.Empty)
                .Replace("[", string.Empty)
                .Replace(")", string.Empty)
                .Replace("]", string.Empty);

            string[] rawEndsArray = rawEnds.Split(',');

            (int tempMin, int tempMax) = (int.Parse(rawEndsArray[0]), int.Parse(rawEndsArray[1]));

            return (first == '[' ? tempMin : tempMin + 1, end == ']' ? tempMax : tempMax - 1);
        }

        public ISet<int> GetEndPoints() => new HashSet<int> { min, max };
    }
}
