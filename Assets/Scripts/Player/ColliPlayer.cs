using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliPlayer : MonoBehaviour
{
    public GameObject SpawnTree;

    public GameObject CollectButt;

    private bool hitAnimal;

    
    public void ShowCollectButt()
    {
        CollectButt.SetActive(true);
    }
    public void HideCollectButt()
    {
        CollectButt.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
         
        if (other.CompareTag("BlockGrass") && !other.CompareTag("Tree"))
        {
            SpawnTree.SetActive(true);
        }
        if (other.CompareTag("Tree"))
        {
            CollectButt.SetActive(true);
            SpawnTree.SetActive(false);
        }
        if (other.CompareTag("Cow") || other.CompareTag("Chicken"))
        {
            hitAnimal = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            CollectButt.SetActive(true);
            SpawnTree.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("BlockGrass"))
        {
            SpawnTree.SetActive(false);
        }
        if (other.CompareTag("Tree"))
        {
            CollectButt.SetActive(false);
        }
        if (other.CompareTag("Cow") || other.CompareTag("Chicken"))
        {
            hitAnimal = false;
        }
    }
    public bool HitAnimalState()
    {
        return hitAnimal;
    }
    public void PressCollectButton()
    {
        CollectButt.SetActive(false);
    }
}
