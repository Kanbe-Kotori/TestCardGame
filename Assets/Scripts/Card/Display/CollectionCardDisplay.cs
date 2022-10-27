using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionCardDisplay : CardDisplay
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
        
        effectText.text = Instance.Card.Effect;
        
        if (Instance is MinionCardInstance minion)
        {
            ATKText.text = minion.CurrentATK.ToString();
            ATKFrame.color = frameColor;
            HPText.text = minion.CurrentHP.ToString();
            HPFrame.color = frameColor;
        }
        else if (Instance is MagicCardInstance magic)
        {
            ATKText.gameObject.SetActive(false);
            HPText.gameObject.SetActive(false);
            ATKBG.gameObject.SetActive(false);
            HPBG.gameObject.SetActive(false);
            ATKFrame.gameObject.SetActive(false);
            HPFrame.gameObject.SetActive(false);
        }
    }
}
