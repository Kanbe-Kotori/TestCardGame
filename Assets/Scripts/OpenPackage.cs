using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OpenPackage : MonoBehaviour
{
    private Store _store;
	
    public GameObject cardPrefab;
    public GameObject cardPanel;
    private readonly List<GameObject> _cardsInPackage = new();

    void Start()
    {
        this._store = GetComponent<Store>();
    }

    void Update()
    {
        
    }
    
    public void OnClickOpen()
    {
        if (_store.PlayerDataManager.Gold < 100)
        {
            return;
        }
        else
        {
            _store.PlayerDataManager.Gold -= 100;
            _store.goldText.text = _store.PlayerDataManager.Gold.ToString();
        }

        Clear();
        for (var i = 0; i < 5; i++)
        {
            var newCard = Instantiate(cardPrefab, cardPanel.transform);
            newCard.GetComponent<CardDisplay>().instance = CardInstance.Create(_store.DrawRandomCard());
            _cardsInPackage.Add(newCard);
        }

        SaveToPlayerData();
        _store.PlayerDataManager.Save();
    }
	
    public void Clear()
    {
        _cardsInPackage.ForEach(Destroy);
        _cardsInPackage.Clear();
    }

    public void SaveToPlayerData()
    {
        _cardsInPackage.Select(card => card.GetComponent<CardDisplay>().instance.Card.ID)
            .ToList()
            .ForEach(_store.PlayerDataManager.AddSingleCard);
    }
}
