using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CardDisplay : MonoBehaviour
{
	public Text nameText;
	public Text costText;
	public Text effectText;
	public Text ATKText;
	public Text HPText;

	public Image BG;
	public Image Frame;
	public Image CostBG;
	public Image CostFrame;
	public Image ATKBG;
	public Image ATKFrame;
	public Image HPBG;
	public Image HPFrame;

	public CardInstance instance;

	void Start()
	{
		Show();
	}

	void Update()
	{

	}

	public abstract void Show();

	public Color GetColorFromRarity()
	{
		switch (instance.Card.Rarity)
		{
			case Card.CardRarity.COMMON:
				return Color.white;
			case Card.CardRarity.RARE:
				return Color.blue;
			case Card.CardRarity.EPIC:
				return Color.magenta;
			case Card.CardRarity.LEGENDARY:
				return Color.yellow;
			default:
				return Color.black;
		}
	}
}
