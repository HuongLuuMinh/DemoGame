using Fusion;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LobbyController : MonoBehaviour
{
    [SerializeField] RoomInfo RoomInfoPref;
    [SerializeField] GameObject ListRoom;
    [SerializeField] private NetworkRunner RunnerPref;
    [SerializeField]private NetworkSceneManagerDefault NetworkSceneManagerDefault;
    [SerializeField] private TMP_InputField RoomNameInput;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private TextMeshProUGUI txtNumber;

    public static string LOBBY_NAME => "NongTrai01";
    private SessionInfo CurrentRoom;

    private void OnEnable()
    {
        FusionManager.ON_SESSION_LIST_UPDATED += UpdateListRooms;
    }

    private void OnDisable()
    {
        FusionManager.ON_SESSION_LIST_UPDATED -= UpdateListRooms;
    }
    
    private void Start()
    {
        NetworkRunner runner = Instantiate(RunnerPref);
        FusionManager.Instance.Init(runner, NetworkSceneManagerDefault);
        FusionManager.Instance.JoinLobby(LOBBY_NAME);
        txtName.text = "";
        txtNumber.text = "";
    }

    public void UpdateListRooms(List<SessionInfo> sessionList)
    {
        foreach(Transform item in ListRoom.transform)
        {
            Destroy(item.gameObject);
        }
        for (int i = 0; i < sessionList.Count; i++)
        {
            RoomInfo rominfor = Instantiate(RoomInfoPref, ListRoom.transform);
            rominfor.Init(this, sessionList[i]);
        }
        if (sessionList.Count > 0)
        {
            SetCurrentRoom(sessionList[0]);
        }
    }
    public void SetCurrentRoom(SessionInfo roomInfo)
    {
        CurrentRoom = roomInfo;
        txtName.text = CurrentRoom.Name;
        txtNumber.text = CurrentRoom.PlayerCount.ToString();
    }
    public void CreateGame()
    {
        FusionManager.Instance.HostAGame(LOBBY_NAME, RoomNameInput.text);
    }

    public void JoinGame()
    {
        FusionManager.Instance.JoinAGame(LOBBY_NAME, CurrentRoom.Name);
    }
}
