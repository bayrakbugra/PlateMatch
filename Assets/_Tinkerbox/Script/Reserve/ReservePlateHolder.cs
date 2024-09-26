using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReservePlateHolder
{
    public List<GameObject> ReservePlateList;
    public int MaxCapacity;

    public void AddPlateToReserveList(GameObject go) => ReservePlateList.Add(go);
    public void RemovePlateToReserveList(GameObject go) => ReservePlateList.Remove(go);
    public int GetCurrentReservePlateCount() => ReservePlateList.Count;
    public void ClearTheReserveList() => ReservePlateList.Clear();
    public int GetNeededPlateCount() => MaxCapacity - ReservePlateList.Count;
    
    public void RemoveListByForLoop(List<GameObject> willRemove)
    {
        for (int i = 0; i < willRemove.Count; i++)
        {
            ReservePlateList.Remove(willRemove[i]);
        }
    }

    public bool IsReserveFull()
    {
        if (ReservePlateList.Count >= MaxCapacity) return true;

        return false;
    }



}
