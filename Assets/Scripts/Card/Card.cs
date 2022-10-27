public class Card
{
	public static int Total = 0;
	public enum CardClass
	{
		URBAN,
		MAGE,
		ENGINEER,
		GENERIC
	}

	public static CardClass GetClassFromString(string name)
	{
		return name switch
		{
			"U" => CardClass.URBAN,
			"M" => CardClass.MAGE,
			"E" => CardClass.ENGINEER,
			_ => CardClass.GENERIC
		};
	}

	public enum CardRarity
    {
		COMMON,
		RARE,
		EPIC,
		LEGENDARY,
		BASIC
	}

	public static CardRarity GetRarityFromString(string name)
	{
		return name switch
		{
			"C" => CardRarity.COMMON,
			"R" => CardRarity.RARE,
			"E" => CardRarity.EPIC,
			"L" => CardRarity.LEGENDARY,
			_ => CardRarity.BASIC
		};
	}

	public readonly int NumberID;
	public readonly string ID;
	public readonly string Name;
	public readonly CardClass Class;
	public readonly CardRarity Rarity;
	public readonly int Cost;
	public readonly string Effect;
	public Card(string id, string name, CardClass cardClass, CardRarity rarity, int cost, string effect)
	{
		this.NumberID = Total++;
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
