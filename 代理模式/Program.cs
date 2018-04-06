using System;

namespace 代理模式
{
    public abstract class Food
    {
        public abstract void Bread();
    }

    public class SomeG : Food
    {
        private Supermarket sup;

        public override void Bread()
        {
            if (sup == null)
                sup = new Supermarket();
            Console.WriteLine("我给你买面包，可以。但");
            this.Money();
            Console.WriteLine("我去给你买面包了");
            sup.Bread();
        }

        public void Money()
        {
            Console.WriteLine("收取跑腿费");
        }
    }

    public class Supermarket : Food
    {
        public override void Bread()
        {
            Console.WriteLine("购买一个面包");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Food food = new SomeG();
            food.Bread();
            Console.ReadLine();
        }
    }
}