using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemUI
{
    public GameItemId GameItemId;
    public Sprite Image;

}

[CreateAssetMenu(fileName = "ItemScriptable", menuName = "ScriptableObject/ItemScriptable", order = 1)]
public class ItemScriptable : ScriptableObject
{
    public List<ItemUI> ListItemUI;
}
