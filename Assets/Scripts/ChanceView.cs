using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ChanceView : MonoBehaviour
{
    [SerializeField] private Button _buttonDone, _buttonClose;
    [SerializeField] private TMP_InputField _inputMinimum, _inputMaximum;
    [SerializeField] private Transform _content;
    [SerializeField] private SliderPanel _sliderPrefab;

    public event Action<ChanceView> Close;

    private List<SliderPanel> _sliders = new List<SliderPanel>();
    private List<Chance> _chances;

    private void OnEnable()
    {
        _buttonDone.onClick.AddListener(SaveChances);
        _buttonClose.onClick.AddListener(ClosePressed);
    }

    private void OnDisable()
    {
        _buttonDone.onClick.RemoveAllListeners();
        _buttonClose.onClick.RemoveAllListeners();
    }

    public void Initialize(List<Chance> chances)
    {
        _chances = chances;
        foreach(Chance chance in chances)
        {
            SliderPanel slider = Instantiate(_sliderPrefab, _content);
            slider.Initialize(chance.Name, chance.Value);
            _inputMinimum.text = chance.Minimum.ToString();
            _inputMaximum.text = chance.Maximum.ToString();
            _sliders.Add(slider);
        }
    }

    public void DestroyView() => Destroy(gameObject);

    private void ClosePressed() => Close?.Invoke(this);

    private void SaveChances()
    {
        int.TryParse(_inputMinimum.text, out int minimum);
        int.TryParse(_inputMaximum.text, out int maximum);

        for(int i = 0; i < _sliders.Count; i++)
        {
            _chances[i].Value = _sliders[i].SliderValue;
            _chances[i].Minimum = minimum;
            _chances[i].Maximum = maximum;
        }

        Close?.Invoke(this);
    }

}
