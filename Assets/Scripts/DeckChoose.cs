using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckChoose : MonoBehaviour
{
    public static readonly int DECK_PER_PAGE = 6;

    public GameObject deckPanel;
    public GameObject deckPrefab;
    
    private int _currentPage = 0;
    private List<Deck> _playerdecks = new();

    private readonly List<GameObject> _currentPageDecks = new();

    void Start()
    {
        InitDecks();
        RenderDecks();
    }

    void Update()
    {
        
    }
    
    public void PageUp()
    {
        if (_currentPage < _playerdecks.Count / DECK_PER_PAGE)
            _currentPage++;
        RenderDecks();
    }
    
    public void PageDown()
    {
        if (_currentPage > 0)
            _currentPage--;
        RenderDecks();
    }

    private void InitDecks()
    {
        PlayerDataManager.Instance.Decks.ToList().ForEach(_playerdecks.Add);
    }
    
    private void RenderDecks()
    {
        _currentPageDecks.ForEach(Destroy);
        _currentPageDecks.Clear();
        
        for (var i = 0; i < DECK_PER_PAGE; i++)
        {
            if (DECK_PER_PAGE * _currentPage + i >= _playerdecks.Count)
                return;
            var deck = _playerdecks[DECK_PER_PAGE * _currentPage + i];
            var newDeck = Instantiate(deckPrefab, deckPanel.transform);
            newDeck.GetComponent<DeckDisplay>().Deck = deck;
            _currentPageDecks.Add(newDeck);
        }
    }
    
    public void OnClickQuit()
    {
        SceneManager.LoadScene("Menu");
    }
}
