using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public TextAsset playerData;
    
    public int gold;
    public readonly Dictionary<string, int> Collection = new();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Save()
    {
        List<string> dataLines = new();
        dataLines.Add("gold," + this.gold);
        Collection.ToList().ForEach(kv => dataLines.Add("card," + kv.Key + "," + kv.Value));

        string path = Application.dataPath + "/Data/PlayerData.csv";
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
                gold = int.Parse(values[1]);
            }
            else if (values[0] == "card")
            {
                Collection[values[1]] = int.Parse(values[2]);
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
