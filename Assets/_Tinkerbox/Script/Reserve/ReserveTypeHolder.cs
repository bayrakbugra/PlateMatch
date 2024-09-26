using System.Collections;
using System.Collections.Generic;
using Script.Plate;
using UnityEngine;

[System.Serializable]
public enum TypeOfReserve
{
    Type1,
    Type2,
    Type3,
    Type4,
    Null
}

[System.Serializable]
public class ReserveTypeHolder
{
    public TypeOfReserve ReserveType;

    public void ChangeCurrentType(TypeOfReserve typeOfReserve) => ReserveType = typeOfReserve;

    public bool ReserveTypeIsNull()
    {
        if (ReserveType == TypeOfReserve.Null) return true;

        return false;
    }

    public TypeOfReserve GetCurrentReserveType() => ReserveType;
}
