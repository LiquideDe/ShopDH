public class GetRandomArmor : GetRandomEquipment
{
    private float _carapacesValue, _flakValue, _meshValue, _powerValue;

    public GetRandomArmor(EquipmentDataBase equipmentDataBase, float carapacesValue, float flakValue, float meshValue, float powerValue) : base(equipmentDataBase)
    {
        _carapacesValue = carapacesValue;
        _flakValue = flakValue;
        _meshValue = meshValue;
        _powerValue = powerValue;
    }

    protected override Equipment RandomEquipment()
    {
        if (TryGetInChanse(_carapacesValue))
            return GetRandomEquipmentFromDataBase(_equipmentDataBase.Carapaces);

        else if (TryGetInChanse(_flakValue))
            return GetRandomEquipmentFromDataBase(_equipmentDataBase.Flaks);

        else if (TryGetInChanse(_meshValue))
            return GetRandomEquipmentFromDataBase(_equipmentDataBase.Mesh);

        else if (TryGetInChanse(_powerValue))
            return GetRandomEquipmentFromDataBase(_equipmentDataBase.Powers);

        return null;
    }
}
