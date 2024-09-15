using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShopPresenter
{
    private EquipmentDataBase _dataBase;
    private List<Equipment> _equipments = new List<Equipment>();
    private ShopView _view;
    private AudioManager _audioManager;
    private LvlFactory _lvlFactory;
    private Chance _bolterChance, _firearmsChance, _flamesChance, _plasmaChance, _laserChance, _mechanicumChance, _meltasChance, _chaosChance, _grenadeChance;
    private Chance _rangeUpgradeChance, _meleeUpgradeChance;
    private Chance _bolterBulletsChance, _fireArmsBulletsChance, _plasmaLiquidChance, _flameLiquidChance, _chaosBulletsChance, _laserChargesChance;
    private Chance _chainsChance, _powerFieldsChance, _forceChance, _shockChance;
    private Chance _carapacesChance, _flaksChance, _meshChance, _powersChance;
    private Chance _exoticsChance, _shieldsTechChance, _thingsChance, _implantsChance, _drugsChance;

    public void Initialize(ShopView view, AudioManager audioManager, LvlFactory lvlFactory)
    {
        _view = view;
        _audioManager = audioManager;
        _dataBase = new EquipmentDataBase();
        _lvlFactory = lvlFactory;
        SetNamesToChance();
        Subscribe();
    }

    private void Subscribe()
    {
        _view.GenerateItems += GenerateList;
        _view.SendQr += ShowQr;
        _view.ShowArmorChance += ShowArmorChancePanel;
        _view.ShowBulletChance += ShowBulletsChancePanel;
        _view.ShowChaosChance += ShowChaosChancePanel;
        _view.ShowDrugsChance += ShowDrugsChancePanel;
        _view.ShowExoticChance += ShowExoticChancePanel;
        _view.ShowGrenadeChance += ShowGrenadeChancePanel;
        _view.ShowImplantsChance += ShowImplantsChancePanel;
        _view.ShowMeleeChance += ShowMeleeChancePanel;
        _view.ShowRangeChance += ShowRangeChancePanel;
        _view.ShowShieldChance += ShowShieldChancePanel;
        _view.ShowThingsChance += ShowThingsChancePanel;
        _view.ShowUpgradeChance += ShowUpgradeChancePanel;

        _view.RemoveThisItem += RemoveThisItem;
    }

    private void RemoveThisItem(string name)
    {
        _audioManager.PlayCancel();
        foreach (Equipment equipment in _equipments)
            if (string.Compare(name, equipment.Name, true) == 0)
            {
                _equipments.Remove(equipment);
                break;
            }
        _view.ShowList(_equipments);
    }

    private void CloseChancePanel(ChanceView chanceView)
    {
        _audioManager.PlayDone();
        chanceView.DestroyView();
    }

    private ChanceView CreateChancePanel()
    {
        ChanceView chanceView = _lvlFactory.Get(TypeScene.ChancePanel).GetComponent<ChanceView>();
        chanceView.Close += CloseChancePanel;
        return chanceView;
    }

    private void ShowUpgradeChancePanel()
    {
        List<Chance> chances = new List<Chance>() { _rangeUpgradeChance, _meleeUpgradeChance };
        CreateChancePanel().Initialize(chances);
    }

    private void ShowThingsChancePanel()
    {
        List<Chance> chances = new List<Chance>() { _thingsChance };
        CreateChancePanel().Initialize(chances);
    }

    private void ShowShieldChancePanel()
    {
        List<Chance> chances = new List<Chance>() { _shieldsTechChance };
        CreateChancePanel().Initialize(chances);
    }

    private void ShowRangeChancePanel()
    {        
        List<Chance> chances = new List<Chance>() { _bolterChance, _firearmsChance, _flamesChance, _plasmaChance, _laserChance, _mechanicumChance, _meltasChance };
        CreateChancePanel().Initialize(chances);
    }

    private void ShowMeleeChancePanel()
    {
        List<Chance> chances = new List<Chance>() { _chainsChance, _powerFieldsChance, _shockChance, _forceChance };
        CreateChancePanel().Initialize(chances);
    }

    private void ShowImplantsChancePanel()
    {
        List<Chance> chances = new List<Chance>() { _implantsChance };
        CreateChancePanel().Initialize(chances);
    }

    private void ShowGrenadeChancePanel()
    {
        List<Chance> chances = new List<Chance>() { _grenadeChance };
        CreateChancePanel().Initialize(chances);
    }

    private void ShowExoticChancePanel()
    {
        List<Chance> chances = new List<Chance>() { _exoticsChance };
        CreateChancePanel().Initialize(chances);
    }

    private void ShowDrugsChancePanel()
    {
        List<Chance> chances = new List<Chance>() { _drugsChance };
        CreateChancePanel().Initialize(chances);
    }

    private void ShowChaosChancePanel()
    {
        List<Chance> chances = new List<Chance>() { _chaosChance };
        CreateChancePanel().Initialize(chances);
    }

    private void ShowBulletsChancePanel()
    {
        List<Chance> chances = new List<Chance>() { _bolterBulletsChance, _fireArmsBulletsChance, _flameLiquidChance, _plasmaLiquidChance, _laserChargesChance, _chaosBulletsChance };
        CreateChancePanel().Initialize(chances);
    }

    private void ShowArmorChancePanel()
    {
        List<Chance> chances = new List<Chance>() { _carapacesChance, _flaksChance, _meshChance, _powersChance };
        CreateChancePanel().Initialize(chances);
    }

    private void SetNamesToChance()
    {
        _bolterChance = new Chance("���������");
        _firearmsChance = new Chance("�������������");
        _flamesChance = new Chance("�������������");
        _plasmaChance = new Chance("����������");
        _laserChance = new Chance("��������");
        _mechanicumChance = new Chance("���������");
        _meltasChance = new Chance("������");
        _chaosChance = new Chance("����");
        _grenadeChance = new Chance("�������");
        _rangeUpgradeChance = new Chance("����������� �����������");
        _meleeUpgradeChance = new Chance("����������� ��������");
        _bolterBulletsChance = new Chance("�����");
        _fireArmsBulletsChance = new Chance("������� ��� ��������������");
        _plasmaLiquidChance = new Chance("�������� ��� ������");
        _flameLiquidChance = new Chance("�������� ��� ��������������");
        _chaosBulletsChance = new Chance("������� �����");
        _laserChargesChance = new Chance("�������� �������");
        _chainsChance = new Chance("������");
        _powerFieldsChance = new Chance("�������");
        _forceChance = new Chance("������������");
        _shockChance = new Chance("�������");
        _carapacesChance = new Chance("���������");
        _flaksChance = new Chance("����");
        _meshChance = new Chance("��������");
        _powersChance = new Chance("�������");
        _exoticsChance = new Chance("����������");
        _shieldsTechChance = new Chance("������� ����");
        _thingsChance = new Chance("����");
        _implantsChance = new Chance("��������");
        _drugsChance = new Chance("��������");
    }

    private void ShowQr()
    {
        var path = Path.Combine($"{Application.dataPath}/StreamingAssets/qrcp", "1.txt");
        List<string> data = new List<string>();
        foreach(Equipment equipment in _equipments)
        {
            if(equipment.TypeEq == Equipment.TypeEquipment.Thing)
            {
                JSONEquipmentReader reader = new JSONEquipmentReader();
                reader.amount = 1;
                reader.description = equipment.Description;
                reader.name = equipment.Name;
                reader.rarity = equipment.Rarity;
                reader.typeEquipment = equipment.TypeEq.ToString();
                reader.weight = equipment.Weight;
                data.Add(JsonUtility.ToJson(reader));
            }
            else if(equipment.TypeEq == Equipment.TypeEquipment.Armor)
            {
                Armor armor = (Armor)equipment;
                JSONArmorReader reader = new JSONArmorReader();
                reader.amount = 1;
                reader.body = armor.DefBody;
                reader.description = armor.Description;
                reader.hands = armor.DefHands;
                reader.head = armor.DefHead;
                reader.legs = armor.DefLegs;
                reader.maxAgility = armor.MaxAgil;
                reader.name = armor.Name;
                reader.rarity = armor.Rarity;
                reader.typeEquipment = armor.TypeEq.ToString();
                reader.weight = armor.Weight;
                data.Add(JsonUtility.ToJson(reader));
            }
            else if(equipment.TypeEq == Equipment.TypeEquipment.Grenade)
            {
                Weapon weapon = (Weapon)equipment;
                JSONGrenadeReader reader = new JSONGrenadeReader();
                reader.amount = 1;
                reader.damage = weapon.Damage;
                reader.description = weapon.Description;
                reader.name = weapon.Name;
                reader.penetration = weapon.Penetration;
                reader.properties = weapon.Properties;
                reader.rarity = weapon.Rarity;
                reader.typeEquipment = weapon.TypeEq.ToString();
                reader.weaponClass = weapon.ClassWeapon;
                reader.weight = weapon.Weight;
                data.Add(JsonUtility.ToJson(reader));
            }
            else if(equipment.TypeEq == Equipment.TypeEquipment.Melee)
            {
                Weapon weapon = (Weapon)equipment;
                JSONMeleeReader reader = new JSONMeleeReader();
                reader.amount = 1;
                reader.damage = weapon.Damage;
                reader.description = weapon.Description;
                reader.name = weapon.Name;
                reader.penetration = weapon.Penetration;
                reader.properties = weapon.Properties;
                reader.rarity = weapon.Rarity;
                reader.typeEquipment = weapon.TypeEq.ToString();
                reader.weaponClass = weapon.ClassWeapon;
                reader.weight = weapon.Weight;
                data.Add(JsonUtility.ToJson(reader));
            }
            else if(equipment.TypeEq == Equipment.TypeEquipment.Range)
            {
                Weapon weapon = (Weapon)equipment;
                JSONRangeReader reader = new JSONRangeReader();
                reader.amount = 1;
                reader.clip = weapon.Clip;
                reader.damage = weapon.Damage;
                reader.description = weapon.Description;
                reader.name = weapon.Name;
                reader.penetration = weapon.Penetration;
                reader.properties = weapon.Properties;
                reader.range = weapon.Range;
                reader.rarity = weapon.Rarity;
                reader.reload = weapon.Reload;
                reader.rof = weapon.Rof;
                reader.typeEquipment = weapon.TypeEq.ToString();
                reader.weaponClass = weapon.ClassWeapon;
                reader.weight = weapon.Weight;
                data.Add(JsonUtility.ToJson(reader));
            }
        }

        File.WriteAllLines(path, data);
        System.Diagnostics.Process.Start($"{Application.dataPath}/StreamingAssets/qrcp/command.bat");
    }

    private void GenerateList()
    {
        if (_equipments.Count > 0)
            _equipments.Clear();
        _audioManager.PlayClick();

        GetRandomRange getRandomRange = new GetRandomRange(_dataBase, _bolterChance.Value, _firearmsChance.Value, _flamesChance.Value, _plasmaChance.Value, 
            _laserChance.Value, _mechanicumChance.Value);
        _equipments.AddRange(getRandomRange.GetListRandomEquipment(_bolterChance.Minimum, _bolterChance.Maximum));

        GetRandomMelee getRandomMelee = new GetRandomMelee(_dataBase, _chainsChance.Value, _powerFieldsChance.Value, _forceChance.Value, _shockChance.Value);
        _equipments.AddRange(getRandomMelee.GetListRandomEquipment(_chainsChance.Minimum, _chainsChance.Maximum));

        GetRandomBullets getRandomBullets = new GetRandomBullets(_dataBase, _bolterBulletsChance.Value, _fireArmsBulletsChance.Value, _plasmaLiquidChance.Value,
            _flameLiquidChance.Value, _chaosBulletsChance.Value, _laserChargesChance.Value);
        _equipments.AddRange(getRandomBullets.GetListRandomEquipment(_bolterBulletsChance.Minimum, _bolterBulletsChance.Maximum));

        GetRandomArmor getRandomArmor = new GetRandomArmor(_dataBase, _carapacesChance.Value, _flaksChance.Value, _meshChance.Value, _powersChance.Value);
        _equipments.AddRange(getRandomArmor.GetListRandomEquipment(_carapacesChance.Minimum, _carapacesChance.Maximum));
        Debug.Log($"��������� ���� ���� {_shieldsTechChance.Value}, ������� {_shieldsTechChance.Minimum}, �������� {_shieldsTechChance.Maximum}");
        _equipments.AddRange(GetListFromOneType(_shieldsTechChance.Value, _dataBase.ShieldsTech, _shieldsTechChance.Minimum, _shieldsTechChance.Maximum));
        Debug.Log($"��������� _grenadeChance ���� {_grenadeChance.Value}, ������� {_grenadeChance.Minimum}, �������� {_grenadeChance.Maximum}");
        _equipments.AddRange(GetListFromOneType(_grenadeChance.Value, _dataBase.Grenades, _grenadeChance.Minimum, _grenadeChance.Maximum));
        Debug.Log($"��������� _rangeUpgradeChance ���� {_rangeUpgradeChance.Value}, ������� {_rangeUpgradeChance.Minimum}, �������� {_rangeUpgradeChance.Maximum}");
        _equipments.AddRange(GetListFromOneType(_rangeUpgradeChance.Value, _dataBase.RangeUpgrade, _rangeUpgradeChance.Minimum, _rangeUpgradeChance.Maximum));
        Debug.Log($"��������� _meleeUpgradeChance ���� {_meleeUpgradeChance.Value}, ������� {_meleeUpgradeChance.Minimum}, �������� {_meleeUpgradeChance.Maximum}");
        _equipments.AddRange(GetListFromOneType(_meleeUpgradeChance.Value, _dataBase.MeleeUpgrade, _meleeUpgradeChance.Minimum, _meleeUpgradeChance.Maximum));
        Debug.Log($"��������� _thingsChance ���� {_thingsChance.Value}, ������� {_thingsChance.Minimum}, �������� {_thingsChance.Maximum}");
        _equipments.AddRange(GetListFromOneType(_thingsChance.Value, _dataBase.Things, _thingsChance.Minimum, _thingsChance.Maximum));
        Debug.Log($"��������� _exoticsChance ���� {_exoticsChance.Value}, ������� {_exoticsChance.Minimum}, �������� {_exoticsChance.Maximum}");
        _equipments.AddRange(GetListFromOneType(_exoticsChance.Value, _dataBase.Exotics, _exoticsChance.Minimum, _exoticsChance.Maximum));
        Debug.Log($"��������� _chaosChance ���� {_chaosChance.Value}, ������� {_chaosChance.Minimum}, �������� {_chaosChance.Maximum}");
        _equipments.AddRange(GetListFromOneType(_chaosChance.Value, _dataBase.Chaos, _chaosChance.Minimum, _chaosChance.Maximum));
        Debug.Log($"��������� _implantsChance ���� {_implantsChance.Value}, ������� {_implantsChance.Minimum}, �������� {_implantsChance.Maximum}");
        _equipments.AddRange(GetListFromOneType(_implantsChance.Value, _dataBase.Implants, _implantsChance.Minimum, _implantsChance.Maximum));
        Debug.Log($"��������� ���� _drugsChance {_drugsChance.Value}, ������� {_drugsChance.Minimum}, �������� {_drugsChance.Maximum}");
        _equipments.AddRange(GetListFromOneType(_drugsChance.Value, _dataBase.Drugs, _drugsChance.Minimum, _drugsChance.Maximum));

        _view.ShowList(_equipments);

    }

    private List<Equipment> GetListFromOneType(float value, List<Equipment> equipments, int minimum, int maximum)
    {
        GetRandomThing getRandomThing = new GetRandomThing(_dataBase, value, equipments);
        return getRandomThing.GetListRandomEquipment(minimum, maximum);
    }

}
