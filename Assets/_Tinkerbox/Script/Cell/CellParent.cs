using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Script.Cell;
using Script.Plate;
using UnityEngine;

public class CellParent : MonoBehaviour
{
 public BaseCell BCell;
 public CellHoldedList CHoldedList;
 public ColliderControll CControl;
 public CellPlateMatchControll CPMControll;
 
 public BoxCollider CellCollider;
 public CellManager CManager;

 private void Update()
 {
  SetColliderYSize();
 }

 private void Start()
 {


  CHoldedList._bCell = BCell;
  CHoldedList._cManager = CManager;
  CHoldedList._isActive = CControl.CanHittable;
  
  CPMControll = new CellPlateMatchControll(CHoldedList);

  CellInit();
  DOTween.SetTweensCapacity(2500,2500);
 }

 
 private void CellInit()
 {
  if (!CControl.CanHittable)
  {
   CHoldedList.SetTableRotation(false,1,0.1f);
   CHoldedList.SetPlatePosition(false,gameObject);
   SetPlateOutline(0);
   CControl.SetColliderYSize(CellCollider,CHoldedList.GetHoldedPlateListCount());

  }
  else
  {
   CHoldedList.SetTableRotation(true,1,0.1f);
   CHoldedList.SetPlatePosition(true,gameObject);
   SetPlateOutline(5);
   CControl.SetColliderYSize(CellCollider,CHoldedList.GetHoldedPlateListCount());
  }
  

 }

 public void SetPlateOutline(float width)
 {
  
  if(CHoldedList.PlateList.Count == 0)return;
  
  for (int i = 0; i < CHoldedList.PlateList.Count; i++)
  {
   CHoldedList.PlateList[i].GetComponent<PlateParent>().POController.SetOutlineWidth(width);
  }
  
 }
 public void SetCellHitableStatus(bool status)
 {

  if (status && !CControl.CanHittable)
  {
   CHoldedList.SetTableRotation(true,1.5f,0.25f);
   CHoldedList.SetPlatePosition(true,gameObject);
   SetPlateOutline(5);
   CControl.CanHittable = true;
  }

  if (!status && CControl.CanHittable)
  {
   CHoldedList.SetTableRotation(false,1,0.1f);
   CHoldedList.SetPlatePosition(false,gameObject);
   SetPlateOutline(0);

  }

  
 }

 public void SetColliderYSize()
 {
  CControl.SetColliderYSize(CellCollider,CHoldedList.PlateList.Count);
 }

 public void OnBasketMovementStart(int needed,BasketPlateMovement bpm)
 {
  //Ihtiyac olunan tabaklari bir liste icinde tutar.
  List<GameObject> plateList = GetMatchedTopPlate(needed);

  //Alinan tabaklari holder listesinden siler.
 CHoldedList.RemoveListByForLoop(plateList);
  
 //Bu tabaklari sepete gonderir.
  bpm.MoveOnBasket(plateList);
  
  
 }

 public void OnReserveMovementStart(int needed,ReserveMovementController rmc)
 {
  List<GameObject> plateList = GetMatchedTopPlate(needed);

  CHoldedList.RemoveListByForLoop(plateList);

  rmc.MoveOnReserve(plateList);
 }

 public TypeOfPlate GetTopPlateType() => CHoldedList.PlateList[CHoldedList.PlateList.Count-1].GetComponent<PlateParent>().PTHolder.PlateType;
 
  private List<GameObject> GetMatchedTopPlate(int neededCount)
  {
   List<GameObject> tt = new List<GameObject>();
  
   tt = CPMControll.GetMatchedPlate();
   
   //Eger ihtiyac olunan sayi eldeki sayiddan daha kucuk ise listedeki elemanlar yeniden duzenlenir.
   if (tt.Count > neededCount)
   {
    var willRemove = tt.Count - neededCount;
  
    Debug.Log($"TT count : {tt.Count} , neededCount: {neededCount} , willRemove:{willRemove}");
    for (int i = 0; i < willRemove; i++)
    {
     tt.RemoveAt(tt.Count-1);
    }
    
   }
   //if(tt.Count == 0) return;
   Debug.Log(tt.Count  );

   return tt;
  }


}




[System.Serializable]
public class ColliderControll
{
 public bool CanHittable;
 
 public void SetColliderYSize(BoxCollider coll, int plateCount) =>
  coll.size = new Vector3(.75f,( plateCount + (plateCount * 0.1f))*2, .75f);
}
