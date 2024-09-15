using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabHolder", menuName = "Holder/PrefabHolder")]
public class PrefabHolder : ScriptableObject
{
    [SerializeField] private GameObject _chancePanel;

    public GameObject Get(TypeScene typeScene)
    {
        switch (typeScene)
        {
            case TypeScene.ChancePanel:
                return _chancePanel;

            default:
                throw new ArgumentException(nameof(TypeScene));
        }
    }
}
