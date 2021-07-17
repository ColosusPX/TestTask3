using UnityEngine;
using UnityEngine.EventSystems;

public class ClickReaciver : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] UIController UI;
    public void OnPointerClick(PointerEventData eventData)
    {
        UI.CubeClick();
    }
}
