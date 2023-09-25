using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthenticationManager : MonoBehaviour
{
    [SerializeField] private IntEventChannel _audioEvent;

    public async void LoginAnonymously() {
        using (new Load("Logging you in...")) {
            await Authentication.Login();
            _audioEvent.RaiseIntEvent(1);
            SceneManager.LoadSceneAsync("Lobby");
        }
    }
}