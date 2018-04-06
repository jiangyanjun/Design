using System;

namespace 命令模式
{
    //创建执行者
    public class SomeG
    {
        public void OrderMeal()
        {
            Console.WriteLine("好吧，我去订餐");
        }
    }

    //定义命令抽象类
    public abstract class Command
    {
        protected SomeG _SomeG;

        public Command(SomeG g)
        {
            this._SomeG = g;
        }

        public abstract void Tel();
    }

    //定义酒店
    public class Hotel : Command
    {
        public Hotel(SomeG g) : base(g)
        { }

        public override void Tel()
        {
            base._SomeG.OrderMeal();
        }
    }

    public class SomeM
    {
        private Command _command;

        public SomeM(Command com)
        {
            this._command = com;
        }

        public void Go()
        {
            _command.Tel();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("小明让小刚去酒店订餐");
            //定义执行者，小刚
            SomeG g = new SomeG();
            //定义命令，订餐
            Command com = new Hotel(g);
            //定义命令者，小明
            SomeM m = new SomeM(com);
            //执行命令
            m.Go();
            Console.ReadLine();
        }
    }
}