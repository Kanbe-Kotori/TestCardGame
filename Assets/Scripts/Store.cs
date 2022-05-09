using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameObject cardData;
    public GameObject playerData;
    
    public CardDataManager cardDataManager;
    public PlayerDataManager playerDataManager;
    public Text goldText;

    void Start()
    {
        cardDataManager = cardData.GetComponent<CardDataManager>();
        cardDataManager.Load();

        playerDataManager = playerData.GetComponent<PlayerDataManager>();
        playerDataManager.Load();
        
        goldText.text = playerDataManager.gold.ToString();
    }

    void Update()
    {
        
    }

    public Card DrawRandomCard()
    {
        return Random.Range(0F, 1F) switch
        {
            <= 0.03125F => cardDataManager.LegendaryCards[Random.Range(0, cardDataManager.LegendaryCards.Count)],
            <= 0.125F => cardDataManager.EpicCards[Random.Range(0, cardDataManager.EpicCards.Count)],
            <= 0.375F => cardDataManager.RareCards[Random.Range(0, cardDataManager.RareCards.Count)],
            _ => cardDataManager.CommonCards[Random.Range(0, cardDataManager.CommonCards.Count)]
        };
    }
}
