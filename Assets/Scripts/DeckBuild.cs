using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckBuild : MonoBehaviour
{

    public static readonly int CARD_PER_PAGE = 8;
    public static readonly int CARD_PER_DECK = 9;
    
    public GameObject collectionPanel;
    public GameObject deckPanel;
    
    public GameObject collectionCardPrefab;
    public GameObject deckCardPrefab;

    private readonly Dictionary<Card, int> _playerCards = new();
    private int _currentPage = 0;
    private int _currentDeck = 0;

    private Deck _deck;
    
    private readonly List<GameObject> _currentPageCards = new();
    private readonly List<GameObject> _deckCards = new();
    
    void Start()
    {
        InitPlayerDeck();
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
    
    public void PageLeft()
    {
        if (_currentDeck > 0)
            _currentDeck--;
        RenderDeckCards();
    }
    
    public void PageRight()
    {
        if (_currentDeck < _deck.Build.Count / CARD_PER_DECK)
            _currentDeck++;
        RenderDeckCards();
    }

    public void OnClickSave()
    {
        var id = PlayerDataManager.Instance.CurrentDeckID;
        PlayerDataManager.Instance.Decks[id] = this._deck;
        PlayerDataManager.Instance.Save();
    }
    
    public void OnClickQuit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void AddCardToDeck(Card card)
    {
        if (_deck.Build.ContainsKey(card))
        {
            if (_deck.Build[card] < 3)
                _deck.Build[card]++;
        }
        else
        {
            _deck.Build[card] = 1;
        }
        RenderDeckCards();
    }
    
    public void RemoveCardFromDeck(Card card)
    {
        if (_deck.Build.ContainsKey(card))
        {
            if (_deck.Build[card] > 1)
            {
                _deck.Build[card]--;
            }
            else
            {
                _deck.Build.Remove(card);
                if (_currentDeck >= _deck.Build.Count / CARD_PER_DECK && _currentDeck > 0)
                {
                    _currentDeck--;
                }
            }
        }
        RenderDeckCards();
    }

    private void InitPlayerCards()
    {
        PlayerDataManager.Instance.Collection.ToList()
            .Where(kv => _deck.CardClassValid(kv.Key)).ToList()
            .ForEach(kv => _playerCards.Add(CardDataManager.Instance.GetCardByID(kv.Key), kv.Value));
    }

    private void InitPlayerDeck()
    {
        var id = PlayerDataManager.Instance.CurrentDeckID;
        _deck = PlayerDataManager.Instance.Decks.Count > id ? PlayerDataManager.Instance.Decks[id] : new Deck("Unnamed", "urban");
    }

    private void RenderCollectionCards()
    {
        _currentPageCards.ForEach(Destroy);
        _currentPageCards.Clear();
        
        var kvList = _playerCards.ToList().OrderBy(kv=>kv.Key.Cost).ThenBy(kv=>kv.Key.NumberID).ToList();
        for (var i = 0; i < CARD_PER_PAGE; i++)
        {
            if (CARD_PER_PAGE * _currentPage + i >= kvList.Count)
                return;
            var kv = kvList[CARD_PER_PAGE * _currentPage + i];
            var newCard = Instantiate(collectionCardPrefab, collectionPanel.transform);
            newCard.GetComponent<CollectionCardDisplay>().instance = CardInstance.Create(kv.Key);
            newCard.GetComponent<CollectionCardDisplay>().number.text = "×" + kv.Value;
            _currentPageCards.Add(newCard);
        }
    }
    
    private void RenderDeckCards()
    {
        _deckCards.ForEach(Destroy);
        _deckCards.Clear();

        var kvList = _deck.Build.ToList().OrderBy(kv=>kv.Key.Cost).ThenBy(kv=>kv.Key.NumberID).ToList();
        for (var i = 0; i < CARD_PER_DECK; i++)
        {
            if (CARD_PER_DECK * _currentDeck + i >= _deck.Build.Count)
                return;
            var kv = kvList[CARD_PER_DECK * _currentDeck + i];
            var newCard = Instantiate(deckCardPrefab, deckPanel.transform);
            newCard.GetComponent<DeckCardDisplay>().instance = CardInstance.Create(kv.Key);
            newCard.GetComponent<DeckCardDisplay>().number.text = kv.Value.ToString();
            _deckCards.Add(newCard);
        }
    }
}
