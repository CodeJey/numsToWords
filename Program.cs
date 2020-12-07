using System;

namespace numsToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        try{
            Console.WriteLine("Въведете число, което да се изпише словом.");
            string num = Console.ReadLine();

            int number;
            string stotinki;

            //Separating the passed string and parsing the leva and the stotinki.
            if (num.Contains('.'))
            {
            number = int.Parse(num.Split('.')[0]);
            stotinki = num.Split('.')[1];
            }
            else if (num.Contains(','))
            {
            number = int.Parse(num.Split(',')[0]);
            stotinki = num.Split(',')[1];
            }
            else
            {
                number = int.Parse(num);
                stotinki = " ";
            }

            string toWord = "";
            int firstDigit = number % 10;
            int secondDigit = (number/10) % 10;
            int thirdDigit = (number/100) % 10;
            int fourdDigit = (number/1000) % 10;
            int fifthDigit = (number/10000) % 10;
            int sixthDigit = (number/100000) % 10;
            int seventhDigit = (number/1000000) % 10;
            
            if (number <= 20)
            {
                toWord = tens(number);
            }

                else if (number > 20 && number <= 99)
                {
                    toWord = toHundreds(firstDigit, secondDigit);
                }

                    else if (number > 99 && number <= 999)
                    {
                        toWord = hundreds(thirdDigit, secondDigit, firstDigit);
                    }

                        else if (number > 999 && number <= 9999)
                        {
                            toWord = firstThousand(fourdDigit, thirdDigit, secondDigit, firstDigit);
                        }

                            else if (number > 9999 && number <= 99999)
                            {
                                toWord = secThousand(fifthDigit, fourdDigit, thirdDigit, secondDigit, firstDigit);
                            }

                                else if(number > 99999 && number <= 999999)
                                {
                                    toWord = thousandHundreds(sixthDigit, fifthDigit, fourdDigit, thirdDigit, secondDigit, firstDigit);
                                }

                                    else if (number > 999999 && number <= 9999999)
                                    {
                                        toWord = millions(seventhDigit, sixthDigit, fifthDigit, fourdDigit, thirdDigit, secondDigit, firstDigit);
                                    }

                                        else 
                                        {
                                            Console.WriteLine("Не можем да изпишем тази сума словом все още. :)");
                                            Environment.Exit(0);
                                            
                                        }

            Console.ForegroundColor = ConsoleColor.Red;
            //Checking if there are stotinki in the passed number & printing different outputs
            if (stotinki != " ") {
                
                int stot = int.Parse(stotinki);
                int firstStot = stot % 10;
                int secStot = (stot/10) % 10;

                if (stot <= 20) {
                    if (firstStot == 1 && secStot == 0 || firstStot == 2 && secStot == 0) stotinki = tens(stot).Replace("един", "една").Replace("два", "две");
                    else stotinki = tens(stot);
                    }
                else if (stot > 20 && firstStot != 0) {
                    string[] spl = toHundreds(firstStot, secStot).Split(' ');
                    stotinki =  spl[0] + " " + spl[1] + " " + spl[2].Replace("един", "една").Replace("два", "две");
                }
                else stotinki = toHundreds(firstStot, secStot);

                if (number != 1){
                if (firstStot == 1 && secStot == 0) Console.WriteLine(toWord + " лева" + " и " + stotinki +" стотинка");
                else Console.WriteLine(toWord + " лева" + " и " + stotinki +" стотинки");
                }
                else {
                    if (firstStot == 1 && secStot == 0) Console.WriteLine(toWord + " лев" + " и " + stotinki +" стотинка");
                    else Console.WriteLine(toWord + " лев" + " и " + stotinki +" стотинки");
                }
            }

            else{
                if (number != 1 ) Console.WriteLine(toWord + " лева");
                else Console.WriteLine(toWord + " лев");
                }

