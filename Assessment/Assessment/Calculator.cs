namespace Assessment
{
    internal class Calculator
    {
        static void Main(string[] args)
        {
            string temp, equation, chunk = "", result;
            bool check;
            int i, b;

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
                        b = -1;
                        for (i = 0; i < equation.Length; i++)
                        {
                            if (equation[i] == '(')
                            {
                                b = i;
                            }
                        }
                        if (b != -1)
                        {
                            chunk = equation.Substring(b + 1, equation.IndexOf(")") - 1 - b);
                            result = BEDMAS(chunk);
                            equation = equation.Replace($"({chunk})", result);
                        }
                        else
                        {
                            result = BEDMAS(equation);
                            Console.WriteLine(result);
                            check = true;
                        }
                    } while (!check);
                    check = false;
                    break;
            }
        }
        static string BEDMAS(string equation)
        {
            bool check = false;
            string chunkx, chunky;
            int i, _ = 0, d, m, a, s;
            double result = 0, x, y, j;

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
                        if (equation[i] == '.')
                        {
                            i--;
                        }
                    } while (int.TryParse(equation[i].ToString(), out _));
                    chunkx = equation.Substring(i + 1, equation.IndexOf("!") - 1 - i);
                    x = double.Parse(chunkx);
                    for (j = x - 1, result = x; j > 1; j--)
                    {
                        result *= j;
                    }
                    equation = equation.Replace($"{chunkx}!", result.ToString());
                }
                else
                {
                    check = true;
                }
            } while (!check);
            check = false;
            do
            {
                if (equation.IndexOf("^") != -1)
                {
                    i = equation.IndexOf("^");
                    do
                    {
                        i--;
                        if (i < 0)
                        {
                            break;
                        }
                        if (equation[i] == '.')
                        {
                            i--;
                        }
                    } while (int.TryParse(equation[i].ToString(), out _));
                    chunkx = equation.Substring(i + 1, equation.IndexOf("^") - 1 - i);
                    x = double.Parse(chunkx);
                    i = equation.IndexOf("^");
                    do
                    {
                        i++;
                        if (i > equation.Length - 1)
                        {
                            break;
                        }
                        if (equation[i] == '.')
                        {
                            i++;
                        }
                    } while (int.TryParse(equation[i].ToString(), out _));
                    chunky = equation.Substring(equation.IndexOf("^") + 1, i - 1 - equation.IndexOf("^"));
                    y = double.Parse(chunky);
                    result = Math.Pow(x, y);
                    equation = equation.Replace($"{chunkx}^{chunky}", result.ToString());
                }
                else
                {
                    check = true;
                }
            } while (!check);
            check = false;
            do
            {
                d = equation.IndexOf("/");
                m = equation.IndexOf("*");
                if (d == m)
                {
                    break;
                }
                if (m == -1)
                {
                    i = equation.IndexOf("/");
                    do
                    {
                        i--;
                        if (i < 0)
                        {
                            break;
                        }
                        if (equation[i] == '.')
                        {
                            i--;
                        }
                    } while (int.TryParse(equation[i].ToString(), out _));
                    chunkx = equation.Substring(i + 1, equation.IndexOf("/") - 1 - i);
                    x = double.Parse(chunkx);
                    i = equation.IndexOf("/");
                    do
                    {
                        i++;
                        if (i > equation.Length - 1)
                        {
                            break;
                        }
                        if (equation[i] == '.')
                        {
                            i++;
                        }
                    } while (int.TryParse(equation[i].ToString(), out _));
                    chunky = equation.Substring(equation.IndexOf("/") + 1, i - 1 - equation.IndexOf("/"));
                    y = double.Parse(chunky);
                    result = x / y;
                    equation = equation.Replace($"{chunkx}/{chunky}", result.ToString());
                }
                else
                {
                    if (d == -1)
                    {
                        i = equation.IndexOf("*");
                        do
                        {
                            i--;
                            if (i < 0)
                            {
                                break;
                            }
                            if (equation[i] == '.')
                            {
                                i--;
                            }
                        } while (int.TryParse(equation[i].ToString(), out _));
                        chunkx = equation.Substring(i + 1, equation.IndexOf("*") - 1 - i);
                        x = double.Parse(chunkx);
                        i = equation.IndexOf("*");
                        do
                        {
                            i++;
                            if (i > equation.Length - 1)
                            {
                                break;
                            }
                            if (equation[i] == '.')
                            {
                                i++;
                            }
                        } while (int.TryParse(equation[i].ToString(), out _));
                        chunky = equation.Substring(equation.IndexOf("*") + 1, i - 1 - equation.IndexOf("*"));
                        y = double.Parse(chunky);
                        result = x * y;
                        equation = equation.Replace($"{chunkx}*{chunky}", result.ToString());
                    }
                    else
                    {
                        if (d < m)
                        {
                            i = equation.IndexOf("/");
                            do
                            {
                                i--;
                                if (i < 0)
                                {
                                    break;
                                }
                                if (equation[i] == '.')
                                {
                                    i--;
                                }
                            } while (int.TryParse(equation[i].ToString(), out _));
                            chunkx = equation.Substring(i + 1, equation.IndexOf("/") - 1 - i);
                            x = double.Parse(chunkx);
                            i = equation.IndexOf("/");
                            do
                            {
                                i++;
                                if (i > equation.Length - 1)
                                {
                                    break;
                                }
                                if (equation[i] == '.')
                                {
                                    i++;
                                }
                            } while (int.TryParse(equation[i].ToString(), out _));
                            chunky = equation.Substring(equation.IndexOf("/") + 1, i - 1 - equation.IndexOf("/"));
                            y = double.Parse(chunky);
                            result = x / y;
                            equation = equation.Replace($"{chunkx}/{chunky}", result.ToString());
                        }
                        else
                        {
                            i = equation.IndexOf("*");
                            do
                            {
                                i--;
                                if (i < 0)
                                {
                                    break;
                                }
                                if (equation[i] == '.')
                                {
                                    i--;
                                }
                            } while (int.TryParse(equation[i].ToString(), out _));
                            chunkx = equation.Substring(i + 1, equation.IndexOf("*") - 1 - i);
                            x = double.Parse(chunkx);
                            i = equation.IndexOf("*");
                            do
                            {
                                i++;
                                if (i > equation.Length - 1)
                                {
                                    break;
                                }
                                if (equation[i] == '.')
                                {
                                    i++;
                                }
                            } while (int.TryParse(equation[i].ToString(), out _));
                            chunky = equation.Substring(equation.IndexOf("*") + 1, i - 1 - equation.IndexOf("*"));
                            y = double.Parse(chunky);
                            result = x * y;
                            equation = equation.Replace($"{chunkx}*{chunky}", result.ToString());
                        }
                    }
                }
            } while (!check);
            check = false;
            do
            {
                a = equation.IndexOf("+");
                s = equation.IndexOf("-");
                if (a == s)
                {
                    break;
                }
                if (s == -1)
                {
                    i = equation.IndexOf("+");
                    do
                    {
                        i--;
                        if (i < 0)
                        {
                            break;
                        }
                        if (equation[i] == '.')
                        {
                            i--;
                        }
                    } while (int.TryParse(equation[i].ToString(), out _));
                    chunkx = equation.Substring(i + 1, equation.IndexOf("+") - 1 - i);
                    x = double.Parse(chunkx);
                    i = equation.IndexOf("+");
                    do
                    {
                        i++;
                        if (i > equation.Length - 1)
                        {
                            break;
                        }
                        if (equation[i] == '.')
                        {
                            i++;
                        }
                    } while (int.TryParse(equation[i].ToString(), out _));
                    chunky = equation.Substring(equation.IndexOf("+") + 1, i - 1 - equation.IndexOf("+"));
                    y = double.Parse(chunky);
                    result = x + y;
                    equation = equation.Replace($"{chunkx}+{chunky}", result.ToString());
                }
                else
                {
                    if (a == -1)
                    {
                        i = equation.IndexOf("-");
                        do
                        {
                            i--;
                            if (i < 0)
                            {
                                break;
                            }
                            if (equation[i] == '.')
                            {
                                i--;
                            }
                        } while (int.TryParse(equation[i].ToString(), out _));
                        chunkx = equation.Substring(i + 1, equation.IndexOf("-") - 1 - i);
                        x = double.Parse(chunkx);
                        i = equation.IndexOf("-");
                        do
                        {
                            i++;
                            if (i > equation.Length - 1)
                            {
                                break;
                            }
                            if (equation[i] == '.')
                            {
                                i++;
                            }
                        } while (int.TryParse(equation[i].ToString(), out _));
                        chunky = equation.Substring(equation.IndexOf("-") + 1, i - 1 - equation.IndexOf("-"));
                        y = double.Parse(chunky);
                        result = x - y;
                        equation = equation.Replace($"{chunkx}-{chunky}", result.ToString());
                    }
                    else
                    {
                        if (a < s)
                        {
                            i = equation.IndexOf("+");
                            do
                            {
                                i--;
                                if (i < 0)
                                {
                                    break;
                                }
                                if (equation[i] == '.')
                                {
                                    i--;
                                }
                            } while (int.TryParse(equation[i].ToString(), out _));
                            chunkx = equation.Substring(i + 1, equation.IndexOf("+") - 1 - i);
                            x = double.Parse(chunkx);
                            i = equation.IndexOf("+");
                            do
                            {
                                i++;
                                if (i > equation.Length - 1)
                                {
                                    break;
                                }
                                if (equation[i] == '.')
                                {
                                    i++;
                                }
                            } while (int.TryParse(equation[i].ToString(), out _));
                            chunky = equation.Substring(equation.IndexOf("+") + 1, i - 1 - equation.IndexOf("+"));
                            y = double.Parse(chunky);
                            result = x + y;
                            equation = equation.Replace($"{chunkx}+{chunky}", result.ToString());
                        }
                        else
                        {
                            i = equation.IndexOf("-");
                            do
                            {
                                i--;
                                if (i < 0)
                                {
                                    break;
                                }
                                if (equation[i] == '.')
                                {
                                    i--;
                                }
                            } while (int.TryParse(equation[i].ToString(), out _));
                            chunkx = equation.Substring(i + 1, equation.IndexOf("-") - 1 - i);
                            x = double.Parse(chunkx);
                            i = equation.IndexOf("-");
                            do
                            {
                                i++;
                                if (i > equation.Length - 1)
                                {
                                    break;
                                }
                                if (equation[i] == '.')
                                {
                                    i++;
                                }
                            } while (int.TryParse(equation[i].ToString(), out _));
                            chunky = equation.Substring(equation.IndexOf("-") + 1, i - 1 - equation.IndexOf("-"));
                            y = double.Parse(chunky);
                            result = x - y;
                            equation = equation.Replace($"{chunkx}-{chunky}", result.ToString());
                        }
                    }
                }
            } while (!check);
            return equation;
        }
    }
}
