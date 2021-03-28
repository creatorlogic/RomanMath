using System;
using System.Collections.Generic;
using System.Data;

namespace RomanMath.Impl
{
    public static class Service
    {
        public static bool IsNotAllowedSymbols(string expression)
        {
            string AllowedSymbols = "MDCLXVI-+*/";

            foreach (var i in expression)
            {
                if (AllowedSymbols.Contains(i))
                    continue;
                else
                    return true;
            }

            return false;
        }

        public static int ConvertFromRomanToDigital(string number)
        {
            switch (number)
            {
                case "M":
                    return 1000;
                case "D":
                    return 500;
                case "C":
                    return 100;
                case "L":
                    return 50;
                case "X":
                    return 10;
                case "V":
                    return 5;
                case "I":
                    return 1;
            }
            throw new Exception("Invalid input expression");
        }

        /// <summary>
        /// See TODO.txt file for task details.
        /// Do not change contracts: input and output arguments, method name and access modifiers
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>

        public static double Evaluate(string expression)
        {
            expression = expression.Replace(" ", "");
            if (string.IsNullOrEmpty(expression) || IsNotAllowedSymbols(expression))
                throw new Exception("Not invalid input");

            int number = 0;
            List<string> expressionInRoman = new List<string>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i].ToString() == "-" || expression[i].ToString() == "+" || expression[i].ToString() == "*" || expression[i].ToString() == "/")
                {
                    expressionInRoman.Add(number.ToString());
                    number = 0;
                    expressionInRoman.Add(expression[i].ToString());
                    i++; ;
                }
                number += ConvertFromRomanToDigital(expression[i].ToString());
            }
            expressionInRoman.Add(number.ToString());

            string expressionFinally = string.Join(" ", expressionInRoman.ToArray());

            double result = Convert.ToDouble(new DataTable().Compute(expressionFinally, null).ToString());

            return result;
        }
    }
}
