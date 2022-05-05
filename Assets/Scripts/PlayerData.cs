using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public Store store;
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
        _collection.ToList().ForEach(kv => dataLines.Add(kv.Key + "," + kv.Value));

        string path = Application.dataPath + "/Data/PlayerData.csv";
        File.WriteAllLines(path, dataLines);
    }
    
    public void Load()
    {
        
    }

    public void AddSingleCard(string cardID)
    {
        if (_collection.ContainsKey(cardID))
            _collection[cardID]++;
        else
            _collection[cardID] = 1;
    }
}
