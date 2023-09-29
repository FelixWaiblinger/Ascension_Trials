using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputReader _input;

    void Awake() { _input.InitGameInput(); }
}
