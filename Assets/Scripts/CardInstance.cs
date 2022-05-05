using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardInstance
{
	public readonly Card Card;
	public int CurrentCost {get; set;}

	protected CardInstance(Card card)
	{
		this.Card = card;
		this.CurrentCost = card.Cost;
	}
	public static CardInstance Create(Card card)
	{
		return card switch
		{
			MinionCard => new MinionCardInstance(card),
			MagicCard => new MagicCardInstance(card),
			_ => null
		};
	}
}

public class MinionCardInstance : CardInstance
{
	public int CurrentATK {get; set;}
	public int CurrentHP {get; set;}
	public MinionCardInstance(Card card) : base(card)
	{
		if (Card is MinionCard minionCard)
		{
			this.CurrentATK = minionCard.ATK;
			this.CurrentHP = minionCard.HP;
		}
	}
}

public class MagicCardInstance : CardInstance
{
	public MagicCardInstance(Card card) : base(card)
	{
		if (Card is MagicCard magicCard)
		{
			//do sth
		}
	}
}
