using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TextInfoView : MonoBehaviour
{
    [SerializeField] private Button _buttonClose;
    [SerializeField] private TextMeshProUGUI _textName, _textDescription;

    public event Action<TextInfoView> Close;

    private void OnEnable()
    {
        _buttonClose.onClick.AddListener(ClosePressed);
    }

    public void Initialize(Equipment equipment)
    {
        _textName.text = equipment.Name;
        _textDescription.text = equipment.Description;
    }

    public void DestroyView() => Destroy(gameObject);
    private void ClosePressed() => Close?.Invoke(this);
}
