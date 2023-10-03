using System.Collections;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class SaveGame
{
    public string Name { get; set; }
    public long Coin { get; set; }
    public List<GameItem> GameItems { get; set; }
}

public class PlayerProfile : ISingleton<PlayerProfile>
{
    public bool IsInit { get; private set; }
    public SaveGame SaveGame { get; private set; }

    public static Action ON_COIN_CHANGE { get; set; }
    public const string PLAYER_NAME = "Player01";
    public PlayerProfile()
    {
        IsInit = false;
    }
    public void InitProfile()
    {
        /*FirebaseManager.Instance.ReadProfileData(PLAYER_NAME,
            (rs, data) =>
            {
                if (rs == true && data !=null)
                {
                    SaveGame = JsonConvert.DeserializeObject<SaveGame>(data);
                }
                else
                {
                    SaveGame = new SaveGame()
                    {
                        Name = "PlayerName",
                        Coin = 10000,
                        GameItems = new List<GameItem>(){
                            new GameItem(){ID = GameItemId.ITEM_01,number =1, name = "item1"},
                        }
                    };
                    SaveProfileToServer();
                }
                IsInit = true;
            });*/
        SaveGame = new SaveGame()
        {
            Name = "PlayerName",
            Coin = 10000,
            GameItems = new List<GameItem>(){
                            new GameItem(){ID = GameItemId.ITEM_01,number =1, name = "item1"},
                            new GameItem(){ID = GameItemId.ITEM_02,number =1, name = "item2"},
                            new GameItem(){ID = GameItemId.ITEM_03,number =1, name = "item3"},
                            new GameItem(){ID = GameItemId.ITEM_04,number =1, name = "item4"},
                        }
        };
        IsInit = true;
    }
    public void SaveProfileToServer()
    {
        FirebaseManager.Instance.WriteProfileData(PLAYER_NAME, JsonConvert.SerializeObject(SaveGame));
    }
    public string GetName()
    {
        return SaveGame.Name;
    }
    public long GetCurrentCoin()
    {
        return SaveGame.Coin;
    }
    public void IncreaseCoin(long number)
    {
        SaveGame.Coin += number;
        ON_COIN_CHANGE?.Invoke();
        //SaveProfileToServer();
    }
    public bool DecreaseCoin(long number)
    {
        if (SaveGame.Coin >= number)
        {
            SaveGame.Coin -= number;
            ON_COIN_CHANGE?.Invoke();
            //SaveProfileToServer();
            return true;        }
        else
        {
            return false;
        }
    }
    public void AddGameItem (GameItemId itemId)
    {
        GameItem item = SaveGame.GameItems.Find(x => x.ID == itemId);
        if (item != null)
        {
            item.number++;
        }
        else
        {
            SaveGame.GameItems.Add(new GameItem() { ID = itemId });
        }
        //SaveProfileToServer();
    }
    public bool UseGameItem (GameItemId itemid)
    {
        GameItem item = SaveGame.GameItems.Find(x => x.ID == itemid);
        if (item != null)
        {
            item.number--;
            if (item.number < 0)
            {
                SaveGame.GameItems.Remove(item);
            }
            //SaveProfileToServer();
            return true;
        }
        else
        {
            return false;
        }
    }
}
