using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public List<CellParent> CellList;

    
    /// <summary>
    ///  Set cell clickable.
    /// </summary>
    /// <param name="xLeft"></param>
    /// <param name="xRight"></param>
    /// <param name="zUp"></param>
    /// <param name="zDown"></param>
    /// <param name="currentXY"></param>
    public void OnSetCellStatus(Vector2 left,Vector2 right,Vector2 up,Vector2 down )
    {
        //Debug.Log($"xleft:{xLeft} , xRight:{xRight} , zUp:{zUp} , zDown:{zDown} current: {currentXY[0]}");

        for (int i = 0; i < CellList.Count; i++)
        {
            if (CellList[i].GetComponent<CellParent>().BCell.Column == left.x && CellList[i].GetComponent<CellParent>().BCell.Row == left.y)
            {
                Debug.Log("LEFT");
                CellList[i].GetComponent<CellParent>().SetCellHitableStatus(true);
            }
            if (CellList[i].GetComponent<CellParent>().BCell.Column == right.x && CellList[i].GetComponent<CellParent>().BCell.Row == left.y)
            {
                Debug.Log("RIGHT");
                CellList[i].GetComponent<CellParent>().SetCellHitableStatus(true);


            }  if (CellList[i].GetComponent<CellParent>().BCell.Column == up.x && CellList[i].GetComponent<CellParent>().BCell.Row == up.y)
            {
                Debug.Log("UP");
                CellList[i].GetComponent<CellParent>().SetCellHitableStatus(true);

            }  if (CellList[i].GetComponent<CellParent>().BCell.Column == down.x && CellList[i].GetComponent<CellParent>().BCell.Row == down.y)
            {
                Debug.Log("DOWN");
                CellList[i].GetComponent<CellParent>().SetCellHitableStatus(true);

            }
        
      
        }
    }
}
