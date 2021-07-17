using UnityEngine;
using UnityEngine.UI;

public class MouseClick : MonoBehaviour
{
    [SerializeField] UIController UI;

    public void Click()
    {
        UI.MouseDown(gameObject.GetComponent<Image>());
    }
}
