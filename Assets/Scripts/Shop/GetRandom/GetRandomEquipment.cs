using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public abstract class GetRandomEquipment
{
    protected EquipmentDataBase _equipmentDataBase;

    public GetRandomEquipment(EquipmentDataBase equipmentDataBase) => _equipmentDataBase = equipmentDataBase;

    public List<Equipment> GetListRandomEquipment(int min, int max, int attempts = 0)
    {
        List<Equipment> equipments = new List<Equipment>();
        if (max == 0)
            return equipments;

        if (attempts == 0)
            attempts = max;

        Equipment equipment = RandomEquipment();
        if(equipment != null)
            equipments.Add(equipment);

        attempts--;

        min = Math.Clamp(min - equipments.Count, 0, min);

        if (equipments.Count <= max && attempts > 0)
        {
            equipments.AddRange(GetListRandomEquipment(min, max - equipments.Count, attempts));
        }
        else if (attempts == 0 && equipments.Count < min)
            equipments.AddRange(GetListRandomEquipment(min, max - equipments.Count));

        return equipments;
    }

    protected abstract Equipment RandomEquipment();

    protected Equipment GetRandomEquipmentFromDataBase(List<Equipment> equipments)
    {
        Random rnd = new Random();
        int dice = rnd.Next(0, equipments.Count);
        return equipments[dice];
    }

    protected bool TryGetInChanse(float chance)
    {
        Random rnd = new Random();
        int dice = rnd.Next(1, 100);
        if (dice < chance)
            return true;

        return false;
    }
}
