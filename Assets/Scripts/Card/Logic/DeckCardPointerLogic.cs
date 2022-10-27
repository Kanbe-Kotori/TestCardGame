using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckCardPointerLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject cardPrefab;
    private GameObject _cardPreview;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        var deck = GameObject.Find("Deck");
        if (deck == null) return;
        
        _cardPreview = Instantiate(cardPrefab, deck.transform.Find("CardPreview"));
        _cardPreview.GetComponent<CardDisplay>().instance = CardInstance.Create(this.GetComponent<CardDisplay>().instance.Card);
        _cardPreview.transform.position = this.transform.position;
        var cardBG = _cardPreview.transform.Find("CardBG");
        if (cardBG != null)
        {
            cardBG.GetComponent<Image>().raycastTarget = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(_cardPreview);
        _cardPreview = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var card = this.GetComponent<CardDisplay>().instance.Card;
        var deck = GameObject.Find("DeckBuild");
        if (deck != null)
        {
            deck.GetComponent<DeckBuild>().RemoveCardFromDeck(card);
        }
        Destroy(_cardPreview);
        _cardPreview = null;
    }

}
