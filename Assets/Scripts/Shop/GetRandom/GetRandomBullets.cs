using System.Collections.Generic;

public class GetRandomBullets : GetRandomEquipment
{
    private float _bolterBullets, _fireArmsBullets, _plasmaLiquid, _flameLiquid, _chaosBullets, _laserCharges;

    public GetRandomBullets(EquipmentDataBase dataBase,float bolterBullets, float fireArmsBullets, float plasmaLiquid, float flameLiquid, float chaosBullets, float laserCharges) 
        : base(dataBase)
    {
        _bolterBullets = bolterBullets;
        _fireArmsBullets = fireArmsBullets;
        _plasmaLiquid = plasmaLiquid;
        _flameLiquid = flameLiquid;
        _chaosBullets = chaosBullets;
        _laserCharges = laserCharges;
    }

    protected override Equipment GetGuaranteedEquipment()
    {
        List<Equipment> bullets = new List<Equipment>();

        if (_bolterBullets > 0)
            bullets.AddRange(_equipmentDataBase.BolterBullets);

        if (_fireArmsBullets > 0)
            bullets.AddRange(_equipmentDataBase.FireArmsBullets);

        if (_plasmaLiquid > 0)
            bullets.AddRange(_equipmentDataBase.PlasmaLiquid);

        if (_flameLiquid > 0)
            bullets.AddRange(_equipmentDataBase.FlameLiquid);

        if (_chaosBullets > 0)
            bullets.AddRange(_equipmentDataBase.ChaosBullets);

        if (_laserCharges > 0)
            bullets.AddRange(_equipmentDataBase.LaserCharges);

        return GetRandomEquipmentFromDataBase(bullets);
    }

    protected override Equipment RandomEquipment()
    {
        if (TryGetInChanse(_bolterBullets))
            return GetRandomEquipmentFromDataBase(_equipmentDataBase.BolterBullets);

        else if (TryGetInChanse(_fireArmsBullets))
            return GetRandomEquipmentFromDataBase(_equipmentDataBase.FireArmsBullets);

        else if (TryGetInChanse(_plasmaLiquid))
            return GetRandomEquipmentFromDataBase(_equipmentDataBase.PlasmaLiquid);

        else if (TryGetInChanse(_flameLiquid))
            return GetRandomEquipmentFromDataBase(_equipmentDataBase.FlameLiquid);

        else if (TryGetInChanse(_chaosBullets))
            return GetRandomEquipmentFromDataBase(_equipmentDataBase.ChaosBullets);

        else if (TryGetInChanse(_laserCharges))
            return GetRandomEquipmentFromDataBase(_equipmentDataBase.LaserCharges);

        return null;
    }
}
