using System;

namespace 迭代器模式
{
    //麻将手牌接口
    public interface Iterator
    {
        object GetCurrent(); //当前的牌

        bool MoveNext(); //是否还有

        void Next(); //下一张牌
    }

    //麻将手牌集合
    public interface IListCollection
    {
        Iterator GetIterator();
    }

    //麻将手牌具体实现
    public class Mahjong : IListCollection
    {
        private int[] collection;

        public Mahjong()
        {
            collection = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        public int Length()
        {
            return collection.Length;
        }

        public int GetElement(int index)
        {
            return collection[index];
        }

        public Iterator GetIterator()
        {
            return new MahjongList(this);
        }
    }

    //麻将看牌迭代器
    public class MahjongList : Iterator
    {
        private int _index;
        private Mahjong _list;

        public MahjongList(Mahjong mj)
        {
            _list = mj;
            _index = 0;
        }

        public object GetCurrent()
        {
            return _list.GetElement(_index);
        }

        public bool MoveNext()
        {
            if (_index < _list.Length())
            {
                return true;
            }
            return false;
        }

        public void Next()
        {
            if (_index < _list.Length())
            {
                _index++;
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            //麻将手牌集合
            IListCollection list = new Mahjong();
            //麻将手牌迭代器
            Iterator iterator = list.GetIterator();
            while (iterator.MoveNext())
            {
                int i = (int)iterator.GetCurrent();
                Console.WriteLine(i.ToString());
                iterator.Next();
            }
            Console.Read();
        }
    }
}