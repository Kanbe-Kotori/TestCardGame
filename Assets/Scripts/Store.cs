using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public TextAsset cardData;
    public List<CardData> allCards = new List<CardData>();
    public List<CardData> genericCards = new List<CardData>();
    public List<CardData> commonCards = new List<CardData>();
    public List<CardData> rareCards = new List<CardData>();
    public List<CardData> epicCards = new List<CardData>();
    public List<CardData> legendaryCards = new List<CardData>();
    void Start()
    {
        loadData();
    }

    void Update()
    {
        
    }
    
    public void loadData() {
        var lines = cardData.text.Split('\n');
        foreach (var line in lines) {
            var values = line.Split(',');
            if (values[0] == "#") {
                //这一行是注释
                continue;
            } else if (values[0] == "minion") {
                var id = values[1];
                var name = values[2];
                var cardclass = CardData.GetClassFromString(values[3]);
                var cardrarity = CardData.GetRarityFromString(values[4]);
                var cost = int.Parse(values[5]);
                var effect = values[6];
                var atk = int.Parse(values[7]);
                var hp = int.Parse(values[8]);
                var minioncard = new MinionCardData(id, name, cardclass, cardrarity, cost, effect, atk, hp);
                addCard(minioncard);
            } else if (values[0] == "magic") {
                var id = values[1];
                var name = values[2];
                var cardclass = CardData.GetClassFromString(values[3]);
                var cardrarity = CardData.GetRarityFromString(values[4]);
                var cost = int.Parse(values[5]);
                var effect = values[6];
                var magiccard = new MagicCardData(id, name, cardclass, cardrarity, cost, effect);
                addCard(magiccard);
            }
        }
        Debug.Log(allCards.Count);
    }

    void addCard(CardData card)
    {
        allCards.Add(card);
        switch (card.cardRarity)
        {
            case CardData.CardRarity.COMMON:
                commonCards.Add(card);
                break;
            case CardData.CardRarity.RARE:
                rareCards.Add(card);
                break;
            case CardData.CardRarity.EPIC:
                epicCards.Add(card);
                break;
            case CardData.CardRarity.LEGENDARY:
                legendaryCards.Add(card);
                break;
            default:
                genericCards.Add(card);
                break;
        }
    }
	
    public CardData DrawRandomCard()
    {
        var d = Random.Range(0F, 1F);
        if (d <= 0.03125F)
        {
            return legendaryCards[Random.Range(0, legendaryCards.Count)];
        }
        else if (d <= 0.125F)
        {
            return epicCards[Random.Range(0, epicCards.Count)];
        }
        else if (d <= 0.375F)
        {
            return rareCards[Random.Range(0, rareCards.Count)];
        }
        else
        {
            return commonCards[Random.Range(0, commonCards.Count)];
        }
    }
}
