using System;
using System.Collections;
using System.Collections.Generic;
using Script.Plate;
using UnityEngine;

public class RayManager : MonoBehaviour
{
   public LayerMask GridLayer;
   public LayerMask ObstacleLayer;
   public ReserveParent RParent;
   public BasketController BController;

   public GameObject GetHittedGrid()
   {
      GameObject hitted = null;

      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      if (Physics.Raycast(ray,out RaycastHit hit,100,GridLayer))
      {
         hitted = hit.collider.gameObject;
      }
    
      return hitted;
   }

   public GameObject ObstacleControll()
   {
      GameObject hitted = null;

      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      if (Physics.Raycast(ray,out RaycastHit hit,ObstacleLayer))
      {
         hitted = hit.collider.gameObject;
      }

      return hitted;
   }

   public void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         var obstacle = ObstacleControll();
         
         if(obstacle != null) return;

         var hittedGrid = GetHittedGrid();
         
         if(hittedGrid == null) return;
         
         if(!hittedGrid.transform.parent.GetComponent<CellParent>().CControl.CanHittable) return;
         
         /*
          * Kac tane oldugu
          * Tabak tipi
          * list halinde hareket edecek tabaklar.
          */
         //Hangi satir ve sutun oldugunu gosterir.
         hittedGrid.transform.parent.GetComponent<CellParent>().BCell.OnDebugRowColumn();
         
         //Secilen griddeki tabaklarin list hali
         //List<GameObject> plateList = hittedGrid.transform.parent.GetComponent<CellParent>().GetMatchedTopPlate();
         
         //Secilen tabaklarin tipi
         //TypeOfPlate t = plateList[0].GetComponent<PlateParent>().PTHolder.PlateType;
         
         //Sepetteki bos yer sayisi
         //var neededCount = BController.CurrentBasketMono.BHPlate.GetNeededPlateCount();

       
         
         //Sepet secimi
         //BController.CurrentBasketMono.BPMovement.MoveOnBasket(plateList);
         
         //-------------------------------------
         
         //Cell degiskeni
         CellParent currentCP= hittedGrid.transform.parent.GetComponent<CellParent>();
         //tabak tipi
         TypeOfPlate t = currentCP.GetTopPlateType();
         
         
         if (BController.CurrentBasketMono != null && BController.CurrentBasketMono.BTHolder.BasketType == (TypeOfBasket)t &&BController.CurrentBasketMono.BHPlate.GetNeededPlateCount() != 0 )
         {
               Debug.Log("Basket and plate type is same!");
               currentCP.OnBasketMovementStart(BController.CurrentBasketMono.BHPlate.GetNeededPlateCount(),BController.CurrentBasketMono.BPMovement);
               Debug.Log(BController.CurrentBasketMono.BHPlate.GetNeededPlateCount());
               Debug.Log("Move to basket.");
         }
         else if (BController.CurrentBasketMono == null || BController.CurrentBasketMono.BTHolder.BasketType != (TypeOfBasket)t  || BController.CurrentBasketMono.BHPlate.GetNeededPlateCount() == 0)
         {
            var tempReserve = RParent.OnCalculateReserveAvailable(t);
            
            if(tempReserve == null) return;
            
            currentCP.OnReserveMovementStart(tempReserve.RPlateHolder.GetNeededPlateCount(),tempReserve.RMovementControl);
            
            //Level Fail kontrol edilecek.
         }
         
         
         /*
          * Ilk olarak sepete bakılacak sepet aynı tip mi?
          * sepet aynı tip ise ihtiyac olunan sayiya bakilacak.
          * Eger ihtiyac olan sayi kadar varsa sepete gonderilecek.
          * ----------
          * Eger sepet yok ise reserve alanlara bakilacak.
          * Aynı reserve alani bos ise oraya ihtiyac olunan sayi kadar gonderilecek.
          * eger bos degil ise game fail.
          */
         
      }
   }
}
