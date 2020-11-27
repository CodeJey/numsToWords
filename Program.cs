using System;

namespace numsToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
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
    }
}
