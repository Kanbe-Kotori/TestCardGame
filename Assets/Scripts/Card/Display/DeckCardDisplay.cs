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
        if (Instance == null)
            return;
		
        nameText.text = Instance.Card.Name;
        costText.text = Instance.Card.Cost.ToString();
        var frameColor = GetColorFromRarity();
        Frame.color = frameColor;
        CostFrame.color = frameColor;
    }
}
