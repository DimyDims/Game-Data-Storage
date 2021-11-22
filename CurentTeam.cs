using System.Collections.Generic;

[System.Serializable]
public class CurentTeam
{
    private Character[] _characters;

    private List<Item> _items;

    private int[] _resources;

    public CurentTeam()
    { 
        _characters = new Character[4];
        _items = new List<Item>();
        _resources = new int[9];

    }
    public Character[] GetCharacters()
    {
        return _characters;
    }
    public void ChangeCurrentCharacter(int numberCharacterInTeam, Character character)
    {
        _characters[numberCharacterInTeam] = character;
    }
    public void RemoveCurrentCharacter(int numberCharacterInTeam, Character character)
    {
        _characters[numberCharacterInTeam] = null;
    }
    public List<Item> GetCurrentItems()
    {
        return _items;
    }
    public void AddItem(Item item)
    {
        _items.Add(item);
    }
    public void RemoveItem(Item item)
    {
        _items.Remove(item);
    }

    public int[] GetCurrentTeamResources()
    {
        return _resources;
    }

    public void ChangeAmmunition(int ammunitionNumber, int value)
    {
        _resources[ammunitionNumber] += value;
    }
}
