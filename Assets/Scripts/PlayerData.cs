using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public TextAsset playerData;
    
    public int gold;
    private readonly Dictionary<string, int> _collection = new();

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
        _collection.ToList().ForEach(kv => dataLines.Add("card," + kv.Key + "," + kv.Value));

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
                _collection[values[1]] = int.Parse(values[2]);
            }
        }
    }

    public void AddSingleCard(string cardID)
    {
        if (_collection.ContainsKey(cardID))
            _collection[cardID]++;
        else
            _collection[cardID] = 1;
        Save();
    }
}
