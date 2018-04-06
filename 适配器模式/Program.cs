using System;

namespace 适配器模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region 类

            Console.WriteLine("女神拿到了戚风蛋糕");
            Console.WriteLine("女神开始制作黑森林蛋糕");
            ICake cake = new CakeProcess();
            cake.Make();
            Console.ReadLine();

            #endregion 类

            #region 对象

            Console.WriteLine("小明同学喜欢天使蛋糕");
            Console.WriteLine("女神开始修改黑森林蛋糕");
            BlackForestCake blackCake = new AngleCakeProcess();
            blackCake.State();
            Console.ReadLine();

            #endregion 对象
        }
    }

    #region 类适配器

    internal interface ICake
    {
        void Make();
    }

    public class BlackForestCake
    {
        public virtual void State()
        {
            Console.WriteLine("这是黑森林蛋糕");
        }
    }

    public class CakeProcess : BlackForestCake, ICake
    {
        public void Make()
        {
            this.State();
        }
    }

    #endregion 类适配器

    #region 对象适配器

    public class AngleCake
    {
        public void State()
        {
            Console.WriteLine("这是天使蛋糕");
        }
    }

    public class AngleCakeProcess : BlackForestCake
    {
        public override void State()
        {
            AngleCake cake = new AngleCake();
            cake.State();
        }
    }

    #endregion 对象适配器
}