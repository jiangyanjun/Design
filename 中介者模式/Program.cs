using System;
using System.Collections.Generic;

namespace 中介者模式
{
    //猜拳赌钱

    #region 创建玩家类

    //创建抽象的玩家类
    public abstract class AbstractPlayer
    {
        public int Money { get; set; }

        public AbstractPlayer()
        {
            Money = 0;
        }

        public abstract void Change(int count, AbstractMediator mediator);
    }

    public class SomgM : AbstractPlayer
    {
        public override void Change(int count, AbstractMediator mediator)
        {
            mediator.Change(count);
        }
    }

    public class NvShen : AbstractPlayer
    {
        public override void Change(int count, AbstractMediator mediator)
        {
            mediator.Change(count);
        }
    }

    #endregion 创建玩家类

    #region 创建中介者

    //创建中介者来管理玩家和玩家的钱
    public abstract class AbstractMediator
    {
        public List<AbstractPlayer> list = new List<AbstractPlayer>();
        public State State { get; set; }

        public AbstractMediator(State state)
        {
            this.State = state;
        }

        public void Change(int Count)
        {
            State.Change(Count);
        }

        public void Enter(AbstractPlayer partner)
        {
            list.Add(partner);
        }
    }

    public class MediatorPater : AbstractMediator
    {
        public MediatorPater(State initState) : base(initState)
        {
            Console.WriteLine("中介者创建完毕，可以对钱进行操作了");
        }
    }

    #endregion 创建中介者

    #region 创建状态实体类

    //创建状态类
    public abstract class State
    {
        protected AbstractMediator mediator;

        public abstract void Change(int Count);
    }

    //小明赢
    public class AWin : State
    {
        public AWin(AbstractMediator abMedia)
        {
            this.mediator = abMedia;
        }

        public override void Change(int Count)
        {
            foreach (AbstractPlayer p in mediator.list)
            {
                SomgM m = p as SomgM;
                if (m != null)
                    m.Money += Count;
                else
                    p.Money -= Count;
            }
        }
    }

    //女神赢
    public class BWin : State
    {
        public BWin(AbstractMediator abMedia)
        {
            this.mediator = abMedia;
        }

        public override void Change(int Count)
        {
            foreach (AbstractPlayer p in mediator.list)
            {
                NvShen n = p as NvShen;
                if (n != null)
                    n.Money += Count;
                else
                    p.Money -= Count;
            }
        }
    }

    //平局
    public class Init : State
    {
        public Init()
        {
            Console.WriteLine("平局");
        }

        public override void Change(int Count)
        {
            return;
        }
    }

    #endregion 创建状态实体类

    internal class Program
    {
        private static void Main(string[] args)
        {
            //初始化
            AbstractPlayer someM = new SomgM();
            AbstractPlayer nvShen = new NvShen();
            //初始金钱
            someM.Money = 20;
            nvShen.Money = 20;
            //初始中介者，初始平局状态
            AbstractMediator mediator = new MediatorPater(new Init());
            //女神和小明，加入游戏
            mediator.Enter(someM);
            mediator.Enter(nvShen);
            //小明赢了
            mediator.State = new AWin(mediator);
            mediator.Change(10);
            //女神赢了
            mediator.State = new BWin(mediator);
            mediator.Change(5);
            //双方的钱
            Console.WriteLine("小明 现在钱：{0}", someM.Money);
            Console.WriteLine("女神 现在钱：{0}", nvShen.Money);

            Console.ReadLine();
        }
    }
}