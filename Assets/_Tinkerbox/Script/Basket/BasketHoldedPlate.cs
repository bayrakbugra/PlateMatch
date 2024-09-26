using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class BasketHoldedPlate
{
   public List<GameObject> HoldedPlateList;
   public Transform ParentObject;
   public BasketParticleHolder BPHolder { get; set; }
   
   private int _capacity = 12;

   public int GetCurrentHoldedPlateCount() => HoldedPlateList.Count;

   public int GetNeededPlateCount() => _capacity - HoldedPlateList.Count;

   public void AddBasketHoldedList(GameObject go)
   {
      HoldedPlateList.Add(go);
      if (GetCurrentHoldedPlateCount() == _capacity)
      {
         Debug.Log("BASKET IS FULL");
         float f = 0;
         DOTween.To(x => f = x, 0, 1, 1f).OnComplete(() =>
         {
            Debug.Log("WASH START");
            BPHolder.PlayWashParticle();
         });
      }
   }
}
