using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickStart()
    {

    }
    
    public void OnClickStore()
    {
        SceneManager.LoadScene("Store");
    }
    
    public void OnClickDeck()
    {
        SceneManager.LoadScene("DeckChoose");
    }
    
    public void OnClickExit()
    {
        Application.Quit();
    }
}
