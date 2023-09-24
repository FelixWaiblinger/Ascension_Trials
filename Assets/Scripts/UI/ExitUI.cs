using UnityEngine;
using TMPro;

public class ExitUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _time;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        transform.rotation = _camera.transform.rotation;
    }

    public void UpdateTime(float time)
    {
        _time.text = time >= 0 ? ((int)time).ToString() : "";
    }
}
