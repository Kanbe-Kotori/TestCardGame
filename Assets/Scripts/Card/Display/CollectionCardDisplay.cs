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
        if (instance == null)
            return;
		
        nameText.text = instance.Card.Name;
        costText.text = instance.Card.Cost.ToString();
        var frameColor = GetColorFromRarity();
        Frame.color = frameColor;
        CostFrame.color = frameColor;
        
        effectText.text = instance.Card.Effect;
        
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
}
