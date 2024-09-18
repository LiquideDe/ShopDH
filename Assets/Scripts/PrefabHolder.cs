using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabHolder", menuName = "Holder/PrefabHolder")]
public class PrefabHolder : ScriptableObject
{
    [SerializeField] private GameObject _chancePanel, _textInfo;

    public GameObject Get(TypeScene typeScene)
    {
        switch (typeScene)
        {
            case TypeScene.ChancePanel:
                return _chancePanel;

            case TypeScene.TextInfo:
                return _textInfo;

            default:
                throw new ArgumentException(nameof(TypeScene));
        }
    }
}
