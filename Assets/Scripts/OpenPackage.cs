using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPackage : MonoBehaviour
{
    private Store store;
	
    public GameObject cardEntity;
    public GameObject cards;
    private List<GameObject> cardList = new List<GameObject>();
    void Start()
    {
        store = GetComponent<Store>();
    }

    void Update()
    {
        
    }
    
    public void OnClickOpen()
    {
        Clear();
        for (var i = 0; i < 5; i++)
        {
            var newCard = Instantiate(cardEntity, cards.transform);
            newCard.GetComponent<CardDisplay>().instance = CardInstance.Create(store.DrawRandomCard());
            cardList.Add(newCard);
        }
    }
	
    public void Clear()
    {
        cardList.ForEach(Destroy);
        cardList.Clear();
    }
}
