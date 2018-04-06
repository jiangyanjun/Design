using System;
using System.Threading.Tasks;

namespace 单例模式
{
    public class Goddess
    {
        private static Goddess _Goddess;

        private static object obj = new object();

        private Goddess()
        {
            Console.WriteLine("我有空，走吧");
        }

        //创建全局访问点
        public static Goddess HelloGoddess()
        {
            if (_Goddess == null)
            {
                lock (obj)
                {
                    if (_Goddess == null)
                        _Goddess = new Goddess();
                    else
                    {
                        Console.WriteLine("很抱歉，我没有时间");
                    }
                }
            }
            else
            {
                Console.WriteLine("很抱歉，我没有时间");
            }
            return _Goddess;
        }
    }

    public class Suitors
    {
        public async void Go()
        {
            Task xm = xiaoMing();
            Task xg = xiaoGang();
            await xm;
            await xg;
        }

        public async Task xiaoGang()
        {
            await Task.Delay(1000);
            Goddess girl = Goddess.HelloGoddess();
        }

        public async Task xiaoMing()
        {
            await Task.Delay(1000);
            Goddess girl = Goddess.HelloGoddess();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Suitors su = new Suitors();
            su.Go();
            Console.ReadLine();
        }
    }
}