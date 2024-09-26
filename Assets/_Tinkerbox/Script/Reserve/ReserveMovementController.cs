using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;


[System.Serializable]
public class ReserveMovementController
{
   private ReservePlateHolder _rph;
   private ReserveTransformHolder _rth;
   public BasketController _bc;

   public ReserveMovementController(ReservePlateHolder rph,ReserveTransformHolder rth,BasketController bc)
   {
      _rph = rph;
      _rth = rth;
      _bc = bc;
   }
   
   public void MoveOnReserve(List<GameObject> movedList)
   {
      for (int i = 0; i < movedList.Count; i++)
      {
         var a = movedList[i].gameObject;
         var lastIndex = i;

         a.transform.DOJump(_rth.ReserveList[_rph.ReservePlateList.Count].transform.position, 2.5f, 1, .5f).SetEase(Ease.Linear).SetDelay(0.15f + (i*0.15f));
         a.transform.DORotate(new Vector3(360, 0, 0), .5f , RotateMode.FastBeyond360).SetEase(Ease.Linear).SetDelay(0.15f + (i * 0.15f)).OnComplete(() =>
         {
            a.transform.DOLocalRotate(new Vector3(0, -90, 60), 0.025f, RotateMode.Fast).SetEase(Ease.Linear);
              
            if (lastIndex == movedList.Count - 1)
            {
               Debug.Log("Movement Done!");
            }
           
         });

         _rph.ReservePlateList.Add(movedList[i]);
      }
   }

   public void MoveOnReserveToBasket(List<GameObject> movedList,float delay)
   {
      for (int i = 0; i < movedList.Count; i++)
      {
         var a = movedList[i].gameObject;
         var lastIndex = i;

         a.transform.DOJump(_bc.CurrentBasketMono.BHTransform.HoldedTransformList[_bc.CurrentBasketMono.BHPlate.GetCurrentHoldedPlateCount()].position, 2.5f, 1, .35f).SetEase(Ease.Linear).SetDelay(0.15f + (i*0.15f))
            .SetDelay(delay).OnComplete(() =>
            {
               a.transform.SetParent(_bc.CurrentBasketMono.gameObject.transform,true);
            });
         a.transform.DORotate(new Vector3(360, 0, 0), .35f , RotateMode.FastBeyond360).SetEase(Ease.Linear).SetDelay(0.15f + (i * 0.15f)).SetDelay(delay).OnComplete(() =>
         {
            a.transform.DOLocalRotate(new Vector3(0, -90, 60), 0.025f, RotateMode.Fast).SetEase(Ease.Linear);
              
            if (lastIndex == movedList.Count - 1)
            {
               Debug.Log("Movement Done!");
               _rph.ClearTheReserveList();
            }
           
         });
         
         //Debug.Log();
         _bc.CurrentBasketMono.BHPlate.AddBasketHoldedList(movedList[i]);
         //_rph.ReservePlateList.Remove(movedList[i]);
      }
   }
}
