using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("InputReader")]
    [SerializeField] private InputReader _input;

    void Awake() { _input.InitGameInput(); }
}
