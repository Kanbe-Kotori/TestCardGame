using System;
using System.Collections.Generic;
using System.Linq;

public class Deck
{
    public enum DeckClass
    {
        URBAN,
        MAGE,
        ENGINEER,
        FAILED
    }

    public static DeckClass GetClassFromString(string name)
    {
        return name.ToLower() switch
        {
            "urban" => DeckClass.URBAN,
            "mage" => DeckClass.MAGE,
            "engineer" => DeckClass.ENGINEER,
            _ => DeckClass.FAILED
        };
    }
    public readonly Dictionary<Card, int> Build = new();
    
    public readonly DeckClass Class;

    public string Name;

    public Deck(string name, string classStr)
    {
        this.Name = name;
        this.Class = GetClassFromString(classStr);
    }

    public void FromRaw(string line)
    {
        line.Split(";").ToList().ForEach(AddSingleCard);
    }

    protected void AddSingleCard(string value)
    {
        Console.WriteLine(value);
        var values = value.Split('*');
        var card = CardDataManager.Instance.GetCardByID(values[0]);
        if (card == null || Build.ContainsKey(card)) return;
        Build[card] = int.Parse(values[1]);
    }

    public string ToRaw()
    {
        var raw = "";
        Build.ToList().ForEach(kv=>raw += kv.Key.ID + "*" + kv.Value + ";");
        return raw.TrimEnd(';');
    }

    public int GetTotal()
    {
        return Build.Values.Sum();
    }

    public bool CheckValid()
    { 
        if (GetTotal() != 40) return false;
        if (Build.Any(kv => kv.Value is < 0 or > 3)) return false;
        if (Build.Any(kv => !CardClassValid(kv.Key))) return false;
        return true;
    }

    public bool CardClassValid(Card card)
    {
        return card.Class switch
        {
            Card.CardClass.GENERIC => true,
            Card.CardClass.URBAN => Class == DeckClass.URBAN,
            Card.CardClass.MAGE => Class == DeckClass.MAGE,
            Card.CardClass.ENGINEER => Class == DeckClass.ENGINEER,
            _ => false
        };
    }

    public bool CardClassValid(string cardName)
    {
        return CardClassValid(CardDataManager.Instance.GetCardByID(cardName));
    }
}
