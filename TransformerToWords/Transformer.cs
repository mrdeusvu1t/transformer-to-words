using System;
using System.Text;

namespace TransformerToWords
{
    /// <summary>
    /// Implements transformer class.
    /// </summary>
    public class Transformer
    {
        /// <summary>
        /// Transforms each element of source array into its 'word format'.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of 'word format' of elements of source array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <example>
        /// new[] { 2.345, -0.0d, 0.0d, 0.1d } => { "Two point three four five", "Minus zero", "Zero", "Zero point one" }.
        /// </example>
        public string[] Transform(double[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("array is empty", nameof(source));
            }

            string[] array = new string[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                array[i] = TransformToWords(source[i]);
            }

            return array;
        }

        public static string TransformToWords(double number)
        {
            if (number is double.Epsilon)
            {
                return "Double Epsilon";
            }

            if (double.IsNaN(number))
            {
                return "Not a Number";
            }

            if (number == double.NegativeInfinity)
            {
                return "Negative Infinity";
            }

            if (number == double.PositiveInfinity)
            {
                return "Positive Infinity";
            }

            string result = "";

            char[] n = number.ToString().ToCharArray();

            for (int i = 0; i < n.Length; i++)
            {
                switch (n[i])
                {
                    case '0':
                        result += "zero";
                        break;
                    case '1':
                        result += "one";
                        break;
                    case '2':
                        result += "two";
                        break;
                    case '3':
                        result += "three";
                        break;
                    case '4':
                        result += "four";
                        break;
                    case '5':
                        result += "five";
                        break;
                    case '6':
                        result += "six";
                        break;
                    case '7':
                        result += "seven";
                        break;
                    case '8':
                        result += "eight";
                        break;
                    case '9':
                        result += "nine";
                        break;
                    case '+':
                        result += "plus";
                        break;
                    case '-':
                        result += "minus";
                        break;
                    case 'E':
                        result += "E";
                        break;
                    case ',':
                        result += "point";
                        break;
                }

                if (i < n.Length - 1)
                {
                    result += " ";
                }
            }

            var sb = new StringBuilder(result);
            sb[0] = char.ToUpper(sb[0]);
            result = sb.ToString();

            return result;
        }
    }
}
