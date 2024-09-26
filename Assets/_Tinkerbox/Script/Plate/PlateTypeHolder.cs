using UnityEngine.Serialization;

namespace Script.Plate
{
    public enum TypeOfPlate
    {
        Type1,
        Type2,
        Type3,
        Type4
    }
    [System.Serializable]
    public class PlateTypeHolder
    {
         public TypeOfPlate PlateType;
        
    }
}