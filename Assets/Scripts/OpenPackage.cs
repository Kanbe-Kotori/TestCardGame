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
        if (PlayerDataManager.Instance.Gold < 100)
        {
            return;
        }
        else
        {
            PlayerDataManager.Instance.Gold -= 100;
            _store.goldText.text = PlayerDataManager.Instance.Gold.ToString();
        }

        Clear();
        for (var i = 0; i < 5; i++)
        {
            var newCard = Instantiate(cardPrefab, cardPanel.transform);
            newCard.GetComponent<CardDisplay>().Instance = CardInstance.Create(_store.DrawRandomCard());
            _cardsInPackage.Add(newCard);
        }

        SaveToPlayerData();
        PlayerDataManager.Instance.SaveToFile();
    }
	
    void Clear()
    {
        _cardsInPackage.ForEach(Destroy);
        _cardsInPackage.Clear();
    }

    void SaveToPlayerData()
    {
        _cardsInPackage.Select(card => card.GetComponent<CardDisplay>().Instance.Card.ID)
            .ToList()
            .ForEach(PlayerDataManager.Instance.AddSingleCard);
    }
}
