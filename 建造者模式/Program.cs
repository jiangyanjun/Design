using System;
using System.Collections.Generic;

namespace 建造者模式
{
    public abstract class Hire
    {
        //蜡烛
        public abstract void Candle();

        //香槟
        public abstract void Champagne();

        //烛光晚餐
        public abstract Supper GetSupper();

        //牛排
        public abstract void Steak();
    }

    public class SomeA : Hire
    {
        private Supper Su = new Supper();

        public override void Candle()
        {
            Su.Add("购买蜡烛");
        }

        public override void Champagne()
        {
            Su.Add("制作牛排");
        }

        public override Supper GetSupper()
        {
            return Su;
        }

        public override void Steak()
        {
            Su.Add("拿出香槟");
        }
    }

    public class SomeMing
    {
        public void Go(Hire hi)
        {
            Supper sup = hi.GetSupper();
            sup.GetSupper();
        }

        public void Read(Hire hi)
        {
            hi.Candle();
            hi.Champagne();
            hi.Steak();
        }
    }

    public class Supper
    {
        private IList<string> list = new List<string>();

        public void Add(string name)
        {
            list.Add(name);
        }

        public void GetSupper()
        {
            foreach (string name in list)
            {
                Console.WriteLine(name + "。完毕");
            }
            Console.WriteLine("可以享用晚餐了");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("小明约出女神");
            Console.WriteLine("小明开始让小A准备晚餐");
            SomeMing m = new SomeMing();
            Hire hi = new SomeA();
            m.Read(hi);
            Console.WriteLine("晚餐准备完毕");
            m.Go(hi);
            Console.ReadLine();
        }
    }
}