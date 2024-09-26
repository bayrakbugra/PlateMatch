using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserveMono : MonoBehaviour
{
   public ReserveTypeHolder RTypeHolder;
   public ReserveTransformHolder RTransformHolder;
   public ReservePlateHolder RPlateHolder;
   public ReserveMovementController RMovementControl;
   public BasketController BController;
   
   private void Start()
   {
      RMovementControl = new ReserveMovementController(RPlateHolder, RTransformHolder,BController);
   }

   public void ControllTheReserveForBasket(TypeOfBasket t,int neededCount,float delay)
   {
     
         
         List<GameObject> tt = new List<GameObject>();
         tt = RPlateHolder.ReservePlateList;


         if (RPlateHolder.GetCurrentReservePlateCount()>neededCount)
         {
            var total = neededCount;

            total = RPlateHolder.GetCurrentReservePlateCount() - neededCount;
            
            for (int i = 0; i < total; i++)
            {
               tt.RemoveAt(tt.Count-1);
            }
         }
         
         Debug.Log($"RSERVE : {tt.Count} , RPHOLDER:{RPlateHolder.GetCurrentReservePlateCount()} , NEEDED:{neededCount}");
         RMovementControl.MoveOnReserveToBasket(tt,delay);
         
      
     
   }
   
   private void Update()
   {
      if (RPlateHolder.GetCurrentReservePlateCount() == 0 && RTypeHolder.GetCurrentReserveType() != TypeOfReserve.Null)
      {
         RTypeHolder.ChangeCurrentType(TypeOfReserve.Null);
      }

      if (RPlateHolder.GetCurrentReservePlateCount() != 0 )
      {
         RTypeHolder.ChangeCurrentType((TypeOfReserve)RPlateHolder.ReservePlateList[0].GetComponent<PlateParent>().PTHolder.PlateType);
      }
   }
}
