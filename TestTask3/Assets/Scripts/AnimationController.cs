using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] RectTransform _panel;

    RectTransform _canvas;

    Vector3 _startPosition, _direction;

    private void Start()
    {
        _canvas = gameObject.GetComponent<RectTransform>();
        _startPosition = _panel.anchoredPosition;
        _direction = new Vector3(-(_canvas.sizeDelta.x + _startPosition.x), _startPosition.y, 0);
    }

    private void Update()
    {
        _panel.anchoredPosition += (Vector2)(_direction - _startPosition) * Time.deltaTime / 2;

        if (Mathf.Abs((_panel.anchoredPosition - (Vector2)_direction).magnitude) < 5)
        {
            Vector3 vector = _startPosition;
            _startPosition = _direction;
            _direction = vector;
        }
    }
}
