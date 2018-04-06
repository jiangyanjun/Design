using System;

namespace 装饰器模式
{
    public class Beautiful : GoodGirl
    {
        public Beautiful(Girl gi)
            : base(gi)
        { }

        public void ChangeBeautiful()
        {
            Console.WriteLine("变得漂亮一点吧");
        }

        public override void Speak()
        {
            base.Speak();
            ChangeBeautiful();
        }
    }

    public abstract class Girl
    {
        public abstract void Speak();
    }

    public class Goddess : Girl
    {
        public override void Speak()
        {
            Console.WriteLine("我是女神，王小花");
        }
    }

    public abstract class GoodGirl : Girl
    {
        private Girl girl;

        public GoodGirl(Girl gi)
        {
            this.girl = gi;
        }

        public override void Speak()
        {
            if (girl != null)
            {
                girl.Speak();
            }
        }
    }

    public class Rich : GoodGirl
    {
        public Rich(Girl gi)
            : base(gi)
        { }

        public void ChangeRich()
        {
            Console.WriteLine("让我更有钱");
        }

        public override void Speak()
        {
            base.Speak();
            ChangeRich();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Girl girl = new Goddess();
            Console.WriteLine("女神改变计划开始：");
            GoodGirl goodGirl = new Beautiful(girl);
            Console.WriteLine("让女神变漂亮");
            goodGirl.Speak();
            Console.WriteLine("-------------------");
            Console.WriteLine("让女神变富有");
            goodGirl = new Rich(girl);
            goodGirl.Speak();
            Console.ReadLine();
        }
    }
}