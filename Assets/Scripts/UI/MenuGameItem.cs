using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGameItem : MonoBehaviour
{
    [SerializeField] List<ItemUIView> ListImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowGameItem()
    {
        foreach (ItemUIView item in ListImage)
        {
            item.Hide();
        }
        int i = 0;
        foreach (var item in PlayerProfile.Instance.SaveGame.GameItems)
        {
            ListImage[i].Init(item);
            i++;
            
        }
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
