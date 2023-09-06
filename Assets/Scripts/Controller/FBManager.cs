using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FBManager : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingStep());
    }
    private IEnumerator LoadingStep()
    {
        Debug.Log("Loading controller step 0");
        GameDataManager.Instance.InitData();
        yield return new WaitUntil(() => (GameDataManager.Instance.IsInit == true));

        /*Debug.Log("Loading controller step 1");
        StartCoroutine(NotificationManager.Instance.RequestNotificationPermission());
        yield return new WaitUntil(() => (NotificationManager.Instance.IsInit == true));*/

        Debug.Log("Loading controller step 2"); 
        FirebaseManager.Instance.IsnitFirebase();
        yield return new WaitUntil(() => (FirebaseManager.Instance.IsInit == true));

        /*Debug.Log("LoadingController LoadingStep 3 ");
        TransactionServer.Instance.Init();
        yield return new WaitUntil(() => (TransactionServer.Instance.IsInit == true));*/

        Debug.Log("Loading controller step 4");
        PlayerProfile.Instance.InitProfile();
        yield return new WaitUntil(() => (PlayerProfile.Instance.IsInit == true));

        Debug.Log("Loading controller step 5");
        SceneManager.LoadScene("MainMenu");

        yield return null;
    }
}
