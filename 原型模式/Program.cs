using System;

namespace 原型模式
{
    public class CopySomeMing : SomeMing
    {
        public CopySomeMing(string strName)
            : base(strName)
        {
        }
        public override SomeMing Copy()
        {
            var result = this.MemberwiseClone();
            return (SomeMing)this.MemberwiseClone();
        }
    }

    public abstract class SomeMing
    {
        public SomeMing(string Name)
        {
            this.strName = Name;
            Console.WriteLine("小明出发去找女神");
        }

        public string strName { get; set; }
        private string MyProperty = "校长";

        public abstract SomeMing Copy();
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            SomeMing m = new CopySomeMing("小明");
            Console.WriteLine("女神说：小明，马上给我买一份肯德基，一份麦当劳，一份必胜客回来。速去速去");
            Console.WriteLine("小明复制了两个分身");
            SomeMing m2 = m.Copy();
            SomeMing m3 = m.Copy();
            Console.WriteLine(m.strName);
            Console.WriteLine(m2.strName);
            Console.WriteLine(m3.strName);
            Console.ReadLine();
        }
    }
}