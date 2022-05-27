using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameObject cardData;
    public GameObject playerData;
    
    public CardDataManager CardDataManager { get; private set; }
    public PlayerDataManager PlayerDataManager { get; private set; }
    
    public Text goldText;

    void Start()
    {
        CardDataManager = cardData.GetComponent<CardDataManager>();
        CardDataManager.Load();

        PlayerDataManager = playerData.GetComponent<PlayerDataManager>();
        PlayerDataManager.Load();
        
        goldText.text = PlayerDataManager.Gold.ToString();
    }

    void Update()
    {
        
    }

    public Card DrawRandomCard()
    {
        return Random.Range(0F, 1F) switch
        {
            <= 0.03125F => CardDataManager.LegendaryCards[Random.Range(0, CardDataManager.LegendaryCards.Count)],
            <= 0.125F => CardDataManager.EpicCards[Random.Range(0, CardDataManager.EpicCards.Count)],
            <= 0.375F => CardDataManager.RareCards[Random.Range(0, CardDataManager.RareCards.Count)],
            _ => CardDataManager.CommonCards[Random.Range(0, CardDataManager.CommonCards.Count)]
        };
    }
}
