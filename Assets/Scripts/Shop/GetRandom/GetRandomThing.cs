using System.Collections.Generic;

public class GetRandomThing : GetRandomEquipment
{
    private float _thingValue;
    private List<Equipment> _things;

    public GetRandomThing(EquipmentDataBase equipmentDataBase,float thingValue, List<Equipment> things) : base(equipmentDataBase)
    {
        _thingValue = thingValue;
        _things = new List<Equipment>(things);
    }

    protected override Equipment RandomEquipment()
    {
        if (TryGetInChanse(_thingValue))
            return GetRandomEquipmentFromDataBase(_things);

        return null;
    }
}
