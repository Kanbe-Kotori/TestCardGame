using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckDisplay : MonoBehaviour
{
    public Text nameText;
    public Text classText;
    public Text countText;
    
    public Image BG;

    public Deck Deck;
    
    void Start()
    {
        Show();
    }

    void Update()
    {
        
    }

    public void Show()
    {
        if (Deck == null)
            return;

        nameText.text = Deck.Name;
        classText.text = "职业:" + Deck.GetStringFromClass(Deck.Class);
        countText.text = Deck.Count() + "/40";
    }
}
