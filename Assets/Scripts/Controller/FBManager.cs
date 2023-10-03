using System.Collections;
using TMPro; 
using UnityEngine;
using UnityEngine.SceneManagement;

public class FBManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI debugLog;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingStep());
    }
    private IEnumerator LoadingStep()
    {
        Debug.Log("Loading controller step 0");
        debugLog.text = "Loading Game Data Manager";
        GameDataManager.Instance.InitData();
        yield return new WaitUntil(() => (GameDataManager.Instance.IsInit == true));

        /*Debug.Log("Loading controller step 1");
        debugLog.text = "Loading Mobile Notification";
        StartCoroutine(NotificationManager.Instance.RequestNotificationPermission());
        yield return new WaitUntil(() => (NotificationManager.Instance.IsInit == true));*/

        /*Debug.Log("Loading controller step 2");
        debugLog.text = "Loading Firebase";
        FirebaseManager.Instance.IsnitFirebase();
        yield return new WaitUntil(() => (FirebaseManager.Instance.IsInit == true));*/

        /*Debug.Log("LoadingController LoadingStep 3 ");
        
        TransactionServer.Instance.Init();
        yield return new WaitUntil(() => (TransactionServer.Instance.IsInit == true));*/

        Debug.Log("Loading controller step 4");
        debugLog.text = "Player Profile";
        PlayerProfile.Instance.InitProfile();
        yield return new WaitUntil(() => (PlayerProfile.Instance.IsInit == true));

        Debug.Log("Loading controller step 5");
        debugLog.text = "Loading Main Menu";
        SceneManager.LoadScene("MainMenu");

        yield return null;
    }
}
