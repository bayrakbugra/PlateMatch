using System.Collections;
using System.Collections.Generic;
using Script.Cell;
using Script.Plate;
using UnityEngine;

public class CellPlateMatchControll
{
    private CellHoldedList CHList;

    public CellPlateMatchControll(CellHoldedList clist)
    {
        CHList = clist;
    }

    public List<GameObject> GetMatchedPlate()
    {
        List<GameObject> pList = new List<GameObject>();
        if (CHList.PlateList.Count == 0) return pList;
        

        
        TypeOfPlate t = CHList.PlateList[CHList.PlateList.Count - 1].GetComponent<PlateParent>().PTHolder.PlateType;
        
        for (int i = CHList.PlateList.Count-1; 0 <= i; i--)
        {
            if(CHList.PlateList[i].GetComponent<PlateParent>().PTHolder.PlateType == t) pList.Add(CHList.PlateList[i]);
            else
            {
                break;
            }
        }
        //Debug.Log(pList.Count);
        return pList;
    }
}
