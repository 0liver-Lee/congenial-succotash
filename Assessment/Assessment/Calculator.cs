namespace Assessment
{
    internal class Calculator
    {
        static void Main(string[] args)
        {
            string temp, equation, chunk = "";
            bool check;

            temp = Console.ReadLine();

            switch (temp)
            {
                case "Line":
                    break;
                case "lengthLine":
                    break;
                case "midpointLine":
                    break;
                case "gradientLine":
                    break;
                case "rad2Deg":
                    break;
                case "deg2Rad":
                    break;
                case "vec":
                    break;
                case "addVec":
                    break;
                case "subVec":
                    break;
                case "dotVec":
                    break;
                case "scalVec":
                    break;
                case "mat":
                    break;
                case "addMat":
                    break;
                case "dotMat":
                    break;
                case "scalMat":
                    break;
                case "detMat":
                    break;
                case "invMat":
                    break;
                case "numPrime":
                    break;
                case "numCheckDigit":
                    break;
                case "numRand":
                    break;
                case "caesarEn":
                    break;
                case "caesarDe":
                    break;
                case "affineEn":
                    break;
                case "affineDe":
                    break;
                case "bruteAffine":
                    break;
                default:
                    equation = temp.Replace(" ", "");
                    check = false;
                    do
                    {
                        if (equation.IndexOf("(") != -1)
                        {
                            chunk = equation.Substring(equation.IndexOf("(") + 1, equation.IndexOf(")") - 1 - equation.IndexOf("("));
                            chunk = BEDMAS(chunk);
                        }
                        else
                        {
                            BEDMAS(equation);
                        }
                    } while (!check);
                    check = false;
                    break;
            }
        }
        static string BEDMAS(string equation)
        {
            bool check = false;
            string chunk;
            int i, j, x, _ = 0, result = 0;

            do
            {
                if (equation.IndexOf("!") != -1)
                {
                    i = equation.IndexOf("!");
                    do
                    {
                        i--;
                        if (i < 0)
                        {
                            break;
                        }
                    } while (int.TryParse(equation[i].ToString(), out _));
                    chunk = equation.Substring(i + 1, equation.IndexOf("!") - 1 - i);
                    x = int.Parse(chunk);
                    for (j = x - 1, result = x; j > 0; j--)
                    {
                        result *= j;
                    }
                    Console.WriteLine(result);
                    Console.ReadLine();
                }
                else
                {
                    check = true;
                }
            } while (!check);
            return equation;
        }
    }
}
