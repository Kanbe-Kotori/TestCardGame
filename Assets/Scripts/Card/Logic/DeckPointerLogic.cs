using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DeckPointerLogic : MonoBehaviour, IPointerClickHandler
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
        PlayerDataManager.Instance.CurrentDeck = GetComponent<DeckDisplay>().Deck;
        SceneManager.LoadScene("DeckBuild");
    }
}
