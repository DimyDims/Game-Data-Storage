using System;
using System.Linq;

[Serializable]
public class Character
{
    private readonly int[] _pureAttributeValues;

    private readonly int[] _computedAttributeValues;

    private readonly int[] _computedResistanceValues;

    private readonly bool[] _isActiveAbility;

    private readonly int[] _traitsId;

    private readonly int?[] _itemsId;

    private readonly string _nameKey;
    public string NameKey => $"CHARACTER_NAME.{_nameKey}";

    public string CustomName { get; set; }

    public int Experience { get; set; }

    public int AttributePoints { get; set; }

    public int AbilityPoints { get; set; }

    private readonly string _portraitPath;
    public string PortraitPath => _portraitPath;

    public CHARACTER_CLASS Class { get; set; }

    public Character(string nameKey, string portraitPath, int[] traitsId)
    {
        if (string.IsNullOrWhiteSpace(nameKey))
        {
            throw new ArgumentNullException(nameof(nameKey));
        }

        if (string.IsNullOrWhiteSpace(portraitPath))
        {
            throw new ArgumentNullException(nameof(portraitPath));
        }

        if (traitsId == null || traitsId.Length < 3)
        {
            throw new ArgumentException(nameof(traitsId));
        }

        _itemsId = new int?[6];
        _nameKey = nameKey;
        _portraitPath = portraitPath;
        _traitsId = traitsId.Take(3).ToArray();

        int attributesCount = Enum.GetNames(typeof(CHARACTER_ATTRIBUTE)).Length;
        _pureAttributeValues = new int[attributesCount];
        _computedAttributeValues = new int[attributesCount];

        int resistanceCount = Enum.GetNames(typeof(CHARACTER_RESISTANCE)).Length;
        _computedResistanceValues = new int[resistanceCount];

        int abilitiesCount = Enum.GetNames(typeof(CHARACTER_ABILITY)).Length;
        _isActiveAbility = new bool[abilitiesCount];
    }

    public int? GetItemId(int index)
    {
        return _itemsId[index];
    }

    public void SetItemId(int index, int? id)
    {
        _itemsId[index] = id;
    }

    public int GetTraitId(CHARACTER_TRAIT_SLOT slot)
    {
        return _traitsId[(int)slot];
    }

    public bool ContainsTrait(int traitId)
    {
        return _traitsId.Contains(traitId);
    }

    public bool IsActiveAbility(CHARACTER_ABILITY ability)
    {
        return _isActiveAbility[(int)ability];
    }

    public void ActivateAbility(CHARACTER_ABILITY ability)
    {
        _isActiveAbility[(int)ability] = true;
    }

    public int GetPureAttributeValue(CHARACTER_ATTRIBUTE attribute)
    {
        return _pureAttributeValues[(int)attribute];
    }
    
    public void SetPureAttributeValue(CHARACTER_ATTRIBUTE attribute, int value)
    {
        _pureAttributeValues[(int)attribute] = value;
    }

    public void ChangePureAttributeValue(CHARACTER_ATTRIBUTE attribute, int value)
    {
        _pureAttributeValues[(int)attribute] += value;
    }
}
