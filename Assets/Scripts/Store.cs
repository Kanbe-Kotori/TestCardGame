using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public Text goldText;

    void Start()
    {
        goldText.text = PlayerDataManager.Instance.Gold.ToString();
    }

    void Update()
    {
        
    }

    public Card DrawRandomCard()
    {
        return Random.Range(0F, 1F) switch
        {
            <= 0.03125F => CardDataManager.Instance.LegendaryCards[Random.Range(0, CardDataManager.Instance.LegendaryCards.Count)],
            <= 0.125F => CardDataManager.Instance.EpicCards[Random.Range(0, CardDataManager.Instance.EpicCards.Count)],
            <= 0.375F => CardDataManager.Instance.RareCards[Random.Range(0, CardDataManager.Instance.RareCards.Count)],
            _ => CardDataManager.Instance.CommonCards[Random.Range(0, CardDataManager.Instance.CommonCards.Count)]
        };
    }
    
    public void OnClickQuit()
    {
        SceneManager.LoadScene("Menu");
    }
}
