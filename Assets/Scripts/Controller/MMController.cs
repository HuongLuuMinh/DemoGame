using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMController : MonoBehaviour
{
    public GameObject SettingMenu;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void OpenSetting()
    {
         if(SettingMenu)
            SettingMenu.SetActive(true);
    }

    public void CloseSetting()
    {
        SettingMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
