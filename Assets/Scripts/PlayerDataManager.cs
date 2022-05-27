using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public TextAsset playerData;
    
    public int Gold { get; set; }
    public readonly Dictionary<string, int> Collection = new();
    public readonly List<Deck> Decks = new();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Save()
    {
        List<string> dataLines = new();
        dataLines.Add("#,Gold Data");
        dataLines.Add("gold," + this.Gold);
        
        dataLines.Add("#,Card Data");
        Collection.ToList().ForEach(kv => dataLines.Add("card," + kv.Key + "," + kv.Value));
        
        dataLines.Add("#,Deck Data");
        Decks.ForEach(d=>dataLines.Add("deck," + d.Name + "," + d.ToRaws()));

        var path = Application.dataPath + "/Data/PlayerData.csv";
        File.WriteAllLines(path, dataLines);
    }
    
    public void Load()
    {
        var lines = playerData.text.Split('\n');
        foreach (var line in lines)
        {
            var values = line.Split(',');
            if (values[0] == "#") {
                //这一行是注释
                continue;
            }
            else if (values[0] == "gold")
            {
                Gold = int.Parse(values[1]);
            }
            else if (values[0] == "card")
            {
                Collection[values[1]] = int.Parse(values[2]);
            }
            else if (values[0] == "deck")
            {
                var deck = new Deck(values[1]);
                values.Skip(2).ToList().ForEach(deck.AddRaw);
                Decks.Add(deck);
            }
        }
    }

    public void AddSingleCard(string cardID)
    {
        if (Collection.ContainsKey(cardID))
            Collection[cardID]++;
        else
            Collection[cardID] = 1;
        Save();
    }
}
