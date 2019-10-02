using System;

namespace BasicConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //pyramid construction
            //var pyramid = "1\r\n7 6\r\n1 7 8\r\n2 3 6 9";
            //var pyramid = "1\r\n8 4\r\n2 6 9\r\n8 5 9 3";

            var pyramid = "215\r\n193 124\r\n117 237 442\r\n218 935 347 235\r\n320 804 522 417 345\r\n229 601 723 835 133 124\r\n248 202 277 433 207 263 257\r\n359 464 504 528 516 716 871 182\r\n461 441 426 656 863 560 380 171 923\r\n381 348 573 533 447 632 387 176 975 449\r\n223 711 445 645 245 543 931 532 937 541 444\r\n330 131 333 928 377 733 017 778 839 168 197 197\r\n131 171 522 137 217 224 291 413 528 520 227 229 928\r\n223 626 034 683 839 53 627 310 713 999 629 817 410 121\r\n924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";

            //split the pyramid into lines
            var lines = pyramid.Split("\r\n");
            //get array dimensions
            var arrayLength = lines.Length;
            var list = new int[arrayLength, arrayLength + 1];



            //use for loop to iterate through rows
            for (var i = 0; i < lines.Length; i++)
            {
                var currentLine = lines[i];
                //split the row into numbers
                var numbers = currentLine.Split(" ");

                for (var j = 0; j < numbers.Length; j++)
                {
                    //get current number from the array and convert to int
                    var currentStringNumber = numbers[j];
                    var currentNumber = Convert.ToInt32(currentStringNumber);
                    //if number is prime set custom int
                    currentNumber = IsPrime(currentNumber) ? -9999 : currentNumber;
                    list[i, j] = currentNumber;
                }
            }

            //start the loop at one step above the bottom of the pyramid
            for (int i = arrayLength - 2; i >= 0; i--)
            {
                for (int j = 0; j < arrayLength; j++)
                {
                    list[i, j] = Math.Max(list[i, j] + list[i + 1, j], list[i, j] + list[i + 1, j + 1]);
                }
            }
            Console.WriteLine(string.Format("Output: {0}", list[0, 0]));
            Console.ReadLine();
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}