using System;

namespace 观察者模式
{
    //定义关注微博的委托
    public delegate void FansHandler(object ob);

    //定义女神的微博
    public class NvShenWeiBo
    {
        //写微博
        public string Info { get; set; }

        //关注的粉丝
        public FansHandler fansList;

        //写微博
        public NvShenWeiBo(string strInfo)
        {
            this.Info = strInfo;
        }

        //添加一个粉丝
        public void AddFans(FansHandler fans)
        {
            this.fansList += fans;
        }

        //失去一个粉丝
        public void RemoveFans(FansHandler fans)
        {
            this.fansList -= fans;
        }

        //女神发布微博
        public void Update()
        {
            if (fansList != null)
                fansList(this);
        }
    }

    //订阅者
    public class Fans
    {
        //粉丝姓名
        public string Name { get; set; }

        //加载粉丝姓名
        public Fans(string name)
        {
            this.Name = name;
        }

        //传一个女神的微博
        public void TiShi(object obj)
        {
            NvShenWeiBo nvshen = obj as NvShenWeiBo;
            if (nvshen != null)
                Console.WriteLine("{0}微博收到一条信息，女神更新微博来，赶快去看看", this.Name);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Fans SomgM = new Fans("小明");
            Fans SomgG = new Fans("小刚");
            //女神正在写微博
            NvShenWeiBo nv = new NvShenWeiBo("今天天气好好啊，谁带我出去玩");
            //小明和小刚是女神的粉丝
            nv.AddFans(new FansHandler(SomgM.TiShi));
            nv.AddFans(new FansHandler(SomgG.TiShi));
            //这个时候女神发布了微博，小明和小刚都收到了提示
            nv.Update();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("小刚，不想关注女神了");
            nv.RemoveFans(new FansHandler(SomgG.TiShi));
            nv.Update();
            Console.ReadLine();
        }
    }
}