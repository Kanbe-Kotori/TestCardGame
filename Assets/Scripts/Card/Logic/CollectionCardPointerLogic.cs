using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectionCardPointerLogic : MonoBehaviour, IPointerClickHandler
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var card = this.GetComponent<CardDisplay>().instance.Card;
        var deck = GameObject.Find("DeckBuild");
        if (deck != null)
        {
            deck.GetComponent<DeckBuild>().AddCardToDeck(card);
        }
    }
}
