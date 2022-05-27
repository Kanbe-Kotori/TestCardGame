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
    
    public CardDataManager CardDataManager { get; private set; }
    public PlayerDataManager PlayerDataManager { get; private set; }

    private readonly Dictionary<Card, int> _playerCards = new();
    
    private int _currentPage = 0;
    private readonly List<GameObject> _currentPageCards = new();
    private readonly List<GameObject> _deckCards = new();
    
    void Start()
    {
        CardDataManager = cardData.GetComponent<CardDataManager>();
        CardDataManager.Load();

        PlayerDataManager = playerData.GetComponent<PlayerDataManager>();
        PlayerDataManager.Load();

        InitPlayerCards();
        RenderCollectionCards();
        
        RenderDeckCards();
    }

    void Update()
    {
        
    }

    public void PageUp()
    {
        if (_currentPage < _playerCards.Count / CARD_PER_PAGE)
            _currentPage++;
        RenderCollectionCards();
    }
    
    public void PageDown()
    {
        if (_currentPage > 0)
            _currentPage--;
        RenderCollectionCards();
    }

    private void InitPlayerCards()
    {
        PlayerDataManager.Collection.ToList()
            .ForEach(kv => _playerCards.Add(CardDataManager.GetCardByID(kv.Key), kv.Value));
    }

    public void RenderCollectionCards()
    {
        _currentPageCards.ForEach(Destroy);
        _currentPageCards.Clear();
        
        var kvList = _playerCards.ToList().OrderBy(kv=>kv.Key.NumberID).ToList();
        //kvList.Sort((kv1, kv2)=>kv1.Key.NumberID.CompareTo(kv2.Key.NumberID));
        for (int i = 0; i < CARD_PER_PAGE; i++)
        {
            if (CARD_PER_PAGE * _currentPage + i >= kvList.Count)
                return;
            var kv = kvList[CARD_PER_PAGE * _currentPage + i];
            var newCard = Instantiate(collectionCardPrefab, collectionPanel.transform);
            newCard.GetComponent<CardDisplay>().instance = CardInstance.Create(kv.Key);
            newCard.GetComponent<CardCounter>().number.text = "×" + kv.Value;
            _currentPageCards.Add(newCard);
        }
    }
    
    public void RenderDeckCards()
    {
        _deckCards.ForEach(Destroy);
        _deckCards.Clear();

        var deck = PlayerDataManager.Decks.Count > 0 ? PlayerDataManager.Decks[0] : new Deck("Unnamed");
        foreach (var kv in deck.Build)
        {
            var newCard = Instantiate(deckCardPrefab, deckPanel.transform);
            newCard.GetComponent<CardDisplay>().instance = CardInstance.Create(CardDataManager.GetCardByID(kv.Key));
            newCard.GetComponent<CardCounter>().number.text = kv.Value.ToString();
            _deckCards.Add(newCard);
        }
    }
}
