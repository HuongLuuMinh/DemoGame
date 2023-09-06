using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    int m_Tree, m_Mushroom,m_Milk,m_Egg;
    bool isCollect;
    
    // Start is called before the first frame update
    void Start()
    {
        SetCollectState(false);
    }
    public void IncreaseTree()
    {
        m_Tree++;
    }
    public void IncreaseMushroom()
    {
        m_Mushroom++;
    }
    public bool isCollectState()
    {
        return isCollect;
    }
    public void SetCollectState(bool state)
    {
        isCollect = state;
    }
    public void CollectItem()
    {
        SetCollectState(true);
    }
    public void IncreaseMilk()
    {
        m_Milk++;
    }
    public void IncreaseEgg()
    {
        m_Egg++;
    }
}
