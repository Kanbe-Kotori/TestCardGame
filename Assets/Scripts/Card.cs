using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
	public enum CardClass
	{
		URBAN,
		MAGE,
		GENERIC
	}

	public static CardClass GetClassFromString(string name)
	{
		return name switch
		{
			"U" => CardClass.URBAN,
			"M" => CardClass.MAGE,
			_ => CardClass.GENERIC
		};
	}

	public enum CardRarity
    {
		COMMON,
		RARE,
		EPIC,
		LEGENDARY,
		GENERIC
	}

	public static CardRarity GetRarityFromString(string name)
	{
		return name switch
		{
			"C" => CardRarity.COMMON,
			"R" => CardRarity.RARE,
			"E" => CardRarity.EPIC,
			"L" => CardRarity.LEGENDARY,
			_ => CardRarity.GENERIC
		};
	}

	public readonly string ID;
	public readonly string Name;
	public readonly CardClass Class;
	public readonly CardRarity Rarity;
	public readonly int Cost;
	public readonly string Effect;
	public Card(string id, string name, CardClass cardClass, CardRarity rarity, int cost, string effect)
	{
		this.ID = id;
		this.Name = name;
		this.Class = cardClass;
		this.Rarity = rarity;
		this.Cost = cost;
		this.Effect = effect;
	}
}

public class MinionCard : Card
{
	public readonly int ATK;
	public readonly int HP;
	public MinionCard(string id, string name, CardClass cardClass, CardRarity rarity, int cost, string effect, int atk, int hp):
		base(id, name, cardClass, rarity, cost, effect)
	{
		this.ATK = atk;
		this.HP = hp;
	}
}

public class MagicCard : Card
{
	public MagicCard(string id, string name, CardClass cardClass, CardRarity rarity, int cost, string effect):
		base(id, name, cardClass, rarity, cost, effect)
	{
		//do sth
	}
}
