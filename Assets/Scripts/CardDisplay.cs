using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
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

	public void Show()
	{
		nameText.text = instance.CardData.Name;
		costText.text = instance.CardData.Cost.ToString();
		effectText.text = instance.CardData.Effect;
		var frameColor = GetColorFromRarity();
		Frame.color = frameColor;
		CostFrame.color = frameColor;
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
	}

	public Color GetColorFromRarity()
	{
		switch (instance.CardData.Rarity)
		{
			case CardData.CardRarity.COMMON:
				return Color.white;
			case CardData.CardRarity.RARE:
				return Color.blue;
			case CardData.CardRarity.EPIC:
				return Color.magenta;
			case CardData.CardRarity.LEGENDARY:
				return Color.yellow;
			default:
				return Color.black;
		}
	}
}
