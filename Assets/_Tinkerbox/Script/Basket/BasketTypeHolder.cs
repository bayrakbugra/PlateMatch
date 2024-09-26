using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum TypeOfBasket
{
    Type1,
    Type2,
    Type3,
    Type4
}

[System.Serializable]
public class BasketTypeHolder
{
    public TypeOfBasket BasketType;
}
