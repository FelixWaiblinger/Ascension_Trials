using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    [SerializeField] private InitController _playerPrefab;
    [SerializeField] private IntEventChannel _exitEvent;

    #region SETUP

    public override void OnNetworkSpawn()
    {
        SpawnPlayerServerRpc(NetworkManager.Singleton.LocalClientId);
    }

    void OnEnable()
    {
        _exitEvent.OnIntEventRaised += ExitChamber;
    }

    void OnDisable()
    {
        _exitEvent.OnIntEventRaised -= ExitChamber;
    }

    async public override void OnDestroy()
    {
        base.OnDestroy();
        await MatchmakingService.LeaveLobby();
        
        NetworkManager.Singleton?.Shutdown();
    }

    #endregion

    #region RPC

    [ServerRpc(RequireOwnership = false)]
    private void SpawnPlayerServerRpc(ulong playerId)
    {
        var spawn = Instantiate(_playerPrefab);
        spawn.NetworkObject.SpawnWithOwnership(playerId);
    }

    #endregion
    
    void ExitChamber(int exitIndex)
    {

    }

}