using System;
using System.Collections.Generic;

namespace 享元模式
{
    public class SomeMTeam : Team
    {
        private string name;

        public SomeMTeam(string strName)
        {
            this.name = strName;
        }

        public override void Introduce(string strSex)
        {
            Console.WriteLine("姓名，" + name + "。性别，" + strSex);
        }
    }

    public abstract class Team
    {
        public abstract void Introduce(string strSex);
    }

    public class TeamFactory
    {
        public Dictionary<string, Team> teamList = new Dictionary<string, Team>();

        public TeamFactory()
        {
            teamList.Add("小明", new SomeMTeam("小明"));
            teamList.Add("女神", new SomeMTeam("女神"));
        }

        public Team GetTeam(string key)
        {
            Team team = null;
            if (teamList.ContainsKey(key))
                return teamList[key] as Team;
            else
            {
                Console.WriteLine("新人加入");
                team = new SomeMTeam(key);
                return team;
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("小明和女神创建一个小团队");
            TeamFactory fa = new TeamFactory();
            Team teamM = fa.GetTeam("小明");
            teamM.Introduce("男");
            Team nvS = fa.GetTeam("女神");
            nvS.Introduce("女");
            Team teamG = fa.GetTeam("小刚");
            teamG.Introduce("男");

            Console.ReadLine();
        }
    }
}