using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Fusion;

public class RoomInfo : MonoBehaviour
{
    [SerializeField] private Image Image;
    [SerializeField] private TextMeshProUGUI m_RoomName;
    [SerializeField] private TextMeshProUGUI m_NumberPlayer;

    private LobbyController LobbyController;
    private SessionInfo SessionInfo;
    public void Init(LobbyController lobbyController, SessionInfo sessionInfo)
    {
        LobbyController = lobbyController;
        SessionInfo = sessionInfo;
        m_RoomName.text = sessionInfo.Name;
        m_NumberPlayer.text = sessionInfo.PlayerCount.ToString();
    }

    public void OnSellect()
    {
        LobbyController.SetCurrentRoom(SessionInfo);
    }
}
