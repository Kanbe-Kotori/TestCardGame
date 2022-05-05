using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OpenPackage : MonoBehaviour
{
    private Store _store;
	
    public GameObject cardEntity;
    public GameObject cards;
    private List<GameObject> cardList = new();

    void Start()
    {
        this._store = GetComponent<Store>();
    }

    void Update()
    {
        
    }
    
    public void OnClickOpen()
    {
        if (_store.PlayerData.gold < 100)
        {
            return;
        }
        else
        {
            _store.PlayerData.gold -= 100;
            _store.goldText.text = _store.PlayerData.gold.ToString();
        }

        Clear();
        for (var i = 0; i < 5; i++)
        {
            var newCard = Instantiate(cardEntity, cards.transform);
            newCard.GetComponent<CardDisplay>().instance = CardInstance.Create(_store.DrawRandomCard());
            cardList.Add(newCard);
        }

        SaveToPlayerData();
        _store.PlayerData.Save();
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
            .ForEach(_store.PlayerData.AddSingleCard);
    }
}
