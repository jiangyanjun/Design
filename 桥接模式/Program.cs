using System;

namespace 桥接模式
{
    //奥迪双钻
    public class Auldey : Car
    {
        public override void Down()
        {
            Console.WriteLine("车往后走");
        }

        public override void Left()
        {
            Console.WriteLine("车往左拐");
        }

        public override void Right()
        {
            Console.WriteLine("车往右拐");
        }

        public override void Up()
        {
            Console.WriteLine("车往前走");
        }
    }

    //奥迪遥控器
    public class AuldeyRemote : Remote
    {
        public AuldeyRemote(Car carU)
            : base(carU)
        {
        }

        public override void Up()
        {
            Console.WriteLine("开始校准方向");
            base.Left();
            base.Right();
            Console.WriteLine("方向校准完毕");
            Console.WriteLine("------------------");
            base.Up();
        }
    }

    //遥控车抽象
    public abstract class Car
    {
        public abstract void Down();

        public abstract void Left();

        public abstract void Right();

        public abstract void Up();
    }

    //遥控器
    public class Remote
    {
        private Car car;

        public Remote(Car carU)
        {
            this.car = carU;
        }

        public virtual void Down()
        {
            car.Down();
        }

        public virtual void Left()
        {
            car.Left();
        }

        public virtual void Right()
        {
            car.Right();
        }

        public virtual void Up()
        {
            car.Up();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Car car = new Auldey();
            Remote re = new AuldeyRemote(car);
            re.Up();
            re.Down();
            re.Right();
            Console.ReadLine();
        }
    }
}