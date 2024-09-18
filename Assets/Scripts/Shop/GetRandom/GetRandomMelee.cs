using System.Collections.Generic;

public class GetRandomMelee : GetRandomEquipment
{
    private float _chainValue, _powerValue, _forceValue, _schockValue;

    public GetRandomMelee(EquipmentDataBase dataBase,float chainValue, float powerValue, float forceValue, float schockValue) : base (dataBase)
    {
        _chainValue = chainValue;
        _powerValue = powerValue;
        _forceValue = forceValue;
        _schockValue = schockValue;
    }

    protected override Equipment GetGuaranteedEquipment()
    {
        List<Equipment> melees = new List<Equipment>();

        if (_chainValue > 0)
            melees.AddRange(_equipmentDataBase.Chains);

        if (_powerValue > 0)
            melees.AddRange(_equipmentDataBase.PowerFields);

        if (_forceValue > 0)
            melees.AddRange(_equipmentDataBase.Force);

        if (_schockValue > 0)
            melees.AddRange(_equipmentDataBase.Shock);

        return GetRandomEquipmentFromDataBase(melees);
    }

    protected override Equipment RandomEquipment()
    {
        if (TryGetInChanse(_chainValue))
            return GetRandomEquipmentFromDataBase(_equipmentDataBase.Chains);

        else if (TryGetInChanse(_powerValue))
            return (GetRandomEquipmentFromDataBase(_equipmentDataBase.PowerFields));

        else if (TryGetInChanse(_forceValue))
            return (GetRandomEquipmentFromDataBase(_equipmentDataBase.Force));

        else if (TryGetInChanse(_schockValue))
            return (GetRandomEquipmentFromDataBase(_equipmentDataBase.Shock));

        return null;
    }
}
