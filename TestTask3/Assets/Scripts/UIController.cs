using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] RectTransform _downPanel, _sliderPanel, _plusMinusPanel, _randomPanel;
    [SerializeField] Text _redText, _greenText, _blueText;
    [SerializeField] Slider _slider;
    [SerializeField] Material _mat;

    Image _panel;
    int _redColor, _greenColor, _blueColor;
    bool _isButtonPlusDown, _isButtonMinusDown, _isMat;

    public void SliderValueChamged()
    {
        _greenColor = (int)(255 * _slider.value);
        _greenText.text = "G: " + _greenColor;
        if (_panel != null)
            _panel.color = new Color(_panel.color.r, _greenColor / 255f, _panel.color.b);
        if (_isMat)
            _mat.color = new Color(_mat.color.r, _greenColor / 255f, _mat.color.b);
    }

    public void RandomButton()
    {
        _blueColor = (int)(Random.Range(0, 256));
        _blueText.text = "B: " + _blueColor;
        if (_panel != null)
            _panel.color = new Color(_panel.color.r, _panel.color.g, _blueColor / 255f);
        if(_isMat)
            _mat.color = new Color(_mat.color.r, _mat.color.g, _blueColor / 255f);
    }

    public void MouseDown(Image image)
    {
        _redColor = (int)(255 * image.color.r);
        _greenColor = (int)(255 * image.color.g);
        _blueColor = (int)(255 * image.color.b);

        _redText.text = _redColor.ToString();
        _greenText.text = "G: " + _greenColor;
        _blueText.text = "B: " + _blueColor;
        
        _panel = image;
        _isMat = false;
        _slider.value = _greenColor / 255f;
    }

    public void CubeClick()
    {
        _panel = null;

        _redColor = (int)(255 * _mat.color.r);
        _greenColor = (int)(255 * _mat.color.g);
        _blueColor = (int)(255 * _mat.color.b);

        _redText.text = _redColor.ToString();
        _greenText.text = "G: " + _greenColor;
        _blueText.text = "B: " + _blueColor;

        _slider.value = _greenColor / 255f;
        _isMat = true;
    }

    public void onPointerDownRaceButton(int num)
    {
        if (num == 1)
            _isButtonPlusDown = true;
        else
            _isButtonMinusDown = true;
    }

    public void onPointerUpRaceButton()
    {
        _isButtonPlusDown = false;
        _isButtonMinusDown = false;
    }

    private void FixedUpdate()
    {
        if (_isButtonPlusDown && _redColor < 255)
        {
            _redColor++;
            _redText.text = _redColor.ToString();
            if (_panel != null)
                _panel.color = new Color(_redColor / 255f, _panel.color.g, _panel.color.b);
            if (_isMat)
                _mat.color = new Color(_redColor / 255f, _mat.color.g, _mat.color.b);
        }
        else if (_isButtonMinusDown && _redColor > 0)
        {
            _redColor--;
            _redText.text = _redColor.ToString();
            if (_panel != null)
                _panel.color = new Color(_redColor / 255f, _panel.color.g, _panel.color.b);
            if (_isMat)
                _mat.color = new Color(_redColor / 255f, _mat.color.g, _mat.color.b);
        }
    }
}