            Console.ResetColor();
        }
        catch{
            Console.WriteLine("Подавате грешен вход. Опитайте пак.");
        }
        }

        //Method for numbers from 0 to 20
        public static string tens(int n)
        {
            string result = "";
            switch (n)
            {
                case 0: result = "нула"; break;
                case 1: result = "един"; break;
                case 2: result = "два"; break;
                case 3: result = "три"; break;
                case 4: result = "четири"; break;
                case 5: result = "пет"; break;
                case 6: result = "шест"; break;
                case 7: result = "седем"; break;
                case 8: result = "осем"; break;
                case 9: result = "девет"; break;
                case 10: result = "десет"; break;
                case 11: result = "единадесет"; break;
                case 12: result = "дванадесет"; break;
                case 13: result = "тринадесет"; break;
                case 14: result = "четиринадесет"; break;
                case 15: result = "петнадесет"; break;
                case 16: result = "шестнадесет"; break;
                case 17: result = "седемнадесет"; break;
                case 18: result = "осемнадесет"; break;
                case 19: result = "деветнадесет"; break;
                case 20: result = "двадесет"; break;
            }
            return result;
        }

        //Method for numbers from 21 to 99
        public static string toHundreds(int i, int j)
        {
            string toHun = "";
            if(i == 0) toHun = tens(j) + "десет";
                else toHun = tens(j) + "десет и " + tens(i);
                return toHun;
        }

        //Method for numbers from 100 to 999
        public static string hundreds (int h, int d, int e)
        {
            string hs = "";
            switch (h)
            {
                case 1: hs = "сто"; break;
                case 2: hs = "двеста"; break;
                case 3: hs = "триста"; break;
                case 4: hs = "четиристотин"; break;
                case 5: hs = "петстотин"; break;
                case 6: hs = "шестотин"; break;
                case 7: hs = "седемстотин"; break;
                case 8: hs = "осемстотин"; break;
                case 9: hs = "деветстотин"; break;
            }

            if (d == 0 && e == 0) return hs;
            else if(d != 0 && e == 0){
                if (d <= 2) hs = hs + " и " + tens(d*10);
                else hs = hs + " и " + toHundreds(e, d);
            }
            else {
               if (d <= 2 && e == 0 || d <= 2 && e != 0 && (e+ 10*d)<=20) hs = hs + " и " + tens(e + d*10);
                else hs = hs + " " + toHundreds(e, d); 
            }
            return hs;
        }

        //Method for numbers from 1000 to 9999
        public static string firstThousand (int t, int h, int d, int e)
        {
            string toNineTh = "";
            //for the special cases - 1000 and 2000
            if (t == 1)
            {
                //for 1000 
                if (h == 0 && d == 0 && e == 0) toNineTh = "хиляда";
                //to 1020
                else if (h == 0 && d < 2 ) toNineTh = "хиляда и " + tens(d*10 + e);
                //to 1099
                else if (h == 0 && d >= 2 && d <= 9)
                {
                    if (e == 0) toNineTh = "хиляда и " + toHundreds(e, d);
                    else toNineTh = "хиляда " + toHundreds(e, d);
                }
                //to 1999
                else 
                {
                    if (d == 0 && e == 0) toNineTh = "хиляда и " + hundreds(h, d, e);
                    else toNineTh = "хиляда " + hundreds(h, d, e);
                }

            }
            else if (t == 2)
            {
                //for 2000 
                if (h == 0 && d == 0 && e == 0) toNineTh = "две хиляди";
                //to 2020
                else if (h == 0 && d < 2 ) toNineTh = "две хиляди и " + tens(d*10 + e);
                //to 2099
                else if (h == 0 && d >= 2 && d <= 9)
                {
                    if (e == 0) toNineTh = "две хиляди и " + toHundreds(e, d);
                    else toNineTh = "две хиляди " + toHundreds(e, d);
                }
                //to 2999
                else 
                {
                    if (d == 0 && e == 0) toNineTh = "две хиляди и " + hundreds(h, d, e);
                    else toNineTh = "две хиляди " + hundreds(h, d, e);
                }
            }

            //for all other cases
            else 
            { 
                if (h == 0 && d == 0 && e == 0) toNineTh = tens(t) + " хиляди";

                else if (h == 0 && d < 2 ) toNineTh = tens(t) + " хиляди и " + tens(d*10 + e);   

                else if (h == 0 && d >= 2 && d <= 9)
                {
                    if (e == 0) toNineTh = tens(t) + " хиляди и " + toHundreds(e, d);
                    else toNineTh = tens(t) + " хиляди " + toHundreds(e, d);
                }

                else 
                {
                    if (d == 0 && e == 0) toNineTh = tens(t) + " хиляди и " + hundreds(h, d, e);
                    else toNineTh = tens(t) + " хиляди " + hundreds(h, d, e);
                }
            }
            return toNineTh;
        }

        //from 10000 to 99 999
        public static string secThousand (int dt, int t, int h, int d, int e)
        {
            string toNineHun = "";
            int dS = dt*10 + t;
            //till 19k
            if (dS<20){
                if (h == 0 && d == 0 && e == 0) toNineHun = tens(dS) + " хиляди";

                else if (h == 0 && d < 2 ) toNineHun = tens(dS) + " хиляди и " + tens(d*10 + e);   

                else if (h == 0 && d >= 2 && d <= 9)
                {
                    if (e == 0) toNineHun = tens(dS) + " хиляди и " + toHundreds(e, d);
                    else toNineHun = tens(dS) + " хиляди " + toHundreds(e, d);
                }

                else 
                {
                    if (d == 0 && e == 0) toNineHun = tens(dS) + " хиляди и " + hundreds(h, d, e);
                    else toNineHun = tens(dS) + " хиляди " + hundreds(h, d, e);
                }
            }
            //for over 19k 
            else{
                if (h == 0 && d == 0 && e == 0) toNineHun = toHundreds(t, dt) + " хиляди";

                else if (h == 0 && d < 2 ) toNineHun = toHundreds(t, dt) + " хиляди и " + tens(d*10 + e);   

                else if (h == 0 && d >= 2 && d <= 9)
                {
                    if (e == 0) toNineHun = toHundreds(t, dt) + " хиляди и " + toHundreds(e, d);
                    else toNineHun = toHundreds(t, dt) + " хиляди " + toHundreds(e, d);
                }

                else 
                {
                    if (d == 0 && e == 0) toNineHun = toHundreds(t, dt) + " хиляди и " + hundreds(h, d, e);
                    else toNineHun = toHundreds(t, dt) + " хиляди " + hundreds(h, d, e);
                }
            }
            return toNineHun;
        }

        //from 100 000 to 999 999
        private static string thousandHundreds(int ht, int dt, int t, int h, int d, int e)
        {
            string thousandHun = "";

                if (h == 0 && d == 0 && e == 0) thousandHun = hundreds(ht, dt, t) + " хиляди";

                else if (h == 0 && d < 2 ) thousandHun = hundreds(ht, dt, t) + " хиляди и " + tens(d*10 + e);   

                else if (h == 0 && d >= 2 && d <= 9)
                {
                    if (e == 0) thousandHun = hundreds(ht, dt, t) + " хиляди и " + toHundreds(e, d);
                    else thousandHun = hundreds(ht, dt, t) + " хиляди " + toHundreds(e, d);
                }

                else 
                {
                    if (d == 0 && e == 0) thousandHun = hundreds(ht, dt, t) + " хиляди и " + hundreds(h, d, e);
                    else thousandHun = hundreds(ht, dt, t) + " хиляди " + hundreds(h, d, e);
                }

            return thousandHun;      
        }

        //millions
        private static string millions (int m, int ht, int dt, int t, int h, int d, int e)
        {
            string milRes = "";

            if (ht == 0 && dt == 0 && t == 0 && h == 0 && d == 0 && e == 0) milRes = tens(m) + " милиона";
                else if (ht != 0) 
                {
                    if (dt == 0 && t == 0 && h == 0 && d == 0 && e == 0) milRes = tens(m) + " милиона и " + thousandHundreds(ht, dt, t, h, d, e);
                    else milRes = tens(m) + " милиона " + thousandHundreds(ht, dt, t, h, d, e);
                }
                    else if (dt != 0)
                    {
                         if (t == 0 && h == 0 && d == 0 && e == 0 || dt == 1 && h == 0 && d == 0 && e == 0) milRes = tens(m) + " милиона и " + secThousand(dt, t, h, d, e);
                         else milRes = tens(m) + " милиона " + secThousand(dt, t, h, d, e);
                    }
                        else if (t != 0) 
                        {
                            if (h == 0 && d == 0 && e == 0) milRes = tens(m) + " милиона и " + firstThousand(t, h, d, e);
                            else milRes = tens(m) + " милиона " + firstThousand(t, h, d, e);
                        }
                            else if (h != 0) 
                            {
                                if (d == 0 && e == 0) milRes = tens(m) + " милиона и " + hundreds(h, d, e);
                                else milRes = tens(m) + " милиона " + hundreds(h, d, e);
                            }
                                else if (d != 0 && d < 2) milRes = tens(m) + " милиона и " + tens((d*10) + e);
                                    else if (d != 0 && d >= 2) milRes = tens(m) + " милиона и " + toHundreds(e, d);
                                        else if (e != 0) milRes = tens(m) + " милиона и " + tens(e);

            if (m == 1) milRes = milRes.Replace("милиона", "милион");

            return milRes;
        }
    }
}
