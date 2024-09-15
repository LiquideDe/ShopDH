public class GetRandomRange : GetRandomEquipment
{
    private float _bolterValue, _firearmsValue, _flamesValue, _plasmasValue, _lasersValue, _mechanicumValue;
    public GetRandomRange(EquipmentDataBase equipmentDataBase, float bolterValue, float firearmsValue,
        float flamesValue, float plasmasValue, float lasersValue, float mechanicumValue) : base(equipmentDataBase)
    {
        _bolterValue = bolterValue;
        _firearmsValue = firearmsValue;
        _flamesValue = flamesValue;
        _plasmasValue = plasmasValue;
        _lasersValue = lasersValue;
        _mechanicumValue = mechanicumValue;
    }

    protected override Equipment RandomEquipment()
    {
        if (TryGetInChanse(_bolterValue))
            return GetRandomEquipmentFromDataBase(_equipmentDataBase.Bolters);

        else if (TryGetInChanse(_firearmsValue))
            return(GetRandomEquipmentFromDataBase(_equipmentDataBase.Firearms));

        else if (TryGetInChanse(_flamesValue))
            return(GetRandomEquipmentFromDataBase(_equipmentDataBase.Flames));

        else if (TryGetInChanse(_plasmasValue))
            return(GetRandomEquipmentFromDataBase(_equipmentDataBase.Plasmas));

        else if (TryGetInChanse(_lasersValue))
            return(GetRandomEquipmentFromDataBase(_equipmentDataBase.Lasers));

        else if (TryGetInChanse(_mechanicumValue))
            return(GetRandomEquipmentFromDataBase(_equipmentDataBase.Mechanicums));

        return null;
    }
}
