using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckCardDisplay : CardDisplay
{
    public Text number;
    void Start()
    {
        Show();
    }

    void Update()
    {
        
    }

    public override void Show()
    {
        if (instance == null)
            return;
		
        nameText.text = instance.Card.Name;
        costText.text = instance.Card.Cost.ToString();
        var frameColor = GetColorFromRarity();
        Frame.color = frameColor;
        CostFrame.color = frameColor;
    }
}
