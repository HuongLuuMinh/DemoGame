using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameItemId id;
    private bool isEnter;
    private ColliPlayer controller;
    ItemController m_ItCon;

    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        controller = FindObjectOfType<ColliPlayer>();
        m_ItCon = FindObjectOfType<ItemController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_ItCon.isCollectState() && isEnter)
        {
            PlayerProfile.Instance.AddGameItem(id);
            isEnter = false;
            m_ItCon.SetCollectState(false);
            controller.HideCollectButt();
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(isEnter == false && other.tag == "Player")
        {
            isEnter = true;
            controller.ShowCollectButt();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isEnter = true;
            controller.ShowCollectButt();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            controller.HideCollectButt();
            isEnter = false;
        }
    }
}
