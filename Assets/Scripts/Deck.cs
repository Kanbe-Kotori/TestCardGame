using System.Collections.Generic;
using System.Linq;

public class Deck
{
    public readonly Dictionary<Card, int> Build = new();

    public string Name;

    public Deck(string name)
    {
        this.Name = name;
    }

    public void AddRaw(string line)
    {
        var values = line.Split('×');
        var card = CardDataManager.Instance.GetCardByID(values[0]);
        if (Build.ContainsKey(card)) return;
        Build[card] = int.Parse(values[1]);
    }

    public string ToRaws()
    {
        var raw = "";
        Build.ToList().ForEach(kv=>raw += kv.Key.ID + "×" + kv.Value + ",");
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
