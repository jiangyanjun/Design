using System;
using System.Collections.Generic;

namespace 备忘录模式
{
    //与女神交往过的男人
    public class Man
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    //女神的备忘录
    public class ContactMemento
    {
        public List<Man> manList;

        public ContactMemento(List<Man> list)
        {
            manList = list;
        }
    }

    //备忘录
    public class MobileOwner
    {
        public List<Man> manList { get; set; }

        public MobileOwner(List<Man> man)
        {
            manList = man;
        }

        //创建备忘录
        public ContactMemento CreateMemento()
        {
            return new ContactMemento(new List<Man>(manList));
        }

        //备忘录数据导入
        public void RestoreMemeoto(ContactMemento memento)
        {
            manList = memento.manList;
        }

        //显示现在的备忘录
        public void Show()
        {
            Console.WriteLine("联系人列表中有{0}个人", manList.Count);
            foreach (Man per in manList)
            {
                Console.WriteLine("姓名：{0} 年龄{1}", per.Name, per.Age);
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            //现在有三个人
            List<Man> man = new List<Man>()
            {
                new Man() { Name="小A", Age=18 },
                new Man() { Name="小B", Age=19 },
                new Man() { Name="小C", Age=20 },
            };
            //女神的记录
            MobileOwner mobileOwner = new MobileOwner(man);
            mobileOwner.Show();
            //创建备忘录
            ContactMemento ConM = mobileOwner.CreateMemento();
            //删除女神的记录
            mobileOwner.manList.RemoveRange(0, 3);
            mobileOwner.Show();
            //恢复女神的记录
            mobileOwner.RestoreMemeoto(ConM);
            mobileOwner.Show();
            Console.ReadLine();
        }
    }
}