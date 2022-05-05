using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData
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
	public CardData(string id, string name, CardClass cardClass, CardRarity rarity, int cost, string effect)
	{
		this.ID = id;
		this.Name = name;
		this.Class = cardClass;
		this.Rarity = rarity;
		this.Cost = cost;
		this.Effect = effect;
	}
}

public class MinionCardData : CardData
{
	public readonly int ATK;
	public readonly int HP;
	public MinionCardData(string id, string name, CardClass cardClass, CardRarity rarity, int cost, string effect, int atk, int hp):
		base(id, name, cardClass, rarity, cost, effect)
	{
		this.ATK = atk;
		this.HP = hp;
	}
}

public class MagicCardData : CardData
{
	public MagicCardData(string id, string name, CardClass cardClass, CardRarity rarity, int cost, string effect):
		base(id, name, cardClass, rarity, cost, effect)
	{
		//do sth
	}
}
