namespace Assessment
{
    public struct Line
    {
        public string name;
        public double x1;
        public double y1;
        public double x2;
        public double y2;
    }
    internal class Calculator
    {
        public static bool E = false;
        static void Main(string[] args)
        {
            string temp, equation, chunk = "", result;
            string[] chunks;
            bool check, dupe = false, found = false;
            int i, b;
            Line[] lines = [];

            while (true)
            {
                temp = Console.ReadLine() + " ";
                try
                {
                    switch (temp.Substring(0, temp.IndexOf(" ")))
                    {
                        case "Line":
                            equation = temp.Replace("Line ", "");
                            Line l = new Line();
                            equation = equation.Replace(" ", "");
                            equation = equation.Replace("(", ",");
                            equation = equation.Replace(")", "");
                            chunks = equation.Split(",");
                            l.name = chunks[0];
                            for (i = 0; i < lines.Length; i++)
                            {
                                if (l.name == lines[i].name)
                                {
                                    Console.WriteLine($"Line {l.name} already exists");
                                    dupe = true;
                                }
                            }
                            if (!dupe)
                            {
                                l.x1 = Convert.ToDouble(chunks[1]);
                                l.y1 = Convert.ToDouble(chunks[2]);
                                l.x2 = Convert.ToDouble(chunks[3]);
                                l.y2 = Convert.ToDouble(chunks[4]);
                                lines = [.. lines, l];
                                Console.WriteLine($"Line {l.name} successfully created");
                            }
                            dupe = false;
                            break;
                        case "lengthLine":
                            equation = temp.Replace("lengthLine ", "");
                            for (i = 0; i < lines.Length; i++)
                            {
                                if (equation == lines[i].name + " ")
                                {
                                    found = true;
                                    Console.WriteLine(Math.Sqrt(Math.Pow(lines[i].x2 - lines[i].x1, 2) + Math.Pow(lines[i].y2 - lines[i].y1, 2)));
                                }
                            }
                            if (!found)
                            {
                                Console.WriteLine($"Line {equation}not found");
                            }
                            found = false;
                            break;
                        case "midpointLine":
                            equation = temp.Replace("midpointLine ", "");
                            for (i = 0; i < lines.Length; i++)
                            {
                                if (equation == lines[i].name + " ")
                                {
                                    found = true;
                                    Console.WriteLine(Math.Sqrt(Math.Pow(lines[i].x2 - lines[i].x1, 2) + Math.Pow(lines[i].y2 - lines[i].y1, 2)) / 2);
                                }
                            }
                            if (!found)
                            {
                                Console.WriteLine($"Line {equation}not found");
                            }
                            found = false;
                            break;
                        case "gradientLine":
                            equation = temp.Replace("gradientLine ", "");
                            for (i = 0; i < lines.Length; i++)
                            {
                                if (equation == lines[i].name + " ")
                                {
                                    found = true;
                                    Console.WriteLine((lines[i].y2 - lines[i].y1) / (lines[i].x2 - lines[i].x1));
                                }
                            }
                            if (!found)
                            {
                                Console.WriteLine($"Line {equation}not found");
                            }
                            found = false;
                            break;
                        case "rad2Deg":
                            equation = temp.Replace("rad2Deg ", "");
                            Console.WriteLine(Convert.ToDouble(equation) * 180 / Math.PI);
                            break;
                        case "deg2Rad":
                            equation = temp.Replace("deg2Rad ", "");
                            Console.WriteLine(Convert.ToDouble(equation) * Math.PI / 180);
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
                                        if (i > 0 && (Char.IsAsciiDigit(equation[i - 1]) || equation[i - 1] == '!'))
                                        {
                                            equation = equation.Insert(i, "*");
                                        }
                                    }
                                    if (equation[i] == ')' && i < equation.Length - 1)
                                    {
                                        if (Char.IsAsciiDigit(equation[i + 1]))
                                        {
                                            Console.WriteLine("Syntax Error");
                                            check = true;
                                        }
                                    }
                                    if (Char.IsAsciiLetter(equation[i]))
                                    {
                                        equation = "++";
                                    }
                                }
                                if (b != -1)
                                {
                                    chunk = equation.Substring(b + 1, equation.IndexOf(")") - 1 - b);
                                    try
                                    {
                                        result = BEDMAS(chunk);
                                        equation = equation.Replace($"({chunk})", result);
                                    }
                                    catch
                                    {
                                        if (E)
                                        {
                                            Console.WriteLine("Math Error");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Syntax Error");
                                        }
                                        check = true;
                                    }

                                }
                                else
                                {
                                    check = true;
                                    try
                                    {
                                        result = BEDMAS(equation);
                                        if (result.IndexOf("∞") != -1)
                                        {
                                            result = "Math Error";
                                        }
                                        Console.WriteLine(result);
                                    }
                                    catch
                                    {
                                        if (E)
                                        {
                                            Console.WriteLine("Math Error");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Syntax Error");
                                        }
                                    }

                                }
                            } while (!check);
                            check = false;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Syntax Error");
                }
            }
        }
        static string BEDMAS(string equation)
        {
            bool check = false;
            string chunkx, chunky;
            int i, _ = 0, d, m, a, s;
            double result = 0, x, y, j;

            if (equation.IndexOf("∞") != -1)
            {
                E = true;
            }

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
                if (equation.IndexOf("E") != -1)
                {
                    E = true;
                }
                a = equation.IndexOf("+");
                s = equation.IndexOf("-");
                do
                {
                    if (equation.IndexOf("-") != -1)
                    {
                        if (equation[equation.IndexOf("-") - 1] == 'E')
                        {
                            equation = equation.Replace("E-", "@");
                        }
                        else
                        {
                            s = equation.IndexOf('-');
                            check = true;
                        }
                    }
                    else
                    {
                        check = true;
                    }
                } while (!check);
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
