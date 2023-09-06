using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    ItemController m_ItCon;
    public GameItemId id;

    bool isTrigger;

    // Start is called before the first frame update
    void Start()
    {
        m_ItCon = FindObjectOfType<ItemController>();
        isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_ItCon.isCollectState() == true && isTrigger)
        {
            m_ItCon.SetCollectState(false);
            m_ItCon.IncreaseTree();
            PlayerProfile.Instance.IncreaseCoin(800);
            PlayerProfile.Instance.AddGameItem(id);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = false;
        }
    }
}
