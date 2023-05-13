using System.Collections.Generic;

namespace _2503
{
    public class CheckNumber
    {
        public int FirstNumber, SeconedNumber, ThirdNumber;
        public int Strike, Ball;

        public CheckNumber(int a, int b, int c, int d, int f)
        {
            FirstNumber = a;
            SeconedNumber = b;
            ThirdNumber = c;
            Strike = d;
            Ball = f;
        }
    }

    class Input
    {
        public static List<CheckNumber> input()
        {
            string NOQ = Console.ReadLine();
            int Number_Of_Question = int.Parse(NOQ);

            List<CheckNumber> checkList = new List<CheckNumber>();
            for(int i = 0; i < Number_Of_Question; i++)
            {
                string s = Console.ReadLine();
                string[] ss = s.Split();

                int a = int.Parse(ss[0]);
                int b = int.Parse(ss[1]);
                int c = int.Parse(ss[2]);

                CheckNumber Save = new CheckNumber(a / 100, (a / 10) % 10, a % 10, b, c);
                checkList.Add(Save);
            }

            return checkList;
        }
    }

    class Sol
    {
        public static int sol(List<CheckNumber> CheckList)
        {
            int s, b, ans = 0;
            bool StrikeCheck, BallCheck;

            for(int i = 1; i<= 9; i++)
                for (int j = 1; j <= 9; j++)
                    for (int k = 1; k <= 9; k++)
                    {
                        if (i == j || i == k || j == k) continue;

                        StrikeCheck = true; 
                        BallCheck = true;

                        foreach(CheckNumber CN in CheckList)
                        {
                            s = 0; b = 0;

                            if (i == CN.FirstNumber) s++;
                            if (j == CN.SeconedNumber) s++;
                            if (k == CN.ThirdNumber) s++;

                            if (s != CN.Strike)
                            {
                                StrikeCheck = false;
                                break;
                            }

                            if (j == CN.FirstNumber || k == CN.FirstNumber) b++;
                            if (i == CN.SeconedNumber || k == CN.SeconedNumber) b++;
                            if (i == CN.ThirdNumber || j == CN.ThirdNumber) b++;

                            if(b != CN.Ball)
                            {
                                BallCheck = false;
                                break;
                            }
                        }

                        if (StrikeCheck && BallCheck) ans++;
                    }

            return ans;
        }
    }
    internal class Program
    {
        static void Main()
        {
            List<CheckNumber> CheckList = Input.input();
            Console.WriteLine(Sol.sol(CheckList));
        }
    }
}