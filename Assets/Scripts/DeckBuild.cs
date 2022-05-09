using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckBuild : MonoBehaviour
{

    public static readonly int CARD_PER_PAGE = 8;
    
    public GameObject collectionPanel;
    public GameObject deckPanel;
    
    public GameObject collectionCardPrefab;
    public GameObject deckCardPrefab;
    
    public GameObject cardData;
    public GameObject playerData;
    
    public CardDataManager cardDataManager;
    public PlayerDataManager playerDataManager;

    private readonly Dictionary<Card, int> _playerCards = new();
    
    private int _currentPage = 0;
    private List<GameObject> _currentPageCards = new();
    void Start()
    {
        cardDataManager = cardData.GetComponent<CardDataManager>();
        cardDataManager.Load();

        playerDataManager = playerData.GetComponent<PlayerDataManager>();
        playerDataManager.Load();

        InitPlayerCards();
        RenderCollectionCards();
    }

    void Update()
    {
        
    }

    private void InitPlayerCards()
    {
        playerDataManager.Collection.ToList()
            .ForEach(kv => _playerCards.Add(cardDataManager.GetCardByID(kv.Key), kv.Value));
    }

    public void RenderCollectionCards()
    {
        _currentPageCards.Clear();
        var kvList = _playerCards.ToList();
        kvList.Sort((kv1, kv2)=>kv1.Key.NumberID.CompareTo(kv2.Key.NumberID));
        for (int i = 0; i < CARD_PER_PAGE; i++)
        {
            var kv = kvList[CARD_PER_PAGE * _currentPage + i];
            var newCard = Instantiate(collectionCardPrefab, collectionPanel.transform);
            newCard.GetComponent<CardDisplay>().instance = CardInstance.Create(kv.Key);
            newCard.GetComponent<CardCounter>().number.text = "×" + kv.Value.ToString();
            _currentPageCards.Add(newCard);
        }
    }
}
