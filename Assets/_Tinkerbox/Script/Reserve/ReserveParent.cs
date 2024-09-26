using System.Collections;
using System.Collections.Generic;
using Script.Plate;
using UnityEngine;

public class ReserveParent : MonoBehaviour
{
   public List<ReserveMono> ReserveMonoList;
   
   /*
    * Ilk olarak ayni tipteki reserve monolari inceleyip sayisi kucuk mu ona bakip eger sayisi kucukse yerlestirecek eger yeterli sayiya ulasmis ise stack null olan baska bir stack ariyacak.
    */

   public ReserveMono OnCalculateReserveAvailable(TypeOfPlate t)
   {
      var _rMono = CheckReserveTypeAndNeededValue(t);
      var _tempRMono = GetNullReserve();
      
      if (_rMono == null) return _tempRMono;
      
      return _rMono;
   }

   private ReserveMono CheckReserveTypeAndNeededValue(TypeOfPlate t)
   {
      for (int i = 0; i < ReserveMonoList.Count; i++)
      {
         if (ReserveMonoList[i].RTypeHolder.GetCurrentReserveType() == (TypeOfReserve)t && !ReserveMonoList[i].RPlateHolder.IsReserveFull())
         {
            return ReserveMonoList[i];
         }
      }
      return null;
   }

   private ReserveMono GetNullReserve()
   {
      for (int i = 0; i < ReserveMonoList.Count; i++)
      {
         if (ReserveMonoList[i].RTypeHolder.GetCurrentReserveType() == TypeOfReserve.Null) return ReserveMonoList[i];
      }

      return null;
   }

   public void CheckAllReserve(TypeOfBasket t,int neededCount)
   {
      for (int i = 0; i < ReserveMonoList.Count; i++)
      {
         if (ReserveMonoList[i].RTypeHolder.GetCurrentReserveType() == (TypeOfReserve)t)
         {
            Debug.Log("KAC TANE");
            ReserveMonoList[i].ControllTheReserveForBasket(t,neededCount,(0.1f + (i*0.1f)));
         }
      }
   }
   /*#region MyRegion

   public bool AnyReserveIsNull()
   {
      for (int i = 0; i < ReserveMonoList.Count; i++)
      {
         if (ReserveMonoList[i].RTypeHolder.GetCurrentReserveType() == TypeOfReserve.Null) return true;
      }

      return false;
   }

   public ReserveMono GetReserveOfNull()
   {
      for (int i = 0; i < ReserveMonoList.Count; i++)
      {
         if (ReserveMonoList[i].RTypeHolder.GetCurrentReserveType() == TypeOfReserve.Null)
         {
            return ReserveMonoList[i];
            break;
         }
      }

      return null;
   }

   public bool IsReserveFull(int index)
   {
      if (ReserveMonoList[index].RPlateHolder.IsReserveFull()) return true;

      return false;
   }

   public bool IsPlateMatchWithAnyReserve(PlateTypeHolder t)
   {
      for (int i = 0; i < ReserveMonoList.Count; i++)
      {
         if (ReserveMonoList[i].RTypeHolder.GetCurrentReserveType() == (TypeOfReserve)t.PlateType && ReserveMonoList[i]) return true;
      }

      return false;
   }

   public ReserveMono GetUsefullReserve()
   {
      
      return null;
   }

   #endregion*/
  
   
}
