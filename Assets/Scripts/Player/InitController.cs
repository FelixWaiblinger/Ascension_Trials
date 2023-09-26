using UnityEngine;
using Unity.Netcode;

public class InitController : NetworkBehaviour
{
    [SerializeField] private GameData _gameData;

    public override void OnNetworkSpawn()
    {
        var character = _gameData.Players[NetworkManager.Singleton.LocalClientId];
        var abilities = GetComponent<AbilityController>();
        var movement = GetComponent<MovementController>();
        var status = GetComponent<StatusController>();
        var hud = GetComponentInChildren<PlayerUI>();

        Instantiate(character.Visuals, transform);
        abilities.Init(character.Abilities);
        movement.Init(character.Speed);
        status.Init(character.Health, character.Armor);
        hud.Init(character.Health, character.Abilities);
    }
}
