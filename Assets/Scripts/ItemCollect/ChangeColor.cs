using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Renderer mr;
    [SerializeField] GameItemId id;
    
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<Renderer>();
        ChangeItemColor(id);
    }
    public void ChangeItemColor(GameItemId id)
    {
        if(id == GameItemId.ITEM_01)
        {
            mr.material.color = new Color(0.2361948f, 1f, 0f, 1f);
        }
        if(id == GameItemId.ITEM_02)
        {
            mr.material.color = new Color(0f, 1f, 0.9693696f, 1f);
        }
        if (id == GameItemId.ITEM_03)
        {
            mr.material.color = new Color(0.8066038f, 1f, 0.9939327f, 1f);
        }
        if (id == GameItemId.ITEM_04)
        {
            mr.material.color = new Color(0.7264151f, 0.1953097f, 0.411f, 1f);
        }
    }
}
