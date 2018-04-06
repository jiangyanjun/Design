using System;

namespace 状态模式
{
    //恋爱时期，做事情的抽象类
    public abstract class Love
    {
        //状态
        public Account Account { get; set; }

        //好感度
        public int GoodWill { get; set; }

        //吃饭
        public abstract void Eat();

        //约会
        public abstract void YueHui();

        //增加好感度
        public abstract void AddGoodWill(int good);

        //减少好感度
        public abstract void DelGoodWill(int good);
    }

    //状态
    public class Account
    {
        public Love love { get; set; }

        public Account(int good)
        {
            love = new Friend(0, this);
        }

        public void Eat()
        {
            love.Eat();
        }

        public void YueHui()
        {
            love.YueHui();
        }

        public void DelGoodWill(int good)
        {
            love.DelGoodWill(good);
        }
    }

    //朋友
    public class Friend : Love
    {
        public Friend(int good, Account love)
        {
            this.GoodWill = good;
            this.Account = love;
        }

        public override void AddGoodWill(int good)
        {
            this.GoodWill += good;
            Ask();
        }

        public override void DelGoodWill(int good)
        {
            this.GoodWill -= good;
            Ask();
        }

        public override void Eat()
        {
            AddGoodWill(1);
            Console.WriteLine("我们只是朋友，我不去");
            Ask();
        }

        public override void YueHui()
        {
            AddGoodWill(1);
            Console.WriteLine("我们只是朋友，我不去");
            Ask();
        }

        //询问是否有好感
        public void Ask()
        {
            if (this.GoodWill > 5)
            {
                Account.love = new Lovers();
            }
        }
    }

    public class Lovers : Love
    {
        public override void AddGoodWill(int good)
        {
            this.GoodWill += good;
            Ask();
        }

        public override void DelGoodWill(int good)
        {
            this.GoodWill -= good;
            Ask();
        }

        public override void Eat()
        {
            Console.WriteLine("我们是恋人，我去");
        }

        public override void YueHui()
        {
            Console.WriteLine("我们是恋人，我去");
        }

        //询问是否有好感
        public void Ask()
        {
            if (this.GoodWill < 5)
            {
                Account.love = new Friend(this.GoodWill, this.Account);
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("两个人刚认识");
            Account account = new Account(0);
            Console.WriteLine("约吃饭");
            account.Eat();
            Console.WriteLine("慢慢交往，继续不停的约吃饭");
            for (int i = 0; i < 5; i++)
            {
                account.Eat();
            }
            account.Eat();
            account.YueHui();
            Console.ReadLine();
        }
    }
}