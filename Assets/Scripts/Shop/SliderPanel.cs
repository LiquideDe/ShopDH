using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderPanel : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _znachenie;
    [SerializeField] private TextMeshProUGUI _textName;

    public float SliderValue => _slider.value;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SliderChanged);
        SliderChanged(_slider.value);
    }

    public void Initialize(string name, float value)
    {
        _textName.text = name;
        gameObject.SetActive(true);
        _slider.value = value;
        SliderChanged(value);
    }

    private void SliderChanged(float amount)
    {
        _znachenie.text = $"{amount}%";
    }
}
