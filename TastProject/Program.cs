namespace TastProject
{
    class Channl
    {
        string Name;
        int point;
        Channl()
        {
            string Name = "";
            int point = 0;
        }

        public void ChannlData(string s, int i)
         {
            Name = s;
            point = i;
         }
    }
    internal class Program
        {
            static void Main(string[] args)
            {
                int point1 = 0;
                int point2 = 0;
                string ans = "";

                string for_storage = Console.ReadLine(); // 입력 받는용

                Channl[] channls = new Channl[102]; 

                int Number_Of_Channel = int.Parse(for_storage);

                for (int i = 0; i < Number_Of_Channel; i++)
                {
                    string k = Console.ReadLine();

                    channls[i].ChannlData(k, i);

                    if (k == "KBS1") point1 = i;
                    if (k == "KBS2") point2 = i;
                }

                //KBS1이 KBS2보다 더 아래에 있다면 1번 도중 순서 바뀌는것 고려
                if (point1 > point2) point2 += 1;

                //KBS1찾을 때까지 밑으로 내리기 - 1
                for (int i = 0; i < point1; i++)
                {
                    ans += "1";
                }

                //KBS1찾으면 맨 위로 올리기 - 4
                for (int i = 0; i < point1; i++)
                {
                    ans += "4";
                }

                //KBS2찾을 때까지 밑으로 내리기 - 1
                for (int i = 0; i < point2; i++)
                {
                    ans += "1";
                }

                //KBS2찾으면 2번째 위까지 올리기 - 4
                for (int i = 0; i < point2 - 1; i++)
                {
                    ans += "4";
                }

                Console.WriteLine(ans);
            }
        }
}