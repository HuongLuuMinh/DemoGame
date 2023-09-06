using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUIView : MonoBehaviour
{
    [SerializeField] Image Img;
    [SerializeField] TextMeshProUGUI Number;

    public void Init(GameItem gameItem)
    {
        Img.gameObject.SetActive(true);
        Number.gameObject.SetActive(true);
        Img.sprite = GameDataManager.Instance.GetItemSprite(gameItem.ID);
        Number.text = gameItem.number.ToString();
    }

    public void Hide()
    {
        Img.gameObject.SetActive(false);
        Number.gameObject.SetActive(false);
    }
}
