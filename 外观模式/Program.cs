using System;

namespace 外观模式
{
    public class BuyKFC
    {
        public bool Buy()
        {
            Console.WriteLine("去最近的KFC，进行购买");
            return true;
        }
    }

    public class EatKFC
    {
        private BuyKFC buyKfc;
        private LookKFC lookKfc;

        public EatKFC()
        {
            lookKfc = new LookKFC();
            buyKfc = new BuyKFC();
        }

        public void Eat()
        {
            if (lookKfc.Look())
            {
                if (buyKfc.Buy())
                {
                    Console.WriteLine("买完肯德基了，我们可以吃了");
                }
            }
            else
            {
                Console.WriteLine("不好意思，附近没有肯德基");
            }
        }
    }

    public class LookKFC
    {
        public bool Look()
        {
            Console.WriteLine("正在查询最接近的KFC");
            return true;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine();
            EatKFC eat = new EatKFC();
            eat.Eat();
            Console.Read();
        }
    }
}