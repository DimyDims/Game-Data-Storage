using System;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Company
{
    private SCENE_TYPE _sceneType;

    private CurentTeam _curentTeam;

    private HubMission _curentMission;

    private int[] _resourceAmount;

    public int Week { get; set; }

    public List<int> ItemsId { get; private set; }

    public List<Character> Characters { get; }

    public ShipAbilities ShipAbilities { get; }

    public HubStorage HubStorage { get; }

    public Company()
    {
        _sceneType = SCENE_TYPE.HUB;

        ItemsId = new List<int>();

        _curentTeam = new CurentTeam();

        Characters = new List<Character>();

        int count = System.Enum.GetNames(typeof(GAME_RESOURCE)).Length;
        _resourceAmount = new int[count];

        ShipAbilities = new ShipAbilities();

        HubStorage = new HubStorage();

        SetResourceAmount(GAME_RESOURCE.CREDITS, 1500);
        SetResourceAmount(GAME_RESOURCE.INFODISCS, 40);
        SetResourceAmount(GAME_RESOURCE.SAMPLES, 40);
        SetResourceAmount(GAME_RESOURCE.MICROCHIPS, 40);
    }

    public void SetItemsId(IEnumerable<int> itemsId)
    {
        if (itemsId == null)
        {
            throw new ArgumentNullException(nameof(itemsId));
        }

        ItemsId = itemsId.ToList();
    }

    public HubMission GetCurentMission()
    {
        return _curentMission;
    }

    public CurentTeam GetCurentTeam()
    {
        return _curentTeam;
    }

    public void SetSceneType(SCENE_TYPE sceneType)
    {
        _sceneType = sceneType;
    }

    public int GetResourceAmount(GAME_RESOURCE resource)
    {
        return _resourceAmount[(int)resource];
    }

    public void SetResourceAmount(GAME_RESOURCE resource, int amount)
    {
        _resourceAmount[(int)resource] = amount;
    }

    public void ChangeResourceAmount(GAME_RESOURCE resource, int value)
    {
        _resourceAmount[(int)resource] += value;
    }
}
