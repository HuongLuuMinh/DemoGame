using Newtonsoft.Json;
using UnityEngine;

public class GameDataManager : ISingleton<GameDataManager>
{
    private ItemScriptable itemScriptable;
    public bool IsInit { get; private set; }
    public GameDataManager()
    {
        IsInit = false;
    }
    public void InitData()
    {
        Debug.Log("GameDataManager init Data");
        itemScriptable = Resources.Load<ItemScriptable>("ItemScriptable");
        IsInit = true;
    }
    public Sprite GetItemSprite(GameItemId id)
    {
        var rs = itemScriptable.ListItemUI.Find(x => x.GameItemId == id);
        if(rs == null)
        {
            rs = itemScriptable.ListItemUI[0];
        }
        return rs.Image;
    }
}
