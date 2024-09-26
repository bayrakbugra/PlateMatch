using System;
using System.Collections;
using System.Collections.Generic;
using Script.Plate;
using UnityEngine;

public class PlateParent : MonoBehaviour
{
  public BasePlate BPlate;
  public PlateTypeHolder PTHolder;
  public PlateOutlineController POController;

  private void Start()
  {
    BPlate.EnableRandomGrime();
  }
  
  
}
