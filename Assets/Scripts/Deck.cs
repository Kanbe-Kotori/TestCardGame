using System.Collections.Generic;
using System.Linq;

public class Deck
{
    public readonly Dictionary<string, int> Build = new();

    public string Name;

    public Deck(string name)
    {
        this.Name = name;
    }
    
    public void AddSingleCard(string cardID)
    {
        if (Build.ContainsKey(cardID))
            Build[cardID]++;
        else
            Build[cardID] = 1;
    }
    
    public void RemoveSingleCard(string cardID)
    {
        if (!Build.ContainsKey(cardID)) return;
        if (Build[cardID] > 1)
            Build[cardID]--;
        else
            Build.Remove(cardID);
    }

    public void AddRaw(string line)
    {
        var values = line.Split('×');
        if (Build.ContainsKey(values[0])) return;
        Build[values[0]] = int.Parse(values[1]);
    }

    public string ToRaws()
    {
        var raw = "";
        Build.ToList().ForEach(kv=>raw += kv.Key + "×" + kv.Value + ",");
        return raw.TrimEnd(',');
    }

    public int GetTotal()
    {
        return Build.Values.Sum();
    }

    public bool CheckValid()
    {
        return GetTotal() == 40 && Build.All(kv => kv.Value is >= 0 and <= 3);
    }
}
