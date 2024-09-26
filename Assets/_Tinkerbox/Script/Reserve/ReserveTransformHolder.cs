using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReserveTransformHolder
{
    public List<Transform> ReserveList;

    public Transform GetReserveTransformByIndex(int index) => ReserveList[index];
}
