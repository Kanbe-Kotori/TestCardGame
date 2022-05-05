using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardInstance
{
	public readonly CardData CardData;
	public int CurrentCost {get; set;}

	protected CardInstance(CardData cardData)
	{
		this.CardData = cardData;
		this.CurrentCost = cardData.Cost;
	}
	public static CardInstance Create(CardData card)
	{
		return card switch
		{
			MinionCardData => new MinionCardInstance(card),
			MagicCardData => new MagicCardInstance(card),
			_ => null
		};
	}
}

public class MinionCardInstance : CardInstance
{
	public int CurrentATK {get; set;}
	public int CurrentHP {get; set;}
	public MinionCardInstance(CardData cardData) : base(cardData)
	{
		if (CardData is MinionCardData minionCard)
		{
			this.CurrentATK = minionCard.ATK;
			this.CurrentHP = minionCard.HP;
		}
	}
}

public class MagicCardInstance : CardInstance
{
	public MagicCardInstance(CardData cardData) : base(cardData)
	{
		if (CardData is MagicCardData magicCard)
		{
			//do sth
		}
	}
}
