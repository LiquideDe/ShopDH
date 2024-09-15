using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopView : MonoBehaviour
{
    [SerializeField] private Button _buttonQr, _buttonGenerate, _buttonSave, _buttonRange, _buttonUpgrade, _buttonMelee, _buttonBullets, 
        _buttonGrenade, _buttonArmor, _buttonShields, _buttonThings, _buttonExotic, _buttonChaos, _buttonImplants, _buttonDrugs;

    [SerializeField] private Transform _content;
    [SerializeField] private ItemInListWithAdditionalButton _itemPrefab;

    private List<ItemInListWithAdditionalButton> _items = new List<ItemInListWithAdditionalButton>();

    public event Action SendQr, GenerateItems, Save;
    public event Action<string> ShowThisItem, RemoveThisItem;
    public event Action ShowRangeChance, ShowUpgradeChance, ShowMeleeChance, ShowGrenadeChance, ShowBulletChance, ShowArmorChance, ShowShieldChance,
        ShowThingsChance, ShowExoticChance, ShowChaosChance, ShowImplantsChance, ShowDrugsChance;


    private void OnEnable()
    {
        _buttonQr.onClick.AddListener(QrPressed);
        _buttonGenerate.onClick.AddListener(GeneratePressed);
        _buttonSave.onClick.AddListener(SavePressed);
        _buttonRange.onClick.AddListener(ShowRangeChancePresed);
        _buttonUpgrade.onClick.AddListener(ShowUpgradePressed);
        _buttonMelee.onClick.AddListener(ShowMeleeChancePressed);
        _buttonBullets.onClick.AddListener(ShowBulletChancePressed);
        _buttonGrenade.onClick.AddListener(ShowGrenadeChancePressed);
        _buttonArmor.onClick.AddListener(ShowArmorChancePressed);
        _buttonShields.onClick.AddListener(ShowShieldChancePressed);
        _buttonThings.onClick.AddListener(ShowThingsChancePressed);
        _buttonExotic.onClick.AddListener(ShowExoticChancePressed);
        _buttonChaos.onClick.AddListener(ShowChaosChancePressed);
        _buttonImplants.onClick.AddListener(ShowImplantsChancePressed);
        _buttonDrugs.onClick.AddListener(ShowDrugsChancePressed);

    }    

    public void ShowList(List<Equipment> equipments)
    {
        if(_items.Count > 0)
        {
            foreach(ItemInListWithAdditionalButton item in _items)
            {
                Destroy(item.gameObject);
            }
            _items.Clear();
        }


        foreach(Equipment equipment in equipments)
        {
            ItemInListWithAdditionalButton item = Instantiate(_itemPrefab, _content);
            item.ChooseThis += ShowThisItemPressed;
            item.AdditionalButtonAction += RemoveThisItemPressed;
            item.Initialize(equipment.Name);
            _items.Add(item);
        }
    }

    private void RemoveThisItemPressed(string name) => RemoveThisItem?.Invoke(name);

    private void ShowThisItemPressed(string name) => ShowThisItem?.Invoke(name);

    private void SavePressed() => Save?.Invoke();

    private void GeneratePressed() => GenerateItems?.Invoke();

    private void QrPressed() => SendQr?.Invoke();

    private void ShowDrugsChancePressed() => ShowDrugsChance?.Invoke();

    private void ShowImplantsChancePressed() => ShowImplantsChance?.Invoke();

    private void ShowChaosChancePressed() => ShowChaosChance?.Invoke();

    private void ShowExoticChancePressed() => ShowExoticChance?.Invoke();

    private void ShowThingsChancePressed() => ShowThingsChance?.Invoke();

    private void ShowShieldChancePressed() => ShowShieldChance?.Invoke();

    private void ShowArmorChancePressed() => ShowArmorChance?.Invoke();

    private void ShowGrenadeChancePressed() => ShowGrenadeChance?.Invoke();

    private void ShowBulletChancePressed() => ShowBulletChance?.Invoke();

    private void ShowMeleeChancePressed() => ShowMeleeChance?.Invoke();

    private void ShowUpgradePressed() => ShowUpgradeChance?.Invoke();

    private void ShowRangeChancePresed() => ShowRangeChance?.Invoke();
}
