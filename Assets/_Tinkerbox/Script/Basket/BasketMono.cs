using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMono : MonoBehaviour
{
   public BasketTypeHolder BTHolder;
   public BasketHoldedTransfrom BHTransform;
   public BasketHoldedPlate BHPlate;
   public BasketPlateMovement BPMovement;
   public BasketParticleHolder BPHolder;
   public BasketController BController;

   private void Start()
   {
      BController = FindObjectOfType<BasketController>();
      BHPlate.BPHolder = BPHolder;
      BHPlate.ParentObject = this.transform;
      BPMovement = new BasketPlateMovement(BHPlate,BHTransform);
      BPHolder.BC = BController;
   }


}
