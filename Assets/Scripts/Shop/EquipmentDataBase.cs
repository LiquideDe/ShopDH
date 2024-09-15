using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EquipmentDataBase
{
    private List<Equipment> _bolters = new List<Equipment>();
    private List<Equipment> _firearms = new List<Equipment>();
    private List<Equipment> _flames = new List<Equipment>();
    private List<Equipment> _plasmas = new List<Equipment>();
    private List<Equipment> _lasers = new List<Equipment>();
    private List<Equipment> _mechanicums = new List<Equipment>();
    private List<Equipment> _meltas = new List<Equipment>();
    private List<Equipment> _chaos = new List<Equipment>();
    private List<Equipment> _grenades = new List<Equipment>();

    private List<Equipment> _rangeUpgrade = new List<Equipment>();
    private List<Equipment> _meleeUpgrade = new List<Equipment>();

    private List<Equipment> _bolterBullets = new List<Equipment>();
    private List<Equipment> _fireArmsBullets = new List<Equipment>();
    private List<Equipment> _plasmaLiquid = new List<Equipment>();
    private List<Equipment> _flameLiquid = new List<Equipment>();
    private List<Equipment> _chaosBullets = new List<Equipment>();
    private List<Equipment> _laserCharges = new List<Equipment>();

    private List<Equipment> _chains = new List<Equipment>();
    private List<Equipment> _exotics = new List<Equipment>();
    private List<Equipment> _powerFields = new List<Equipment>();
    private List<Equipment> _force = new List<Equipment>();
    private List<Equipment> _shock = new List<Equipment>();

    private List<Equipment> _carapaces = new List<Equipment>();
    private List<Equipment> _flaks = new List<Equipment>();
    private List<Equipment> _mesh = new List<Equipment>();
    private List<Equipment> _powers = new List<Equipment>();

    private List<Equipment> _shieldsTech = new List<Equipment>();

    private List<Equipment> _things = new List<Equipment>();
    private List<Equipment> _implants = new List<Equipment>();
    private List<Equipment> _drugs = new List<Equipment>();
    //private List<Equipment> _shieldsMyth = new List<Equipment>();    

    public EquipmentDataBase()
    {
        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Range/Bolter", _bolters); 
        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Range/Firearms", _firearms);   
        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Range/Flame", _flames);       
        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Range/Laser", _lasers);      
        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Range/Plasma", _plasmas);   
        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Range/Mechanicum", _mechanicums);
        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Range/Melta", _meltas);
        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Range/Chaos", _chaos);        

        AddEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Bullets/Bolt", _bolterBullets);
        AddEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Bullets/Firearm", _fireArmsBullets);
        AddEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Bullets/Flame", _flameLiquid);
        AddEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Bullets/Laser", _laserCharges);
        AddEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Bullets/Plasma", _plasmaLiquid);
        AddEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Bullets/Chaos", _chaosBullets);

        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Range/Exotic", _exotics);

        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Grenade", _grenades);

        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Melee/Chaos", _chaos);
        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Melee/Chain", _chains);
        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Melee/Exotic", _exotics);
        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Melee/PowerField", _powerFields);
        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Melee/Psy", _force);
        AddWeapon($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Melee/Shock", _shock);

        AddArmor($"{Application.dataPath}/StreamingAssets/Equipments/Armor/Carapace", _carapaces);
        AddArmor($"{Application.dataPath}/StreamingAssets/Equipments/Armor/Flak", _flaks);
        AddArmor($"{Application.dataPath}/StreamingAssets/Equipments/Armor/Mesh", _mesh);
        AddArmor($"{Application.dataPath}/StreamingAssets/Equipments/Armor/Power", _powers);

        AddEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Shields/Myth", _chaos);
        AddEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Shields/Tech", _shieldsTech);

        AddEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Things/ForMelee", _meleeUpgrade);
        AddEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Things/ForRange", _rangeUpgrade);

        AddEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Things/Regular", _things);

        AddEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Things/Chaos", _chaos);

        AddEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Implants", _implants);

        AddEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Drugs", _drugs);
                           
    }

    public List<Equipment> Bolters => _bolters;
    public List<Equipment> Firearms => _firearms;
    public List<Equipment> Flames => _flames;
    public List<Equipment> Plasmas => _plasmas;
    public List<Equipment> Lasers => _lasers;
    public List<Equipment> Mechanicums => _mechanicums;
    public List<Equipment> Meltas => _meltas;
    public List<Equipment> Chaos => _chaos;
    public List<Equipment> Grenades => _grenades;
    public List<Equipment> RangeUpgrade => _rangeUpgrade;
    public List<Equipment> MeleeUpgrade => _meleeUpgrade;
    public List<Equipment> Chains => _chains;
    public List<Equipment> Exotics => _exotics;
    public List<Equipment> PowerFields => _powerFields;
    public List<Equipment> Force => _force;
    public List<Equipment> Shock => _shock;
    public List<Equipment> Carapaces => _carapaces;
    public List<Equipment> Flaks => _flaks;
    public List<Equipment> Mesh => _mesh;
    public List<Equipment> Powers => _powers;
    public List<Equipment> ShieldsTech => _shieldsTech;
    public List<Equipment> Implants => _implants; 
    public List<Equipment> Drugs => _drugs;
    public List<Equipment> BolterBullets => _bolterBullets;
    public List<Equipment> FireArmsBullets => _fireArmsBullets;
    public List<Equipment> PlasmaLiquid => _plasmaLiquid;
    public List<Equipment> FlameLiquid => _flameLiquid;
    public List<Equipment> ChaosBullets => _chaosBullets;
    public List<Equipment> LaserCharges => _laserCharges;
    public List<Equipment> Things => _things;

    private void AddWeapon(string path, List<Equipment> weapons)
    {
        string[] firearmsFiles = Directory.GetFiles(path, "*.JSON");
        foreach (string firearm in firearmsFiles)
        {
            string[] data = File.ReadAllLines(firearm);

            if (isRange(data[0]))
            {
                JSONRangeReader weaponReader = JsonUtility.FromJson<JSONRangeReader>(data[0]);
                weapons.Add(new Weapon(weaponReader));
            }
            else
            {
                JSONMeleeReader weaponReader = JsonUtility.FromJson<JSONMeleeReader>(data[0]);
                weapons.Add(new Weapon(weaponReader));
            }            
        }
    }

    private void AddEquipment(string path, List<Equipment> equipments)
    {
        string[] eqiopmentFiles = Directory.GetFiles(path, "*.JSON");
        foreach (string equipmentFile in eqiopmentFiles)
        {
            string[] data = File.ReadAllLines(equipmentFile);
            JSONEquipmentReader equipment = JsonUtility.FromJson<JSONEquipmentReader>(data[0]);
            equipments.Add(new Equipment(equipment.name, equipment.description, equipment.rarity, 1, equipment.weight)); 
        }
    }
    
    private void AddArmor(string path, List<Equipment> armors)
    {
        string[] armorFiles = Directory.GetFiles(path, "*.JSON");
        foreach (string armorFile in armorFiles)
        {
            string[] data = File.ReadAllLines(armorFile);
            JSONArmorReader armor = JsonUtility.FromJson<JSONArmorReader>(data[0]);
            armors.Add(new Armor(armor));
        }
    }

    private bool isRange(string data)
    {
        try
        {
            JSONRangeReader weaponReader = JsonUtility.FromJson<JSONRangeReader>(data);
            return true;
        }

        catch
        {
            return false;
        }
    }
}
