using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GPController : MonoBehaviour
{
    [SerializeField] MenuGameItem MenuGameItem;
    
    public GameObject SettingMenu;
    // Update is called once per frame
    void Update()
    {
        
    }

     public void OpenSetting()
    {
        if (SettingMenu)
            SettingMenu.SetActive(true);
    }
    public void Resume()
    {
        SettingMenu.SetActive(false);
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ShowGameItem()
    {
        MenuGameItem.gameObject.SetActive(true);
        MenuGameItem.ShowGameItem();
    }
}
