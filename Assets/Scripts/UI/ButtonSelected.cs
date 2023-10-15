using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelected : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private GameObject _toolTip;

    public void OnSelect(BaseEventData eventData)
    {
        _toolTip.SetActive(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        _toolTip.SetActive(false);
    }
}
