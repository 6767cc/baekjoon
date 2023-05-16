using System.Drawing;
using System.Xml.Serialization;

namespace _1004
{
    class Point
    {
        public int x, y;

        public Point(int x, int y) //시작점 끝점 
        {
            this.x = x;
            this.y = y;
        }
    }

    class Planetary_system //혹성 궤도
    {
        public int x, y, r;

        public Planetary_system(int x, int y, int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }
    }

    class problem_information //테스트 케이스 정보를 모아둔 클래스
    {
        public Point Start, End;
        public List<Planetary_system> Case_Of_Planetary_system;

        public problem_information(Point Start, Point End, List<Planetary_system> Case_Of_Planetary_system) 
        {
            this.Start = Start;
            this.End = End;
            this.Case_Of_Planetary_system = Case_Of_Planetary_system;
        }
    }

    class Input
    {
       public static List<problem_information> input()
        {
            int TC = 0;
            List<Planetary_system> problem_informations = new List<Planetary_system>();
            List<problem_information> values = new List<problem_information>();

            
            string Temporary_Input = Console.ReadLine();//줄 단위 임시로 받기
            int T = int.Parse(Temporary_Input);

            for(int i = 0; i < T; i++)
            {
                //시작위치와 끝 위치 찾기 
                Temporary_Input = Console.ReadLine();
                string[] Start_End_Point = Temporary_Input.Split();
                int Sx = int.Parse(Start_End_Point[0]), Sy = int.Parse(Start_End_Point[1]), Ex = int.Parse(Start_End_Point[2]), Ey = int.Parse(Start_End_Point[3]); ;
                Point Start_Point = new Point(Sx, Sy);
                Point End_Point = new Point(Ex, Ey);

                //행성계 저장
                Temporary_Input = Console.ReadLine();
                int N = int.Parse(Temporary_Input);

                for(int j = 0; j < N; j++)
                {
                    Temporary_Input = Console.ReadLine();
                    string[] x_y_r = Temporary_Input.Split();

                    int x = int.Parse(x_y_r[0]); int y = int.Parse(x_y_r[1]); int r = int.Parse(x_y_r[2]);
                    Planetary_system Save = new Planetary_system(x, y, r);
                    problem_informations.Add(Save);
                }

                problem_information problem_Information = new problem_information(Start_Point, End_Point, problem_informations);
                values.Add(problem_Information);
            }

            return values;
        }
    }

    class Sol
    {
        public static List<int> sol(List<problem_information> values) 
        {
            List<int> Ans = new List<int>();

            foreach(problem_information a in values) 
            {
                Point Start = a.Start, End = a.End;
                int approach_leave = 0;

                foreach(Planetary_system b in a.Case_Of_Planetary_system)
                {
                    //하나만 원안에 들어가 있을 경우 ++
                    double Ch1 = b.r * b.r - (Start.x - b.x) * (Start.x - b.x) - (Start.y - b.y) * (Start.y - b.y);
                    double Ch2 = b.r * b.r - (End.x - b.x) * (End.x - b.x) - (End.y - b.y) * (End.y - b.y);

                    if(Ch1 < 0 && Ch2 > 0) approach_leave++;
                    if(Ch1 > 0 && Ch2 < 0) approach_leave++;
                }
                Ans.Add(approach_leave);
            }

            return Ans;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            List<problem_information> values = Input.input();
            List<int> Ans = Sol.sol(values);

            foreach(int i in Ans) 
            {
                Console.WriteLine(i);
            }
        }
    }
}