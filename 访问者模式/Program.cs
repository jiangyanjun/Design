using System;

namespace 访问者模式
{
    //女神跟小明出去玩，不同的地方，会准备不同的衣服
    public interface IVisual
    {
        void Play(Beach b);

        void Play(Snow s);
    }

    public class NvShen : IVisual
    {
        public void Play(Snow s)
        {
            Console.WriteLine("我要准备羽绒服");
            s.Go();
        }

        public void Play(Beach b)
        {
            Console.WriteLine("我要准备泳装");
            b.Go();
        }
    }

    //小明组织出去玩
    public abstract class SomeM
    {
        public abstract void Accept(IVisual vistor);

        public abstract void Go();
    }

    //去沙滩
    public class Beach : SomeM
    {
        public override void Accept(IVisual vistor)
        {
            vistor.Play(this);
        }

        public override void Go()
        {
            Console.WriteLine("出发去海边玩");
        }
    }

    //去雪山
    public class Snow : SomeM
    {
        public override void Accept(IVisual vistor)
        {
            vistor.Play(this);
        }

        public override void Go()
        {
            Console.WriteLine("出发去雪山玩");
        }
    }

    public class GoToPlay
    {
        public SomeM m;

        public GoToPlay()
        {
            Random dom = new Random();
            int num = dom.Next(3);
            if (num <= 1)
            {
                m = new Beach();
            }
            else
            {
                m = new Snow();
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            GoToPlay play = new GoToPlay();
            SomeM m = play.m;
            m.Accept(new NvShen());
            Console.ReadLine();
        }
    }
}