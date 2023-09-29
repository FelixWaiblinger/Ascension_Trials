using UnityEngine;
using Unity.Netcode;

public class InitController : NetworkBehaviour
{
    [SerializeField] private GameData _gameData;

    public override void OnNetworkSpawn()
    {
        Debug.Log($"Initializing client {NetworkManager.Singleton.LocalClientId}");
        var character = _gameData.Players[NetworkManager.Singleton.LocalClientId];

        Instantiate(character.Visuals, transform);
        GetComponent<AbilityController>().Init(character.Abilities);
        GetComponent<MovementController>().Init(character.Speed);
        GetComponent<StatusController>().Init(character.Health, character.Armor);
        GetComponentInChildren<PlayerUI>().Init(character.Health, character.Abilities);
    }
}
