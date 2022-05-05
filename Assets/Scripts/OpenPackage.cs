using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OpenPackage : MonoBehaviour
{
    private Store _store;
	
    public GameObject cardEntity;
    public GameObject cards;
    private List<GameObject> cardList = new List<GameObject>();

    public PlayerData PlayerData;
    void Start()
    {
        this._store = GetComponent<Store>();
    }

    void Update()
    {
        
    }
    
    public void OnClickOpen()
    {
        Clear();
        for (var i = 0; i < 5; i++)
        {
            var newCard = Instantiate(cardEntity, cards.transform);
            newCard.GetComponent<CardDisplay>().instance = CardInstance.Create(_store.DrawRandomCard());
            cardList.Add(newCard);
        }
    }
	
    public void Clear()
    {
        cardList.ForEach(Destroy);
        cardList.Clear();
    }

    public void SaveToPlayerData()
    {
        cardList.Select(card => card.GetComponent<CardDisplay>().instance.CardData.ID)
            .ToList()
            .ForEach(PlayerData.AddSingleCard);
    }
}
