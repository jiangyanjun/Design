using System;

namespace 模板方式模式
{
    public abstract class FallInLove
    {
        public void Go()
        {
            Console.WriteLine("两个人从相识到相爱的过程");
            this.Single();
            if (this.GoodWill())
            {
                this.Know();
                this.Love();
            }
        }

        public abstract bool GoodWill();

        public void Know()
        {
            Console.WriteLine("两个人相识");
        }

        public void Love()
        {
            Console.WriteLine("两个人恋爱");
        }

        public void Single()
        {
            Console.WriteLine("两个人都是单身");
        }
    }

    public class Loser : FallInLove
    {
        public override bool GoodWill()
        {
            Console.WriteLine("没有好感");
            Console.WriteLine("感情破裂");
            return false;
        }
    }

    public class Winer : FallInLove
    {
        public override bool GoodWill()
        {
            Console.WriteLine("互相有好感");
            return true;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("成功");
            FallInLove fall = new Winer();
            fall.Go();
            Console.WriteLine("-------------------------------");
            Console.Write("失败");
            fall = new Loser();
            fall.Go();
            Console.ReadLine();
        }
    }
}