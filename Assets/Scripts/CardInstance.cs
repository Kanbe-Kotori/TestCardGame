using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardInstance
{
	public CardData card;
	public int currentCost;
	public CardInstance(CardData card)
	{
		this.card = card;
		this.currentCost = card.cost;
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
	public int currentATK;
	public int currentHP;
	public MinionCardInstance(CardData _card) : base(_card)
	{
		if (card is MinionCardData)
		{
			var minionCard = card as MinionCardData;
			this.currentATK = minionCard.ATK;
			this.currentHP = minionCard.HP;
		}
	}
}

public class MagicCardInstance : CardInstance
{
	public MagicCardInstance(CardData _card) : base(_card)
	{
		if (card is MagicCardData)
		{
			var magicCard = card as MagicCardData;
			//do sth
		}
	}
}
