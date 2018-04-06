using System;
using System.Collections.Generic;

namespace 组合模式
{
    public class A : Card
    {
        public A(string strName)
            : base(strName)
        { }

        public override void PlayingCard()
        {
            Console.WriteLine("四个A");
        }
    }

    public abstract class Card
    {
        protected string name;

        public Card(string strName)
        {
            this.name = strName;
        }

        public abstract void PlayingCard();
    }

    public class GoodCard : Card
    {
        private IList<Card> cardList = new List<Card>();

        public GoodCard(string strName)
            : base(strName)
        { }

        public void Add(Card card)
        {
            cardList.Add(card);
        }

        public override void PlayingCard()
        {
            Console.WriteLine("我是" + this.name + "。我现在有");
            foreach (Card model in cardList)
            {
                model.PlayingCard();
            }
        }
    }

    public class Two : Card
    {
        public Two(string strName)
            : base(strName)
        { }

        public override void PlayingCard()
        {
            Console.WriteLine("四个二");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Card cardA = new A("");
            Card cardTwo = new Two("");
            GoodCard goodCard = new GoodCard("小明");
            goodCard.Add(cardA);
            goodCard.Add(cardTwo);
            goodCard.PlayingCard();
            Console.ReadLine();
        }
    }
}