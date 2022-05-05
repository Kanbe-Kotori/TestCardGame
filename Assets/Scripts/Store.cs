using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public TextAsset cardData;
    public PlayerData PlayerData;
    public Text goldText;

    public readonly List<Card> AllCards = new List<Card>();
    public readonly List<Card> GenericCards = new List<Card>();
    public readonly List<Card> CommonCards = new List<Card>();
    public readonly List<Card> RareCards = new List<Card>();
    public readonly List<Card> EpicCards = new List<Card>();
    public readonly List<Card> LegendaryCards = new List<Card>();

    void Start()
    {
        LoadCardData();
        PlayerData.Load();
        goldText.text = PlayerData.gold.ToString();
    }

    void Update()
    {
        
    }
    
    private void LoadCardData() {
        var lines = cardData.text.Split('\n');
        foreach (var line in lines) {
            var values = line.Split(',');
            if (values[0] == "#") {
                //这一行是注释
                continue;
            } else if (values[0] == "minion") {
                var id = values[1];
                var cardName = values[2];
                var cardClass = Card.GetClassFromString(values[3]);
                var cardRarity = Card.GetRarityFromString(values[4]);
                var cost = int.Parse(values[5]);
                var effect = values[6];
                var atk = int.Parse(values[7]);
                var hp = int.Parse(values[8]);
                var minionCard = new MinionCard(id, cardName, cardClass, cardRarity, cost, effect, atk, hp);
                AddCard(minionCard);
            } else if (values[0] == "magic") {
                var id = values[1];
                var cardName = values[2];
                var cardClass = Card.GetClassFromString(values[3]);
                var cardRarity = Card.GetRarityFromString(values[4]);
                var cost = int.Parse(values[5]);
                var effect = values[6];
                var magicCard = new MagicCard(id, cardName, cardClass, cardRarity, cost, effect);
                AddCard(magicCard);
            }
        }
        Debug.Log(AllCards.Count);
    }

    private void AddCard(Card card)
    {
        AllCards.Add(card);
        switch (card.Rarity)
        {
            case Card.CardRarity.COMMON:
                CommonCards.Add(card);
                break;
            case Card.CardRarity.RARE:
                RareCards.Add(card);
                break;
            case Card.CardRarity.EPIC:
                EpicCards.Add(card);
                break;
            case Card.CardRarity.LEGENDARY:
                LegendaryCards.Add(card);
                break;
            case Card.CardRarity.GENERIC:
            default:
                GenericCards.Add(card);
                break;
        }
    }
	
    public Card DrawRandomCard()
    {
        return Random.Range(0F, 1F) switch
        {
            <= 0.03125F => LegendaryCards[Random.Range(0, LegendaryCards.Count)],
            <= 0.125F => EpicCards[Random.Range(0, EpicCards.Count)],
            <= 0.375F => RareCards[Random.Range(0, RareCards.Count)],
            _ => CommonCards[Random.Range(0, CommonCards.Count)]
        };
    }
}
