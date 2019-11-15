using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test
{

    class Program
    {
        string convertNumSys(string s, int inBase, int outBase) // Перевод числа s из inBase системы счисления в outBase
        {
            const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string res = "";                            // хранит ответ, переменная
            int dig = 0;                                // хранит текущии символ входнои строки
            int temp = 0, basePower = 1;                // хранит значение полученное после перевода из заданнои системы счисления в десятичную
            for (int i = s.Length - 1; i >= 0; i--)
            {
                dig = Convert.ToInt32(s[i]);
                if ((dig >= 48) && (dig <= 57))
                    dig = dig - 48;
                else
                {
                    if ((dig >= 65) && (dig <= 90))
                        dig = dig - 65;
                    else
                    {
                        if ((dig >= 97) && (dig <= 122))
                            dig = dig - 97;
                    }
                }
                temp = temp + dig * basePower;
                basePower = basePower * inBase;
            }
            res = "";
            while (temp != 0)
            {
                dig = temp % outBase;
                res = digits[dig] + res;
                temp = temp / outBase;
            }
            return res;
        }

        static int Buff(int a, int b)           // Получение данных и промежуточные проверки
        {
            Program p = new Program();

            string inputStr;
            bool f;
            int temp;
            // Проверка на дурака-----------------------------------------
            do
            {
                f = true;
                Console.Write("Введите входное число для преобразования: ");
                inputStr = Console.ReadLine();
                for (int i = 0; i < inputStr.Length; i++)
                {
                    temp = Convert.ToInt32(inputStr[i]);
                    if ((temp >= 48) && (temp <= 57))
                        temp = temp - 48;
                    else
                    {
                        if ((temp >= 65) && (temp <= 90))
                            temp = temp - 55;
                        else
                        {
                            if ((temp >= 97) && (temp <= 122))
                                temp = temp - 87;
                            else
                                f = false;
                        }
                    }

                    if ((temp < 0) || (temp >= a))
                        f = false;
                }
            }
            while (f == false);
            // ------------------------------------------------------------
            string s = p.convertNumSys(inputStr, a, b);
            return Convert.ToInt32(s);
        }

        static void End(int num, int sys)           // Перевод в 13-ю систему
        {
            List<int> result = new List<int>();

            while (num > 0)
            {
                result.Add(num % sys);
                num /= sys;
            }

            result.Reverse();
            Console.WriteLine("Ответ: {0}", string.Join("", result));
        }

        static void Main(string[] args)
        {
            int X1 = Buff(13, 10), X2 = Buff(9, 10); // Перевод двух чисел в 10-ю систему
            End(X1 * X2, 13);                        // Вывод в 13-й с.с.
            Console.ReadKey();
        }

    }
}
