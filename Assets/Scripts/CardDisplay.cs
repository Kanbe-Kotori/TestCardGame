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
	/*
	{
		if (instance == null)
			return;
		
		nameText.text = instance.Card.Name;
		costText.text = instance.Card.Cost.ToString();
		var frameColor = GetColorFromRarity();
		Frame.color = frameColor;
		CostFrame.color = frameColor;
		
		if (effectText != null)
			effectText.text = instance.Card.Effect;

		if (ATKText == null || HPText == null)
			return;
		
		if (instance is MinionCardInstance minion)
		{
			ATKText.text = minion.CurrentATK.ToString();
			ATKFrame.color = frameColor;
			HPText.text = minion.CurrentHP.ToString();
			HPFrame.color = frameColor;
		}
		else if (instance is MagicCardInstance magic)
		{
			ATKText.gameObject.SetActive(false);
			HPText.gameObject.SetActive(false);
			ATKBG.gameObject.SetActive(false);
			HPBG.gameObject.SetActive(false);
			ATKFrame.gameObject.SetActive(false);
			HPFrame.gameObject.SetActive(false);
		}
	}*/

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
