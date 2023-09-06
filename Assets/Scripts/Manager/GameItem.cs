using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameItemId
{
    NONE,
    ITEM_01,
    ITEM_02,
    ITEM_03,
    ITEM_04,
    ITEM_05,
    ITEM_06,
}
public class GameItem 
{
    public GameItemId ID { get; set; }
    public int number { get; set; }
    public string name { get; set; }
    public string Description { get; set; }
}
