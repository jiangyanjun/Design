using System;

namespace 责任链模式
{
    //小明，如果小明的好感提升，那么就可以让更多的人参谋
    public class SomeM
    {
        public string Name { get; set; }
        public int GoodWill { get; set; }

        public SomeM(string strName, int intGoodWill)
        {
            this.Name = strName;
            this.GoodWill = intGoodWill;
        }
    }

    //女神让其他人看看小明，帮着参谋参谋
    public abstract class Participate
    {
        //关系
        public string Name { get; set; }

        //下一个参谋的人
        public Participate Next { get; set; }

        public Participate(string name)
        {
            Name = name;
        }

        public abstract void Meet(SomeM m);
    }

    //女神的朋友
    public class Friend : Participate
    {
        public Friend(string name) : base(name)
        { }

        public override void Meet(SomeM m)
        {
            if (m.GoodWill < 10)
            {
                Console.WriteLine("女神的{0}，直接把小明。PASS掉", Name);
            }
            else
            {
                Next.Meet(m);
            }
        }
    }

    //女神的哥哥
    public class Brother : Participate
    {
        public Brother(string name) : base(name)
        { }

        public override void Meet(SomeM m)
        {
            if (m.GoodWill < 20)
            {
                Console.WriteLine("女神的{0}，直接把小明。PASS掉", Name);
            }
            else
            {
                Next.Meet(m);
            }
        }
    }

    //女神的妈妈
    public class Mom : Participate
    {
        public Mom(string name) : base(name)
        { }

        public override void Meet(SomeM m)
        {
            if (m.GoodWill < 30)
            {
                Console.WriteLine("女神的{0}，直接把小明。PASS掉", Name);
            }
            else
            {
                Console.WriteLine("女神的{0}，同意你们俩交往了。", Name);
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            //设置责任链关系。朋友《哥哥《妈妈
            Participate friend = new Friend("朋友");
            Participate brother = new Brother("哥哥");
            Participate mom = new Mom("妈妈");
            friend.Next = brother;
            brother.Next = mom;

            //带小明见人
            SomeM m = new SomeM("小明", 18);
            friend.Meet(m);
            //让小明打扮一下，再见人
            SomeM m1 = new SomeM("潮男小明", 50);
            friend.Meet(m1);
            Console.ReadLine();
        }
    }
}