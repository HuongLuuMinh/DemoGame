using Fusion;
using System;
using System.Collections.Generic;
using UnityEngine;

public struct NetworkInputData : INetworkInput
{
    public Vector3 direction;
}

public class FusionManager : ISingleton<FusionManager>
{
    public static Action<List<SessionInfo>> ON_SESSION_LIST_UPDATED { get; set; }
    public NetworkRunner _runner { get; private set; }
    public NetworkSceneManagerDefault NetworkSceneManagerDefault { get; private set; }
    public Dictionary<PlayerRef, NetworkObject> _spawnedCharacters { get; private set; } = new Dictionary<PlayerRef, NetworkObject>();

    public void Init(NetworkRunner networkRunner, NetworkSceneManagerDefault networkSceneManagerDefault)
    {
        Debug.Log("FusionManager start init");
        _runner = networkRunner;
        NetworkSceneManagerDefault = networkSceneManagerDefault;
    }
    
    public async void JoinLobby(string lobbyName)
    {
        await _runner.JoinSessionLobby(SessionLobby.ClientServer, lobbyName);
    }
    async void StartGame(GameMode mode,string lobby,string roomName)
    {
        Debug.Log("FusionManager start");
        _runner.ProvideInput = true;
        _runner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        StartGameArgs config = new StartGameArgs()
        {
            GameMode = mode,
            SessionName = roomName,
            CustomLobbyName = lobby,
            Scene = 4,
            SceneManager = _runner.gameObject.GetComponent<NetworkSceneManagerDefault>(),
        };
        await _runner.StartGame(config);

    }

    public void HostAGame(string lobby, string sessionName)
    {
        StartGame(GameMode.Host, lobby, sessionName);
    }

    public void JoinAGame(string lobby, string sessionName)
    {
        StartGame(GameMode.Client, lobby, sessionName);
    }

    public void ExitGame()
    {
        _runner.Shutdown();
    }
}
