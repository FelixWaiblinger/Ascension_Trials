using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using TMPro;

/// <summary>
///     Play some satisfying click sounds
/// </summary>
public class ButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private TMP_Text _text;

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayClip("ButtonUp");
        // _text.rectTransform.position -= Vector3.down * _text.rectTransform.parent.
    }

    public void OnPointerUp(PointerEventData eventData) {
        PlayClip("ButtonDown");
    }

    private static void PlayClip(string n) {
        var clip = Addressables.LoadAssetAsync<AudioClip>(n).WaitForCompletion();
        AudioSource.PlayClipAtPoint(clip, Vector3.zero, 0.5f);
    }
}