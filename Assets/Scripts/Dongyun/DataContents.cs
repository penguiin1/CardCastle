using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#region Stat


[Serializable]
public class Stat
{
	public int num;
	public int cost;
	public int range ;
	public int minattack;
	public int maxattack;
   public int shield;

   public string name;
   public string explain ; 
}

[Serializable]
public class StatData : ILoader<int, Stat>
{
	public List<Stat> stats = new List<Stat>();

	public Dictionary<int, Stat> MakeDict()
	{
		Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
		foreach (Stat stat in stats)
			dict.Add(stat.num, stat);
		return dict;
	}
}



#endregion