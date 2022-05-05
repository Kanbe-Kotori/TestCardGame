using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public CardDataLoader cardDataLoader;
    public PlayerDataLoader playerDataLoader;
    public Text goldText;

    void Start()
    {
        cardDataLoader.Load();
        playerDataLoader.Load();
        goldText.text = playerDataLoader.gold.ToString();
    }

    void Update()
    {
        
    }

    public Card DrawRandomCard()
    {
        return Random.Range(0F, 1F) switch
        {
            <= 0.03125F => cardDataLoader.LegendaryCards[Random.Range(0, cardDataLoader.LegendaryCards.Count)],
            <= 0.125F => cardDataLoader.EpicCards[Random.Range(0, cardDataLoader.EpicCards.Count)],
            <= 0.375F => cardDataLoader.RareCards[Random.Range(0, cardDataLoader.RareCards.Count)],
            _ => cardDataLoader.CommonCards[Random.Range(0, cardDataLoader.CommonCards.Count)]
        };
    }
}
