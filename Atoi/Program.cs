using System;

namespace Atoi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] lst = { "42", "   -42", "4193 with words", "91283472332", "-91283472332", "21474836460", "20000000000000000000",
                    "+ ", " -", "   ", " 5-  ", " - 5  ", " s + 4 ", "    0000000000000   " };

            foreach (var s in lst)
            {
                int atoi = MyAtoi(s);
                Console.WriteLine("Atoi=" + atoi.ToString());
            }

        }

        static int MyAtoi(string s)
        {
            string cad = "";
            int atoi = 0;
            int step = 1;
            bool mc = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (step == 1)
                {
                    if (s[i] == ' ')
                    {
                        step = 1;
                        continue;
                    }
                    else if (s[i] == '+' || s[i] == '-')
                    {
                        step = 2;
                        cad += s[i];
                        continue;
                    }
                    else if (char.IsNumber(s[i]))
                    {
                        step = 3;
                        cad += s[i];
                        mc = mc || (Convert.ToInt32(s[i].ToString()) > 0);
                        continue;
                    }
                    else
                    {
                        step = 4;
                        cad = "";
                        break;
                    }
                }
                else
                {
                    if (char.IsNumber(s[i]))
                    {
                        step = 3;
                        cad += s[i];
                        mc = mc || (Convert.ToInt32(s[i].ToString()) > 0);
                        continue;
                    }
                    else
                    {
                        if (step == 2)
                        {
                            step = 4;
                            cad = "";
                            break;
                        }
                        else if (step == 3)
                        {
                            step = 5;
                            break;
                        }
                    }
                }

            }

            Int32.TryParse(cad, out atoi);
            if (mc && atoi == 0)
            {
                if (cad.Length > 1)
                {
                    if (cad.Trim()[0] == '-')
                        atoi = Int32.MinValue;
                    else
                        atoi = Int32.MaxValue;
                }
            }

            return atoi;
        }

    }
}
