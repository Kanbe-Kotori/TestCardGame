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

	public string id;
	public string name;
	public CardClass cardClass;
	public CardRarity cardRarity;
	public int cost;
	public string effect;
	public CardData(string _id, string _name, CardClass _class, CardRarity _rarity, int _cost, string _effect)
	{
		this.id = _id;
		this.name = _name;
		this.cardClass = _class;
		this.cardRarity = _rarity;
		this.cost = _cost;
		this.effect = _effect;
	}
}

public class MinionCardData : CardData
{
	public int ATK;
	public int HP;
	public MinionCardData(string _id, string _name, CardClass _class, CardRarity _rarity, int _cost, string _effect, int _atk, int _hp):
		base(_id, _name, _class, _rarity, _cost, _effect)
	{
		this.ATK = _atk;
		this.HP = _hp;
	}
}

public class MagicCardData : CardData
{
	public MagicCardData(string _id, string _name, CardClass _class, CardRarity _rarity, int _cost, string _effect):
		base(_id, _name, _class, _rarity, _cost, _effect)
	{
		//do sth
	}
}
