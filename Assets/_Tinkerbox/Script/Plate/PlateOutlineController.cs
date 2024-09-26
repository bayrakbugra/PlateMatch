using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlateOutlineController
{
   public MeshRenderer PlateMRenderer;

   public void SetOutlineWidth(float amount) => PlateMRenderer.material.SetFloat("_OutlineWidth", amount);
}
