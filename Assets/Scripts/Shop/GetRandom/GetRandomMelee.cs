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
