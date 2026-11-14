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
    public struct Vec
    {
        public string name;
        public double x;
        public double y;
    }
    public struct Mat
    {
        public string name;
        public double a;
        public double b;
        public double c;
        public double d;
    }
    internal class Calculator
    {
        public static bool E = false;
        static void Main()
        {
            string temp, equation, chunk = "", result;
            string[] chunks;
            bool check, dupe = false, found = false, foundy = false;
            int i, x = -1, y = -1;
            Line[] lines = [];
            Vec[] vectors = [];
            Mat[] matrices = [];

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
                            equation = temp.Replace("vec ", "");
                            Vec v = new Vec();
                            equation = equation.Replace(" ", ",");
                            equation = equation.Replace("(", "");
                            equation = equation.Replace(")", "");
                            chunks = equation.Split(",");
                            v.name = chunks[0];
                            for (i = 0; i < vectors.Length; i++)
                            {
                                if (v.name == vectors[i].name)
                                {
                                    Console.WriteLine($"Vector {v.name} already exists");
                                    dupe = true;
                                }
                            }
                            if (!dupe)
                            {
                                v.x = Convert.ToDouble(chunks[1]);
                                v.y = Convert.ToDouble(chunks[2]);
                                vectors = [.. vectors, v];
                                Console.WriteLine($"Vector {v.name} successfully created");
                            }
                            dupe = false;
                            break;
                        case "addVec":
                            equation = temp.Replace("addVec ", "");
                            chunks = equation.Split(' ');
                            for (i = 0; i < vectors.Length; i++)
                            {
                                if (chunks[0] == vectors[i].name)
                                {
                                    found = true;
                                    x = i;
                                }
                                else
                                {
                                    if (chunks[1] == vectors[i].name)
                                    {
                                        foundy = true;
                                        y = i;
                                    }
                                }
                            }
                            if (!found || !foundy)
                            {
                                Console.WriteLine($"Vectors {equation}not found");
                            }
                            else
                            {
                                Console.WriteLine($"{vectors[x].x + vectors[y].x} {vectors[x].y + vectors[y].y}");
                            }
                                found = false;
                            foundy = false;
                            break;
                        case "subVec":
                            equation = temp.Replace("subVec ", "");
                            chunks = equation.Split(' ');
                            for (i = 0; i < vectors.Length; i++)
                            {
                                if (chunks[0] == vectors[i].name)
                                {
                                    found = true;
                                    x = i;
                                }
                                else
                                {
                                    if (chunks[1] == vectors[i].name)
                                    {
                                        foundy = true;
                                        y = i;
                                    }
                                }
                            }
                            if (!found || !foundy)
                            {
                                Console.WriteLine($"Vectors {equation}not found");
                            }
                            else
                            {
                                Console.WriteLine($"{vectors[x].x - vectors[y].x} {vectors[x].y - vectors[y].y}");
                            }
                            found = false;
                            foundy = false;
                            break;
                        case "dotVec":
                            break;
                        case "scalVec":
                            break;
                        case "mat":
                            equation = temp.Replace("mat ", "");
                            Mat m = new Mat();
                            equation = equation.Replace(" ", ",");
                            equation = equation.Replace("(", "");
                            equation = equation.Replace(")", "");
                            chunks = equation.Split(",");
                            m.name = chunks[0];
                            for (i = 0; i < matrices.Length; i++)
                            {
                                if (m.name == matrices[i].name)
                                {
                                    Console.WriteLine($"Matrix {m.name} already exists");
                                    dupe = true;
                                }
                            }
                            if (!dupe)
                            {
                                m.a = Convert.ToDouble(chunks[1]);
                                m.b = Convert.ToDouble(chunks[2]);
                                m.c = Convert.ToDouble(chunks[3]);
                                m.d = Convert.ToDouble(chunks[4]);
                                matrices = [.. matrices, m];
                                Console.WriteLine($"Matrix {m.name} successfully created");
                            }
                            dupe = false;
                            break;
                        case "addMat":
                            equation = temp.Replace("addMat ", "");
                            chunks = equation.Split(' ');
                            for (i = 0; i < matrices.Length; i++)
                            {
                                if (chunks[0] == matrices[i].name)
                                {
                                    found = true;
                                    x = i;
                                }
                                else
                                {
                                    if (chunks[1] == matrices[i].name)
                                    {
                                        foundy = true;
                                        y = i;
                                    }
                                }
                            }
                            if (!found || !foundy)
                            {
                                Console.WriteLine($"Matrices {equation}not found");
                            }
                            else
                            {
                                Console.WriteLine($"{matrices[x].a + matrices[y].a} {matrices[x].b + matrices[y].b}\n{matrices[x].c + matrices[y].c} {matrices[x].d + matrices[y].d}");
                            }
                            found = false;
                            foundy = false;
                            break;
                        case "dotMat":
                            break;
                        case "scalMat":
                            break;
                        case "detMat":
                            equation = temp.Replace("detMat ", "");
                            for (i = 0; i < matrices.Length; i++)
                            {
                                if (equation == matrices[i].name + " ")
                                {
                                    found = true;
                                    Console.WriteLine(matrices[i].a * matrices[i].d - matrices[i].b * matrices[i].c);
                                }
                            }
                            if (!found)
                            {
                                Console.WriteLine($"Line {equation}not found");
                            }
                            found = false;
                            break;
                        case "invMat":
                            equation = temp.Replace("invMat ", "");
                            double det = 0, tempd, a, b, c, d;
                            for (i = 0; i < matrices.Length; i++)
                            {
                                if (equation == matrices[i].name + " ")
                                {
                                    found = true;
                                    det = matrices[i].a * matrices[i].d - matrices[i].b * matrices[i].c;
                                    a = matrices[i].a;
                                    b = matrices[i].b;
                                    c = matrices[i].c;
                                    d = matrices[i].d;
                                    tempd = a;
                                    a = d;
                                    d = tempd;
                                    b *= -1;
                                    c *= -1;
                                    Console.WriteLine($"{1 / det * a} {1 / det * b}\n{1 / det * c} {1 / det * d}");
                                }
                            }
                            if (!found)
                            {
                                Console.WriteLine($"Line {equation}not found");
                            }
                            found = false;
                            break;
                        case "numPrime":
                            equation = temp.Replace("numPrime ", "");
                            switch (Convert.ToInt32(equation))
                            {
                                case >= 10000 or <= 0:
                                    Console.WriteLine("Math Error");
                                    break;
                                case 1:
                                    Console.WriteLine("False");
                                    break;
                                case 2:
                                    Console.WriteLine("True");
                                    break;
                                default:
                                    found = false;
                                    for (i = 2; i < Math.Sqrt(Convert.ToInt32(equation)); i++)
                                    {
                                        if (Convert.ToDouble(equation) / i == Convert.ToInt32(Convert.ToDouble(equation) / i))
                                        {
                                            found = true;
                                        }
                                    }
                                    if (found)
                                    {
                                        Console.WriteLine("False");
                                    }
                                    else
                                    {
                                        Console.WriteLine("True");
                                    }
                                        break;
                            }
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
                                int z = -1;
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
                                if (z != -1)
                                {
                                    chunk = equation.Substring(z + 1, equation.IndexOf(")") - 1 - z);
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
                                            E = false;
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
