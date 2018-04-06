using System;

namespace 策略者模式
{
    //定义衣服的接口
    internal interface IClothes
    {
        double Buy(double money);
    }

    //女的买衣服打八折
    internal class WoMan : IClothes
    {
        public double Buy(double money)
        {
            Console.WriteLine("打八折，太好了");
            return money * 0.8;
        }
    }

    //男的不打折
    internal class Man : IClothes
    {
        public double Buy(double money)
        {
            Console.WriteLine("我擦勒，不打折");
            return money;
        }
    }

    //去商店买衣服
    internal class GoToShop
    {
        private IClothes clothes;

        public GoToShop(IClothes clo)
        {
            clothes = clo;
        }

        public double BuyClothes(double money)
        {
            return clothes.Buy(money);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            const double money = 100;
            //小明和女神去买衣服
            Console.WriteLine("女神买衣服");
            GoToShop shop = new GoToShop(new WoMan());
            Console.WriteLine(shop.BuyClothes(money));
            Console.WriteLine("------------------");
            Console.WriteLine("小明买衣服");
            shop = new GoToShop(new Man());
            Console.WriteLine(shop.BuyClothes(money));
            Console.ReadLine();
        }
    }
}